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
    (double amount, string productName, ClientType clientType, string address, PaymentType paymentType)
    {
        Order order = new Order(amount, productName, clientType, address, paymentType);
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

    public List<Order> GetOrdersByState(OrderState orderState)
    {
        return _orderRepository.GetAllOrders().Where(order => order.State == orderState).ToList();
    }

    public Order? GetOrderById(int id)
    {
        return _orderRepository.GetAllOrders().FirstOrDefault(order => order.Id == id);
    }
}