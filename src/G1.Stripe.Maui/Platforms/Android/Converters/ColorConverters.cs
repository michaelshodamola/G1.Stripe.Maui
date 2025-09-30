using JInteger = global::Java.Lang.Integer;

namespace G1.Stripe.Maui.Platforms.Android.Converters;

public static class ColorConverters
{
    #region Methods

    public static int ToArgb(this Color c) =>
        ((int)(c.Alpha * 255) << 24) |
        ((int)(c.Red * 255) << 16) |
        ((int)(c.Green * 255) << 8) |
         (int)(c.Blue * 255);

    #endregion Methods
}