namespace aclima01.SmartEnums.Client;

internal class Program
{
    static void Main(string[] args)
    {
        var paymentMethodFromValue = PaymentMethod.FromValue(1);

        Console.WriteLine($"The payment method (from Value) is {paymentMethodFromValue}");

        var paymentMethodFromName = PaymentMethod.FromName("PIX");

        Console.WriteLine($"The payment method (from Name) is {paymentMethodFromName}");

        var paymentMethodAsEnum = PaymentMethod.CreditCard;

        Console.WriteLine($"The payment method as Enum is {paymentMethodAsEnum}");

        Console.ReadKey();
    }
}
