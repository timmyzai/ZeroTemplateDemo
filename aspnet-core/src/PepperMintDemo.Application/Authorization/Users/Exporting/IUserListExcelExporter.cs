using System.Collections.Generic;
using PepperMintDemo.Authorization.Users.Dto;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}