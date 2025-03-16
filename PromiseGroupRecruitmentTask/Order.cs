using PromiseGroupRecruitmentTask.Enums;

namespace PromiseGroupRecruitmentTask;

public class Order
{
    public OrderState State { get; set; }
    public double Amount { get; set; }
    public string Name { get; set; }
    public ClientType ClientType { get; set; }
    public string Address { get; set; }
    public PaymentType PaymentType { get; set; }

    public Order(OrderState state, double amount, string name, ClientType clientType, string address, PaymentType paymentType)
    {
        State = state;
        Amount = amount;
        Name = name;
        ClientType = clientType;
        Address = address;
        PaymentType = paymentType;
    }
}