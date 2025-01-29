namespace Cpsc370Final;

using System;
// using Position;
// using Velocity;
// using Particle;

public class Firework
{

    public int centerX = (Console.WindowWidth) / 2;
    public int centerY = (Console.WindowHeight) / 2;
    
    public bool isExploded = false;
    //public List<Particle> particles;
    public List<char> TestParticle { get; set; } = new List<char> { '*' };

    String ManageFirework() // handles particle movement
    {
        if (isExploded)
        {
            return "Exploded!";
            // get particle
            
            
            // place particle at x position
            
            // place particle at y position
            
        }

        return "Not Exploded!";
    }

    void Explode() // makes the firework explode
    {
        // if key is pressed
        
        isExploded = true;
        ManageFirework();
    }
}