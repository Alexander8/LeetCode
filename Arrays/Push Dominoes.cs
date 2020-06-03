public class Solution
{
    public string PushDominoes(string dominoes)
    {
        var sb = new StringBuilder(dominoes.Length);
        var map = new (int rightPressure, int leftPressure)[dominoes.Length];

        for (var i = 0; i < dominoes.Length; ++i)
        {
            if (dominoes[i] == 'R')
                map[i] = (int.MaxValue, 0);
            else if (dominoes[i] != 'L' && i - 1 >= 0 && map[i - 1].rightPressure != 0)
                map[i] = (map[i - 1].rightPressure - 1, map[i].leftPressure);
        }

        for (var i = dominoes.Length - 1; i >= 0; --i)
        {
            if (dominoes[i] == 'L')
                map[i] = (0, int.MaxValue);
            else if (dominoes[i] != 'R' && i + 1 < dominoes.Length && map[i + 1].leftPressure != 0)
                map[i] = (map[i].rightPressure, map[i + 1].leftPressure - 1);
        }

        foreach (var item in map)
        {
            if (item.rightPressure > item.leftPressure)
                sb.Append('R');
            else if (item.rightPressure < item.leftPressure)
                sb.Append('L');
            else
                sb.Append('.');
        }

        return sb.ToString();
    }
}