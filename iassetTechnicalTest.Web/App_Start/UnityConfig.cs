using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using iassetTechnicalTest.Domain;
using System;
using iassetTechnicalTest.Domain.Helpers;


namespace iassetTechnicalTest.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor(new GWServiceAddress
            {
                GlobalWeatherSoapServiceAddress = Settings.Instance.GWServiceAddress
            }, TimeSpan.FromSeconds(60)));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}