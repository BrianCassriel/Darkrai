Authors: Hemi Shah, Rhea John, Margo Burbank, Brian Cassriel, David Giani
Course: CPSC 370 

Sources: Console Rendering (https://github.com/NinovanderMark/ConsoleRenderer/tree/main)
Files: Cpsc370Final includes: Color.cs, Firework.cs, Particle.cs, Pixel.cs, Position.cs, Program.cs, README.txt, render.cs, 
Simulation.cs, Simulation.cs, velocity.cs
Cpsc370Final.Tests includes: Fireworks_Tests.cs, Particle_tests.cs, Pixeltests.cs, Renderertests.cs, Simulation_Tests.cs

Class Overviews: 

Color.cs
- color(enum): None, White, red, green, Blue, Yellow, Cyan, Magenta

Firework.cs
Variables
- FireworkPosition (Position): stores current position of the firework 
- IsExploded (bool): indicates if the firework has exploded
- centerParticleSymbol (char): user an asterisk to represent the center of the explosion 
- particles (List<Particle>): list of particles created during the explosion 
- particleColor (Color): defines color of particle 
Public methods
- ManageFirework: places center particle if explodes
- Launch: simulates launching firework, position is updates over time
- OnFrame: controls firework movement and explosion per frame
- DrawFirework: draws firework and particles if exploded
- Explode: triggers explotion and manages particles
Private Methods
- PlaceCenterParticle: place center within boundaries
- PlaceParticle(Position, char): places individual particles at specific position
- CreateParticles(): generates particles in circular arangement 

Particle.cs
Variables
particlePosition (Position): stores particles current position 
velocity (velocity): determines direction and speed of movement 
isFinished (bool): indicates if the particle has finished its lifespan 
particleSymbol (char): represents the character used to display the particle 
lifetime (float): determines how long the particle exists before disappearing
particleColor (Color): determines color of particle 
Public Methods
ManageParticle: updates the particle's position, renders it, and decreases its lifetime
Private Methods
MoveParticle: moves the particle based on its velocity 

Pixel.cs
Variables
symbol (char): represents the character used to display pixel 
color (Color): defines the color of pixel 
position (Position): stores the position of pixel on screen 

Position.cs
Variables
x (int): stores the x-coordinate of the position 
y (int): stores the y-coordinate of the position 

Program.cs
Variable
isRunning (bool): controls if main loop is running 
Public Method
Main: starts loop for the program 
Private methods
MainLoop: continuously updates simulation frame
ReadInput: quit if Q is pressed, launch firework if space is pressed 

Render.cs
Variables
framerate (int): controls the rendering speed 
canvas (ConsoleCcanvas): represents the drawing surface for rendering 
Public Methods
GetFrameRate: returns the frame delay 
OnFrame: clears and redraws the screen each frame, update simulation 
SetPixel: set pixel at x,y with specified symbol and color
ClearPixel: clears specific pixel 
SetPixels: sets multiple pixels 
ClearPixels: clears batch of pixels
Exit: clears console and exits rendering 
GetWidth: returns width of console canvas 
GetHeight: returns height of console canvas 
GetConsoleColor: converts the custom color into console color for rendering 

Simulation.cs
Variables
Fireworks(List<Firework>): list of active fireworks in the simulation 
isStopped (bool): controls whether the simulation is currently stopped
LastFireworkDate (DateTime): stores last time firework was launched
Public Methods
OnFrame: updates and animates all active fireworks
TryLaunchRandomFirework: launch new firework based on randomized time threshold 
LaunchRandomFirework: launch randomly placed firework when space is pressed
Stop: stops simulation from running 
Private Methods
AddFirework: adds new firework to active list 
RemoveFirework: removes firework from line if exists
getFirework: returns specific firework by index 
GetFireworks: returns full list of active fireworks
GetRandomFirework: create firework at random position and color 

Velocity.cs
x (int): represents horizontal speed 
y (int): represents verticle 

