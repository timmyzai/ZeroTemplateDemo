using System.Collections.Generic;
using MvvmHelpers;
using PepperMintDemo.Models.NavigationMenu;

namespace PepperMintDemo.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}