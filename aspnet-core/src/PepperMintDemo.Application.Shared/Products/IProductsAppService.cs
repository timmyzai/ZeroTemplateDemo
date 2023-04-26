using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PepperMintDemo.Products.Dtos;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Products
{
    public interface IProductsAppService : IApplicationService
    {
        Task<PagedResultDto<GetProductsForViewDto>> GetAll(GetAllProductsInput input);

        Task<GetProductsForViewDto> GetProductsForView(Guid id);

        Task<GetProductsForEditOutput> GetProductsForEdit(EntityDto<Guid> input);

        Task CreateOrEdit(CreateOrEditProductsDto input);

        Task Delete(EntityDto<Guid> input);

        Task<FileDto> GetProductsToExcel(GetAllProductsForExcelInput input);

        Task<PagedResultDto<ProductsUserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);

    }
}