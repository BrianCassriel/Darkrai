namespace Cpsc370Final.Tests;

public class SimulationsTest
{
    [Fact]
    public void SimulationTest1()
    {
        Assert.Equal((Fireworks.Count + 1), (Fireworks.Add(new Firework())).Count);
        Assert.Equal((Fireworks.Count - 1), Fireworks.RemoveFirework(0).Count);
        Assert.Equal(GetFirework(0), Fireworks[0]);
        Assert.Equal();
    }
}