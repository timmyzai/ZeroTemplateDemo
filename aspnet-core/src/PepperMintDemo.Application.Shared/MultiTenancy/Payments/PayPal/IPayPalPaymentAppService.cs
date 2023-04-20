using System.Threading.Tasks;
using Abp.Application.Services;
using PepperMintDemo.MultiTenancy.Payments.PayPal.Dto;

namespace PepperMintDemo.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
