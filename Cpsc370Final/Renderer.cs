using System.Drawing;

namespace Cpsc370Final;

using Simulation;
using Firework;
using Color;
using Pixel;

public static class Renderer
{
    private static int width;
    private static int height;
    private static char[,] screenBuffer;
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

    public static void Draw(Simulation simulation)
    {
        Firework[] fireworks = Simulation.getFireworks();
        for (Firework firework : fireworks)
        {
            Position position = firework.getPosition();
            screenBuffer[position.x, position.y] = new Pixel(firework.getSymbol(), firework.getColor());
        }
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
        screenBuffer = new char[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                screenBuffer[i, j] = ' ';
            }
        }
    }

    private static void Render()
    {
        for (int i = 0; i < height; i++)
        {
            writeLine(i, new string(screenBuffer[i, 0], width));
        }
    }

    private static void writeLine(int lineNum, string line)
    {
        Console.SetCursorPosition(0, lineNum);
        Console.Write(line);
    }
}