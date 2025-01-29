namespace Cpsc370Final;

public class Renderer
{
    private int width;
    private int height;
    private int[,] screenBuffer;
    
    public Renderer()
    {
        this.SetupConsoleScreenSize();
        this.SetupScreenBuffer();
    }

    private void SetupConsoleScreenSize()
    {
        this.width = Console.WindowWidth;
        this.height = Console.WindowHeight;
    }

    private void SetupScreenBuffer()
    {
        // 2D array to hold the screen buffer
        this.screenBuffer = new int[this.height, this.width];
    }

    private void writeLine(int lineNum, string line)
    {
        Console.SetCursorPosition(0, lineNum);
        Console.Write(line);
    }
}