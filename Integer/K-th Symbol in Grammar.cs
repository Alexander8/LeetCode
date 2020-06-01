public class Solution 
{
    public int KthGrammar(int N, int K) 
    {
        if (N == 1) return 0;

        var charsCnt = (int)Math.Pow(2, N - 1);

        while (N > 2)
        {
            var secondHalf = K - 1 >= charsCnt / 2;

            if (secondHalf)
            {
                K -= charsCnt / 2;
                if (K % 2 == 1)
                    ++K;
                else
                    --K;
            }

            charsCnt /= 2;            
            --N;
        }

        return K == 1 ? 0 : 1;
    }
}