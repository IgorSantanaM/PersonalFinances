namespace PersonalFinances.Application.Mail
{
    public interface IMailDeliveryReporter
    {
        Task ReportSuccessAsync(Guid accountId);
        Task ReportFailureAsync(Guid accountId, string error);
    }
}
