using PepperMintDemo.Common.Dto;

using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace PepperMintDemo.Products.Dtos
{
    public class CreateOrEditProductsDto : EntityDto<Guid?>
    {

        [Required]
        [StringLength(ProductsConsts.MaxNameLength, MinimumLength = ProductsConsts.MinNameLength)]
        public string Name { get; set; }

        public ProductType Type { get; set; }

        public long UserId { get; set; }

    }
}