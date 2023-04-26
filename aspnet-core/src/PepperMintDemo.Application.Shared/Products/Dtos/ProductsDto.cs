using PepperMintDemo.Common.Dto;

using System;
using Abp.Application.Services.Dto;

namespace PepperMintDemo.Products.Dtos
{
    public class ProductsDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public ProductType Type { get; set; }

        public long UserId { get; set; }

    }
}