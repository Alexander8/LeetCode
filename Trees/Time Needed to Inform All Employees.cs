public class Solution 
{
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) 
    {
        var times = new Dictionary<int, int>();
        var mapMngr = new Dictionary<int, List<int>>();

        for (var i = 0; i < manager.Length; ++i)
        {
            if (!mapMngr.TryGetValue(manager[i], out var lst))
            {
                lst = new List<int>();
                mapMngr.Add(manager[i], lst);
            }

            lst.Add(i);
        }

        return Walk(headID, mapMngr, informTime);
    }

    private static int Walk(int headID, Dictionary<int, List<int>> mapMngr, int[] informTime)
    {
        if (!mapMngr.ContainsKey(headID)) return 0;

        var time = 0;

        foreach (var m in mapMngr[headID])
        {
            time = Math.Max(time, informTime[headID] + Walk(m, mapMngr, informTime));
        }

        return time;
    }
}