namespace PromiseGroupRecruitmentTask;

public class UserInterface
{
    private OrderService _orderService;

    public UserInterface(OrderService orderService)
    {
        _orderService = orderService;
    }
    
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("1. Create new order");
            Console.WriteLine("2. Forward order to warehouse");
            Console.WriteLine("3. Forward order to dispatch");
            Console.WriteLine("4. View all orders");
            Console.WriteLine("5. Exit");

            Console.Write("Choose number (1-5): ");
            string operation = Console.ReadLine();
            HandleOperation(operation);
        }
    }

    public void HandleOperation(string operation)
    {
        switch (operation)
        {
            case "1":
                Console.WriteLine("Enter name of order: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter amount of order: ");
                string amount = Console.ReadLine();
                Console.WriteLine("Choose client type:\n1 - Company\n 2 - Individual");
                string clientType = Console.ReadLine();
                Console.WriteLine("Enter address: ");
                string address = Console.ReadLine();
                
                break;
            case "2":
                Console.WriteLine("Choice =  2");
                break;
            case "3":
                Console.WriteLine("Choice =  3");
                break;
            case "4":
                Console.WriteLine("Choice =  4");
                break;
            case "5":
                Console.WriteLine("Choice =  5");
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}