using PromiseGroupRecruitmentTask.Enums;

namespace PromiseGroupRecruitmentTask.DTOs;

public record OrderData(string ProductName, string Amount, string ClientType, string PaymentType, string Address);