using System.Threading.Tasks;
using PepperMintDemo.Authorization.Users;

namespace PepperMintDemo.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
