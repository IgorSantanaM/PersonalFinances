﻿using PersonalFinances.Application.DTOs;
using System.Threading.Channels;

namespace PersonalFinances.Application.Mail
{
    public class AccountCreatedMailQueue : IMailQueue
    {
        private readonly Channel<AccountForSendingMailDto> channel;
        public AccountCreatedMailQueue(int capacity = 100)
        {
            var options = new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            channel = Channel.CreateBounded<AccountForSendingMailDto>(options);
        }
        public async Task AddMailToQueue(AccountForSendingMailDto data)
            => await channel.Writer.WriteAsync(data);

        public async Task<AccountForSendingMailDto> FetchMailFromQueueAsync(CancellationToken token)
            => await channel.Reader.ReadAsync(token);
    }
}
