public class Solution 
{
    public int MinNumberOfFrogs(string croakOfFrogs) 
    {
        var res = 0;
        var free = 0;
        var unfinished = new Dictionary<char, int>();

        for (var i = 0; i < croakOfFrogs.Length; ++i)
        {
            if (unfinished.TryGetValue(croakOfFrogs[i], out var cnt))
            {
                if (cnt - 1 == 0)
                    unfinished.Remove(croakOfFrogs[i]);
                else
                    unfinished[croakOfFrogs[i]] = cnt - 1;

                if (croakOfFrogs[i] == 'k')
                {
                    ++free;
                }
                else
                {
                    var next = GetNext(croakOfFrogs[i]);

                    if (!unfinished.TryGetValue(next, out var cnt2))
                        cnt2 = 0;

                    unfinished[next] = cnt2 + 1;
                }
            }
            else
            {
                if (croakOfFrogs[i] != 'c')
                    return -1;

                if (!unfinished.TryGetValue('r', out var cnt2))
                    cnt2 = 0;

                unfinished['r'] = cnt2 + 1;

                if (croakOfFrogs[i] == 'c')
                {
                    if (res == 0 || free <= 0)
                    {
                        ++res;
                        ++free;
                    }

                    --free;
                }
            }            
        }

        return unfinished.Count > 0 ? -1 : res; 
    }

    private static char GetNext(char c)
    {
        switch (c)
        {
            case 'c': return 'r';
            case 'r': return 'o';
            case 'o': return 'a';
            case 'a': return 'k';
        }

        throw new Exception();
    }
}