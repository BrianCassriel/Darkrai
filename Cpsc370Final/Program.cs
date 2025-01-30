namespace Cpsc370Final;

class Program
{
    private static Thread inputThread;
    static void Main(string[] args)
    {
        Renderer.Initialize();
        Simulation.Start();
        inputThread = new Thread(ReadInput);
        inputThread.Start();
    }

    private static void ReadInput()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                inputThread.Join();
                Simulation.Stop();
                Renderer.Exit();
                break;
            }
        }
    }
}