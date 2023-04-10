# Task 3 - Part 1 : Totoshka - The dog who can smell BOMBS!


## Step 1: Define arrays for directions and function for checking safe cells


Define two arrays, dr and dc, to represent the directions that Totoshka can move. These arrays define the eight possible directions that Totoshka can move in the minefield: up, up-right, right, down-right, down, down-left, left, and up-left.


## Step 2: Define the IsSafe function

Define a function IsSafe(minefield, n, m, row, col) that checks if a given field is safe for Totoshka to move to. The function should return True if the field is within the bounds of the minefield and doesn't contain a bomb (i.e., minefield[row][col] == 0), and False otherwise.




## Step 3: Define the BFS Funtion 

Define a function BFS(minefield, n, m) that performs a BFS search to find a safe path for Totoshka. The function should return a list of tuples (row, col) 






## Step 4: Empty Queue Inside BFS 

In the BFS function, create an empty queue and add all safe fields in the first row of the minefield to the queue.




## Step 5: Queue Mechanism 

While the queue is not empty, remove the first element from the queue and store its row, column, and path in variables.


## Step 6: There is No SIDE EXIT 

If the current field is in the last row of the minefield, return the path.



## Step 7: Adjacent Field Check 

Otherwise, iterate over the 8 adjacent fields and check if each one is safe. If it is, add it to the queue with a new path that includes the current field.


## Step 8: Define Direction Arrays

If no safe path is found, return 'No Safe Path Founded".