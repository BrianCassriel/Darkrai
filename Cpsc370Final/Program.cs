namespace Cpsc370Final;

class Program
{
    private static bool isRunning = true;
    
    static void Main(string[] args)
    {
        MainLoop();
    }

    static void MainLoop()
    {
        while (isRunning)
        {
            Renderer.OnFrame();
            Thread.Sleep(Renderer.GetFrameRate());
            ReadInput();
        }
        Renderer.Exit();
    }

    private static void ReadInput()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Q)
            {
                isRunning = false;
            } else if (key.Key == ConsoleKey.Spacebar)
            {
                Simulation.LaunchRandomFirework();
            }
        }
    }
}