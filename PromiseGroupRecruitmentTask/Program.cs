using PromiseGroupRecruitmentTask.Repositories;
using PromiseGroupRecruitmentTask.Services;
using PromiseGroupRecruitmentTask.Validators;

namespace PromiseGroupRecruitmentTask;

public class Program
{
    public static void Main(string[] args)
    {
        IOrderRepository orderRepository = new OrderRepository();
        IValidator validator = new Validator();
        
        IOrderService orderService = new OrderService(orderRepository, validator);
        
        UserInterface userInterface = new UserInterface(orderService);
        
        userInterface.Run();
    }
}