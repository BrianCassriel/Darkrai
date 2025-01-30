namespace Cpsc370Final;

using System.Threading;

public static class Renderer
{
    private static int width;
    private static int height;
    private static Pixel[,] screenBuffer;
    private static int frameTime = 1000 / 24;
    private static bool shouldExit = false;
    private static Thread renderThread;

    public static void Initialize()
    {
        SetupConsoleScreenSize();
        SetupScreenBuffer();
        renderThread = new Thread(RenderLoop);
        renderThread.Start();
    }
    
    public static void RenderLoop()
    {
        while (shouldExit == false)
        {
            Render();
            Thread.Sleep(frameTime);
        }
        renderThread.Join();
        Console.Clear();
    }
    
    public static void DrawFirework(Firework firework)
    {
        Position position = firework.FireworkPosition;
        screenBuffer[position.x, position.y] = new Pixel(firework.centerParticleSymbol, firework.particleColor);
    }
    
    public static void Exit()
    {
        shouldExit = true;
    }

    private static void SetupConsoleScreenSize()
    {
        width = Console.WindowWidth;
        height = Console.WindowHeight;
    }

    private static void SetupScreenBuffer()
    {
        screenBuffer = new Pixel[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                screenBuffer[i, j] = new Pixel(' ', Color.None);
            }
        }
    }

    private static void Render()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                WritePixel(screenBuffer[i, 0]);
            }
            Console.WriteLine();
        }
    }

    private static void WritePixel(Pixel pixel)
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = GetConsoleColor(pixel.color);
        Console.Write(pixel.symbol);
        Console.ResetColor();
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