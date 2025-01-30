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
            var firework = new Firework(position, Color.Red);

            var expectedX = 10;
            var expectedY = 10;

            Assert.Equal(expectedX, firework.FireworkPosition.x);
            Assert.Equal(expectedY, firework.FireworkPosition.y);
        }
    }
}