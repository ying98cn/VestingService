using Vesting.Services.Signup.WebClient.IoC;
using System.Web.Http;

namespace Vesting.Services.Signup.WebClient
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Call Autofac DI configurations
            AutofacActivator.AutofacResolver();
        }
    }
}
