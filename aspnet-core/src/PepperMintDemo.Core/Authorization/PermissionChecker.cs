using Abp.Authorization;
using PepperMintDemo.Authorization.Roles;
using PepperMintDemo.Authorization.Users;

namespace PepperMintDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
