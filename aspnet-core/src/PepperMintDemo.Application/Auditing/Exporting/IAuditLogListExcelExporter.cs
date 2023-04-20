using System.Collections.Generic;
using PepperMintDemo.Auditing.Dto;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
