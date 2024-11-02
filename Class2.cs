using System;

public interface IPaymentProcessor
{
    void ProcessPayment(double amount);
    void RefundPayment(double amount);
}

public class InternalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing payment of {amount} via internal system.");
    }

    public void RefundPayment(double amount)
    {
        Console.WriteLine($"Refunding payment of {amount} via internal system.");
    }
}

public class ExternalPaymentSystemA
{
    public void MakePayment(double amount)
    {
        Console.WriteLine($"Making payment of {amount} via External Payment System A.");
    }

    public void MakeRefund(double amount)
    {
        Console.WriteLine($"Making refund of {amount} via External Payment System A.");
    }
}

public class ExternalPaymentSystemB
{
    public void SendPayment(double amount)
    {
        Console.WriteLine($"Sending payment of {amount} via External Payment System B.");
    }

    public void ProcessRefund(double amount)
    {
        Console.WriteLine($"Processing refund of {amount} via External Payment System B.");
    }
}

public class PaymentAdapterA : IPaymentProcessor
{
    private ExternalPaymentSystemA _externalSystemA;

    public PaymentAdapterA(ExternalPaymentSystemA externalSystemA)
    {
        _externalSystemA = externalSystemA;
    }

    public void ProcessPayment(double amount)
    {
        _externalSystemA.MakePayment(amount);
    }

    public void RefundPayment(double amount)
    {
        _externalSystemA.MakeRefund(amount);
    }
}

public class PaymentAdapterB : IPaymentProcessor
{
    private ExternalPaymentSystemB _externalSystemB;

    public PaymentAdapterB(ExternalPaymentSystemB externalSystemB)
    {
        _externalSystemB = externalSystemB;
    }

    public void ProcessPayment(double amount)
    {
        _externalSystemB.SendPayment(amount);
    }

    public void RefundPayment(double amount)
    {
        _externalSystemB.ProcessRefund(amount);
    }
}

public class PaymentProcessorFactory
{
    public static IPaymentProcessor GetPaymentProcessor(string paymentType)
    {
        return paymentType switch
        {
            "Internal" => new InternalPaymentProcessor(),
            "ExternalA" => new PaymentAdapterA(new ExternalPaymentSystemA()),
            "ExternalB" => new PaymentAdapterB(new ExternalPaymentSystemB()),
            _ => throw new NotSupportedException("Unknown payment system type.")
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Внутренняя платежная система
        IPaymentProcessor internalProcessor = PaymentProcessorFactory.GetPaymentProcessor("Internal");
        internalProcessor.ProcessPayment(100.0);
        internalProcessor.RefundPayment(50.0);

        // Внешняя платежная система A через адаптер
        IPaymentProcessor adapterA = PaymentProcessorFactory.GetPaymentProcessor("ExternalA");
        adapterA.ProcessPayment(200.0);
        adapterA.RefundPayment(100.0);

        // Внешняя платежная система B через адаптер
        IPaymentProcessor adapterB = PaymentProcessorFactory.GetPaymentProcessor("ExternalB");
        adapterB.ProcessPayment(300.0);
        adapterB.RefundPayment(150.0);
    }
}

