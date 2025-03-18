namespace PromiseGroupRecruitmentTask.DTOs;

public record ServiceResponse(bool Success, OrderData? OrderData, string Message);