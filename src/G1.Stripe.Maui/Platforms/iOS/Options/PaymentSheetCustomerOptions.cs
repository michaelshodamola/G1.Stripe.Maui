using Stripe;

namespace G1.Stripe.Maui.Options;

partial record PaymentSheetCustomerOptions
{
    internal TSPSCustomerConfiguration ToPlatform()
    {
        return new TSPSCustomerConfiguration(CustomerId, EphemeralKey);
    }
}
