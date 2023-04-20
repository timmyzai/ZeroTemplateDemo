using System.Threading.Tasks;
using PepperMintDemo.Sessions.Dto;

namespace PepperMintDemo.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
