using Autofac.Integration.WebApi;
using System.Web.Http;

namespace Vesting.Services.Signup.WebClient.IoC
{
    /// <summary>
    /// The Autofac Activator
    /// </summary>
    public static class AutofacActivator
    {
        /// <summary>
        /// Registers Autofac resolver to the global configuration
        /// </summary>
        public static void AutofacResolver()
        {
            var resolver = new AutofacWebApiDependencyResolver(AutofacConfig.GetConfiguredContainer());

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}