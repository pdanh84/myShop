using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Autofac.Integration.WebApi;
using Shop.Data.Infrastructure;
using Shop.Data;
using Shop.Data.Repositories;
using Shop.Service;
using System.Web.Mvc;
using System.Web.Http;
using Shop.Web.Mappings;
using AutoMapper;
using Shop.Model.Models;
using Shop.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using Microsoft.Owin.Security.DataProtection;

[assembly: OwinStartup(typeof(Shop.Web.App_Start.Startup))]

namespace Shop.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
            ConfigureAuth(app);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
            });
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            //Reigster Controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //Register ApiController
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //Register UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            //Register DbFactory
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            //Register DbContext
            builder.RegisterType<MyShopDbContext>().AsSelf().InstancePerRequest();

            //Register ASP.NET Indentity
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            //Register repository
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(rp => rp.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            //Register service
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
                .Where(rp => rp.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            //Set resolver for all register
            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //Set webapi dependencyresolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
