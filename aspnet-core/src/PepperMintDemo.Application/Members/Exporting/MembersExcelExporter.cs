using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using PepperMintDemo.DataExporting.Excel.NPOI;
using PepperMintDemo.Members.Dtos;
using PepperMintDemo.Dto;
using PepperMintDemo.Storage;

namespace PepperMintDemo.Members.Exporting
{
    public class MembersExcelExporter : NpoiExcelExporterBase, IMembersExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public MembersExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetMembersForViewDto> members)
        {
            return CreateExcelPackage(
                "Members.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Members"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        (L("User")) + L("Name")
                        );

                    AddObjects(
                        sheet, members,
                        _ => _.Members.Name,
                        _ => _.UserName
                        );

                });
        }
    }
}