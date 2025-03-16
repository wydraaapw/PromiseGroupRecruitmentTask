namespace PromiseGroupRecruitmentTask;

public class Order
{
    public double Amount { get; set; }
    public string Name { get; set; }
    public ClientType ClientType { get; set; }
    public string Address { get; set; }
    public PaymentType PaymentType { get; set; }

    public Order(double amount, string name, ClientType clientType, string address, PaymentType paymentType)
    {
        Amount = amount;
        Name = name;
        ClientType = clientType;
        Address = address;
        PaymentType = paymentType;
    }
}