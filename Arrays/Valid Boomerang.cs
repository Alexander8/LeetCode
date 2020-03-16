public class Solution 
{
    public bool IsBoomerang(int[][] points)
    {
        if (points.Length != 3) return false;

        if (
            points[0][0] == points[1][0] && points[0][1] == points[1][1]
            ||
            points[0][0] == points[2][0] && points[0][1] == points[2][1]
            ||
            points[1][0] == points[2][0] && points[1][1] == points[2][1]
        )
        {
            return false;
        }

        var (a1, b1, c1) = GetLine(points[0], points[1]);
        var (a2, b2, c2) = GetLine(points[0], points[2]);

        return Math.Abs(a1 - a2) >= double.Epsilon || Math.Abs(b1 - b2) >= double.Epsilon || Math.Abs(c1 - c2) >= double.Epsilon;
    }

    private static (double a, double b, double c) GetLine(int[] p1, int[] p2)
    {
        if (p1[0] != p2[0])
        {
            var k = (double)(p1[1] - p2[1]) / (p1[0] - p2[0]);
            var b = p1[1] - k * p1[0];

            return (k, -1.0, b);
        }
        else
        {
            return (1.0, 0.0, p1[0]);
        }
    }
}