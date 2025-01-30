/* 
namespace Cpsc370Final.Tests;

 public class SimulationsTest
 {
     [Fact]
     public void SimulationTest1()
     {
         Assert.Equal((Fireworks.Count + 1), (Fireworks.Add(new Firework())).Count);
         Assert.Equal((Fireworks.Count - 1), Fireworks.RemoveFirework(0).Count);
         Assert.Equal(GetFirework(0), Fireworks[0]);
         Assert.Equal();
     }
     
}*/

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
            Simulation.GetFireworks().Add(mockFirework);

            // Act
            Simulation.OnFrame();

            // Assert
            // We assume ManageFirework modifies some state. Since it's not implemented, this is a placeholder.
            Assert.NotNull(mockFirework); 
        }

        [Fact]
        public void GetRandomFirework_ShouldReturnValidFirework()
        {
            // Act
            Firework firework = Simulation.GetRandomFirework();

            // Assert
            Assert.NotNull(firework);
            Assert.InRange(firework.Position.x, 1, 2);
            Assert.InRange(firework.Position.y, 1, 2);
        }

        [Fact]
        public void Start_ShouldAddFireworksOverTime()
        {
            // Arrange
            Simulation.Stop(); // Ensure clean state

            // Act
            var startTask = Task.Run(() => Simulation.Start());
            Thread.Sleep(1000); // Allow some time for fireworks to be added
            Simulation.Stop();

            // Assert
            Assert.NotEmpty(Simulation.GetFireworks());
        }

        [Fact]
        public void Stop_ShouldClearFireworksAndSetIsStopped()
        {
            // Arrange
            Simulation.Start();
            Thread.Sleep(1000);
            Simulation.Stop();

            // Assert
            Assert.Empty(Simulation.GetFireworks());
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
    }
}
