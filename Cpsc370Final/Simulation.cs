namespace Cpsc370Final;

using System;
using System.Threading;

public class Simulation
{
    private List<Firework> Fireworks = new List<Firework>();
    private bool isStopped = true;
    private void AddFirework(Firework NewFirework)
    {
        Fireworks.Add(NewFirework);
    }

    private void RemoveFirework(int FireworkIndex)
    {
        if (Fireworks[FireworkIndex] == null) 
            return;
        Fireworks.RemoveAt(FireworkIndex);
    }

    private void UpdateAll()
    {
        foreach (var firework in Fireworks)
        {
            firework.ManageFirework();
        }
    }
    
    private Firework GetFirework(int FireworkIndex)
    {
        return Fireworks[FireworkIndex];
    }
    
    private List<Firework> GetFireworks()
    {
        return Fireworks;
    }
    
    private Firework GetRandomFireworks()
    {
        Random rnd = new Random();
        int x = rnd.Next(1, 3);
        int y = rnd.Next(1, 3);
        
        Array values = Enum.GetValues(typeof(Color));
        Random random = new Random();
        Color randomColor = (Color)values.GetValue(random.Next(values.Length));
        Position position = new Position(x, y);
        
        Firework firework = new Firework(randomColor, position);
        
        return firework;
    }

    private void AddRandomFirework()
    {
        Random rnd = new Random();
        int x = rnd.Next(1, 3);
        int y = rnd.Next(1, 3);
        
        Array values = Enum.GetValues(typeof(Color));
        Random random = new Random();
        Color randomColor = (Color)values.GetValue(random.Next(values.Length));
        
        Fireworks.Add(new Firework(randomColor,  Position(x, y)));
    }
        // gerenate random color and xy position

        // adds random firework every couple seconds
        private void Start()
        {
            isStopped = false;
            while (!isStopped)
            {
                if (Fireworks.Count == 0)
                    break;
                
                DrawFirework(GetRandomFirework(0));
                Fireworks.RemoveAt(0);
                Thread.Sleep(1000);
            }
        }


        private void Stop()
        {
            Fireworks.Clear();
            isStopped = true;
        } 
}

