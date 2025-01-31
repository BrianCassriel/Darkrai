namespace Cpsc370Final;

using System;

public class Firework
{
    public Position fireworkPosition { get; set; }
    public bool isExploded = false;
    public char centerParticleSymbol { get; } = '*';
    public Position launchParticlePosition;
    public List<Particle> particles = new List<Particle>();
    public Color particleColor { get; set; }
    private Random random = new Random();
    private int framesToLive;

    public Firework(Position position, Color color)
    {
        fireworkPosition = position;
        particleColor = color;
        launchParticlePosition = new Position(fireworkPosition.x, Renderer.GetHeight() - 1);
        Random random = new Random();
        framesToLive = random.Next(20, 35);
    }
    
    public bool IsDead()
    {
        return framesToLive <= 0;
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
        Renderer.SetPixel(fireworkPosition.x, fireworkPosition.y, centerParticleSymbol, particleColor);
    }
    
    private void PlaceParticle(Position particlePos, char particleSymbol)
    {
        Renderer.SetPixel(particlePos.x, particlePos.y, particleSymbol, particleColor);
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
            framesToLive--;
            particles.Clear();
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
        PlaceCenterParticle();
        foreach (var particle in particles)
            PlaceParticle(particle.particlePosition, particle.particleSymbol);
    }

    public void CreateLargeParticles()
    {
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