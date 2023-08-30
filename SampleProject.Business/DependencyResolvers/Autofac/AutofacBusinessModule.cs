using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using SampleProject.Business.Abstract;
using SampleProject.Business.Concrete;
using SampleProject.Core.Utilities.Interceptors;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Concrete.EfRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.RegisterType<AppUserManager>().As<IAppUserService>().SingleInstance();
            builder.RegisterType<EfAppUserRepository>().As<IAppUserRepository>().SingleInstance();

            builder.RegisterType<ArticleManager>().As<IArticleService>().SingleInstance();
            builder.RegisterType<EfArticleRepository>().As<IArticleRepository>().SingleInstance();

            builder.RegisterType<LikeManager>().As<ILikeService>().SingleInstance();
            builder.RegisterType<EfLikeRepository>().As<ILikeRepository>().SingleInstance();

            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EfCommentRepository>().As<ICommentRepository>().SingleInstance();

            builder.RegisterType<UserFollowedCategoryManager>().As<IUserFollowedCategoryService>().SingleInstance();
            builder.RegisterType<EfUserFollowedCategoryRepository>().As<IUserFollowedCategoryRepository>().SingleInstance();


            //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
