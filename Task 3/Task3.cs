using System;
using System.Collections.Generic;


    public class Task3
    {

        static int[] dr = { -1, -1, 0, 1, 1, 1, 0, -1 };
        static int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };

        public static bool IsSafe(int[][] minefield, int n, int m, int row, int col)
        {
            if (row < 0 || row >= n || col < 0 || col >= m || minefield[row][col] != 0)
            {
                return false;
            }

            return true;
        }

        public static List<(int, int)> BFS(int[][] minefield, int n, int m)
        {
            // Early exit check
            bool safeExitExists = false;
            for (int i = 0; i < m; i++)
            {
                if (minefield[n - 1][i] == 0)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        int newRow = n - 1 + dr[j];
                        int newCol = i + dc[j];
                        if (IsSafe(minefield, n, m, newRow, newCol))
                        {
                            safeExitExists = true;
                            break;
                        }
                    }
                }
                if (safeExitExists)
                {
                    break;
                }
            }
            if (!safeExitExists)
            {
                return new List<(int, int)>();
            }

            // BFS search
            Queue<(int, int, List<(int, int)>, HashSet<(int, int)>)> queue = new Queue<(int, int, List<(int, int)>, HashSet<(int, int)>)>();

            for (int i = 0; i < m; i++)
            {
                if (minefield[0][i] == 0)
                {
                    List<(int, int)> path = new List<(int, int)>();
                    path.Add((0, i));
                    HashSet<(int, int)> visited = new HashSet<(int, int)>();
                    visited.Add((0, i));
                    queue.Enqueue((0, i, path, visited));
                }
            }

            while (queue.Count > 0)
            {
                var (row, col, path, visited) = queue.Dequeue();

                if (row == n - 1)
                {
                    return path;
                }

                for (int i = 0; i < 8; i++)
                {
                    int newRow = row + dr[i];
                    int newCol = col + dc[i];

                    if (IsSafe(minefield, n, m, newRow, newCol) && !visited.Contains((newRow, newCol)))
                    {
                        List<(int, int)> newPath = new List<(int, int)>(path);
                        newPath.Add((newRow, newCol));
                        HashSet<(int, int)> newVisited = new HashSet<(int, int)>(visited);
                        newVisited.Add((newRow, newCol));
                        queue.Enqueue((newRow, newCol, newPath, newVisited));
                    }
                }
            }

            return null;
        }

        public static void Main()
        {
            int n = 6;
            int m = 6;
            int[][] minefield = new int[][] {
            new int[] {0, 1, 0, 1, 0, 0},
            new int[] {0, 1, 0, 1, 0, 1},
            new int[] {0, 0, 0, 0, 0, 0},
            new int[] {1, 1, 1, 1, 1, 0},
            new int[] {0, 0, 0, 0, 0, 1},
            new int[] {0, 1, 1, 1, 1, 1}
        };

            List<(int, int)> path = BFS(minefield, n, m);

            if (path != null)
            {
                Console.WriteLine("Safe path found:");
                foreach (var (row, col) in path)
                {
                    Console.WriteLine($"({row}, {col})");
                }
            }
            else
            {
                Console.WriteLine("No safe path found.");
            }
        }
    }




