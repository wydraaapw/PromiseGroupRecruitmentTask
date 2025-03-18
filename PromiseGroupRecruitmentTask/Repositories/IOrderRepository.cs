namespace PromiseGroupRecruitmentTask.Repositories;

public interface IOrderRepository
{
    Order AddToRepository(Order order);
    IReadOnlyList<Order> GetAllOrders();
}