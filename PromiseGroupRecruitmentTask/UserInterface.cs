using PromiseGroupRecruitmentTask.DTOs;
using PromiseGroupRecruitmentTask.Enums;

namespace PromiseGroupRecruitmentTask;

public class UserInterface
{
    private OrderService _orderService;
    private Validator _validator;

    public UserInterface(OrderService orderService, Validator validator)
    {
        _orderService = orderService;
        _validator = validator;
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
                OrderData orderData = GetOrderInputData();
                ValidationResult validationResult = _validator.ValidateCreateNewOrder(orderData);
                HandleCreateNewOrder(orderData, validationResult);
                break;
            case "2":
                List<Order> newOrders = _orderService.GetOrdersByState(OrderState.New); // Only new orders can be moved to the warehouse
                
                if (newOrders.Count > 0)
                {
                    foreach (Order order in newOrders)
                    {
                        Console.WriteLine(order);
                    }
                    Console.WriteLine("Enter order Id: ");
                    string orderId = Console.ReadLine();
                    
                }
                else
                {
                    Console.WriteLine("There are no new orders yet, only new orders can be moved to warehouse");
                }
                
                
                
                
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

    private OrderData GetOrderInputData()
    {
        Console.WriteLine("Enter product name: ");
        string productName = Console.ReadLine();
        Console.WriteLine("Enter amount of order: ");
        string amount = Console.ReadLine();
        Console.WriteLine("Choose client type:\n1 - Company\n2 - Individual");
        string clientType = Console.ReadLine();
        Console.WriteLine("Choose payment type:\n1 - Card\n2 - Cash");
        string paymentType = Console.ReadLine();
        Console.WriteLine("Enter address: ");
        string address = Console.ReadLine();

        return new OrderData(productName, amount, clientType, paymentType, address);
    }

    private void HandleCreateNewOrder(OrderData orderData, ValidationResult validationResult)
    {
        if (validationResult.IsValid)
        {
            double parsedAmount = double.Parse(orderData.Amount);
            ClientType typeOfClient = orderData.ClientType == "1" ? ClientType.Company : ClientType.Individual;
            PaymentType typeOfPayment = orderData.PaymentType == "1" ? PaymentType.Card : PaymentType.Cash; 
                    
            Order order = _orderService.CreateNewOrder(parsedAmount, orderData.ProductName, typeOfClient, orderData.Address, typeOfPayment);
                    
            Console.WriteLine($"Order - {order} has been created");
        }
        else
        {
            Console.WriteLine(validationResult.ErrorMessage);
        }
    }
    
}