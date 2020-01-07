public class Solution 
{
    public int MinDominoRotations(int[] A, int[] B) 
    {
        var a = A[0];
        var b = B[0];

        var exclusiveOption = 0;      
        var cnt1 = 0;
        var cnt2 = 0;
        var equalsCnt = 0;

        for (var i = 1; i < A.Length; ++i)
        {
            if (A[i] == B[i] && a != b)
            {
                if (A[i] == a) exclusiveOption = 1;
                if (B[i] == b) exclusiveOption = 2;

                ++equalsCnt;
            }

            if (A[i] != a && cnt1 != -1)
            {
                if (B[i] == a) ++cnt1;
                else cnt1 = -1;
            }

            if (B[i] != b && cnt2 != -1)
            {
                if (A[i] == b) ++cnt2;
                else cnt2 = -1;                    
            }

            if (cnt1 == -1 && cnt2 == -1) return -1;
        }

        if (cnt1 != -1) cnt1 = Math.Min(cnt1, A.Length - cnt1 - equalsCnt);
        if (cnt2 != -1) cnt2 = Math.Min(cnt2, A.Length - cnt2 - equalsCnt);

        if (exclusiveOption == 1) return cnt1;      
        if (exclusiveOption == 2) return cnt2;

        if (cnt1 == -1) return cnt2;
        if (cnt2 == -1) return cnt1;

        return Math.Min(cnt1, cnt2);
    }
}