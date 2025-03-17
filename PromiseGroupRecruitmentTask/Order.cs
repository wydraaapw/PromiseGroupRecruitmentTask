using PromiseGroupRecruitmentTask.Enums;

namespace PromiseGroupRecruitmentTask;

public class Order
{
    private static int _numberOfOrders = 0;
    public int Id { get; set; }
    public OrderState State { get; set; }
    public double Amount { get; set; }
    public string Name { get; set; }
    public ClientType ClientType { get; set; }
    public string Address { get; set; }
    public PaymentType PaymentType { get; set; }

    public Order(OrderState state, double amount, string name, ClientType clientType, string address, PaymentType paymentType)
    {
        Id = _numberOfOrders;
        _numberOfOrders++;
        State = state;
        Amount = amount;
        Name = name;
        ClientType = clientType;
        Address = address;
        PaymentType = paymentType;
    }

    public override string ToString()
    {
        return $"Order ID: {Id}, Name: {Name}, State: {State}, Amount: {Amount} $, Client: {ClientType}, Address: {Address}, Payment: {PaymentType}";
    }
}