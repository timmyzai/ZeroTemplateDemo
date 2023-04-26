using PepperMintDemo.Authorization.Users;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using PepperMintDemo.Members.Exporting;
using PepperMintDemo.Members.Dtos;
using PepperMintDemo.Dto;
using Abp.Application.Services.Dto;
using PepperMintDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace PepperMintDemo.Members
{
    [AbpAuthorize(AppPermissions.Pages_Members)]
    public class MembersAppService : PepperMintDemoAppServiceBase, IMembersAppService
    {
        private readonly IRepository<Members, Guid> _membersRepository;
        private readonly IMembersExcelExporter _membersExcelExporter;
        private readonly IRepository<User, long> _lookup_userRepository;

        public MembersAppService(IRepository<Members, Guid> membersRepository, IMembersExcelExporter membersExcelExporter, IRepository<User, long> lookup_userRepository)
        {
            _membersRepository = membersRepository;
            _membersExcelExporter = membersExcelExporter;
            _lookup_userRepository = lookup_userRepository;

        }

        public async Task<PagedResultDto<GetMembersForViewDto>> GetAll(GetAllMembersInput input)
        {

            var filteredMembers = _membersRepository.GetAll()
                        .Include(e => e.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter);

            var pagedAndFilteredMembers = filteredMembers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var members = from o in pagedAndFilteredMembers
                          join o1 in _lookup_userRepository.GetAll() on o.UserId equals o1.Id into j1
                          from s1 in j1.DefaultIfEmpty()

                          select new GetMembersForViewDto()
                          {
                              Members = new MembersDto
                              {
                                  Name = o.Name,
                                  Id = o.Id
                              },
                              UserName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                          };

            var totalCount = await filteredMembers.CountAsync();

            return new PagedResultDto<GetMembersForViewDto>(
                totalCount,
                await members.ToListAsync()
            );
        }

        public async Task<GetMembersForViewDto> GetMembersForView(Guid id)
        {
            var members = await _membersRepository.GetAsync(id);

            var output = new GetMembersForViewDto { Members = ObjectMapper.Map<MembersDto>(members) };

            if (output.Members.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Members.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Members_Edit)]
        public async Task<GetMembersForEditOutput> GetMembersForEdit(EntityDto<Guid> input)
        {
            var members = await _membersRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetMembersForEditOutput { Members = ObjectMapper.Map<CreateOrEditMembersDto>(members) };

            if (output.Members.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Members.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditMembersDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Members_Create)]
        protected virtual async Task Create(CreateOrEditMembersDto input)
        {
            var members = ObjectMapper.Map<Members>(input);

            await _membersRepository.InsertAsync(members);
        }

        [AbpAuthorize(AppPermissions.Pages_Members_Edit)]
        protected virtual async Task Update(CreateOrEditMembersDto input)
        {
            var members = await _membersRepository.FirstOrDefaultAsync((Guid)input.Id);
            ObjectMapper.Map(input, members);
        }

        [AbpAuthorize(AppPermissions.Pages_Members_Delete)]
        public async Task Delete(EntityDto<Guid> input)
        {
            await _membersRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetMembersToExcel(GetAllMembersForExcelInput input)
        {

            var filteredMembers = _membersRepository.GetAll()
                        .Include(e => e.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter);

            var query = (from o in filteredMembers
                         join o1 in _lookup_userRepository.GetAll() on o.UserId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetMembersForViewDto()
                         {
                             Members = new MembersDto
                             {
                                 Name = o.Name,
                                 Id = o.Id
                             },
                             UserName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                         });

            var membersListDtos = await query.ToListAsync();

            return _membersExcelExporter.ExportToFile(membersListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Members)]
        public async Task<PagedResultDto<MembersUserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_userRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name != null && e.Name.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var userList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<MembersUserLookupTableDto>();
            foreach (var user in userList)
            {
                lookupTableDtoList.Add(new MembersUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user.Name?.ToString()
                });
            }

            return new PagedResultDto<MembersUserLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }
    }
}