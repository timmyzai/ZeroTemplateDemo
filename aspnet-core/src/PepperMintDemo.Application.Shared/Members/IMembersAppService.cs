using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PepperMintDemo.Members.Dtos;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Members
{
    public interface IMembersAppService : IApplicationService
    {
        Task<PagedResultDto<GetMembersForViewDto>> GetAll(GetAllMembersInput input);

        Task<GetMembersForViewDto> GetMembersForView(Guid id);

        Task<GetMembersForEditOutput> GetMembersForEdit(EntityDto<Guid> input);

        Task CreateOrEdit(CreateOrEditMembersDto input);

        Task Delete(EntityDto<Guid> input);

        Task<FileDto> GetMembersToExcel(GetAllMembersForExcelInput input);

        Task<PagedResultDto<MembersUserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);

    }
}