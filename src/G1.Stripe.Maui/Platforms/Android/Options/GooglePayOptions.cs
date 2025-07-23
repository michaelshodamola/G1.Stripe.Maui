using Com.Stripe.Android.Paymentsheet;

namespace G1.Stripe.Maui.Options;

partial record GooglePayOptions
{
    internal PaymentSheet.GooglePayConfiguration ToPlatform()
    {
        var environment = IsTestEnvironment
            ? PaymentSheet.GooglePayConfiguration.Environment.Test!
            : PaymentSheet.GooglePayConfiguration.Environment.Production!;

        return new PaymentSheet.GooglePayConfiguration(environment, CountryCode);
    }
}
