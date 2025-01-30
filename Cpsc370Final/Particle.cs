namespace Cpsc370Final;

public class Particle
{
    public Position particlePosition { get; set; }
    public Velocity velocity { get; set; }
    public bool isFinished = false;
    public char particleSymbol { get; set; }
    
    public float lifetime { get; set; }

    public Particle()
    {
        particlePosition = new Position { x = 10, y = 10 };
        velocity = new Velocity(0, 0);
        lifetime = 20;
        particleSymbol = ' ';
    }

    public Particle(int posX, int posY, Velocity inputVelocity, float inputLifetime, char symbol)
    {
        particlePosition = new Position { x = posX, y = posY };
        velocity = inputVelocity;
        lifetime = inputLifetime;
        particleSymbol = symbol;
    }

    public void ManageParticle()
    {
        if ((lifetime > 0) && (!isFinished))
        {
            Console.SetCursorPosition(particlePosition.x, particlePosition.y);
            Console.Write(particleSymbol);
            
            MoveParticle();

            lifetime--;

            if (lifetime <= 0)
            {
                isFinished = true;
            }
        }
    }

    private void MoveParticle()
    {
        particlePosition.x += velocity.x;
        particlePosition.y += velocity.y;
    }
}