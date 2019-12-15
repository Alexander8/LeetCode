public int MinFlips(int[][] mat) 
{
    var q = new Queue<int[][]>();
    q.Enqueue(mat);
    
    var visited = new HashSet<string>();
    visited.Add(Serialize(mat));
    
    var steps = 0;
    
    while (q.Count > 0)
    {
        var lTmp = new List<int[][]>();
        
        while (q.Count > 0)
        {
            var m = q.Dequeue();
            
            if (IsZero(m)) return steps;
            
            var neighbors = GetNeighbors(m, visited);
            
            lTmp.AddRange(neighbors);
        }
        
        foreach (var n in lTmp)
            q.Enqueue(n);
        
        ++steps;
    }
    
    return -1;
}

private List<int[][]> GetNeighbors(int[][] mat, HashSet<string> visited)
{
    var res = new List<int[][]>();
    
    for (var i = 0; i < mat.Length; ++i)
    {
        for (var j = 0; j < mat[i].Length; ++j)
        {
            var copy = Copy(mat);
            
            copy[i][j] = mat[i][j] == 1 ? 0 : 1;
            
            if (i - 1 >= 0) copy[i - 1][j] = mat[i - 1][j] == 1 ? 0 : 1;
            if (j - 1 >= 0) copy[i][j - 1] = mat[i][j - 1] == 1 ? 0 : 1;
            if (i + 1 < copy.Length) copy[i + 1][j] = mat[i + 1][j] == 1 ? 0 : 1;
            if (j + 1 < copy[i].Length) copy[i][j + 1] = mat[i][j + 1] == 1 ? 0 : 1;
            
            var serialized = Serialize(copy);
            
            if (!visited.Contains(serialized))
            {
                visited.Add(serialized);
                res.Add(copy);
            }
        }
    }
    
    return res;
}

private static bool IsZero(int[][] mat)
{
    for (var i = 0; i < mat.Length; ++i)
        for (var j = 0; j < mat[i].Length; ++j)
            if (mat[i][j] != 0) return false;
    
    return true;
}

private static string Serialize(int[][] mat)
{
    var sb = new StringBuilder(9);
    
    for (var i = 0; i < mat.Length; ++i)
        for (var j = 0; j < mat[i].Length; ++j)
            sb.Append(mat[i][j]);
    
    return sb.ToString();
}

private static int[][] Copy(int[][] mat)
{
    var copy = new int[mat.Length][];
    
    for (var i = 0; i < mat.Length; ++i)
    {
        copy[i] = new int[mat[i].Length];
        
        for (var j = 0; j < mat[i].Length; ++j)
            copy[i][j] = mat[i][j];
    }
    
    return copy;
}