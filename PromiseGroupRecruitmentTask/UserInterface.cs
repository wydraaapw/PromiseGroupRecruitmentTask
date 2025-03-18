using PromiseGroupRecruitmentTask.DTOs;
using PromiseGroupRecruitmentTask.Enums;
using PromiseGroupRecruitmentTask.Services;

namespace PromiseGroupRecruitmentTask;

public class UserInterface
{
    private IOrderService _orderService;
    private bool _isStopped = true;
    
    public UserInterface(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    public void Run()
    {
        while (_isStopped)
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine("1. Create new order");
            Console.WriteLine("2. Forward order to warehouse");
            Console.WriteLine("3. Forward order to dispatch");
            Console.WriteLine("4. View all orders");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==================================================================");

            Console.Write("Choose option (1-5): ");
            string operation = Console.ReadLine();
            HandleOperation(operation);
        }
    }

    public void HandleOperation(string operation)
    {
        switch (operation)
        {
            case "1":
            {
                OrderData orderData = GetOrderInputData();
                ServiceResponse serviceResponse = _orderService.CreateNewOrder(orderData);

                if (serviceResponse.Success)
                {
                    Console.WriteLine($"Order has been created ({orderData})");
                }
                else
                {
                    Console.WriteLine(serviceResponse.Message);
                }

                break;
            }
            case "2":
            {
                int? inputId = GetOrderIdInputByState(OrderState.New, "moved to warehouse");

                if (inputId is not null)
                {
                    ServiceResponse serviceResponse = _orderService.MoveToWareHouse(inputId);

                    if (serviceResponse.Success)
                    {
                        Console.WriteLine($"Order - {serviceResponse.OrderData} has been moved to warehouse");
                    }
                    else
                    {
                        Console.WriteLine(serviceResponse.Message);
                    }
                }
                break;
            }
            case "3":
            {
                int? inputId = GetOrderIdInputByState(OrderState.InWarehouse, "forward to dispatch");

                if (inputId is not null)
                {
                    ServiceResponse serviceResponse = _orderService.ForwardToDispatch(inputId);
                    
                    if (serviceResponse.Success)
                    {
                        Console.WriteLine($"Order - {serviceResponse.OrderData} has been forwarded to dispatch");
                    }
                    else
                    {
                        Console.WriteLine(serviceResponse.Message);
                    }
                }
                break;
            }
            case "4":
            {
                IReadOnlyList<Order> orders = _orderService.GetOrders();

                if (orders.Count() == 0)
                {
                    Console.WriteLine("There is no orders to show");
                }
                else
                {
                    foreach (Order order in orders)
                    {
                        Console.WriteLine(order);
                    }
                }

                break;
            }
            case "5":
                _isStopped = false;
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }

    private OrderData GetOrderInputData()
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter amount of order: ");
        string amount = Console.ReadLine();
        Console.Write("Choose client type:\n1 - Company\n2 - Individual\n: ");
        string clientType = Console.ReadLine();
        Console.Write("Choose payment type:\n1 - Card\n2 - Cash\n: ");
        string paymentType = Console.ReadLine();
        Console.Write("Enter address: ");
        string address = Console.ReadLine();

        return new OrderData(productName, amount, clientType, paymentType, address);
    }
    
    public int? GetOrderIdInputByState(OrderState state, string action)
    {
        IReadOnlyList<Order> orders = _orderService.GetOrdersByState(state);
    
        if (orders.Count == 0)
        {
            Console.WriteLine($"No orders with state {state} available. Only orders with state {state} can be {action}.");
            return null;
        } 
    
        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }
    
        Console.WriteLine("Enter order Id: ");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int id))
        {
            return id;
        }
    
        Console.WriteLine("Invalid id, it must be integer number");
        return null;
    }
}