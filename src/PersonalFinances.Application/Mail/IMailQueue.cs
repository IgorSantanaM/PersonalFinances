using PersonalFinances.Application.DTOs;

namespace PersonalFinances.Application.Mail
{
    public interface IMailQueue
    {
        public Task AddMailToQueue(AccountForSendingMailDto data);
        public Task<AccountForSendingMailDto> FetchMailFromQueueAsync(CancellationToken token);
    }
}
