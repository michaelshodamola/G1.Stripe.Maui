using JInteger = global::Java.Lang.Integer;
using JFloat = global::Java.Lang.Float;

namespace G1.Stripe.Maui.Platforms.Android.Converters;

public static class JavaConverters
{
    #region Methods

    public static JInteger? ToJInt(this Color c)
        => JInteger.ValueOf(c.ToArgb());

    public static JInteger? ToJInt(this int c)
        => JInteger.ValueOf(c);

    public static JFloat? ToJFloat(this float c)
        => JFloat.ValueOf(c);

    #endregion Methods
}