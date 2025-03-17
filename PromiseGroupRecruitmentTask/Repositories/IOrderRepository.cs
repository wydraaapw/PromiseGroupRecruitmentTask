namespace PromiseGroupRecruitmentTask.Repositories;

public interface IOrderRepository
{ 
    List<Order> Orders { get;}
    Order AddToRepository(Order order);
    
}