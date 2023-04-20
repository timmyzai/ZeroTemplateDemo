using System.Threading.Tasks;

namespace PepperMintDemo.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}