using Autofac;
using Autofac.Extensions.DependencyInjection;
using MEFineArts.Data.Logic;
using MEFineArts.Data.Logic.Interfaces;
using MEFineArts.Data.Persistence;
using MEFineArts.Data.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MEFineArts.Web.Api
{
    public static class IocBuilder
    {
        public static IServiceProvider RegisterComponents(IServiceCollection services, IConfiguration configuration)
        {
            var mongoConnection = configuration["ConnectionStrings:MongoDB"];

            var builder = new ContainerBuilder();
            builder.RegisterType<DataManager>().As<IDataManager>().SingleInstance();
            builder.RegisterType<AuthorizationManager>().As<IAuthorizationManager>().SingleInstance();
            builder.RegisterType<MongoDBRepository>().As<IRepository>().WithParameter(new TypedParameter(typeof(string), mongoConnection)).SingleInstance();

            builder.Populate(services);
            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
