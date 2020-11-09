using Microsoft.Practices.Unity.Configuration;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace EmployeeWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //Desde unity.config
            container.LoadConfiguration();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}