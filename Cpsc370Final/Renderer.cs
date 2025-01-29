namespace Cpsc370Final;

public static class Renderer
{
    private static int width;
    private static int height;
    private static Pixel[,] screenBuffer;
    private static int frameTime = 1000 / 24;
    private static bool shouldExit = false;

    static Renderer()
    {
        SetupConsoleScreenSize();
        SetupScreenBuffer();

        while (shouldExit == false)
        {
            Render();
            Thread.Sleep(frameTime);
        }
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
            string line = "";
            for (int j = 0; j < width; j++)
            {
                Pixel pixel = screenBuffer[i, j];
                Console.ForegroundColor = getConsoleColor(pixel.color); // incorrect
                line += pixel.symbol;
            }
            writeLine(i, line);
        }
    }

    private static void writeLine(int lineNum, string line)
    {
        Console.SetCursorPosition(0, lineNum);
        Console.Write(line);
    }
    
    private static ConsoleColor getConsoleColor(Color color)
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
            Color.Magenta => ConsoleColor.Magenta
        };
    }
}