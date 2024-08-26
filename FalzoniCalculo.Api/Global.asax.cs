using FalzoniCalculo.DI;
using System.Web.Http;

namespace FalzoniCalculo.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependencyService.GetServiceProviders();
        }
    }
}
