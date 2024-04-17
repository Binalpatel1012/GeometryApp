using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

class Program
{
    static async Task Main(string[] args)
    {
        
        var featureManagement = new Dictionary<string, string>
        {
            { "FeatureManagement:Square", "true"},
            { "FeatureManagement:Rectangle", "false"},
            { "FeatureManagement:Triangle", "true"}
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(featureManagement)
            .Build();

        
        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);
        var serviceProvider = services.BuildServiceProvider();

        
        var featureManager = serviceProvider.GetRequiredService<IFeatureManagerSnapshot>();

       
        if (await featureManager.IsEnabledAsync("Square"))
        {
            Console.WriteLine("Feature Square is enabled");
        }
        else
        {
            Console.WriteLine("Feature Square is not available");
        }

    }
}
