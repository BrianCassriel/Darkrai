using System;
using System.IO;
using Xunit;

namespace Cpsc370Final.Tests
{
    public class Fireworks_Tests {
        [Fact]
        public void FireworkPosition_ShouldBeAtCenterOnCreation()
        {
            var firework = new Firework();

            var centerX = Console.WindowWidth / 2;
            var centerY = Console.WindowHeight / 2;

            Assert.Equal(centerX, firework.FireworkPosition.x);
            Assert.Equal(centerY, firework.FireworkPosition.y);
        }
    }
}