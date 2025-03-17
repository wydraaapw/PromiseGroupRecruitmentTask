namespace PromiseGroupRecruitmentTask.Repositories;

public class OrderRepository : IOrderRepository
{
    private List<Order> Orders = new();
    public Order AddToRepository(Order order)
    {
        Orders.Add(order);
        return order;
    }

    public List<Order> GetAllOrders()
    {
        return Orders;
    }
}