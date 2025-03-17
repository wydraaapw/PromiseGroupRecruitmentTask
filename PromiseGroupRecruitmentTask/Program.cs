using PromiseGroupRecruitmentTask.Enums;
using PromiseGroupRecruitmentTask.Repositories;

namespace PromiseGroupRecruitmentTask;

public class Program
{
    public static void Main(string[] args)
    {
        IOrderRepository orderRepository = new OrderRepository();
        OrderService orderService = new OrderService(orderRepository);
        UserInterface userInterface = new UserInterface(orderService);
        
        userInterface.Run();
    }
}