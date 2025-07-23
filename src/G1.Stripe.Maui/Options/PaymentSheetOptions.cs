namespace G1.Stripe.Maui.Options;

public partial class PaymentSheetOptions
{
    public required string ClientSecret { get; set; }
    public required string MerchantDisplayName { get; set; }

    public bool AllowsDelayedPaymentMethods { get; set; }

    public PaymentSheetCustomerOptions? Customer { get; set; }

    public GooglePayOptions? GooglePay { get; set; }

    public PaymentSheetBillingDetailsCollectionOptions? BillingDetails { get; set; }
}
