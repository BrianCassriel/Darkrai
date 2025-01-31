using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace Cpsc370Final
{
    using System;

    public class Firework
    {
        public Position fireworkPosition { get; set; }
        public bool isExploded = false;
        private static DateTime BirthDate = DateTime.Now;
        public char centerParticleSymbol { get; } = '*';
        public List<Particle> particles = new List<Particle>();
        public Color particleColor { get; set; }
        private Random random = new Random();
        private Position launchParticlePosition;

        public Firework(Position position, Color color)
        {
            fireworkPosition = position;
            particleColor = color;
            launchParticlePosition = new Position(fireworkPosition.x, Renderer.GetHeight() - 1);
        }
        
        public bool IsDead()
        {
            Random random = new Random();
            int Lifespan = random.Next(3000, 8000);
            TimeSpan Age = DateTime.Now - BirthDate;
            if (Age.Milliseconds > Lifespan)
                return true;
            return false;
        }

        public void Remove()
        {
            foreach (var particle in particles)
            {
                particle.Remove();
            }
            particles.Clear();
        }

        private void PlaceCenterParticle()
        {
            if ((fireworkPosition.x <= Renderer.GetWidth() - 1) && (fireworkPosition.y <= Renderer.GetHeight() - 1))
            {
                Renderer.SetPixel(fireworkPosition.x, fireworkPosition.y, centerParticleSymbol, particleColor);
            }
        }
        
        private void PlaceParticle(Position particlePos, char particleSymbol)
        {
            if (particlePos.x >= 0 && particlePos.x < Renderer.GetWidth()
                                   && particlePos.y >= 0 && particlePos.y < Renderer.GetHeight())
            {
                Renderer.SetPixel(particlePos.x, particlePos.y, particleSymbol, particleColor);
            }
        }

        public void OnFrame()
        {
            if (!isExploded)
            {
                DrawLaunchParticle();
                if (launchParticlePosition.x == fireworkPosition.x && launchParticlePosition.y == fireworkPosition.y)
                    isExploded = true;
            }
            else
            {
                Random rnd = new Random();
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        CreateSmallParticles();
                        break;
                    case 2:
                        CreateMediumParticles();
                        break;
                    default:
                        CreateLargeParticles();
                        break;
                }
                DrawFirework();
            }
        }
        
        public void DrawLaunchParticle()
        {
            Renderer.SetPixel(launchParticlePosition.x, launchParticlePosition.y, '|', particleColor);  
            Renderer.SetPixel(launchParticlePosition.x, launchParticlePosition.y + 1, ' ', particleColor);
            launchParticlePosition.y--;
        }
        
        public void DrawFirework()
        {
            PlaceParticle(fireworkPosition, centerParticleSymbol);
            if (isExploded)
            {
                foreach (var particle in particles)
                {
                    PlaceParticle(particle.particlePosition, particle.particleSymbol);
                }
            }
        }

        public void CreateLargeParticles()
        {
            particles.Clear();
    
            int radius = 4;
            double particleDensity = 12;

            for (int i = 0; i < particleDensity; i++)
            {
                double angle = 2 * Math.PI * i / particleDensity;

                int offsetX = (int)Math.Round(Math.Cos(angle) * 1.5 * radius);
                int offsetY = (int)Math.Round(Math.Sin(angle) * 0.5 *radius);
        
                var particle = new Particle
                {
                    particlePosition = new Position(
                        fireworkPosition.x + offsetX,
                        fireworkPosition.y + offsetY
                    ),
                    particleSymbol = 'o'
                };

                particles.Add(particle);
            }
            
            for (int j = 0; j < particleDensity; j++)
            {
                double angle = 2 * Math.PI * j / particleDensity;

                int offsetX = (int)Math.Round(Math.Cos(angle) * 3 * radius);
                int offsetY = (int)Math.Round(Math.Sin(angle) * 1 * radius);
        
                var particle = new Particle
                {
                    particlePosition = new Position(
                        fireworkPosition.x + offsetX,
                        fireworkPosition.y + offsetY
                    ),
                    particleSymbol = '*'
                };

                particles.Add(particle);
            }
        }
        
        public void CreateMediumParticles()
        {
            particles.Clear();
    
            int radius = 4;
            double particleDensity = 12;

            for (int i = 0; i < particleDensity; i++)
            {
                double angle = 2 * Math.PI * i / particleDensity;

                int offsetX = (int)Math.Round(Math.Cos(angle) * 1.5 * radius);
                int offsetY = (int)Math.Round(Math.Sin(angle) * 0.5 *radius);
        
                var particle = new Particle
                {
                    particlePosition = new Position(
                        fireworkPosition.x + offsetX,
                        fireworkPosition.y + offsetY
                    ),
                    particleSymbol = '+'
                };

                particles.Add(particle);
            }
        }
        
        public void CreateSmallParticles()
        {
            particles.Clear();
    
            int radius = 3;
            double particleDensity = 12;

            for (int i = 0; i < particleDensity; i++)
            {
                double angle = 2 * Math.PI * i / particleDensity;

                int offsetX = (int)Math.Round(Math.Cos(angle) * 1 * radius);
                int offsetY = (int)Math.Round(Math.Sin(angle) * 0.3 * radius);
        
                var particle = new Particle
                {
                    particlePosition = new Position(
                        fireworkPosition.x + offsetX,
                        fireworkPosition.y + offsetY
                    ),
                    particleSymbol = '*'
                };

                particles.Add(particle);
            }
        }
    }
}