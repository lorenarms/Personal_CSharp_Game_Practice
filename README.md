<h1>C# Maze Game</h1>
<h2>Creating a maze game in C#</h2>
<p>
This series of apps was done while following the tutorial located  <a href="https://www.youtube.com/watch?v=T0MpWTbwseg">here</a>. I really wanted to see what could be done in the console with C# regarding interactivity and menus. This tutorial gave me a good starting point for the basics, but I found a few shortcomings in the engine itself, so I added my own improvements in later iterations. 

One such improvement was how the menu and map both flashed on the screen when a key was pressed. This was due to the entire menu/map having to be redrawn to refresh the options/world. I didn't like this, so I created an algorithm for both that would remove the need for an entire refresh, and instead only redraw what needed to be redrawn, leaving the rest of the screen static. This, in my opinion, was a great improvement, as the constant flashing could make your eyes tired over time. The menu logic I created was eventually made into it's own 'utility' method that I use whenever I create a console app. The method can be injected into any C# console app and used to create an arrow-controlled menu anywhere on screen to be used with a simple switch statement.

Another improvement I added was the ability to pick up objects by walking over them in the maze. This was done very rudementarily, and the full implementation is not present in any of the application iterations, but the basic logic is there to collect items in the maze for points.

I also implemented an 'enemy' character that would use very simple logic to follow the player around the maze, and if the player was caught, would end the game. This was inspired by one of my favorite games growing up, <a href="https://www.youtube.com/watch?v=9Lodc0kFYuo">Wizard of Wor</a>. I of course played the Bally Astrocade version, but the idea was the same. In order to make this work in my game, I had to use multi-threading within the app so that enemy updates were independent of player updates, making the enemy chase the player even if the player was standing still.
</p>
