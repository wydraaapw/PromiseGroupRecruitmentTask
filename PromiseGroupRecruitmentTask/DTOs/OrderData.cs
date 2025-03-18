
namespace PromiseGroupRecruitmentTask.DTOs;

public record OrderData(string ProductName, string Amount, string ClientType, string PaymentType, string Address)
{
    public override string ToString()
    {
        return $"Order data (product name: {ProductName}, amount: {Amount})";
    }
}