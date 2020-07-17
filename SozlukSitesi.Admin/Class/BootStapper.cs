using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SozlukSitesi.Core.Repository;
using Autofac.Integration.Mvc;
using SozlukSitesi.Core.İnfastructure;
namespace SozlukSitesi.Admin.Class
{
    public class BootStapper
    {
        //Boot aşamasında çalışacak.
        public static void RunConfig()
        {
            BuildAutoFac();
        }
        private static void BuildAutoFac()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<KullaniciRepository>().As<IKullaniciRepository>();
            builder.RegisterType<BaslikRepository>().As<IBaslikRepository>();
            builder.RegisterType<RolRepository>().As<IRolRepository>();
            builder.RegisterType<MesajRepository>().As<IMesajRepository>();
            builder.RegisterType<EntryRepository>().As<IEntryRepository>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        
    }
}