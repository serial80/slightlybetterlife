"# slightlybetterlife" 

Improvements made:
- The code now works and returns the correct next state of the world for the sample input, for one iteration
- Improved the input parsing, using functions and List.map instead of nested iteration
- Split the evolve method into two parts for readability
- Added some basic logging

Limitations:
- The world cannot grow so this initial state won't be completely represented after a few iterations.

Further improvements
- Use functional paradigm to generate the text output from the 2d array
- The evolve method could be made to use more F# style code with List.map, however how to do this on a 2D array wasn't
immediately obvious to me
- Also the evolveCell method could be improved to use match..with instead of chained if/else
- The approach to evolving the world is still quite imperative overall.   After some research I discovered the method of 
  representing the world as a list of points (i.e. x,y coordinates), where each point in the list is an alive cell, and 
  all others are dead.  This allows various functions to be applied to the list to generate ultimately the new world, 
  which can grow to a size only bounded by the memory of the process or by Int.MaxValue.
- The functions would include things like:
  - Generate list of neighbours of a point
  - Count live neighbours of a point
  - Determine if cell dies, survives, or becomes alive

