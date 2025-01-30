
using Xunit;
using Moq;
using ConsoleRenderer;

namespace Cpsc370Final.Tests
{
    public class RendererTests
    {
        private Mock<ConsoleCanvas> mockCanvas;
        
        public RendererTests()
        {
            mockCanvas = new Mock<ConsoleCanvas>();
            Renderer.SetCanvas(mockCanvas.Object);
        }
        
        [Fact]
        public void GetFrameRate_ReturnsCorrectFrameRate()
        {
            int expectedFrameRate = 1000 / 24;
            int actualFrameRate = Renderer.GetFrameRate();
            Assert.Equal(expectedFrameRate, actualFrameRate);
        }

        [Fact]
        public void SetPixel_SetsPixelCorrectly()
        {
            Renderer.SetPixel(1, 1, 'X', Color.Red);
            mockCanvas.Verify(c => c.Set(1, 1, 'X', ConsoleColor.Red), Times.Once);
        }

        [Fact]
        public void ClearPixel_ClearsPixelCorrectly()
        {
            Renderer.ClearPixel(1, 1);
            mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.White), Times.Once);
        }

        [Fact]
        public void SetPixels_SetsMultiplePixelsCorrectly()
        {
            var pixels = new List<Pixel>
            {
                new Pixel(1, 1, 'X', Color.Red),
                new Pixel(2, 2, 'Y', Color.Green)
            };
            Renderer.SetPixels(pixels);
            mockCanvas.Verify(c => c.Set(1, 1, 'X', ConsoleColor.Red), Times.Once);
            mockCanvas.Verify(c => c.Set(2, 2, 'Y', ConsoleColor.Green), Times.Once);
        }

        [Fact]
        public void ClearPixels_ClearsMultiplePixelsCorrectly()
        {
            var pixels = new List<Pixel>
            {
                new Pixel(1, 1, 'X', Color.Red),
                new Pixel(2, 2, 'Y', Color.Green)
            };
            Renderer.ClearPixels(pixels);
            mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.White), Times.Once);
            mockCanvas.Verify(c => c.Set(2, 2, ' ', ConsoleColor.White), Times.Once);
        }

        [Fact]
        public void Exit_ClearsAndRendersCanvas()
        {
            Renderer.Exit();
            mockCanvas.Verify(c => c.Clear(), Times.Once);
            mockCanvas.Verify(c => c.Render(), Times.Once);
        }

        [Fact]
        public void GetWidth_ReturnsCorrectWidth()
        {
            int expectedWidth = Console.WindowWidth;
            int actualWidth = Renderer.GetWidth();
            Assert.Equal(expectedWidth, actualWidth);
        }

        [Fact]
        public void GetHeight_ReturnsCorrectHeight()
        {
            int expectedHeight = Console.WindowHeight;
            int actualHeight = Renderer.GetHeight();
            Assert.Equal(expectedHeight, actualHeight);
        }
    }
}