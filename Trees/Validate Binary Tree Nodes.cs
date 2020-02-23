public class Solution 
{
    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild) 
    {
        var q = new Queue<int>();
        var visited = new HashSet<int>();
        var cnt = 0;
        
        q.Enqueue(0);
        visited.Add(0);
        
        while (q.Count > 0)
        {
            var node = q.Dequeue();
            ++cnt;
            
            var childs = new[] { leftChild[node], rightChild[node] };
            
            foreach (var child in childs)
            {
                if (child == -1) { ++cnt; continue; }

                if (!visited.Add(child))
                    return false;
                
                q.Enqueue(child);
            }
        }
        
        return cnt == 1 + leftChild.Length + rightChild.Length;
    }
}