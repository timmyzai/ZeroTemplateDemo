using Abp.Dependency;

namespace PepperMintDemo.Web.Xss
{
    public interface IHtmlSanitizer: ITransientDependency
    {
        string Sanitize(string html);
    }
}