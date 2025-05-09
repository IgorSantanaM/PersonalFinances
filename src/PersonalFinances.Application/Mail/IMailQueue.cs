using PersonalFinances.Application.DTOs;

namespace PersonalFinances.Application.Mail
{
    public interface IMailQueue
    {
        public Task AddMailToQueue(AccountForSendindMailDto data);
        public Task<AccountForSendindMailDto> FetchMailFromQueueAsync(CancellationToken token);
    }
}
