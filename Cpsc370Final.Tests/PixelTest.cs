namespace Cpsc370Final.Tests
{
    public class PixelTests
    {
        [Fact]
        public void Pixel_CreatesWithCorrectSymbolAndColor()
        {
            char expectedSymbol = 'A';
            Color expectedColor = Color.Red;
            Pixel pixel = new Pixel(expectedSymbol, expectedColor);
            Assert.Equal(expectedSymbol, pixel.symbol);
            Assert.Equal(expectedColor, pixel.color);
        }

        [Fact]
        public void Pixel_SymbolCanBeUpdated()
        {
            Pixel pixel = new Pixel('A', Color.Red);
            char newSymbol = 'B';
            pixel.symbol = newSymbol;
            Assert.Equal(newSymbol, pixel.symbol);
        }

        [Fact]
        public void Pixel_ColorCanBeUpdated()
        {
            // Arrange
            Pixel pixel = new Pixel('A', Color.Red);
            Color newColor = Color.Blue;

            // Act
            pixel.color = newColor;

            // Assert
            Assert.Equal(newColor, pixel.color);
        }

        [Fact]
        public void Pixel_CreatesWithDefaultValues()
        {
            // Arrange & Act
            Pixel pixel = new Pixel(default(char), default(Color));

            // Assert
            Assert.Equal(default(char), pixel.symbol);
            Assert.Equal(default(Color), pixel.color);
        }
    }
}