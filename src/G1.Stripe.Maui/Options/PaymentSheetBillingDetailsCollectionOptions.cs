namespace G1.Stripe.Maui.Options;

public partial class PaymentSheetBillingDetailsCollectionOptions
{
    public BillingDetailsCollectionMode Name { get; set; }
    public BillingDetailsCollectionMode Phone { get; set; }
    public BillingDetailsCollectionMode Email { get; set; }
    public AddressCollectionMode Address { get; set; }
    public bool AttachDefaultsToPaymentMethod {  get; set; }
}
