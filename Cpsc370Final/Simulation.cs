namespace Cpsc370Final;

public static class Simulation
{
    private static List<Firework> Fireworks = new List<Firework>();
    private static bool isStopped = true;

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

    private static void UpdateAll()
    {
        foreach (var firework in Fireworks)
        {
            firework.ManageFirework();
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

    public static void AddRandomFirework()
    {
        Random rnd = new Random();
        int x = rnd.Next(1, 3);
        int y = rnd.Next(1, 3);

        Array values = Enum.GetValues(typeof(Color));
        Random random = new Random();
        Color randomColor = (Color)values.GetValue(random.Next(values.Length));

        Fireworks.Add(new Firework(new Position(x, y), randomColor));
    }

    public static void Start()
    {
        isStopped = false;
        while (!isStopped)
        {
            Renderer.DrawFirework(GetFirework(0));
            Fireworks.RemoveAt(0);
            Thread.Sleep(1000);
        }
    }

    public static void Stop()
    {
        Fireworks.Clear();
        isStopped = true;
    }
}