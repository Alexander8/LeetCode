public class Solution 
{
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) 
    {
        var cnt = 0;
        var keySet = new HashSet<int>();      
        var q = new SortedList<int, List<int>>();

        q.Add(1, new List<int>());
        q.Add(0, new List<int>());       

        foreach (var b in initialBoxes)
            q[1].Add(b);

        while (true)
        {
            int box = -1;

            if (q[1].Count > 0) 
            { 
                box = q[1][0]; 
                q[1].RemoveAt(0); 
            }
            else 
            {
                var idx = 0;
                while (idx < q[0].Count)
                {
                    if (keySet.Contains(q[0][idx]))
                    {
                        q[1].Add(q[0][idx]);
                        q[0].RemoveAt(idx); 
                    }
                    else
                    {
                        ++idx;
                    }
                }

                if (q[1].Count > 0)
                {
                    box = q[1][0]; 
                    q[1].RemoveAt(0); 
                }
            }

            if (box == -1)
                break;

            cnt += candies[box];

            keySet.UnionWith(keys[box]);                     

            foreach (var cb in containedBoxes[box])
            {                
                if (status[cb] == 1 || keySet.Contains(cb))
                {
                    q[1].Add(cb);
                }               
                else
                {
                    q[0].Add(cb);
                }
            }
        }

        return cnt;
    }
}