public class Solution 
{
    public IList<IList<int>> Combine(int n, int k) 
    {
        var res = new List<IList<int>>();

        Combine(res, new List<int>(), n, k, 1, 0);

        return res;
    }

    private static void Combine(List<IList<int>> res, List<int> current, int n, int k, int start, int pos)
    {
        if (pos == k)
        {
            res.Add(new List<int>(current));
            return;
        }

        for (var num = start; num <= n; ++num)
        {
            current.Add(num);
            Combine(res, current, n, k, num + 1, pos + 1);
            current.RemoveAt(current.Count - 1);
        }
    }
}