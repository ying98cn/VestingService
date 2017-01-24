using Autofac;
using Autofac.Integration.WebApi;
using Vesting.Services.Signup.Business.Implementation;
using Vesting.Services.Signup.Business.Interface;
using System.Reflection;

namespace Vesting.Services.Signup.WebClient.IoC
{
    /// <summary>
    /// The Autofac configuration
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// Gets the configured container
        /// </summary>
        /// <returns></returns>
        public static IContainer GetConfiguredContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<SignupRepository>().As<ISignupRepository>();

            return builder.Build();
        }
    }
}