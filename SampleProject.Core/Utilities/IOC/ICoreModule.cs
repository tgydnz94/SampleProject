using Microsoft.Extensions.DependencyInjection;

namespace SampleProject.Core.Utilities.IOC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
