using Autofac;
using Autofac.Extensions.DependencyInjection;
using MEFineArts.Data.Logic;
using MEFineArts.Data.Logic.Interfaces;
using MEFineArts.Data.Persistence;
using MEFineArts.Data.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MEFineArts.Web.Api
{
    public static class IocBuilder
    {
        public static IServiceProvider RegisterComponents(IServiceCollection services, IConfiguration configuration)
        {
            var mongoConnection = configuration["ConnectionStrings:MongoDB"];
            var s3KeyId = configuration["Keys:S3KeyId"];
            var s3Key = configuration["Keys:S3Key"];

            var builder = new ContainerBuilder();
            builder.RegisterType<DataManager>().As<IDataManager>().SingleInstance();
            builder.RegisterType<AuthorizationManager>().As<IAuthorizationManager>().SingleInstance();
            builder.RegisterType<MongoDBRepository>().As<IRepository>().WithParameter(new TypedParameter(typeof(string), mongoConnection)).SingleInstance();
            builder.RegisterType<ImageManager>().As<IImageManager>().WithParameters(new [] { new NamedParameter("s3KeyId", s3KeyId), new NamedParameter("s3Key", s3Key) }).SingleInstance();

            builder.Populate(services);
            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
