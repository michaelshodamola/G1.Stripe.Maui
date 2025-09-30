using Com.Stripe.Android.Paymentsheet;
using G1.Stripe.Maui.Platforms.Android.Converters;
using Microsoft.Maui.Platform;

namespace G1.Stripe.Maui.Options;

partial class PaymentSheetOptions
{
    public PaymentSheet.GooglePayConfiguration? GooglePayConfiguration { get; set; }

    internal PaymentSheet.Configuration BuildPlatform()
    {
        var configurationBuilder = new PaymentSheet.Configuration.Builder(MerchantDisplayName)
                .AllowsDelayedPaymentMethods(AllowsDelayedPaymentMethods);

        if (BillingDetails is { } billingDetails)
        {
            configurationBuilder.BillingDetailsCollectionConfiguration(billingDetails.ToPlatform());
        }

        if (GooglePayConfiguration is { } googlePay)
        {
            configurationBuilder.GooglePay(GooglePayConfiguration);
        }

        if (Customer is { } customer)
        {
            configurationBuilder.Customer(customer.ToPlatform());
        }

        if (Appearance is { } app)
        {
            static int ARGB(uint hex) => unchecked((int)hex);
            var BLACK = ARGB(0xFF000000);
            var WHITE = ARGB(0xFFFFFFFF);
            var GRAY = ARGB(0xFF888888);
            var LIGHTGRAY = ARGB(0xFFCCCCCC);
            var DARKGRAY = ARGB(0xFF444444);
            var RED = ARGB(0xFFFF0000);
            var GREEN = ARGB(0xFF4CAF50);
            var TRANSPARENT = ARGB(0x00000000);

            var colorsLight = new PaymentSheet.Colors(
                primary: app.Light?.Primary?.ToPlatform() ?? BLACK,
                surface: app.Light?.Surface?.ToPlatform() ?? WHITE,
                component: app.Light?.Component?.ToPlatform() ?? WHITE,
                componentBorder: GRAY,
                componentDivider: LIGHTGRAY,
                onComponent: app.Light?.OnComponent?.ToPlatform() ?? BLACK,
                onSurface: BLACK,
                subtitle: app.Light?.SecondaryText?.ToPlatform() ?? DARKGRAY,
                placeholderText: app.Light?.PlaceholderText?.ToPlatform() ?? GRAY,
                appBarIcon: BLACK,
                error: app.Light?.Error?.ToPlatform() ?? RED
            );

            var colorsDark = new PaymentSheet.Colors(
                primary: app.Dark?.Primary?.ToPlatform() ?? WHITE,
                surface: app.Dark?.Surface?.ToPlatform() ?? BLACK,
                component: app.Dark?.Component?.ToPlatform() ?? DARKGRAY,
                componentBorder: GRAY,
                componentDivider: LIGHTGRAY,
                onComponent: app.Dark?.OnComponent?.ToPlatform() ?? WHITE,
                onSurface: WHITE,
                subtitle: app.Dark?.SecondaryText?.ToPlatform() ?? LIGHTGRAY,
                placeholderText: app.Dark?.PlaceholderText?.ToPlatform() ?? GRAY,
                appBarIcon: WHITE,
                error: app.Dark?.Error?.ToPlatform() ?? RED
            );

            var typography = new PaymentSheet.Typography(
                sizeScaleFactor: app.FontSize.HasValue ? (float)(app.FontSize.Value / 16f) : 1f,
                fontResId: app.FontFamily?.ToJInt()
            );

            var shapes = new PaymentSheet.Shapes(
                cornerRadiusDp: app.CornerRadius ?? 8,
                borderStrokeWidthDp: app.BorderWidth ?? 1
            );

            var primaryButtonColorsLight = new PaymentSheet.PrimaryButtonColors(
                background: app.Light?.PrimaryButtonBackground != null ? app.Light?.PrimaryButtonBackground.ToJInt() : null,
                onBackground: app.Light?.PrimaryButtonOnBackground?.ToPlatform() ?? WHITE,
                border: app.Light?.PrimaryButtonBorder?.ToPlatform() ?? unchecked((int)0x00000000),
                successBackgroundColor: app.Light?.PrimaryButtonSuccessBackground?.ToPlatform() ?? GREEN,
                onSuccessBackgroundColor: app.Light?.PrimaryButtonOnSuccessBackground?.ToPlatform() ?? WHITE
            );

            var primaryButtonColorsDark = new PaymentSheet.PrimaryButtonColors(
                background: app.Dark?.PrimaryButtonBackground != null ? app.Dark?.PrimaryButtonBackground.ToJInt() : null,
                onBackground: app.Dark?.PrimaryButtonOnBackground?.ToPlatform() ?? WHITE,
                border: app.Dark?.PrimaryButtonBorder?.ToPlatform() ?? TRANSPARENT,
                successBackgroundColor: app.Dark?.PrimaryButtonSuccessBackground?.ToPlatform() ?? GREEN,
                onSuccessBackgroundColor: app.Dark?.PrimaryButtonOnSuccessBackground?.ToPlatform() ?? WHITE
            );

            var primaryButtonShape = new PaymentSheet.PrimaryButtonShape(
                heightDp: 48f.ToJFloat(),
                cornerRadiusDp: (app.PrimaryButtonCornerRadius ?? 8f).ToJFloat(),
                borderStrokeWidthDp: (app.PrimaryButtonBorderWidth ?? 1f).ToJFloat()
            );

            var primaryButtonTypography = new PaymentSheet.PrimaryButtonTypography(
                fontResId: app.PrimaryButtonFontFamily?.ToJInt(),
                fontSizeSp: (app.PrimaryButtonFontSize ?? 16f).ToJFloat()
            );

            var primaryButton = new PaymentSheet.PrimaryButton(
                primaryButtonColorsLight,
                primaryButtonColorsDark,
                primaryButtonShape,
                primaryButtonTypography
            );

            var appearance = new PaymentSheet.Appearance(colorsLight, colorsDark, shapes, typography, primaryButton);

            configurationBuilder.Appearance(appearance);
        }

        return configurationBuilder.Build();
    }
}