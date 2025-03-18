using PromiseGroupRecruitmentTask.DTOs;
using PromiseGroupRecruitmentTask.Enums;

namespace PromiseGroupRecruitmentTask;

public class Order
{
    private static int _numberOfOrders = 0;
    public int Id { get; set; }
    public OrderState State { get; set; }
    public double Amount { get; set; }
    public string ProductName { get; set; }
    public ClientType ClientType { get; set; }
    public string Address { get; set; }
    public PaymentType PaymentType { get; set; }
    
    public Order(double amount, string productName, ClientType clientType, string address, PaymentType paymentType)
    {
        Id = _numberOfOrders;
        _numberOfOrders++;
        State = OrderState.New;
        Amount = amount;
        ProductName = productName;
        ClientType = clientType;
        Address = address;
        PaymentType = paymentType;
    }
    
    public override string ToString()
    {
        return $"Order ID: {Id}, Name: {ProductName}, State: {State}, Amount: {Amount} $, Client: {ClientType}, Address: {Address}, Payment: {PaymentType}";
    }

    public static Order CreateOrderFromOrderData(OrderData orderData)
    {
        double amount = double.Parse(orderData.Amount);
        ClientType clientType = orderData.ClientType == "1" ? ClientType.Company : ClientType.Individual;
        Enums.PaymentType paymentType = orderData.PaymentType == "1" ? PaymentType.Card : PaymentType.Cash;

        return new Order(amount, orderData.ProductName, clientType, orderData.Address, paymentType);
    }
}