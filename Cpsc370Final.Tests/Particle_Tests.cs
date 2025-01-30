namespace Cpsc370Final.Tests;

public class Particle_Tests
{
        
    [Fact]
    public void Particle_Constructor_ShouldInitializeCorrectly()
    {
        int expectedX = 10;
        int expectedY = 10;
        Velocity expectedVelocity = new Velocity(0, 0);
        float expectedLifetime = 20;
        char expectedSymbol = '*';

        Particle particle = new Particle(expectedX, expectedY, expectedVelocity, expectedLifetime, expectedSymbol);

        Assert.Equal(expectedX, particle.particlePosition.x);
        Assert.Equal(expectedY, particle.particlePosition.y);
        Assert.Equal(expectedVelocity, particle.velocity);
        Assert.Equal(expectedLifetime, particle.lifetime);
        Assert.Equal(expectedSymbol, particle.particleSymbol);
        Assert.False(particle.isFinished);
    }
    
    [Fact]
    public void ManageParticle_ShouldDecreaseLifetime()
    {
        Particle particle = new Particle(10, 10, new Velocity(1, 1), 5, '*');

        particle.ManageParticle();

        Assert.False(particle.isFinished);
        Assert.Equal(4, particle.lifetime);
    }

    [Fact]
    public void ManageParticle_ShouldSetIsFinished_WhenLifetimeExpires()
    {
        Particle particle = new Particle(10, 10, new Velocity(1, 1), 1, '*');

        particle.ManageParticle();
        particle.ManageParticle(); 
        Assert.True(particle.isFinished);
    }

    [Fact]
    public void MoveParticle_ShouldUpdatePosition()
    {
        Particle particle = new Particle(10, 10, new Velocity(2, 3), 5, '*');
        
        particle.ManageParticle();

        Assert.Equal(12, particle.particlePosition.x);
        Assert.Equal(13, particle.particlePosition.y);
    }
}