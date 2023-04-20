using Microsoft.AspNetCore.Mvc;
using PepperMintDemo.Web.Controllers;

namespace PepperMintDemo.Web.Public.Controllers
{
    public class AboutController : PepperMintDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}