public class Solution 
{
    public int CountArrangement(int N) 
    {
        var numbers = new List<int>(N);
        for (var i = 0; i < N; ++i)
            numbers.Add(i + 1);
        
        return CountArrangement(numbers, 0);
    }
    
    private static int CountArrangement(List<int> numbers, int i)
    {
        if (numbers.Count == 0)
        {
            return 1;
        }
        
        var cnt = 0;
        
        for (var j = 0; j < numbers.Count; ++j)
        {
            var number = numbers[j];
            
            if ((i + 1) % number == 0 || number % (i + 1) == 0)
            {
                numbers.RemoveAt(j);
                cnt += CountArrangement(numbers, i + 1);
                numbers.Insert(j, number);
            }
        }
        
        return cnt;
    }
}