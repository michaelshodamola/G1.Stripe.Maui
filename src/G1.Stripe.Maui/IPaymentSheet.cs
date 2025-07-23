using G1.Stripe.Maui.Options;

namespace G1.Stripe.Maui;

public interface IPaymentSheet
{
    void Initialize(string publishableKey);
    Task<PaymentSheetResult> Open(PaymentSheetOptions options, CancellationToken ct = default);
}
