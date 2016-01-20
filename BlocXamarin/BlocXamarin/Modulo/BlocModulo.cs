using System;
using Autofac;
using BlocXamarin.Service;
using Xamarin.Forms;

namespace BlocXamarin.Modulo
{
    public class BlocModulo :Module
    {
        /*Detecta el tipo de pagina que es y devuelve la pagina principal*/


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatosImpl>().As<IServicioDatos>().SingleInstance();


            /*Registramos las View y los ViewModel
            builder.RegisterType<Login>();
            builder.RegisterType<Login>();
            builder.RegisterType<Principal>();
            builder.RegisterType<Registro>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<PrincipalViewModel>();
            builder.RegisterType<RegistroViewModel>(); */

            builder.RegisterInstance<Func<Page>>(() =>
            {
                var masterP = App.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                var navigation = page as IPageContainer<Page>;
                return navigation != null ? navigation.CurrentPage : page;
            });
        }
    }
}
}