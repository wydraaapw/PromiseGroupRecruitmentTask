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

    public ServiceResponse MoveToWareHouse(int? id)
    {
        Order? order = GetOrderById(id);
        
        if (order is null)
        {
            return new ServiceResponse(false, null, "Order with given id doesn't exist");
        }

        order.State = OrderState.InWarehouse;
        return new ServiceResponse(
            true, 
            new OrderData(order.ProductName, order.Amount.ToString(), order.ClientType.ToString(), 
                order.PaymentType.ToString(), order.Address), 
            $"Success - GetOrderById({id})"
        );
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

    public Order? GetOrderById(int? id)
    {
        Order? order = _orderRepository.GetAllOrders().FirstOrDefault(order => order.Id == id);

        return order;
    }
    
}