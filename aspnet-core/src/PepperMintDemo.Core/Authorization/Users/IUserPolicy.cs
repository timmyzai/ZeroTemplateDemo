using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace PepperMintDemo.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
