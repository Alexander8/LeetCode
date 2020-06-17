public class Solution 
{
    public void Solve(char[][] board) 
    {
        var boardCopy = new char[board.Length][];
        for (var i = 0; i < board.Length; ++i)
        {
            boardCopy[i] = new char[board[i].Length];
            Array.Copy(board[i], boardCopy[i], boardCopy[i].Length);
        }
        
        var visited = new HashSet<(int, int)>();
        var visitedCopy = new HashSet<(int, int)>();
        
        for (var i = 0; i < board.Length; ++i)
        {
            for (var j = 0; j < board[i].Length; ++j)
            {
                if (boardCopy[i][j] == 'O' && !visitedCopy.Contains((i, j)))
                    if (Explore(boardCopy, i, j, visitedCopy, false))
                        Explore(board, i, j, visited, true);
            }
        }
    }
    
    private static bool Explore(char[][] board, int r, int c, HashSet<(int, int)> visited, bool flip)
    {
        var q = new Queue<(int r, int c)>();
        q.Enqueue((r, c));
        visited.Add((r, c));

        var result = true;

        while (q.Count > 0)
        {
            var point = q.Dequeue();
            if (point.r == 0 || point.r == board.Length - 1 || point.c == 0 || point.c == board[r].Length - 1)
                result = false;

            if (flip)
                board[point.r][point.c] = 'X';

            foreach (var dir in Dirs)
            {
                var newR = point.r + dir[0];
                var newC = point.c + dir[1];

                if (newR < 0 || newR == board.Length || newC < 0 || newC == board[newR].Length)
                    continue;

                if (board[newR][newC] == 'O' && visited.Add((newR, newC)))
                    q.Enqueue((newR, newC));
            }
        }

        return result;
    }
    
    private static int[][] Dirs = new int[][]
    {
        new[] {0, 1},
        new[] {1, 0},
        new[] {0, -1},
        new[] {-1, 0}
    };
}