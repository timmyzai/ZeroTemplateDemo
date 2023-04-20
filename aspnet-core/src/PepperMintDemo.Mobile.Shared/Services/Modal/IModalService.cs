using System.Threading.Tasks;
using PepperMintDemo.Views;
using Xamarin.Forms;

namespace PepperMintDemo.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
