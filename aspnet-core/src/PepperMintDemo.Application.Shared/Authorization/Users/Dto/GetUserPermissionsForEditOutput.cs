using System.Collections.Generic;
using PepperMintDemo.Authorization.Permissions.Dto;

namespace PepperMintDemo.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}