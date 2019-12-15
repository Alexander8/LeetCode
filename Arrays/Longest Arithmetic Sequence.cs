public int LongestArithSeqLength(int[] A) 
{
    var len = 2;
    var dp = new Dictionary<int, int>[A.Length];

    for (var i = 0; i < A.Length; ++i)
    {
        dp[i] = new Dictionary<int, int>();
        
        for (var j = 0; j < i; ++j)
        {
            var diff = A[i] - A[j];
            var newLen = dp[j].ContainsKey(diff) ? dp[j][diff] + 1 : 2;
            
            dp[i][diff] = newLen;
            len = Math.Max(len, newLen);                    
        }
    }
    
    return len;        
}