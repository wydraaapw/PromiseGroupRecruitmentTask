using System.Net.Sockets;
using PromiseGroupRecruitmentTask.Enums;
using PromiseGroupRecruitmentTask.Repositories;

namespace PromiseGroupRecruitmentTask;

public class OrderService
{
    private IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Order CreateNewOrder
    (double amount, string name, ClientType clientType, string address, PaymentType paymentType)
    {
        Order order = new Order(amount, name, clientType, address, paymentType);
        _orderRepository.AddToRepository(order);
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
        return _orderRepository.GetAllOrders();
    }
}