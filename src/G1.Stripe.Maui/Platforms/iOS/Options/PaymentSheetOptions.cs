using Stripe;

namespace G1.Stripe.Maui.Options;

partial class PaymentSheetOptions
{
    internal TSPSConfiguration BuildPlatform()
    {
        var configuration = new TSPSConfiguration
        {
            MerchantDisplayName = MerchantDisplayName,
            AllowsDelayedPaymentMethods = AllowsDelayedPaymentMethods
        };

        if (Customer is { } customer)
        {
            configuration.Customer = customer.ToPlatform();
        }

        return configuration;
    }
}