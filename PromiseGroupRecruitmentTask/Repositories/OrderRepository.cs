namespace PromiseGroupRecruitmentTask.Repositories;

public class OrderRepository : IOrderRepository
{
    private List<Order> _orders = new();
    public Order AddToRepository(Order order)
    {
        _orders.Add(order);
        return order;
    }

    public List<Order> GetAllOrders()
    {
        return _orders;
    }
}