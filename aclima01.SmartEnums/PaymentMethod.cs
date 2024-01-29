namespace aclima01.SmartEnums;

public abstract class PaymentMethod : SmartEnum<PaymentMethod>
{
    public static readonly PaymentMethod Boleto = new BoletoPaymentMethod();
    public static readonly PaymentMethod PIX = new PixPaymentMethod();
    public static readonly PaymentMethod CreditCard = new CreditCardPaymentMethod();

    private PaymentMethod(int value, string name)
        : base(value, name)
    {
    }

    private sealed class BoletoPaymentMethod : PaymentMethod
    {
        public BoletoPaymentMethod()
            : base(1, "Boleto")
        {
        }
    }

    private sealed class PixPaymentMethod : PaymentMethod
    {
        public PixPaymentMethod()
            : base(2, "PIX")
        {
        }
    }

    private sealed class CreditCardPaymentMethod : PaymentMethod
    {
        public CreditCardPaymentMethod()
            : base(3, "Credit Card")
        {
        }
    }
}
