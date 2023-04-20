using System.Collections.Generic;
using Abp;
using PepperMintDemo.Chat.Dto;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
