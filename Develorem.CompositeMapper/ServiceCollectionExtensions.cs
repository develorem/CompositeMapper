using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Develorem.CompositeMapping
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCompositeAutoMapper<T>(this IServiceCollection services, params Assembly[] assembliesContainingExplicitMappers) where T : class, IAutoMapper
        {
            services.AddSingleton<IAutoMapper, T>();
            services.AddSingleton<IMapper, CompositeMapper>();
            foreach (var assembly in assembliesContainingExplicitMappers)
            {
                RegisterExplicitScannersInAssembly(services, assembly);
            }
            return services;
        }

        private static void RegisterExplicitScannersInAssembly(IServiceCollection services, Assembly assembly)
        {
            if (assembly == null || services == null) return;

            var baseName = typeof(ExplicitMapper<,>).FullName;

            var types = assembly
                .GetTypes()
                .Where(x => x.BaseType != null && x.BaseType.FullName.StartsWith(baseName))
                ;

            foreach (var type in types)
            {
                services.AddSingleton(type, type);
            }

        }
    }
}
