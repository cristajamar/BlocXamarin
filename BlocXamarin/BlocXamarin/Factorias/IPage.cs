using Xamarin.Forms;

namespace BlocXamarin.Factorias
{
    /*Controla el funcionamiento, gestiona una pagina*/
    public interface IPage
    {
        /*Utiliza un interfece que se encarga de gestionar la navegación,Objeto INavigation definido en Xamarin*/
        INavigation Navigation { get; }
    }
}