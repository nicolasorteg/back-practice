using Microsoft.Extensions.DependencyInjection;
using Refit;
using RepositorioRemotoPrac.Api;
using RepositorioRemotoPrac.Config;
using RepositorioRemotoPrac.Service;

namespace RepositorioRemotoPrac.Infraestructure;

/// <summary>
/// Config. de ID manual
/// </summary>
public static class DependenciesProvider {
    
    public static IServiceProvider BuildServiceProvider() {
        
        var services = new ServiceCollection();

        // api (Refit): genera la implementación de IPostsApi
        services.AddRefitClient<IPostsApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(ApiConfig.BaseUrl));

        // service
        services.AddScoped<PostService>();

        return services.BuildServiceProvider();
    }
}