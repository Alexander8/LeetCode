public class Solution 
{
    public int[] FindOrder(int numCourses, int[][] prerequisites) 
    {
        var res = new List<int>(numCourses);
        var courses = new int[numCourses];
        var map = new Dictionary<int, List<int>>();
        
        foreach (var p in prerequisites)
        {
            if (!map.TryGetValue(p[1], out var list))
            {
                list = new List<int>();
                map.Add(p[1], list);
            }
            
            list.Add(p[0]);
        }
        
        for (var i = 0; i < numCourses; ++i)
        {
            if (!Explore(courses, i, map, res))
                return new int[0];
        }
        
        return res.ToArray();
    }
    
    private static bool Explore(
        int[] courses, 
        int i, 
        Dictionary<int, List<int>> prerequisites,
        List<int> res)
    {
        if (courses[i] == 2)
            return true;
        
        if (courses[i] == 1)
            return false;
        
        courses[i] = 1;
        
        if (prerequisites.TryGetValue(i, out var list))
        {
            foreach (var c in list)
            {
                if (!Explore(courses, c, prerequisites, res))
                    return false;
            }
        }
        
        courses[i] = 2;
        
        res.Insert(0, i);
        
        return true;
    }
}