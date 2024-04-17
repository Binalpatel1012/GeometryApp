public class Rectangle : IShape
{
    private double _length;
    private double _width;

    public Rectangle(double length, double width)
    {
        _length = length;
        _width = width;
    }

    public double CalculateArea() => _length * _width;

    public double CalculatePerimeter() => 2 * (_length + _width);
}
