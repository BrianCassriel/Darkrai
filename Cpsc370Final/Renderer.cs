namespace Cpsc370Final;

using ConsoleRenderer;

public static class Renderer
{
    private static int framerate = 1000 / 24;
    public static bool shouldExit { get; private set; }
    private static ConsoleCanvas canvas = new ConsoleCanvas();

    public static void Start()
    {
        shouldExit = false;
        RenderLoop();
    }
    
    private static void RenderLoop()
    {
        while (!shouldExit)
        {
            canvas.Clear();
            canvas.CreateBorder();
            Simulation.OnFrame();
            canvas.Render();
            Thread.Sleep(framerate);
        }
    }
    
    public static void Exit()
    {
        shouldExit = true;
    }
    
    public static void SetPixel(int x, int y, char symbol, Color color)
    {
        canvas.Set(x, y, symbol, GetConsoleColor(color));
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