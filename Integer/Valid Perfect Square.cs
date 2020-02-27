public class Solution 
{
    public bool IsPerfectSquare(int num) 
    {
        long left = 1;
        long right = int.MaxValue;

        while (left <= right)
        {
            long m = left + (right - left) / 2;
            long res = m * m;
            if (res == num) return true;

            if (res > num) right = m - 1;
            else left = m + 1;
        }

        return false;
    }
}