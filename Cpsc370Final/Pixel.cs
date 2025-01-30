namespace Cpsc370Final;

public class Pixel
{
    public char symbol { get; set; }
    public Color color { get; set; } 
    public Position position { get; set; }
    
    public Pixel(int x, int y, char symbol, Color color)
    {
        this.position = new Position(x, y);
        this.symbol = symbol;
        this.color = color;
    }
}