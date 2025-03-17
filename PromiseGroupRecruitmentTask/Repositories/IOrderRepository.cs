namespace PromiseGroupRecruitmentTask.Repositories;

public interface IOrderRepository
{
    Order AddToRepository(Order order);
    List<Order> GetAllOrders();
}