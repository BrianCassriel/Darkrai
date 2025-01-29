namespace Cpsc370Final
{
    using System;
    
    public class Firework
    {
        public Position FireworkPosition { get; set; }
        public bool isExploded = false;
        public char centerParticleSymbol { get; } = '*';
        public Color particleColor;

        public Firework()
        {
            FireworkPosition = new Position(10,10);
        }

        public Firework(Position position)
        {
            FireworkPosition = position;
        }

        private void PlaceParticle()
        {
            if ((FireworkPosition.x <= Console.WindowWidth - 1) && (FireworkPosition.y <= Console.WindowHeight - 1))
            {
                Console.SetCursorPosition(FireworkPosition.x, FireworkPosition.y);
                Console.Write(centerParticleSymbol);
            }
        }

        public void ManageFirework()
        {
            if (isExploded)
            {
                PlaceParticle();
            }
        }

        public void Explode()
        {
            isExploded = true;
            ManageFirework();
        }
    }
}