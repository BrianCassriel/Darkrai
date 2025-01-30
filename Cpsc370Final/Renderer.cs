namespace Cpsc370Final;

using ConsoleRenderer;

public static class Renderer
{
    private static int framerate = 1000 / 24;
    private static ConsoleCanvas canvas = new ConsoleCanvas(true, true);

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

    public static void SetPixels(List<Pixel> pixels)
    {
        foreach (Pixel pixel in pixels)
        {
            SetPixel(pixel.position.x, pixel.position.y, pixel.symbol, pixel.color);
        }
    }
    
    public static void ClearPixels(List<Pixel> pixels)
    {
        foreach (Pixel pixel in pixels)
        {
            ClearPixel(pixel.position.x, pixel.position.y);
        }
    }

    public static void Exit()
    {
        canvas.Clear();
        canvas.Render();
        Console.Clear();
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