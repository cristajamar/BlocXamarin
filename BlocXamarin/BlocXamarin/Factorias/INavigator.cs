using System;
using System.Threading.Tasks;
using BlocXamarin.ViewModel.Base;

namespace BlocXamarin.Factorias
{
    public interface INavigator
    {
        /*Les pasamos el IviewModelvacio para poder hacer el trabajo directamente en la vista*/
        /*Elimina las ventanas*/
        Task<IViewModel> PopAsync();
        /*Elimina las ventanas modales*/
        Task<IViewModel> PopModalAsyn();
        /*Elimina todas las ventanas hasta llegar a la ventana raiz*/
        Task PopToRootAsync();

        /*Por un lado le pasamos el Interface (IViewModel) y por otro el Template(TViewModel)*/
        /*El IViewModel que le pasamos es un interface ya construido*/
        Task<IViewModel> PushAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel;
        Task<IViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        /*Nos creamos la tarea push para las ventanas raiz/modales*/
        Task<IViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel;
        Task<IViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;
    }
}