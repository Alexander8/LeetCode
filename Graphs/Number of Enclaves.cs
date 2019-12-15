public class Solution 
{
    public int NumEnclaves(int[][] A) 
    {
        var visited = new HashSet<(int X, int Y)>();
        var square = 0;

        for (var i = 0; i < A.Length; ++i)
        {
            for (var j = 0; j < A[i].Length; ++j)
            {
                if (A[i][j] == 1 && !visited.Contains((i , j)))
                {
                    square += GetIslandSquare(A, i, j, visited);
                }
            }
        }

        return square;
    }

    private static int GetIslandSquare(int[][] A, int r, int c, HashSet<(int R, int C)> visited)
    {
        var square = 0;

        var q = new Queue<(int R, int C)>();
        q.Enqueue((r, c));
        visited.Add((r, c));

        var atBoundary = false;

        while (q.Count > 0)
        {
            var p = q.Dequeue();
            if (p.C == 0 || p.R == 0 || p.C == A[p.R].Length - 1 || p.R == A.Length - 1)
                atBoundary = true;

            ++square;

            foreach (var n in GetNeighbors(A, p))            
            {
                if (A[n.R][n.C] == 1 && !visited.Contains(n))
                {
                    visited.Add(n);
                    q.Enqueue(n);
                }
            }
        }

        return atBoundary ? 0 : square;
    }

    private static List<(int R, int C)> GetNeighbors(int[][] A, (int R, int C) p)
    {
        var res = new List<(int X, int Y)>();

        if (p.R + 1 < A.Length)
            res.Add((p.R + 1, p.C));

        if (p.R - 1 >= 0)
            res.Add((p.R - 1, p.C));

        if (p.C + 1 < A[p.R].Length)
            res.Add((p.R, p.C + 1));

        if (p.C - 1 >= 0)
            res.Add((p.R, p.C - 1));

        return res;
    }
}