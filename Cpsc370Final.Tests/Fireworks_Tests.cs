namespace Cpsc370Final.Tests;

public class Fireworks_Tests
{
    [Theory]
    [InlineData("Exploded!")]
    public void Explode_PrintsTrue(String expectedResult)
    {
        Assert.Equal(expectedResult);
    }
    
}