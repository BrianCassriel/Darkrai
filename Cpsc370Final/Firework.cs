using System.Drawing;

using System.Xml.Schema;

namespace Cpsc370Final
{
    using System;

    public class Firework
    {
        public Position FireworkPosition { get; set; }
        public bool isExploded = false;
        private static DateTime BirthDate = DateTime.Now;
        public char centerParticleSymbol { get; } = '*';
        public List<Particle> particles = new List<Particle>();
        public Color particleColor { get; set; }

        public Firework()
        {
            FireworkPosition = new Position(10,10);
        }

        public Firework(Position position, Color color)
        {
            FireworkPosition = position;
            particleColor = color;
        }

        private void PlaceCenterParticle()
        {
            if ((FireworkPosition.x <= Renderer.GetWidth() - 1) && (FireworkPosition.y <= Renderer.GetHeight() - 1))
            {
                Renderer.SetPixel(FireworkPosition.x, FireworkPosition.y, centerParticleSymbol, particleColor);
            }
        }
        
        private void PlaceParticle(Position particlePos, char particleSymb)
        {
            if (particlePos.x >= 0 && particlePos.x < Renderer.GetWidth() && particlePos.y >= 0 && particlePos.y < Renderer.GetHeight())
            {
                Renderer.SetPixel(FireworkPosition.x, FireworkPosition.y, centerParticleSymbol, particleColor);
            }
        }

        public void ManageFirework()
        {
            if (isExploded)
            {
                PlaceCenterParticle();
            }
        }

        public void Launch()
        {
            int startY = Renderer.GetHeight() - 1;
    
            int currentY = startY;
            while (currentY > 5)
            {
                //Renderer.Clear();
                Renderer.SetPixel(Renderer.GetWidth() / 2, currentY, '|', particleColor);  
                Thread.Sleep(80);  
                
                Renderer.SetPixel(Renderer.GetWidth() / 2, currentY + 1, ' ', particleColor);
                currentY--;  
            }

            FireworkPosition.y = currentY; 
            isExploded = true;
            CreateParticles(); 
        }

        public void OnFrame()
        {
            if (!isExploded)
            {
                Launch();  
                FireworkPosition.y -= 1; // Move up by 1
            
                if (FireworkPosition.y <= Renderer.GetHeight() / 2)
                {
                    isExploded = true;
                    CreateParticles();
                }
            }
            else
            {
                DrawFirework(); 
            }

            IsDead();
        }

        
        public void DrawFirework()
        {
            PlaceParticle(FireworkPosition, centerParticleSymbol);

            if (isExploded)
            {
                foreach (var particle in particles)
                {
                    PlaceParticle(particle.particlePosition, particle.particleSymbol);
                }
            }
        }

        private void CreateParticles()
        {
            for (int i = 0; i < 12; i++) // Create 12 particles
            {
                double angle = 2 * Math.PI * i / 12;
                int offsetX = (int)(Math.Cos(angle) * 3); // Radius of 3
                int offsetY = (int)(Math.Sin(angle) * 3);

                var particle = new Particle
                {
                    particlePosition = new Position(FireworkPosition.x + offsetX, FireworkPosition.y + offsetY),
                    particleSymbol = 'o',
                    particleColor = this.particleColor
                };

                particles.Add(particle);
            }
        }

        public void Explode()
        {
            isExploded = true;
            ManageFirework();
        }

        public bool IsDead()
        {
            Random random = new Random();
            int Lifespan = random.Next(500, 2000);
            TimeSpan Age = DateTime.Now - BirthDate;
            if (Age.Milliseconds > Lifespan)
                return true;

            return false;
        }
    }
}