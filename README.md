"# slightlybetterlife" 

Improvements made:
- The code now works and returns the correct next state of the world for the sample input
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
- The approach to evolving the world is still quite imperative overall.  I think that with more time it'd be possible
to design a set of functions which take a world and project each cell onto a new world with it's new value, maybe
even running the evolution of all cells in parallel somehow. My rudimentary F# knowledge is not sufficient to do this
in time however!
