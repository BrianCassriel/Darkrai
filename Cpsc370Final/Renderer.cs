namespace Cpsc370Final;

using ConsoleRenderer;

public static class Renderer
{
    private static int framerate = 1000 / 24;
    public static bool shouldExit = false;
    private static ConsoleCanvas canvas = new ConsoleCanvas();

    public static int GetFrameRate()
    {
        return framerate;
    }
    
    public static void OnFrame()
    {
            canvas.Clear();
            canvas.CreateBorder();
            Simulation.OnFrame();
            canvas.Render();
            Thread.Sleep(framerate);
    }
    
    public static void SetPixel(int x, int y, char symbol, Color color)
    {
        canvas.Set(x, y, symbol, GetConsoleColor(color));
    }
    
    public static void ClearPixel(int x, int y)
    {
        canvas.Set(x, y, ' ', ConsoleColor.White);
    }

    public static void Exit()
    {
        canvas.Clear();
        canvas.Render();
    }
    
    public static int GetWidth()
    {
        return canvas.Width;
    }
    
    public static int GetHeight()
    {
        return canvas.Height;
    }
    
    public static ConsoleColor GetConsoleColor(Color color)
    {
        return color switch
        {
            Color.None => ConsoleColor.White,
            Color.White => ConsoleColor.White,
            Color.Red => ConsoleColor.Red,
            Color.Green => ConsoleColor.Green,
            Color.Blue => ConsoleColor.Blue,
            Color.Yellow => ConsoleColor.Yellow,
            Color.Cyan => ConsoleColor.Cyan,
            Color.Magenta => ConsoleColor.Magenta,
            _ => ConsoleColor.White
        };
    }
}