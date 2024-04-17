[TestClass]
public class RectangleTests
{
    [TestMethod]
    public void TestArea()
    {
        // Arrange
        var rectangle = new Rectangle(10, 5);

        // Act
        var result = rectangle.CalculateArea();

        // Assert
        Assert.AreEqual(50, result);
    }

    [TestMethod]
    public void TestPerimeter()
    {
        // Arrange
        var rectangle = new Rectangle(10, 5);

        // Act
        var result = rectangle.CalculatePerimeter();

        // Assert
        Assert.AreEqual(30, result);
    }
}
