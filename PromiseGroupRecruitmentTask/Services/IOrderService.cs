using PromiseGroupRecruitmentTask.DTOs;
using PromiseGroupRecruitmentTask.Enums;

namespace PromiseGroupRecruitmentTask.Services;

public interface IOrderService
{
    public ServiceResponse CreateNewOrder(OrderData orderData);

    public ServiceResponse MoveToWareHouse(int? id);
    public ServiceResponse ForwardToDispatch(int? id);
    public Order SendForShipment(Order order);
    public List<Order> GetOrders();
    public List<Order> GetOrdersByState(OrderState orderState);
    public Order? GetOrderById(int? id);
    
}