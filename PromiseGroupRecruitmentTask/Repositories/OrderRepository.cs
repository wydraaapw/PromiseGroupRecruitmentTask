namespace PromiseGroupRecruitmentTask.Repository;

public class OrderRepository : IOrderRepository
{
    public List<Order> Orders { get; }
    public Order AddToRepository(Order order)
    {
        Orders.Add(order);
        return order;
    }
}