public class Solution 
{
    public string[] GetFolderNames(string[] names) 
    {
        var map = new Dictionary<string, int>();
        var used = new Dictionary<string, HashSet<int>>();
        var res = new List<string>(names.Length);

        foreach (var name in names)
        {
            var next = ProcessName(name, map, used);
            if (next > 0)
            {
                var tmp = name + "(" + next + ")";
                ProcessName(tmp, map, used);
                res.Add(tmp);
            }
            else
                res.Add(name);

            var nameAndNum = GetNameAndNum(name);
            if (nameAndNum.Num > 0)
            {
                if (!used.TryGetValue(nameAndNum.Name, out var set))
                {
                    set = new HashSet<int>();
                    used.Add(nameAndNum.Name, set);
                }

                set.Add(nameAndNum.Num);                
            }
        }

        return res.ToArray();
    }

    private static int ProcessName(string name, Dictionary<string, int> map, Dictionary<string, HashSet<int>> used)
    {
        var cnt = map.GetValueOrDefault(name, 0);
        if (cnt == 0)
        {
            map.Add(name, 1);
            return 0;
        }

        var next = cnt;
        if (used.TryGetValue(name, out var set))
        {
            while (set.Count > 0)
            {
                if (set.Contains(next))
                {
                    set.Remove(next);
                    ++next;
                }
                else
                    break;
            }
        }

        map[name] = next + 1;

        return next;    
    }

    private static (string Name, int Num) GetNameAndNum(string name)
    {
        if (name[name.Length - 1] != ')') return (string.Empty, 0);

        var idx = name.LastIndexOf('(');
        if (idx < 0) return (string.Empty, 0);

        var sNum = name.Substring(idx + 1, name.Length - 1 - idx - 1);
        if (int.TryParse(sNum, out var num))
            return (name.Substring(0, idx), num);

        return (string.Empty, 0);
    }
}
