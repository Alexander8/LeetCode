public class Solution 
{
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
    {
        var arr = new []
        {
            p1.Select(x => (long)x).ToArray(),
            p2.Select(x => (long)x).ToArray(),
            p3.Select(x => (long)x).ToArray(),
            p4.Select(x => (long)x).ToArray()
        };

        var idx = new int[] { 0, 1, 2, 3 };

        do
        {
            if (IsValidSquare(arr[idx[0]], arr[idx[1]], arr[idx[2]], arr[idx[3]]))
                return true;
        }
        while (NextPermutation(idx));

        return false;
    }

    private static bool IsValidSquare(long[] p1, long[] p2, long[] p3, long[] p4)
    {
        var len1 = GetLen2(p2, p1);        
        var len2 = GetLen2(p3, p2);

        if (len1 == 0 || len2 == 0 || len2 != len1) return false;

        var len3 = GetLen2(p4, p3);

        if (len3 == 0 || len3 != len2) return false;

        var len4 = GetLen2(p1, p4);

        if (len4 == 0 || len4 != len3) return false;

        if (!Is90Deg(p1, p2, p3) || !Is90Deg(p2, p3, p4) || !Is90Deg(p3, p4, p1) || !Is90Deg(p4, p1, p2))
            return false;

        return true;
    }

    private static long GetLen2(long[] p1, long[] p2)
    {
        return (p2[0] - p1[0]) * (p2[0] - p1[0]) + (p2[1] - p1[1]) * (p2[1] - p1[1]);
    }

    private static bool Is90Deg(long[] p1, long[] p2, long[] p3)
    {
        var p1p2x = p1[0] - p2[0];
        var p1p2y = p1[1] - p2[1];

        var p3p2x = p3[0] - p2[0];
        var p3p2y = p3[1] - p2[1];

        return p1p2x * p3p2x + p1p2y * p3p2y == 0;
    }

    // https://ru.wikibooks.org/wiki/%D0%A0%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D0%B8_%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%9D%D0%B0%D1%80%D0%B0%D0%B9%D0%B0%D0%BD%D1%8B#C#
    private static bool NextPermutation(int[] sequence)
    {
        var i = sequence.Length;

        do
        {
            if (i < 2)
                return false;
            --i;
        }
        while (sequence[i - 1] >= sequence[i]);

        var j = sequence.Length;

        while (i < j && sequence[i - 1] >= sequence[--j]);

        SwapItems(sequence, i - 1, j);

        j = sequence.Length;
        while (i < --j)
            SwapItems(sequence, i++, j);

        return true;
    }

    private static void SwapItems(int[] sequence, int i, int j)
    {
        var item = sequence[i];
        sequence[i] = sequence[j];
        sequence[j] = item;
    }
}