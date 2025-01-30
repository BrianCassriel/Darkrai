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
        private Random random = new Random();

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
            if (particlePos.x >= 0 && particlePos.x < Renderer.GetWidth()  
                                   && particlePos.y >= 0 && particlePos.y < Renderer.GetHeight())
            {
                //Renderer.SetPixel(particlePos.x, particlePos.y, particleSymb, particleColor); // this is the line to actually use particles
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
            int fireworkY = startY;
            int fireworkX = FireworkPosition.x;

            while (fireworkY > 5) 
            {
                Renderer.SetPixel(fireworkX, fireworkY, '|', particleColor);  
                Thread.Sleep(80);  

                Renderer.SetPixel(fireworkX, fireworkY + 1, ' ', particleColor);
                fireworkY--;  
            }

            FireworkPosition.y = fireworkY; 
            isExploded = true;
            CreateParticles(); 
        }
 

        private void UpdateCenterPosition()
        {
            int maxY = Renderer.GetHeight() / 2;
            int minY = 5; 
        
            FireworkPosition.x = random.Next(0, Renderer.GetWidth());
            FireworkPosition.y = random.Next(minY, maxY);
        }

        public void OnFrame()
        {
            if (!isExploded)
            {
                Launch();
                FireworkPosition.y -= 1;

                if (FireworkPosition.y <= Renderer.GetHeight() / 2)
                {
                    isExploded = true;
                    //CreateParticles();
                    CreateParticles(12.0, 2,5, 'o');
                    CreateParticles(12.0, 3,8, 'o');
                    CreateParticles(12.0, 5,13, 'o');
                    UpdateCenterPosition();
                }
            }
            else
            {
                DrawFirework();
                Thread.Sleep(50);
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
            particles.Clear();
    
            int radius = 5;
            double particleDensity = 12;

            for (int i = 0; i < particleDensity; i++)
            {
                double angle = 2 * Math.PI * i / particleDensity;
                int offsetX = (int)Math.Round(Math.Cos(angle) * radius);
                int offsetY = (int)Math.Round(Math.Sin(angle) * 2.5 * radius);
        
                var particle = new Particle
                {
                    particlePosition = new Position(
                        FireworkPosition.x + offsetX,
                        FireworkPosition.y + offsetY
                    ),
                    particleSymbol = 'o'
                };

                particles.Add(particle);
            }
        }

        private void CreateParticles(double density, int radiusX, int radiusY, char centerParticleSymbol)
        {
            double particleDensity = density;

            for (int i = 0; i < particleDensity; i++)
            {
                double angle = 2 * Math.PI * i / particleDensity;
                int offsetX = (int)Math.Round(Math.Cos(angle) * radiusX);
                int offsetY = (int)Math.Round(Math.Sin(angle) * radiusY);
        
                var particle = new Particle
                {
                    particlePosition = new Position(
                        FireworkPosition.x + offsetX,
                        FireworkPosition.y + offsetY
                    ),
                    particleSymbol = centerParticleSymbol
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