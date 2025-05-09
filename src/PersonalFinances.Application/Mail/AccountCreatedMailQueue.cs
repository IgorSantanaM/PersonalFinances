using PersonalFinances.Application.DTOs;
using System.Threading.Channels;

namespace PersonalFinances.Application.Mail
{
    public class AccountCreatedMailQueue : IMailQueue
    {
        private readonly Channel<AccountForSendindMailDto> channel;
        public AccountCreatedMailQueue(int capacity = 100)
        {
            var options = new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            channel = Channel.CreateBounded<AccountForSendindMailDto>(options);
        }
        public async Task AddMailToQueue(AccountForSendindMailDto data)
            => await channel.Writer.WriteAsync(data);

        public async Task<AccountForSendindMailDto> FetchMailFromQueueAsync(CancellationToken token)
            => await channel.Reader.ReadAsync(token);
    }
}
