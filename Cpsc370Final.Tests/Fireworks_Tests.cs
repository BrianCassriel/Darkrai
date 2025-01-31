using System;
using System.IO;
using Xunit;
using System.Drawing;

namespace Cpsc370Final.Tests
{
    public class Fireworks_Tests {
        [Fact]
        public void FireworkPosition_ShouldBeCorrectOnCreation()
        {
            var position = new Position(10, 10);
            var color = Color.Red;
            var firework = new Firework(position, color);

            var expectedX = 10;
            var expectedY = 10;

            Assert.Equal(expectedX, firework.fireworkPosition.x);
            Assert.Equal(expectedY, firework.fireworkPosition.y);
            
            Assert.Equal(color, firework.particleColor);
        }

        [Fact]
        public void Firework_Launch_ShouldUpdatePosition()
        {
            var position = new Position(10, Renderer.GetHeight() - 1);
            var firework = new Firework(position, Color.Blue);

            firework.DrawLaunchParticle();

            Assert.True(firework.fireworkPosition.y < Renderer.GetHeight() - 1, "Launch lines should have moved upwards.");
        }
        
        [Fact]
        public void Firework_ShouldExplodeAndCreateParticles()
        {
            var firework = new Firework(new Position(15, 20), Color.Green);

            firework.Explode();

            Assert.True(firework.isExploded, "Firework should be exploded.");
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
            var firework = new Firework(new Position(10, 10), Color.Blue);

            Assert.False(firework.isExploded, "Firework should not explode before launch.");
            Assert.Empty(firework.particles);
        }
        
        [Fact]
        public void CreateLargeParticles_CreatesCorrectNumberAndSymbols()
        {
            // Arrange
            var firework = new Firework(new Position(10, 10), Color.Red);

            // Act
            firework.CreateLargeParticles();

            if (firework.fireworkPosition.y <= Renderer.GetHeight() / 2)
            {
                Assert.True(firework.isExploded, "Firework should have exploded when reaching the threshold.");
            }
        }

        [Fact]
        public void CreateMediumParticles_CreatesCorrectNumberAndSymbols()
        {
            // Arrange
            var firework = new Firework(new Position(10, 10), Color.Blue);

            // Act
            firework.CreateMediumParticles();

            // Assert
            Assert.Equal(12, firework.particles.Count); // All should be '+'
            Assert.All(firework.particles, p => Assert.Equal('+', p.particleSymbol));
        }
        
        [Fact]
        public void CreateSmallExplosion_CreatesOnlyLastSmallParticles()
        {
            var firework = new Firework(new Position(10, 10), Color.Yellow);
    
            firework.CreateSmallExplosion();

            Assert.Equal(12, firework.particles.Count);
            Assert.All(firework.particles, p => Assert.Equal('*', p.particleSymbol)); 
        }
        
        [Fact]
        public void CreateLargeExplosion_CreatesDoubleLargeParticles()
        {
            var firework = new Firework(new Position(10, 10), Color.Yellow);
    
            firework.CreateLargeExplosion();

            Assert.Equal(24, firework.particles.Count);
            Assert.Contains(firework.particles, p => p.particleSymbol == 'o');
            Assert.Contains(firework.particles, p => p.particleSymbol == '*');
        }
        
        [Fact]
        public void CreateMediumExplosion_CreatesOnlyLastMediumParticles()
        {
            var firework = new Firework(new Position(10, 10), Color.Yellow);
    
            firework.CreateMediumExplosion();

            Assert.Equal(12, firework.particles.Count);
            Assert.All(firework.particles, p => Assert.Equal('+', p.particleSymbol));
        }


        [Fact]
        public void CreateSmallParticles_CreatesCorrectNumberAndSymbols()
        {
            var firework = new Firework(new Position(10, 10), Color.Yellow);
            firework.CreateSmallParticles();

            Assert.Equal(12, firework.particles.Count); // All should be '*'
            Assert.All(firework.particles, p => Assert.Equal('*', p.particleSymbol));
        }
        
    }
}
