using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace PepperMintDemo.Products.Dtos
{
    public class GetProductsForEditOutput
    {
        public CreateOrEditProductsDto Products { get; set; }

        public string UserName { get; set; }

    }
}