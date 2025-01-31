using ConsoleRenderer;

namespace Cpsc370Final;

public class ConsoleCanvasWrapper : IConsoleCanvas
{
    private readonly ConsoleCanvas consoleCanvas;

    public ConsoleCanvasWrapper(ConsoleCanvas consoleCanvas)
    {
        this.consoleCanvas = consoleCanvas;
    }

    public virtual void Set(int x, int y, char symbol, ConsoleColor color)
    {
        consoleCanvas.Set(x, y, symbol, color);
    }

    public virtual void Text(int x, int y, string text, bool centered = false, ConsoleColor? foreground = null,
        ConsoleColor? background = null)
    {
        consoleCanvas.Text(x, y, text, centered, foreground, background);
    }

    public virtual ConsoleRenderer.Pixel Get(int x, int y, bool backBuffer = true)
    {
        return consoleCanvas.Get(x, y, backBuffer);
    }

    public virtual void Clear()
    {
        consoleCanvas.Clear();
    }

    public virtual void Render()
    {
        consoleCanvas.Render();
    }

    public virtual void CreateBorder()
    {
        consoleCanvas.CreateBorder();
    }

    public virtual void Resize(int width, int height)
    {
        consoleCanvas.Resize(width, height);
    }
    
    public int Width => consoleCanvas.Width;
    public int Height => consoleCanvas.Height;
}