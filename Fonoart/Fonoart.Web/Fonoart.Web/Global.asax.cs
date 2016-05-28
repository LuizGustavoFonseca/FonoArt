using AL.NucleoPoliticasComerciais.Mapeamentos;
using Fonoart.SDK.InversaoControle;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Fonoart.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ResolvedorDeDependencias.Instance().CarregarMapeamentos(Mapeador.Mapeamentos());
        }
    }
}
