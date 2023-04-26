using System.Collections.Generic;
using PepperMintDemo.Members.Dtos;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Members.Exporting
{
    public interface IMembersExcelExporter
    {
        FileDto ExportToFile(List<GetMembersForViewDto> members);
    }
}