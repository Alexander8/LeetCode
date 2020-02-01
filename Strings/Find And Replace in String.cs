public class Solution 
{
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) 
    {
        var sb = new StringBuilder(S);
        var shift = 0;
        
        var idxCopy = new int[indexes.Length];
        Array.Copy(indexes, idxCopy, idxCopy.Length);

        Array.Sort(indexes, sources);
        Array.Sort(idxCopy, targets);
        
        for (var i = 0; i < indexes.Length; ++i)
        {
            if (string.CompareOrdinal(S, indexes[i], sources[i], 0, sources[i].Length) != 0)
                continue;
            
            sb.Remove(indexes[i] + shift, sources[i].Length);
            sb.Insert(indexes[i] + shift, targets[i]);
            
            shift += targets[i].Length - sources[i].Length;
        }
        
        return sb.ToString();
    }
}