namespace Cpsc370Final.Tests;

public class VelocityTest
{
    Velocity velocity;
    
    public VelocityTest()
    {
        velocity = new Velocity();
    }
    
    [Fact]
    public void GetX_ShouldReturnX()
    {
        Assert.Equal(velocity.x, 0);
    }
    
    [Fact]
    public void GetY_ShouldReturnY()
    {
        Assert.Equal(velocity.y, 0);
    }
}