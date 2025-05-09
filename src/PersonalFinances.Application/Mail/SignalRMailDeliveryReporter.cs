using Microsoft.Extensions.Logging;

namespace PersonalFinances.Application.Mail
{
    public class SignalRMailDeliveryReporter(ILogger<SignalRMailDeliveryReporter> logger) : IMailDeliveryReporter
    {
        public async Task ReportSuccessAsync(Guid accountId)
        {
            logger.LogInformation("success {accountid}", accountId);
        }
        public async Task ReportFailureAsync(Guid accountId, string error)
        {
            logger.LogError("failure {accountId} | {error}", accountId, error);
        }
    }
}