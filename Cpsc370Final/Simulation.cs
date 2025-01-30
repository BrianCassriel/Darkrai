namespace Cpsc370Final;

public static class Simulation
{
    private static List<Firework> Fireworks = new List<Firework>();
    private static bool isStopped = false;
    private static DateTime LastFireworkDate = DateTime.Now;
    
    private static void AddFirework(Firework NewFirework)
    {
        Fireworks.Add(NewFirework);
    }

    private static void RemoveFirework(int FireworkIndex)
    {
        if (Fireworks[FireworkIndex] == null)
            return;
        Fireworks.RemoveAt(FireworkIndex);
    }

    public static void OnFrame()
    {
        if (isStopped)
            return;
        foreach (var firework in Fireworks)
        {
            firework.OnFrame();
            if(firework.IsDead())
                Fireworks.Remove(firework);
        }
        TryLaunchRandomFirework();
    }

    private static Firework GetFirework(int FireworkIndex)
    {
        return Fireworks[FireworkIndex];
    }

    private static List<Firework> GetFireworks()
    {
        return Fireworks;
    }

    public static void TryLaunchRandomFirework()
    {
        Random random = new Random();
        int threshold = random.Next(500, 3000);
        TimeSpan elapsedTime = DateTime.Now - LastFireworkDate;
        if (elapsedTime.Milliseconds > threshold)
        {
            LaunchRandomFirework();
            LastFireworkDate = DateTime.Now;
        }
    }

    public static void LaunchRandomFirework()
    {
        Fireworks.Add(GetRandomFirework());
    }
    
    private static Firework GetRandomFirework()
    {
        return new Firework(GetRandomPosition(), GetRandomColor());
    }

    /*public static void Start()
    {
        isStopped = false;
        while (!isStopped)
        {
            Random random = new Random();
            int ElapsedTime = random.Next(1, 3);
            if (DateTime.Now - LastFireworkDate > TimeSpan.FromSeconds(ElapsedTime))
                Fireworks.Add(GetRandomFirework());
                LastFireworkDate = DateTime.Now;
        }
    }
    */
    
    private static Position GetRandomPosition()
    {
        Random rnd = new Random();
        int x = rnd.Next(0, Renderer.GetWidth()-1);
        int y = rnd.Next(5, Renderer.GetHeight()-1);
        
        return new Position(x, y);
    }

    private static Color GetRandomColor()
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
