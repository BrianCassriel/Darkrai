using Xunit;

namespace Cpsc370Final.Tests
{
    public class RendererTests
    {
        [Fact]
        public void Exit_SetsShouldExitToTrue()
        {
            Renderer.Exit();
            Assert.True(Renderer.shouldExit);
        }

        [Fact]
        public void GetConsoleColor_ReturnsCorrectConsoleColor()
        {
            Assert.Equal(ConsoleColor.White, Renderer.GetConsoleColor(Color.None));
            Assert.Equal(ConsoleColor.White, Renderer.GetConsoleColor(Color.White));
            Assert.Equal(ConsoleColor.Red, Renderer.GetConsoleColor(Color.Red));
            Assert.Equal(ConsoleColor.Green, Renderer.GetConsoleColor(Color.Green));
            Assert.Equal(ConsoleColor.Blue, Renderer.GetConsoleColor(Color.Blue));
            Assert.Equal(ConsoleColor.Yellow, Renderer.GetConsoleColor(Color.Yellow));
            Assert.Equal(ConsoleColor.Cyan, Renderer.GetConsoleColor(Color.Cyan));
            Assert.Equal(ConsoleColor.Magenta, Renderer.GetConsoleColor(Color.Magenta));
        }
    }
}