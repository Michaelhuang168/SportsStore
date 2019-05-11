using Autofac;
using Autofac.Integration.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Infrastructure.Abstract;
using Vic.SportsStore.WebApp.Infrastructure.Concrete;

namespace Vic.SportsStore.WebApp
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();


            builder

                .RegisterControllers(AppDomain.CurrentDomain.GetAssemblies())

                .PropertiesAutowired();
                        
            builder

               .RegisterType<EFDbContext>()

               .PropertiesAutowired();
                       
            builder

                .RegisterType<EFProductRepository>()

                .As<IProductsRepository>()

                .PropertiesAutowired();
                       
            builder

                .RegisterType<EmailOrderProcessor>()

                .As<IOrderProcessor>()

                .PropertiesAutowired();

            builder

                .RegisterType<DbAuthProvider>()

                .As<IAuthProvider>()

                .PropertiesAutowired();


            builder

                .RegisterType<EmailSettings>()

                .PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}