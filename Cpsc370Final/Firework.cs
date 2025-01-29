namespace Cpsc370Final
{
    using System;
    public class Firework
    {
        public Position FireworkPosition { get; set; }

        public bool isExploded = false;
        public List<char> TestParticle { get; set; } = new List<char> { '*' };

        public Firework()
        {
            FireworkPosition = new Position(Console.WindowWidth / 2, Console.WindowHeight / 2);
        }

        private void PlaceParticle()
        {
            if ((FireworkPosition.x <= Console.WindowWidth - 1) && (FireworkPosition.y <= Console.WindowHeight - 1))
            {
                Console.SetCursorPosition(FireworkPosition.x, FireworkPosition.y);
                Console.Write(TestParticle[0]);
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