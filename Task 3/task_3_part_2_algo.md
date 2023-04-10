
# Task 3 - Part 2 : Where Ally follows Totoshka


## Step 1: Define Direction Arrays

Define two arrays, `dr` and `dc`, to represent the directions that Totoshka can move. These arrays define the eight possible directions that Totoshka can move in the minefield: up, up-right, right, down-right, down, down-left, left, and up-left.

## Step 2: Define IsSafe Function

Define a function `IsSafe` that takes the minefield, its dimensions, and the row and column indices of a cell and returns `True` if the cell is safe and not visited. This function checks if a given cell is within the boundaries of the minefield, is safe to move into (i.e., contains no bomb), and has not been visited before.

## Step 3: Define BFS Function

Define a function `BFS` that takes the minefield and its dimensions and returns a list of cells that represent a safe path for Totoshka and Ally to pass through the minefield. This function will perform the breadth-first search algorithm to find a safe path for Totoshka and Ally to follow in the minefield.

## Step 4: Check for Safe Exit

Check if there exists a safe exit for Totoshka from the top row of the minefield by iterating over all cells in the top row and checking if there exists a safe neighbor for each cell. If there is no safe exit, return an empty list. This step checks if there exists at least one safe path from the top row of the minefield to the bottom row, so that Totoshka and Ally can exit safely. If there is no safe exit, there is no need to perform the BFS algorithm, and the function will immediately return an empty list.

## Step 5: Set Up Data Structures

Create a queue `queue` to store cells to be explored. For each safe cell in the top row, create a list `path` to store visited cells so far, and a set `visited` to store visited cells. This step sets up the `queue`, `path`, and `visited` data structures to perform the BFS algorithm.

## Step 6: Enqueue Safe Cells

Enqueue a tuple `(row, col, path, visited)` into the queue for each safe cell in the top row. This step starts the BFS algorithm by enqueuing all safe cells in the top row of the minefield.

## Step 7: Process Next Cell

While the queue is not empty, dequeue the first element from the queue and unpack it into `(row, col, path, visited)`. This step processes the next cell in the BFS algorithm by dequeuing it from the queue and unpacking its information into variables.

## Step 8: Check for Safe Exit

If the cell `(row, col)` is in the bottom row, return the `path` as the safe path. This step checks if the current cell is in the bottom row of the minefield. If it is, it means Totoshka has found a safe exit, and the function will return the `path` of visited cells.

## Step 9: Visit Safe Neighbors

Iterate over all neighbors of the cell (row, col). If a neighbor is safe, not visited, and not blocked by Ally, add it to visited and append it to path. Create a new tuple (newRow, newCol, newPath, newVisited) and enqueue it into the queue. This step visits all unvisited, safe neighbors of the current cell that Totoshka can move to. If a neighbor is safe, not visited, and not blocked by Ally, it will be added to the visited set and the path list, and a new tuple representing the next cell to be explored will be enqueued.

## Step 10: Backtrack

If all neighbors are already visited or blocked by Ally, backtrack by removing the last cell from path and visited, and enqueue a new tuple with the last cell. This step handles the case where Totoshka reaches a dead end and cannot backtrack because Ally is blocking the previous cell. It removes the last cell from the path and visited set, effectively undoing the previous move, and enqueues a new tuple representing the previous cell to be explored next.

## Step 11: Return None if No Safe Path Found

If the queue is empty and no safe path has been found, return None. This step handles the case where the BFS algorithm has explored all cells in the minefield but has not found a safe exit for Totoshka and Ally. In this case, the function will return None to indicate that there is no safe path.
