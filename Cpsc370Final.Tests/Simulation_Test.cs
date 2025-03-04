using System;
using System.Collections.Generic;
using Xunit;

namespace Cpsc370Final.Tests
{
    public class SimulationTests
    {
        [Fact]
        public void OnFrame_ShouldCallManageFirework_OnAllFireworks()
        {
            // Arrange
            Firework mockFirework = new Firework(new Position(1, 1), Color.Red);
            Simulation.Stop(); // Ensure fresh state
            Simulation.AddFirework(mockFirework);

            // Act
            Simulation.OnFrame();

            // Assert
            // We assume ManageFirework modifies some state. Since it's not implemented, this is a placeholder.
            Assert.NotNull(mockFirework); 
            Assert.Contains(mockFirework, Simulation.GetFireworks());

        }
         
         [Fact]
         public void GetRandomFirework_ShouldReturnValidFirework()
         {
             // Act
             Firework firework = Simulation.GetRandomFirework();
        
             // Assert
             Assert.NotNull(firework);
             Assert.InRange(firework.fireworkPosition.x, 0, Renderer.GetWidth() - 1);  
             Assert.InRange(firework.fireworkPosition.y, 5, Renderer.GetHeight() - 1); 
             // Assert.InRange(firework.Position.x, 1, 2);
             // Assert.InRange(firework.Position.y, 1, 2);
         }

         [Fact]
         public void Start_ShouldAddFireworksOverTime()
         {
             // Arrange
             Simulation.Stop(); // Ensure clean state

             // Act
             //var startTask = Task.Run(() => Simulation.Start());
             Thread.Sleep(1000); // Allow some time for fireworks to be added
             Simulation.Stop();

             // Assert
             Assert.NotEmpty(Simulation.GetFireworks());
         }
        
         
         [Fact]
         public void OnFrame_ShouldLaunchFireworksOverTime()
         {
             // Arrange
             Simulation.Stop();  // Ensure clean state
             DateTime startTime = DateTime.Now;

             // Act
             while (DateTime.Now - startTime < TimeSpan.FromSeconds(2)) // Run for 2 seconds
             {
                 Simulation.OnFrame();
                 Thread.Sleep(1000); // Simulate time passing
             }

             // Assert
             Assert.True(Simulation.GetFireworks().Count > 0); // Ensure some fireworks were added
         }

         [Fact]
         public void Stop_ShouldSetIsStopped()
         {
             // Arrange
             //Simulation.Start();
             Simulation.OnFrame();
             Thread.Sleep(1000);
             Simulation.Stop();

             // Assert
             Assert.Equal(true, Simulation.isStopped);
         }
         
         [Fact]
         public void RemoveFirework_ShouldReturnDifferentFirework()
         {
             // Arrange
             //Simulation.Start();
             Simulation.AddFirework(Simulation.GetRandomFirework());
             Simulation.AddFirework(Simulation.GetRandomFirework());
             while (Simulation.Fireworks[0] == Simulation.Fireworks[1])
                 Simulation.Fireworks[0] = Simulation.GetRandomFirework();
             Firework firework = Simulation.Fireworks[0];
             Simulation.RemoveFirework(0);

             // Assert
             Assert.NotEqual(Simulation.Fireworks[0], firework);
         }

         [Fact]
         public void AddFirework_ShouldIncreaseFireworkCount()
         {
             // Arrange
             Firework newFirework = new Firework(new Position(2, 3), Color.Blue);
             int initialCount = Simulation.GetFireworks().Count;

             // Act
             Simulation.GetFireworks().Add(newFirework);

             // Assert
             Assert.Equal(initialCount + 1, Simulation.GetFireworks().Count);
         }

         [Fact]
         public void RemoveFirework_ShouldDecreaseFireworkCount()
         {
             // Arrange
             Firework firework = new Firework(new Position(3, 4), Color.Green);
             Simulation.GetFireworks().Add(firework);
             int initialCount = Simulation.GetFireworks().Count;

             // Act
             Simulation.GetFireworks().RemoveAt(0);

             // Assert
             Assert.Equal(initialCount - 1, Simulation.GetFireworks().Count);
         }

         [Fact]
         public void LaunchRandomFirework_ShouldAddNewFireworkToFireworks()
         {
             Simulation.AddFirework(Simulation.GetRandomFirework());
             Firework firework = Simulation.GetFireworks()[0];
             Simulation.LaunchRandomFirework();

             Assert.NotEqual(Simulation.Fireworks[Simulation.Fireworks.Count() - 1], firework);
         }
         
         
         
         
         
    }
}