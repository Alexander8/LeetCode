using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp43
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            var res = p.FourSum(new[] {1, 0, -1, 0, -2, 2}, 0);
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var map = new Dictionary<int, List<(int, int)>>();

            for (var i = 0; i < nums.Length; ++i)
            {
                for (var j = i + 1; j < nums.Length; ++j)
                {
                    var s = nums[i] + nums[j];
                    if (!map.TryGetValue(s, out var set))
                    {
                        set = new List<(int, int)>();
                        map.Add(s, set);
                    }

                    set.Add((i, j));
                }
            }

            var resTmp = new HashSet<Entry>();
            var used = new HashSet<int>();

            foreach (var item in map)
            {
                if (used.Contains(item.Key)) continue;

                var x = item.Key;
                var y = target - x;

                used.Add(x);

                if (map.TryGetValue(y, out var set))
                    foreach (var ab in item.Value)
                        foreach (var cd in set)
                            if (ab.Item1 != cd.Item1 && ab.Item1 != cd.Item2 && ab.Item2 != cd.Item1 && ab.Item2 != cd.Item2)
                                resTmp.Add(new Entry(nums[ab.Item1], nums[ab.Item2], nums[cd.Item1], nums[cd.Item2]));
            }

            var res = new List<IList<int>>();

            res.AddRange(resTmp.Select(x => new List<int> { x.a, x.b, x.c, x.d }));

            return res;
        }

        private struct Entry : IEquatable<Entry>
        {
            public readonly int a;
            public readonly int b;
            public readonly int c;
            public readonly int d;

            public Entry(int a, int b, int c, int d)
            {
                var nums = new[] {a, b, c, d};
                Array.Sort(nums);

                this.a = nums[0];
                this.b = nums[1];
                this.c = nums[2];
                this.d = nums[3];
            }

            public bool Equals(Entry other)
            {
                return a == other.a && b == other.b && c == other.c && d == other.d;
            }

            public override bool Equals(object obj)
            {
                return obj is Entry other && Equals(other);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(a, b, c, d);
            }
        }
    }
}