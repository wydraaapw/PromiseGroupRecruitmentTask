namespace PromiseGroupRecruitmentTask.Repositories;

public class OrderRepository : IOrderRepository
{
    public List<Order> Orders { get; } = new();
    public Order AddToRepository(Order order)
    {
        Orders.Add(order);
        return order;
    }
}