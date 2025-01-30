using System.Runtime.CompilerServices;

namespace Cpsc370Final;

public static class Simulation
{
    private static List<Firework> Fireworks = new List<Firework>();
    private static bool isStopped = true;
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
        foreach (var firework in Fireworks)
        {
            firework.OnFrame();
        }
    }

    private static Firework GetFirework(int FireworkIndex)
    {
        return Fireworks[FireworkIndex];
    }

    private static List<Firework> GetFireworks()
    {
        return Fireworks;
    }

    public static Firework GetRandomFirework()
    {
        Random rnd = new Random();
        int x = rnd.Next(1, 3);
        int y = rnd.Next(1, 3);

        Array values = Enum.GetValues(typeof(Color));
        Random random = new Random();
        Color randomColor = (Color)values.GetValue(random.Next(values.Length));

        return new Firework(new Position(x, y), randomColor);
    }

    public static void Start()
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

    public static void Stop()
    {
        Fireworks.Clear();
        isStopped = true;
    }
}
