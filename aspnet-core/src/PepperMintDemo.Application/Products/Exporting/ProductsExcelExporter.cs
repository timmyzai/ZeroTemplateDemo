using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using PepperMintDemo.DataExporting.Excel.NPOI;
using PepperMintDemo.Products.Dtos;
using PepperMintDemo.Dto;
using PepperMintDemo.Storage;

namespace PepperMintDemo.Products.Exporting
{
    public class ProductsExcelExporter : NpoiExcelExporterBase, IProductsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ProductsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetProductsForViewDto> products)
        {
            return CreateExcelPackage(
                "Products.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Products"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Type"),
                        (L("User")) + L("Name")
                        );

                    AddObjects(
                        sheet, products,
                        _ => _.Products.Name,
                        _ => _.Products.Type,
                        _ => _.UserName
                        );

                });
        }
    }
}