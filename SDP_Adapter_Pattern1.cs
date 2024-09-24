//Adapter Pattern (Payment Gateway Integration)
// Target Interface
public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}

// Adaptee Class (Old PayPal System)
public class PayPalPayment
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Payment of ${amount} made using PayPal");
    }
}

// Adapter Class
public class PayPalAdapter : IPaymentGateway
{
    private readonly PayPalPayment _payPal;

    public PayPalAdapter(PayPalPayment payPal)
    {
        _payPal = payPal;
    }

    public void ProcessPayment(decimal amount)
    {
        _payPal.MakePayment(amount);
    }
}

// Client Code
public class PaymentProcessor
{
    private readonly IPaymentGateway _paymentGateway;

    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public void Pay(decimal amount)
    {
        _paymentGateway.ProcessPayment(amount);
    }
}

// Program to demonstrate Adapter pattern
public class Program
{
    public static void Main()
    {
        PayPalPayment oldPayPalSystem = new PayPalPayment();
        IPaymentGateway payPalAdapter = new PayPalAdapter(oldPayPalSystem);

        PaymentProcessor processor = new PaymentProcessor(payPalAdapter);
        processor.Pay(100.00m);
    }
}
