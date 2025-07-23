using Com.Stripe.Android.Paymentsheet;

namespace G1.Stripe.Maui.Options;

partial record PaymentSheetCustomerOptions
{
    internal PaymentSheet.CustomerConfiguration ToPlatform()
    {
        return new PaymentSheet.CustomerConfiguration(CustomerId, EphemeralKey);
    }
}
