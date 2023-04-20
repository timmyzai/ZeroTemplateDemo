using System.Collections.Generic;
using PepperMintDemo.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace PepperMintDemo.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
