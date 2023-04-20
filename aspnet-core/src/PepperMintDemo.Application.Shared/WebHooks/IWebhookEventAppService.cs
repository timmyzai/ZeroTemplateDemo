﻿using System.Threading.Tasks;
using Abp.Webhooks;

namespace PepperMintDemo.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
