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
            
        }


        private bool Stop()
        {
            Fireworks.Clear();
            return true;
        } 
        // clears list of freworks and doestn add any more
}

