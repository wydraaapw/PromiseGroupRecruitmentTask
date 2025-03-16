namespace PromiseGroupRecruitmentTask.Repository;

public interface IOrderRepository
{
    List<Order> Orders { get;}

    Order AddToRepository(Order order);
    
}