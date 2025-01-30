using System;
using System.IO;
using Xunit;

namespace Cpsc370Final.Tests
{
    public class Fireworks_Tests {
        [Fact]
        public void FireworkPosition_ShouldBeCorrectOnCreation()
        {
            var position = new Position(10, 10);
            var firework = new Firework(position);

            var expectedX = 10;
            var expectedY = 10;

            Assert.Equal(expectedX, firework.FireworkPosition.x);
            Assert.Equal(expectedY, firework.FireworkPosition.y);
        }

        [Fact]
        public void Firework_Launch_ShouldUpdatePosition()
        {
            var position = new Position(10, Renderer.GetHeight() - 1);
            var firework = new Firework(position, Color.Blue);

            firework.Launch();

            Assert.True(firework.FireworkPosition.y < Renderer.GetHeight() - 1, "Launch lines should have moved upwards.");
        }
        
        [Fact]
        public void Firework_ShouldExplodeAndCreateParticles()
        {
            var firework = new Firework(new Position(15, 20), Color.Green);

            firework.Explode();

            Assert.True(firework.isExploded, "Firework should be exploded.");
            Assert.NotEmpty(firework.particles);
            Assert.Equal(12, firework.particles.Count);
        }
        
        [Fact]
        public void Firework_ExplodesWithCorrectParticlePositions()
        {
            var position = new Position(15, 20);
            var firework = new Firework(position, Color.Yellow);

            firework.Explode();

            foreach (var particle in firework.particles)
            {
                Assert.True(Math.Abs(particle.particlePosition.x - position.x) <= 3);
                Assert.True(Math.Abs(particle.particlePosition.y - position.y) <= 3);
            }
        }
        
        [Fact]
        public void Firework_DoesNotExplodeBeforeLaunch()
        {
            var firework = new Firework(new Position(10, 10), Color.Purple);

            Assert.False(firework.isExploded, "Firework should not explode before launch.");
            Assert.Empty(firework.particles);
        }
        
        [Fact]
        public void Firework_OnFrame_ShouldTriggerExplosion()
        {
            var firework = new Firework(new Position(10, Renderer.GetHeight() - 1), Color.Cyan);

            firework.OnFrame();

            if (firework.FireworkPosition.y <= Renderer.GetHeight() / 2)
            {
                Assert.True(firework.isExploded, "Firework should have exploded when reaching the threshold.");
            }
        }
        
    }
}
