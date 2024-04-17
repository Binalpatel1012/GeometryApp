public class Square : IShape
{
    private double _side;

    public Square(double side)
    {
        _side = side;
    }

    public double CalculateArea() => _side * _side;

    public double CalculatePerimeter() => 4 * _side;
}
