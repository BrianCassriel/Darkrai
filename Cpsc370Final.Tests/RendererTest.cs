using Moq;

namespace Cpsc370Final.Tests;

public class RendererTests
{
    private Mock<IConsoleCanvas> mockCanvas;
    
    public RendererTests()
    {
        mockCanvas = new Mock<IConsoleCanvas>();
        Renderer.SetCanvas(mockCanvas.Object);
        mockCanvas.Setup(c => c.Width).Returns(100);
        mockCanvas.Setup(c => c.Height).Returns(100);
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
    public void SetPixel_DoesNotSetPixelIfNotOnCanvas()
    {
        Renderer.SetPixel(-1, -1, 'X', Color.Red);
        mockCanvas.Verify(c => c.Set(-1, -1, 'X', ConsoleColor.Red), Times.Never);
    }

    [Fact]
    public void ClearPixel_ClearsPixelCorrectly()
    {
        Renderer.ClearPixel(1, 1);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.White), Times.Once());
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
        mockCanvas.Reset();
        int expectedWidth = Console.WindowWidth;
        int actualWidth = Renderer.GetWidth();
        Assert.Equal(expectedWidth, actualWidth);
    }

    [Fact]
    public void GetHeight_ReturnsCorrectHeight()
    {
        mockCanvas.Reset();
        int expectedHeight = Console.WindowHeight;
        int actualHeight = Renderer.GetHeight();
        Assert.Equal(expectedHeight, actualHeight);
    }
    
    [Fact]
    public void GetConsoleColor_ReturnsCorrectConsoleColor()
    {
        Renderer.SetPixel(1, 1, ' ', Color.None);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.White), Times.Once);
        Renderer.SetPixel(1, 1, ' ', Color.White);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.White), Times.Exactly(2));
        Renderer.SetPixel(1, 1, ' ', Color.Red);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.Red), Times.Once);
        Renderer.SetPixel(1, 1, ' ', Color.Green);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.Green), Times.Once);
        Renderer.SetPixel(1, 1, ' ', Color.Blue);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.Blue), Times.Once);
        Renderer.SetPixel(1, 1, ' ', Color.Yellow);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.Yellow), Times.Once);
        Renderer.SetPixel(1, 1, ' ', Color.Cyan);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.Cyan), Times.Once);
        Renderer.SetPixel(1, 1, ' ', Color.Magenta);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.Magenta), Times.Once);
        Renderer.SetPixel(1, 1, ' ', Color.Unknown);
        mockCanvas.Verify(c => c.Set(1, 1, ' ', ConsoleColor.White), Times.Exactly(3));
    }
    
    [Fact]
    public void OnFrame_ShouldCallCanvasRender()
    {
        Renderer.OnFrame();
        mockCanvas.Verify(c => c.Render(), Times.Once);
    }
}