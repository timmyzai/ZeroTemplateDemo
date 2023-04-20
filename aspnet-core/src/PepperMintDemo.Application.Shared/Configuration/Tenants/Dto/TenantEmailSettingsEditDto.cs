using Abp.Auditing;
using PepperMintDemo.Configuration.Dto;

namespace PepperMintDemo.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}