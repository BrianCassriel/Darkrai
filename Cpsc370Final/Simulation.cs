using System.Runtime.InteropServices.JavaScript;

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

    public static Firework GetRandomFirework()
    {
        Random rnd = new Random();
        int x = rnd.Next(1, Renderer.GetWidth() - 1);
        int y = rnd.Next(1, Renderer.GetHeight() - 1);

        Array values = Enum.GetValues(typeof(Color));
        Random random = new Random();
        Color randomColor = (Color)values.GetValue(random.Next(values.Length));

        return new Firework(new Position(x, y), randomColor);
    }

    public static void TryLaunchRandomFirework()
    {
        Random random = new Random();
        int threshold = random.Next(500, 3000);
        TimeSpan elapsedTime = DateTime.Now - LastFireworkDate;
        if (elapsedTime.Milliseconds > threshold)
        {
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
