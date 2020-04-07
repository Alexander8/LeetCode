public class Solution 
{
    public int MaxSumTwoNoOverlap(int[] A, int L, int M)
    {
        var ps = new int[A.Length];
        ps[0] = A[0];

        for (var i = 1; i < A.Length; ++i)
            ps[i] = A[i] + ps[i - 1];

        var sum = 0;
        var j = 0;

        while (j + L - 1 < A.Length)
        {
            var sumL = ps[j + L - 1] - (j - 1 >= 0 ? ps[j - 1] : 0);

            var sumM = 0;

            var k = 0;

            while (k + M - 1 < j)
            {
                sumM = Math.Max(sumM, ps[k + M - 1] - (k - 1 >= 0 ? ps[k - 1] : 0));
                ++k;
            }

            k = j + L;

            while (k + M - 1 < A.Length)
            {
                sumM = Math.Max(sumM, ps[k + M - 1] - (k - 1 >= 0 ? ps[k - 1] : 0));
                ++k;
            }

            sum = Math.Max(sum, sumL + sumM);

            ++j;
        }

        return sum;
    }
}