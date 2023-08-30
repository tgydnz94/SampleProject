using Microsoft.Extensions.DependencyInjection;
using SampleProject.Core.DependencyResolvers;
using SampleProject.Core.Utilities.IOC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
