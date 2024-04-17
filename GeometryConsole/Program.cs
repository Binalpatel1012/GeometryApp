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
            { "FeatureManagement:Rectangle", "true"},
            { "FeatureManagement:Triangle", "false"}
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(featureManagement)
            .Build();

        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);
        var serviceProvider = services.BuildServiceProvider();

        
        var featureManager = serviceProvider.GetRequiredService<IFeatureManagerSnapshot>();

        Console.WriteLine("Enter the side length of the square:");
        if (double.TryParse(Console.ReadLine(), out double side) && await featureManager.IsEnabledAsync("Square"))
        {
            Square square = new Square(side);
            Console.WriteLine($"Square enabled - Area: {square.CalculateArea()}, Perimeter: {square.CalculatePerimeter()}");
        }
        else
        {
            Console.WriteLine("Square feature is not enabled or invalid input.");
        }




        Console.WriteLine("Enter the length and width for the rectangle:");
        if (double.TryParse(Console.ReadLine(), out double length) && double.TryParse(Console.ReadLine(), out double width))
        {
            if (await featureManager.IsEnabledAsync("Rectangle"))
            {
                Rectangle rectangle = new Rectangle(length, width);
                Console.WriteLine($"Rectangle enabled - Area: {rectangle.CalculateArea()}, Perimeter: {rectangle.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Rectangle feature is not enabled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for length and/or width. Please enter valid numbers.");
        }

        Console.WriteLine("Enter the base, height, and hypotenuse for the triangle:");
        if (double.TryParse(Console.ReadLine(), out double baseLength) && double.TryParse(Console.ReadLine(), out double height) && double.TryParse(Console.ReadLine(), out double hypotenuse))
        {
            if (await featureManager.IsEnabledAsync("Triangle"))
            {
                Triangle triangle = new Triangle(baseLength, height, hypotenuse);
                Console.WriteLine($"Triangle enabled - Area: {triangle.CalculateArea()}, Perimeter: {triangle.CalculatePerimeter()}");
            }
            else
            {
                Console.WriteLine("Triangle feature is not enabled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for base, height, and/or hypotenuse. Please enter valid numbers.");
        }
    }
}
