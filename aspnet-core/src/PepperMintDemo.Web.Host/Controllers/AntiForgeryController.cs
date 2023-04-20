using Microsoft.AspNetCore.Antiforgery;

namespace PepperMintDemo.Web.Controllers
{
    public class AntiForgeryController : PepperMintDemoControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
