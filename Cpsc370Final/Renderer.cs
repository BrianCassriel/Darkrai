namespace Cpsc370Final;

using ConsoleRenderer;

public static class Renderer
{
    public static bool isInColor = true;
    private static int framerate = 1000 / 24;
    private static IConsoleCanvas canvas = new ConsoleCanvasWrapper(new ConsoleCanvas(false, true));
    private static Queue<Color> textColors;
    private static DateTime lastColorTime = DateTime.Now;
    
    public static int GetFrameRate()
    {
        return framerate;
    }
    
    public static void SetCanvas(IConsoleCanvas canvas)
    {
        Renderer.canvas = canvas;
    }
    
    public static void Start()
    {
        Color[] colors = {Color.Red, Color.Yellow, Color.Green, 
            Color.Blue, Color.Cyan, Color.Magenta};
        textColors = new Queue<Color>(colors);
    }
    
    public static void OnFrame()
    {
        canvas.Clear();
        canvas.CreateBorder();
        Simulation.OnFrame();
        WriteInfoText();
        canvas.Render();
    }
    
    private static void WriteInfoText()
    {
        CycleColorText(canvas.Width / 2, 0, " Procedural Fireworks! ");
        canvas.Text(canvas.Width / 2, canvas.Height -1, " Press 'Space' for fun or 'Q' to quit. ", true);
    }

    private static void CycleColorText(int x, int y, String str)
    {
        Color color = textColors.Peek();
        if (lastColorTime.AddSeconds(0.5) < DateTime.Now)
        {
            lastColorTime = DateTime.Now;
            color = textColors.Dequeue();
            textColors.Enqueue(color);
        }
        canvas.Text(x, y, str, true, GetConsoleColor(color));
    }
    
    public static void SetPixel(int x, int y, char symbol, Color color)
    {
        if (!IsOnCanvas(x, y))
            return;
        Color symbolColor = isInColor ? color : Color.None;
        canvas.Set(x, y, symbol, GetConsoleColor(symbolColor));
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

    private static bool IsOnCanvas(int x, int y)
    {
        return x > 0 && y > 0 && x < canvas.Width - 1 && y < canvas.Height - 1;
    }
    
    private static ConsoleColor GetConsoleColor(Color color)
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