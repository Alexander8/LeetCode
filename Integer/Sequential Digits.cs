public class Solution 
{
    public IList<int> SequentialDigits(int low, int high) 
    {
        var res = new List<int>();
        var i = 12;
        var first = 1;
        var deg = 1;

        while (i <= high)
        {
            if (i >= low)
            {
                res.Add(i);
            }

            var end = i % 10;
            if (end == 9) { ++deg; first = 1; }
            else ++first;

            var tmp = 0;
            for (int j = deg, k = first; j >= 0; --j, ++k)
            {
                tmp += k * (int)Math.Pow(10, j);
                ++end;
            }

            i = tmp;
        }

        return res;
    }
}