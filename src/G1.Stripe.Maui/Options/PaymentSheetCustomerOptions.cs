namespace G1.Stripe.Maui.Options;

/// <summary>
/// Identifies the customer when using PaymentSheet, enabling saved payment methods
/// and faster checkout for returning users.
/// </summary>
/// <remarks>
/// To use this feature, you must create an ephemeral key for the customer on your server
/// using your Stripe secret key. The ephemeral key and customer ID pair allow the PaymentSheet
/// to securely retrieve and manage the customer’s saved payment methods.
/// </remarks>
/// <param name="EphemeralKey">
/// A short-lived key created on your server for the specified customer.
/// Required when you want the PaymentSheet to display the customer's saved payment methods.
/// </param>
/// <param name="CustomerId">
/// The unique Stripe customer identifier (e.g., <c>cus_ABC123</c>).
/// Required when providing an <see cref="EphemeralKey"/>.
/// </param>
public partial record PaymentSheetCustomerOptions(string EphemeralKey, string CustomerId);