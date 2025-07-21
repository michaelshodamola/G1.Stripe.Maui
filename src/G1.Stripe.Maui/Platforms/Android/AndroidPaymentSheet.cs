using AndroidX.Activity;
using Com.Stripe.Android;
using Com.Stripe.Android.Paymentsheet;
using AndroidPaymentSheetResult = Com.Stripe.Android.Paymentsheet.PaymentSheetResult;
using SharedPSResult = G1.Stripe.Maui.PaymentSheetResult;

namespace G1.Stripe.Maui.Platforms.Android;

public class AndroidPaymentSheet : IPaymentSheet
{
    internal void CaptureActivity(ComponentActivity activity)
    {
        _capturedActivity = activity;
        _sheet = new PaymentSheet.Builder(new ResultCallback(this)).Build(activity);
    }

    private ComponentActivity? _capturedActivity;

    private PaymentSheet? _sheet;

    private TaskCompletionSource<SharedPSResult>? _tcs;

    public void Initialize(string publishableKey)
    {
        ArgumentNullException.ThrowIfNull(_capturedActivity);
        PaymentConfiguration.Init(_capturedActivity, publishableKey);
    }

    public async Task<SharedPSResult> Open(PaymentSheetOptions options, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(_sheet);

        var configurationBuilder = new PaymentSheet.Configuration.Builder(options.MerchantDisplayName)
            .AllowsDelayedPaymentMethods(true); // Optional

        if (options.GooglePay is { } googlePay) 
        {
            var environment = googlePay.IsTestEnvironment 
                ? PaymentSheet.GooglePayConfiguration.Environment.Test! 
                : PaymentSheet.GooglePayConfiguration.Environment.Production!;

            configurationBuilder = configurationBuilder
                .GooglePay(new PaymentSheet.GooglePayConfiguration(environment, googlePay.CountryCode));
        }

        if (options.Customer is { } customer)
        {
            var customerConfig = new PaymentSheet.CustomerConfiguration(customer.CustomerId, customer.EphemeralKey);
            configurationBuilder = configurationBuilder.Customer(customerConfig);
        }

        var configuration = configurationBuilder.Build();
        _tcs = new TaskCompletionSource<SharedPSResult>();
        using (ct.Register(() => _tcs.TrySetCanceled(ct)))
        {
            _sheet.PresentWithPaymentIntent(options.ClientSecret, configuration);
            return await _tcs.Task.ConfigureAwait(false);
        }
    }

    private class ResultCallback(AndroidPaymentSheet sheet) : Java.Lang.Object, IPaymentSheetResultCallback
    {
        public void OnPaymentSheetResult(AndroidPaymentSheetResult paymentSheetResult)
        {
            switch (paymentSheetResult)
            {
                case AndroidPaymentSheetResult.Canceled c:
                    sheet._tcs?.SetResult(new PaymentSheetResult.Canceled());
                    break;

                case AndroidPaymentSheetResult.Failed f:
                    sheet._tcs?.SetResult(new PaymentSheetResult.Failed(f.Error));
                    break;

                case AndroidPaymentSheetResult.Completed completed:
                    sheet._tcs?.SetResult(new PaymentSheetResult.Completed());
                    break;
                default:
                    sheet._tcs?.SetException(new ImpossiblePaymentSheetException("Result didnt match one of excpected cases"));
                    break;
            }
        }
    }
}