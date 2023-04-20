using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using PepperMintDemo.MultiTenancy.Accounting.Dto;

namespace PepperMintDemo.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
