using Microsoft.Extensions.DependencyInjection;
using SampleProject.Core.CrossCuttingConsern.Caching.Microsoft;
using SampleProject.Core.CrossCuttingConsern.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using SampleProject.Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;

namespace SampleProject.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();

        }
    }
}
