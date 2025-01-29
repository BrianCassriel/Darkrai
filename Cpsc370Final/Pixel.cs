namespace Cpsc370Final;

public class Pixel
{
    public char symbol { get; set; }
    public Color color { get; set; }
    
    public Pixel(char symbol, Color color)
    {
        this.symbol = symbol;
        this.color = color;
    }
}