using PromiseGroupRecruitmentTask.DTOs;
using PromiseGroupRecruitmentTask.Enums;
using PromiseGroupRecruitmentTask.Repositories;
using PromiseGroupRecruitmentTask.Services;
using PromiseGroupRecruitmentTask.Validators;


namespace PromiseGroupRecruitmentTask.Services;

public class OrderService : IOrderService
{
    private IOrderRepository _orderRepository;
    private IValidator _validator;
    public OrderService(IOrderRepository orderRepository, IValidator validator)
    {
        _orderRepository = orderRepository;
        _validator = validator;
    }

    public ServiceResponse CreateNewOrder(OrderData orderData)
    {
        ValidationResult validationResult = _validator.ValidateCreateNewOrder(orderData);

        if (validationResult.Success)
        {
            Order order = Order.CreateOrderFromOrderData(orderData);
            _orderRepository.AddToRepository(order);
            return new ServiceResponse(true, orderData, validationResult.Message);
        }

        return new ServiceResponse(false, orderData, validationResult.Message);
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