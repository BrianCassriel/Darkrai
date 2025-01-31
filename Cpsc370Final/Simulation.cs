namespace Cpsc370Final;

public static class Simulation
{
    public static List<Firework> Fireworks = new List<Firework>();
    public static bool isStopped = false;
    private static DateTime LastFireworkDate = DateTime.Now;
    
    public static void AddFirework(Firework NewFirework)
    {
        Fireworks.Add(NewFirework);
    }

    public static void RemoveFirework(int FireworkIndex)
    {
        if (Fireworks[FireworkIndex] == null)
            return;
        Fireworks.RemoveAt(FireworkIndex);
    }

    public static void OnFrame()
    {
        if (isStopped)
            return;
        
        List<Firework> toRemove = new List<Firework>();
        for (int i = 0; i < Fireworks.Count; i++)
        {
            Firework firework = Fireworks[i];
            firework.OnFrame();
            if (firework.IsDead())
                toRemove.Add(firework);
        }
        foreach(Firework firework in toRemove)
        {
            firework.Remove();
            Fireworks.Remove(firework);   
        }
        TryLaunchRandomFirework();
    }

    public static List<Firework> GetFireworks()
    {
        return Fireworks;
    }

    public static void TryLaunchRandomFirework()
    {
        Random random = new Random();
        int threshold = random.Next(500, 3000);
        TimeSpan elapsedTime = DateTime.Now - LastFireworkDate;
        if (elapsedTime.TotalMilliseconds > threshold)
        {
            LaunchRandomFirework();
            LastFireworkDate = DateTime.Now;
        }
    }

    public static void LaunchRandomFirework()
    {
        Fireworks.Add(GetRandomFirework());
    }
    
    public static Firework GetRandomFirework()
    {
        return new Firework(GetRandomPosition(), GetRandomColor());
    }
    
    public static Position GetRandomPosition()
    {
        Random rnd = new Random();
        int x = rnd.Next(0, Renderer.GetWidth()-1);
        int y = rnd.Next(5, Renderer.GetHeight()-1);
        
        return new Position(x, y);
    }

    public static Color GetRandomColor()
    {
        Array values = Enum.GetValues(typeof(Color));
        Random random = new Random();
        Color randomColor = (Color)values.GetValue(random.Next(values.Length));
        
        return randomColor;
    }

    public static void Stop()
    {
        isStopped = true;
    }
}
