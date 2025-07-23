using Com.Stripe.Android.Paymentsheet;

namespace G1.Stripe.Maui.Options;

partial class PaymentSheetBillingDetailsCollectionOptions
{
    internal PaymentSheet.BillingDetailsCollectionConfiguration ToPlatform()
    {
        return new PaymentSheet.BillingDetailsCollectionConfiguration(
                name: ToPlatform(Name),
                phone: ToPlatform(Phone),
                email: ToPlatform(Email),
                address: ToPlatform(Address),
                attachDefaultsToPaymentMethod: AttachDefaultsToPaymentMethod
        );
    }

    private static PaymentSheet.BillingDetailsCollectionConfiguration.CollectionMode ToPlatform(BillingDetailsCollectionMode billingDetailsCollectionMode)
    {
        return billingDetailsCollectionMode switch
        {
            BillingDetailsCollectionMode.Automatic => PaymentSheet.BillingDetailsCollectionConfiguration.CollectionMode.Automatic!,
            BillingDetailsCollectionMode.Always => PaymentSheet.BillingDetailsCollectionConfiguration.CollectionMode.Always!,
            BillingDetailsCollectionMode.Never => PaymentSheet.BillingDetailsCollectionConfiguration.CollectionMode.Never!,
            _ => throw new NotImplementedException(),
        };
    }

    private static PaymentSheet.BillingDetailsCollectionConfiguration.AddressCollectionMode ToPlatform(AddressCollectionMode billingDetailsCollectionMode)
    {
        return billingDetailsCollectionMode switch
        {
            AddressCollectionMode.Automatic => PaymentSheet.BillingDetailsCollectionConfiguration.AddressCollectionMode.Automatic!,
            AddressCollectionMode.Full => PaymentSheet.BillingDetailsCollectionConfiguration.AddressCollectionMode.Full!,
            AddressCollectionMode.Never => PaymentSheet.BillingDetailsCollectionConfiguration.AddressCollectionMode.Never!,
            _ => throw new NotImplementedException(),
        };
    }
}
