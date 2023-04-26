using PepperMintDemo.Authorization.Users;

using PepperMintDemo.Common.Dto;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using PepperMintDemo.Products.Exporting;
using PepperMintDemo.Products.Dtos;
using PepperMintDemo.Dto;
using Abp.Application.Services.Dto;
using PepperMintDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace PepperMintDemo.Products
{
    [AbpAuthorize(AppPermissions.Pages_Products)]
    public class ProductsAppService : PepperMintDemoAppServiceBase, IProductsAppService
    {
        private readonly IRepository<Products, Guid> _productsRepository;
        private readonly IProductsExcelExporter _productsExcelExporter;
        private readonly IRepository<User, long> _lookup_userRepository;

        public ProductsAppService(IRepository<Products, Guid> productsRepository, IProductsExcelExporter productsExcelExporter, IRepository<User, long> lookup_userRepository)
        {
            _productsRepository = productsRepository;
            _productsExcelExporter = productsExcelExporter;
            _lookup_userRepository = lookup_userRepository;

        }

        public async Task<PagedResultDto<GetProductsForViewDto>> GetAll(GetAllProductsInput input)
        {
            var typeFilter = input.TypeFilter.HasValue
                        ? (ProductType)input.TypeFilter
                        : default;

            var filteredProducts = _productsRepository.GetAll()
                        .Include(e => e.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(input.TypeFilter.HasValue && input.TypeFilter > -1, e => e.Type == typeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter);

            var pagedAndFilteredProducts = filteredProducts
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var products = from o in pagedAndFilteredProducts
                           join o1 in _lookup_userRepository.GetAll() on o.UserId equals o1.Id into j1
                           from s1 in j1.DefaultIfEmpty()

                           select new GetProductsForViewDto()
                           {
                               Products = new ProductsDto
                               {
                                   Name = o.Name,
                                   Type = o.Type,
                                   Id = o.Id
                               },
                               UserName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                           };

            var totalCount = await filteredProducts.CountAsync();

            return new PagedResultDto<GetProductsForViewDto>(
                totalCount,
                await products.ToListAsync()
            );
        }

        public async Task<GetProductsForViewDto> GetProductsForView(Guid id)
        {
            var products = await _productsRepository.GetAsync(id);

            var output = new GetProductsForViewDto { Products = ObjectMapper.Map<ProductsDto>(products) };

            if (output.Products.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Products.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Products_Edit)]
        public async Task<GetProductsForEditOutput> GetProductsForEdit(EntityDto<Guid> input)
        {
            var products = await _productsRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetProductsForEditOutput { Products = ObjectMapper.Map<CreateOrEditProductsDto>(products) };

            if (output.Products.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Products.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditProductsDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Products_Create)]
        protected virtual async Task Create(CreateOrEditProductsDto input)
        {
            var products = ObjectMapper.Map<Products>(input);

            await _productsRepository.InsertAsync(products);
        }

        [AbpAuthorize(AppPermissions.Pages_Products_Edit)]
        protected virtual async Task Update(CreateOrEditProductsDto input)
        {
            var products = await _productsRepository.FirstOrDefaultAsync((Guid)input.Id);
            ObjectMapper.Map(input, products);
        }

        [AbpAuthorize(AppPermissions.Pages_Products_Delete)]
        public async Task Delete(EntityDto<Guid> input)
        {
            await _productsRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetProductsToExcel(GetAllProductsForExcelInput input)
        {
            var typeFilter = input.TypeFilter.HasValue
                        ? (ProductType)input.TypeFilter
                        : default;

            var filteredProducts = _productsRepository.GetAll()
                        .Include(e => e.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(input.TypeFilter.HasValue && input.TypeFilter > -1, e => e.Type == typeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter);

            var query = (from o in filteredProducts
                         join o1 in _lookup_userRepository.GetAll() on o.UserId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetProductsForViewDto()
                         {
                             Products = new ProductsDto
                             {
                                 Name = o.Name,
                                 Type = o.Type,
                                 Id = o.Id
                             },
                             UserName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                         });

            var productsListDtos = await query.ToListAsync();

            return _productsExcelExporter.ExportToFile(productsListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Products)]
        public async Task<PagedResultDto<ProductsUserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_userRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name != null && e.Name.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var userList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<ProductsUserLookupTableDto>();
            foreach (var user in userList)
            {
                lookupTableDtoList.Add(new ProductsUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user.Name?.ToString()
                });
            }

            return new PagedResultDto<ProductsUserLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }
    }
}