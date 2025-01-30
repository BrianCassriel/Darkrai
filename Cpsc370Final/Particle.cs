namespace Cpsc370Final;

public class Particle
{
    public Position ParticlePosition { get; set; }
    public Velocity Velocity { get; set; }
    
    float Lifetime { get; set; }

    public Particle(int x, int y, Velocity velocity, float lifetime)
    {
        ParticlePosition.x = x;
        ParticlePosition.y = y;
        Velocity = velocity;
        Lifetime = lifetime;
    }

    void ManageParticle()
    {
        if (Lifetime > 0)
        {
            
        }
    }
}