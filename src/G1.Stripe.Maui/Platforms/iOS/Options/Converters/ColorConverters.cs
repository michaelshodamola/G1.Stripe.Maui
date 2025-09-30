using UIKit;
using Microsoft.Maui.Graphics;

namespace G1.Stripe.Maui.Platforms.iOS.Converters;

public static class ColorExtensions
{
    public static UIColor ToUIColor(this Color color)
    {
        return UIColor.FromRGBA(
            (nfloat)color.Red,
            (nfloat)color.Green,
            (nfloat)color.Blue,
            (nfloat)color.Alpha);
    }
}