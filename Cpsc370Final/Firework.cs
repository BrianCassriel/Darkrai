using System.Xml.Schema;

namespace Cpsc370Final
{
    using System;

    public class Firework
    {
        public Position FireworkPosition { get; set; }
        public bool isExploded = false;
        public char centerParticleSymbol { get; } = '*';
        public List<Particle> particles = new List<Particle>();
        public Color particleColor;

        public Firework()
        {
            FireworkPosition = new Position(10,10);
        }

        public Firework(Position position, Color color)
        {
            FireworkPosition = position;
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
            if (particlePos.x >= 0 && particlePos.x < Renderer.GetWidth  && particlePos.y >= 0 && particlePos.y < Renderer.GetHeight)
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

        public void OnFrame()
        {
            if (!isExploded)
            {
                Launch();
                FireworkPosition.y -= 1; // Move up by 1
            
                if (FireworkPosition.y <= 5)
                {
                    isExploded = true;
                    CreateParticles();
                }
            }
            else
            {
                DrawFirework();
            }
        }

        public void Launch()
        {
            int startY = Renderer.GetHeight() - 1;
    
            for (int i = startY; i >= 0; i--)
            {
                Renderer.SetPixel(Renderer.GetWidth() / 2, i, '|', particleColor);
                Thread.Sleep(50);
            }
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
                };

                particles.Add(particle);
            }
        }

        public void Explode()
        {
            isExploded = true;
            ManageFirework();
        }
    }
}