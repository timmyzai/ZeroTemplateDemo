using System.Threading.Tasks;
using PepperMintDemo.Security.Recaptcha;

namespace PepperMintDemo.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
