namespace G1.Stripe.Maui.Options;

/// <summary>
/// Defines the visual customization options for the Stripe PaymentSheet.
/// </summary>
public class PaymentSheetAppearanceOptions
{
    #region Public Properties

    /// <summary>
    /// Color palette used when the device is in light mode.
    /// Default: Stripe’s default light theme.
    /// </summary>
    public PaymentSheetColorTheme? Light { get; set; }

    /// <summary>
    /// Color palette used when the device is in dark mode.
    /// Default: Stripe’s default dark theme.
    /// </summary>
    public PaymentSheetColorTheme? Dark { get; set; }

    /// <summary>
    /// Font resource ID for Android (e.g., <c>Resource.Font.roboto_bold</c>).
    /// Default: Stripe system default font.
    /// </summary>
    public int? FontFamily { get; set; }

    /// <summary>
    /// Font name for iOS (e.g., "Roboto-Bold").
    /// Default: System font.
    /// </summary>
    public string? FontFamilyForiOS { get; set; }

    /// <summary>
    /// Base font size (in SP on Android and points on iOS) for general text.
    /// Default: 16.
    /// </summary>
    public int? FontSize { get; set; }

    /// <summary>
    /// Default corner radius (in dp/points) for components such as cards and inputs.
    /// Default: 8.
    /// </summary>
    public int? CornerRadius { get; set; }

    /// <summary>
    /// Border stroke width (in dp/points) for components.
    /// Default: 1.
    /// </summary>
    public int? BorderWidth { get; set; }

    /// <summary>
    /// Font resource ID for Android primary action button text.
    /// Default: Stripe system default bold font.
    /// </summary>
    public int? PrimaryButtonFontFamily { get; set; }

    /// <summary>
    /// Font name for iOS primary action button text (e.g., "Roboto-Bold").
    /// Default: System bold font.
    /// </summary>
    public string? PrimaryButtonFontFamilyForiOS { get; set; }

    /// <summary>
    /// Font size (in SP/points) for the primary action button text.
    /// Default: 16.
    /// </summary>
    public int? PrimaryButtonFontSize { get; set; }

    /// <summary>
    /// Corner radius (in dp/points) for the primary action button.
    /// Default: 8.
    /// </summary>
    public int? PrimaryButtonCornerRadius { get; set; }

    /// <summary>
    /// Border stroke width (in dp/points) for the primary action button.
    /// Default: 1.
    /// </summary>
    public int? PrimaryButtonBorderWidth { get; set; }

    /// <summary>
    /// Height (in dp/points) for the primary action button.
    /// Default: 48.
    /// </summary>
    public int? PrimaryButtonBorderHeight { get; set; }

    #endregion Public Properties
}

/// <summary>
/// Defines the color palette for PaymentSheet components.
/// </summary>
public class PaymentSheetColorTheme
{
    #region Public Properties

    /// <summary>
    /// Primary brand color used for highlights and important UI elements.
    /// Default: Stripe blue (#635BFF).
    /// </summary>
    public Color? Primary { get; set; }

    /// <summary>
    /// Surface/background color for cards and containers.
    /// Default: White in light mode, black in dark mode.
    /// </summary>
    public Color? Surface { get; set; }

    /// <summary>
    /// Component background color for inputs, buttons, and other interactive elements.
    /// Default: White in light mode, dark gray in dark mode.
    /// </summary>
    public Color? Component { get; set; }

    /// <summary>
    /// Color for text or icons displayed on top of <see cref="Component"/>.
    /// Default: Black in light mode, white in dark mode.
    /// </summary>
    public Color? OnComponent { get; set; }

    /// <summary>
    /// Secondary text color for less prominent information.
    /// Default: Dark gray in light mode, light gray in dark mode.
    /// </summary>
    public Color? SecondaryText { get; set; }

    /// <summary>
    /// Placeholder text color for input fields.
    /// Default: Gray (#888888).
    /// </summary>
    public Color? PlaceholderText { get; set; }

    /// <summary>
    /// Color used to indicate errors (e.g., invalid card input).
    /// Default: Red (#FF0000).
    /// </summary>
    public Color? Error { get; set; }

    /// <summary>
    /// Background color for the primary action button.
    /// Default: Stripe blue (#635BFF).
    /// </summary>
    public Color? PrimaryButtonBackground { get; set; }

    /// <summary>
    /// Text color for the primary action button label.
    /// Default: White.
    /// </summary>
    public Color? PrimaryButtonOnBackground { get; set; }

    /// <summary>
    /// Border color for the primary action button.
    /// Default: Transparent.
    /// </summary>
    public Color? PrimaryButtonBorder { get; set; }

    /// <summary>
    /// Background color shown when the primary action button is in success state.
    /// Default: Green (#4CAF50).
    /// </summary>
    public Color? PrimaryButtonSuccessBackground { get; set; }

    /// <summary>
    /// Text color for the primary action button in success state.
    /// Default: White.
    /// </summary>
    public Color? PrimaryButtonOnSuccessBackground { get; set; }

    #endregion Public Properties
}