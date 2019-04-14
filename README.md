
# WHY WOULD YOU NOT JUST USE THE STANDARD LIBRARY

For the same reason you care about reversing linked lists: you are at a white board interview.

# Requirements

Draw a circle into a framebuffer using only integer math.

# Algorithm

[Midpoint circle algorithm](https://en.wikipedia.org/wiki/Midpoint_circle_algorithm)
https://en.wikipedia.org/wiki/Midpoint_circle_algorithm
The basic idea is you start at an easily calculable point (the top for example). You choose the next
point that is closest to the ideal circle. You continue in this way till you reach another easily
calculable point. The left side of the circle for example.

![](Circle.png)

# TODO

The program draws four segments simultaneously. It is possible to draw eighth.
