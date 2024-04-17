public class Triangle : IShape
{
    private double _base;
    private double _height;
    private double _hypotenuse;

    public Triangle(double baseLength, double height, double hypotenuse)
    {
        _base = baseLength;
        _height = height;
        _hypotenuse = hypotenuse;
    }

    public double CalculateArea() => 0.5 * _base * _height;

    public double CalculatePerimeter() => _base + _height + _hypotenuse;
}
