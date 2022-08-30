## Abstract :

In this project, we solve one of Arkose Labs hard captcha images with an accuracy of about 85% without using advanced artificial intelligence (AI) libraries and simply by building a very simple and basic AI. **(For Research Purposes Only)**

## Process :
To solve the maze, first we divide the image into 6 parts, and each part is sent separately for solution, then using the **"ImageCleanerANDFindTargets"** function from the **"ImageHelper"** class, we first remove the image noises, then we change the color of the image to black and white (wall in black and the background in white (then using the original photo, find the density of gray and yellow pixels (which includes our two targets, mouse and cheese). By removing the noise pixels, we find the center of both targets and then mark them with red and blue colors. Then, by sending the obtained photo to the **"MazeSolver"** class (which uses the Breadth-first search algorithm to solve the maze) and giving black colors to detect the wall and, red and blue colors to detect the start and end of the maze, it finds the path and finally, the image will be solved by drawing the path found using a linkedlist. At the end, the 6 parts of the image that were separated are connected again.


### Example : 
![Example image](/Example.jpg)
