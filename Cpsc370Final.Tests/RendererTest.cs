namespace Cpsc370Final.Tests
{
    public class RendererTests
    {
        [Fact]
        public void Initialize_SetsUpConsoleScreenSizeAndScreenBuffer()
        {
            Renderer.Initialize();
            Assert.NotNull(typeof(Renderer).GetField("screenBuffer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null));
        }

        [Fact]
        public void DrawFirework_UpdatesScreenBufferWithFirework()
        {
            Firework firework = new Firework { FireworkPosition = new Position(0, 0), centerParticleSymbol = '*', particleColor = Color.Red };
            Renderer.Initialize();
            Renderer.DrawFirework(firework);
            Pixel pixel = (Pixel)typeof(Renderer).GetField("screenBuffer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null)[0, 0];
            Assert.Equal('*', pixel.symbol);
            Assert.Equal(Color.Red, pixel.color);
        }

        [Fact]
        public void Exit_SetsShouldExitToTrue()
        {
            Renderer.Exit();
            bool shouldExit = (bool)typeof(Renderer).GetField("shouldExit", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
            Assert.True(shouldExit);
        }

        [Fact]
        public void RenderLoop_StopsWhenShouldExitIsTrue()
        {
            Renderer.Initialize();
            Renderer.Exit();
            Thread.Sleep(200); // Allow some time for the render loop to exit
            bool isAlive = (bool)typeof(Renderer).GetField("renderThread", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null).IsAlive;
            Assert.False(isAlive);
        }
    }
}