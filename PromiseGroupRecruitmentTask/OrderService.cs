using System.Net.Sockets;
using PromiseGroupRecruitmentTask.Enums;
using PromiseGroupRecruitmentTask.Repository;

namespace PromiseGroupRecruitmentTask;

public class OrderService
{
    public IOrderRepository OrderRepository { get; set; }

    public OrderService(IOrderRepository orderRepository)
    {
        OrderRepository = orderRepository;
    }
    
    public Order CreateNewOrder
    (double amount, string name, ClientType clientType, string address, PaymentType paymentType)
    {
        Order order = new Order(OrderState.New, amount, name, clientType, address, paymentType);
        OrderRepository.AddToRepository(order);
        return order;
    }

    public Order MoveToWareHouse(Order order)
    {
        order.State = OrderState.InWarehouse;
        return order;
    }

    public Order SendForShipment(Order order)
    {
        order.State = OrderState.InShipping;
        return order;
    }

    public List<Order> GetOrders()
    {
        return OrderRepository.Orders;
    }
}