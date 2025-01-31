namespace Cpsc370Final;

public interface IConsoleCanvas
{
    void Set(int x, int y, char symbol, ConsoleColor color);
    void Text(int x, int y, string text, bool centered = false, ConsoleColor? foreground = null, ConsoleColor? background = null);
    ConsoleRenderer.Pixel Get(int x, int y, bool backBuffer = true);
    void Clear();
    void Render();
    void CreateBorder();
    void Resize(int width, int height);
    int Width { get; }
    int Height { get; }
}