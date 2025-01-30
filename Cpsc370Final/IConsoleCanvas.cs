namespace Cpsc370Final;

public interface IConsoleCanvas
{
    void Set(int x, int y, char symbol, ConsoleColor color);
    void Clear();
    void Render();
    void CreateBorder();
    int Width { get; }
    int Height { get; }
}