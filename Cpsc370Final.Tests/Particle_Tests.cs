namespace Cpsc370Final.Tests;

public class Particle_Tests
{
        [Fact]
        public void ParticelPosition_ShouldBeCorrectOnCreation()
        {
                var position = new Position(10, 10);
                
                var expectedX = 10;
                var expectedY = 10;
                
                Assert.Equal(expectedX, particle.ParticlePosition.x);
                Assert.Equal(expectedY, particle.ParticlePosition.y);
        }
}