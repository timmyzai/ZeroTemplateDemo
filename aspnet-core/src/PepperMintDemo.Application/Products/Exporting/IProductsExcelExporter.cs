using System.Collections.Generic;
using PepperMintDemo.Products.Dtos;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Products.Exporting
{
    public interface IProductsExcelExporter
    {
        FileDto ExportToFile(List<GetProductsForViewDto> products);
    }
}