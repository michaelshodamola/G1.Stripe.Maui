namespace G1.Stripe.Maui.Options;

/// <summary>
/// Controls how the PaymentSheet collects billing details such as name, phone,
/// email, and address from the customer.
/// </summary>
public partial class PaymentSheetBillingDetailsCollectionOptions
{
    /// <summary>
    /// Defines how the customer's full name is collected.
    /// Default: <see cref="BillingDetailsCollectionMode.Automatic"/> (Stripe decides if name is needed).
    /// </summary>
    public BillingDetailsCollectionMode Name { get; set; }

    /// <summary>
    /// Defines how the customer's phone number is collected.
    /// Default: <see cref="BillingDetailsCollectionMode.Automatic"/> (Stripe decides if phone is needed).
    /// </summary>
    public BillingDetailsCollectionMode Phone { get; set; }

    /// <summary>
    /// Defines how the customer's email address is collected.
    /// Default: <see cref="BillingDetailsCollectionMode.Automatic"/> (Stripe decides if email is needed).
    /// </summary>
    public BillingDetailsCollectionMode Email { get; set; }

    /// <summary>
    /// Defines how the customer's address is collected (e.g., none, automatic, required).
    /// Default: <see cref="AddressCollectionMode.Automatic"/> (Stripe decides if address is needed).
    /// </summary>
    public AddressCollectionMode Address { get; set; }

    /// <summary>
    /// Indicates whether the collected billing details should be automatically
    /// attached to the resulting PaymentMethod for future use.
    /// Default: false.
    /// </summary>
    public bool AttachDefaultsToPaymentMethod { get; set; }
}