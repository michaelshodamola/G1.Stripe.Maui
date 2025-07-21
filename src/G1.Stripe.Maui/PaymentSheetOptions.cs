namespace G1.Stripe.Maui;

public class PaymentSheetOptions
{
    public required string ClientSecret { get; set; }
    public required string MerchantDisplayName { get; set; }
    public PaymentSheetCustomerOptions? Customer { get; set; }

    public GooglePayOptions? GooglePay { get; set; }
}
