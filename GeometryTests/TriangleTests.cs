[TestClass]
public class TriangleTests
{
    [TestMethod]
    public void TestArea()
    {
        // Arrange
        var triangle = new Triangle(8, 5, 9.433981); 

        // Act
        var result = triangle.CalculateArea();

        // Assert
        Assert.AreEqual(20, result);
    }

    [TestMethod]
    public void TestPerimeter()
    {
        // Arrange
        var triangle = new Triangle(8, 5, 9.433981); 

        // Act
        var result = triangle.CalculatePerimeter();

        // Assert
        Assert.AreEqual(22.433981, result, 0.000001); 
    }
}
