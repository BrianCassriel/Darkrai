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

    public int Width => consoleCanvas.Width;
    public int Height => consoleCanvas.Height;
}