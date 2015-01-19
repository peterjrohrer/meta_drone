# meta_drone

## What's It Do?

meta_drone lets one control an AR.Drone 2.0 with Meta SpaceGlasses, an augmented reality headset.

## How Do I Control It?

Everything should be visible through a HUD on the screen.

### Altitude

The drone's altitude is controlled by the y position of one's right hand. Raising one's hand will make the drone rise, and dropping one's hand will let it descend. 

### Yaw

The yaw, or rotation, of the drone is controlled by the x position of one's hand. Moving one's hand to the right will make the drone rotate clockwise. Moving one's hand to the left will do the opposite.

### Pitch

Pitch, or forwards movement, is controlled by the y position of one's left hand. Raising one's hand will make the drone move forwards, and dropping one's hand will move it backwards.

### Landing

Landing, at the moment, is triggered when one makes a tight fist with both hands. Unfortunately, the tightness of one's hand often varies. Sometimes, the drone may not land. To land in an emergency, hit `Ctrl-C` in the command line.

### Dead Zones

If you'd like the drone to not move, leave your hands in the middle of the axis related to your control. For instance, to stop the drone from changing altitude, leave your right hand in the middle of the y axis. 

## Using This

To run the program, one will need an AR.Drone 2.0, Meta Glasses, and a computer. First, connect to the drone's wifi after powering the drone on. Run `game.exe` file in the `game` folder after plugging in and connecting the Meta Glasses. Then, once the GUI is visible, run the `main.js` file located in the `wss` directory. The drone should start to rise. Once it has taken off, you should be able to control the drone!

## In Action

A video of the drone in action can be seen [here](https://www.youtube.com/watch?v=8wBbOGdQtEM).

Made by [Matthew Kaufer](http://github.com/mjkaufer), [Peter Rohrer](http://github.com/peterjrohrer), [Tarun Punnoose](http://github.com/tpunnoose), [Rohan Punnoose](http://github.com/rpunnoose), and [Sam Rohrer](http://github.com/srohrer32) at MHacks V. Winner of Best Virtual Reality hack.



[More information available here](http://www.srohrer.me/meta_drone)
