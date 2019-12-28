public int MaxPoints(int[][] points)
{
    var unique = new Dictionary<(int x, int y), int>();
    foreach (var p in points)
    {
        if (!unique.TryGetValue((p[0], p[1]), out var cnt))
            cnt = 1;
        else
            cnt += 1;

        unique[(p[0], p[1])] = cnt;
    }

    if (unique.Count == 1) return unique.First().Value;

    var max = 0;
    var map = new Dictionary<(decimal, decimal, decimal), HashSet<(int, int)>>();
    var counts = new Dictionary<(decimal, decimal, decimal), int>();
    var pointsArr = unique.Keys.ToArray();

    for (var i = 0; i < pointsArr.Length; ++i)
    {
        for (var j = i + 1; j < pointsArr.Length; ++j)
        {
            var p1 = pointsArr[i];
            var p2 = pointsArr[j];

            decimal a, b, c;

            if (p1.x == p2.x)
            {
                a = 1;
                b = 0;
                c = -1 * p1.x;
            }
            else if (p1.y == p2.y)
            {
                a = 0;
                b = 1;
                c = -1 * p1.y;
            }
            else
            {
                a = (decimal) (p1.y - p2.y) / (p1.x - p2.x);
                b = -1;
                c = p1.y  - a * p1.x;
            }

            if (!map.TryGetValue((a, b, c), out var set))
            {
                set = new HashSet<(int, int)>();
                map.Add((a, b, c), set);

                counts.Add((a, b, c), 0);
            }

            if (set.Add(p1))
                counts[(a, b, c)] += unique[p1];

            if (set.Add(p2))
                counts[(a, b, c)] += unique[p2];

            max = Math.Max(max, counts[(a, b, c)]);
        }
    }

    return max;
}