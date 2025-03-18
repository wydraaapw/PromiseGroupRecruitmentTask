using PromiseGroupRecruitmentTask.DTOs;

namespace PromiseGroupRecruitmentTask.Validators;

public class Validator : IValidator
{
    public ValidationResult ValidateCreateNewOrder(OrderData orderData)
    {
        bool isProductNameValid = !string.IsNullOrWhiteSpace(orderData.ProductName);
        bool isAmountValid = double.TryParse(orderData.Amount, out double parsedAmount) && parsedAmount > 0;
        bool isClientTypeValid = orderData.ClientType == "1" || orderData.ClientType == "2";
        bool isPaymentTypeValid = orderData.PaymentType == "1" || orderData.PaymentType == "2";
        bool isAddressValid = !string.IsNullOrWhiteSpace(orderData.Address);

        if (!isProductNameValid)
        {
            return new ValidationResult(false, "Product name is invalid");
        }
        if (!isAmountValid)
        {
            return new ValidationResult(false,
                "Invalid amount, amount should be greater than 0 and separated by ','. Examples of correct amounts - '12', '12,0'");
        }
        if (!isClientTypeValid)
        {
            return new ValidationResult(false,
                "Invalid client type, enter '1' for Company or enter '2' for Individual");
        }
        if (!isPaymentTypeValid)
        {
            return new ValidationResult(false, "Invalid payment type, enter '1' for Card or enter '2' for Cash");
        }
        if (!isAddressValid)
        {
            return new ValidationResult(false, "Invalid address, address can't be empty");
            
        }

        return new ValidationResult(true, "Input to create new order is valid");
    }
}