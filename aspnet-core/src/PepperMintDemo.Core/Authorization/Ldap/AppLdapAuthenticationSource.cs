using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using PepperMintDemo.Authorization.Users;
using PepperMintDemo.MultiTenancy;

namespace PepperMintDemo.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}