#if ANDROID

using Microsoft.Maui.LifecycleEvents;

#endif

namespace G1.Stripe.Maui;

public static class PaymentSheetDI
{
    public static MauiAppBuilder UseStripePaymentSheet(this MauiAppBuilder mauiAppBuilder)
    {
#if ANDROID
        var androidSheet = new AndroidPaymentSheet();
        mauiAppBuilder.ConfigureLifecycleEvents(builder =>
        {
            builder.AddAndroid(ab =>
            {
                ab.OnCreate((activity, bundle) =>
                {
                    if (activity is MauiAppCompatActivity ma)
                    {
                        androidSheet.CaptureActivity(ma);
                    }
                });
            });
        });

        mauiAppBuilder.Services.AddSingleton<IPaymentSheet>(androidSheet);
#elif IOS
        mauiAppBuilder.Services.AddSingleton<IPaymentSheet, iOSPaymentSheet>();
#endif
        return mauiAppBuilder;
    }
}