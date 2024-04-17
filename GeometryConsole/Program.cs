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

        // Accept User Input for Square
        Console.WriteLine("Enter the side length of the square:");
        if (double.TryParse(Console.ReadLine(), out double squareSide) && await featureManager.IsEnabledAsync("Square"))
        {
            Square square = new Square(squareSide);
            Console.WriteLine($"Square enabled - Area: {square.CalculateArea()}, Perimeter: {square.CalculatePerimeter()}");
        }
        else
        {
            Console.WriteLine("Invalid input or Square feature is not enabled.");
        }


        // Accept User Input for Rectangle
        Console.WriteLine("Enter the length and width for the rectangle:");
        if (double.TryParse(Console.ReadLine(), out double rectangleLength) && double.TryParse(Console.ReadLine(), out double rectangleWidth) && await featureManager.IsEnabledAsync("Rectangle"))
        {
            Rectangle rectangle = new Rectangle(rectangleLength, rectangleWidth);
            Console.WriteLine($"Rectangle enabled - Area: {rectangle.CalculateArea()}, Perimeter: {rectangle.CalculatePerimeter()}");
        }
        else
        {
            Console.WriteLine("Invalid input or Rectangle feature is not enabled.");
        }

        // Accept User Input for Triangle
        Console.WriteLine("Enter the base, height, and hypotenuse for the triangle:");
        if (double.TryParse(Console.ReadLine(), out double triangleBase) && double.TryParse(Console.ReadLine(), out double triangleHeight) && double.TryParse(Console.ReadLine(), out double triangleHypotenuse) && await featureManager.IsEnabledAsync("Triangle"))
        {
            Triangle triangle = new Triangle(triangleBase, triangleHeight, triangleHypotenuse);
            Console.WriteLine($"Triangle enabled - Area: {triangle.CalculateArea()}, Perimeter: {triangle.CalculatePerimeter()}");
        }
        else
        {
            Console.WriteLine("Invalid input or Triangle feature is not enabled.");
        }
    }
}
