

using PromiseGroupRecruitmentTask.DTOs;

namespace PromiseGroupRecruitmentTask.Validators;

public interface IValidator
{
    public ValidationResult ValidateCreateNewOrder(OrderData orderData);
}