namespace Cpsc370Final;

public class Simulation
{
    private List<Firework> Fireworks = new List<Firework>();

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
}