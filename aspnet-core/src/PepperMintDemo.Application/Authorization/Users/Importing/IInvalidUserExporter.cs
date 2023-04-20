using System.Collections.Generic;
using PepperMintDemo.Authorization.Users.Importing.Dto;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
