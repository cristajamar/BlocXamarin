using Autofac;
using BlocXamarin.Factorias;
using Xamarin.Forms;

namespace BlocXamarin.Modulo
{
    public class Startup:AutofacBootstrapper
    {
        private readonly App _application;

        public Startup(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<BlocModulo>();
        }

        /*Cada vista nueva, debe estar registarada aquí, ya que es ViewFactory es de donde recuperamos las referencias*/
        protected override void RegisterViews(IViewFactory viewFactory)
        {
           
            //TODO viewFactory.Register<LoginViewModel, Login>();
            //TODO viewFactory.Register<RegistroViewModel, Registro>();
            //TODO viewFactory.Register<PrincipalViewModel, Principal>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            // TODO var main = viewFactory.Resolve<LoginViewModel>();*/ //Incluir la pagina principal
            //TODO var np = new NavigationPage(main);
            //TODO _application.MainPage = np;
        }
    }
}