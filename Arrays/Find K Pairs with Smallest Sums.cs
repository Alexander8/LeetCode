public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
{
    IList<IList<int>> result = new List<IList<int>>();
    if (k == 0 || nums1.Length == 0 || nums2.Length == 0)
    {
        return result;
    }

    var uniqueNums1 = GetUniqueList(nums1);
    var uniqueNums2 = GetUniqueList(nums2);

    var pairs = new Dictionary<int, int>(uniqueNums1.Count);

    for (var i = 0; i < uniqueNums1.Count; ++i) pairs[i] = 0;

    while (result.Count < k && pairs.Count > 0)
    {
        var minPair = pairs.First();
        var minPairValue = (uniqueNums1[minPair.Key], uniqueNums2[minPair.Value]);
        var minPairSum = minPairValue.Item1.X + minPairValue.Item2.X;

        foreach (var pair in pairs)
        {
            var pairValue = (uniqueNums1[pair.Key], uniqueNums2[pair.Value]);
            var pairSum = pairValue.Item1.X + pairValue.Item2.X;

            if (pairSum < minPairSum)
            {
                minPair = pair;
                minPairValue = pairValue;
                minPairSum = pairSum;
            }
        }

        if (minPair.Value + 1 == uniqueNums2.Count)
        {
            pairs.Remove(minPair.Key);
        }
        else
        {
            pairs[minPair.Key] = minPair.Value + 1;
        }

        AddToList(result, minPairValue.Item1, minPairValue.Item2);
    }

    return result.Count > k ? result.Take(k).ToList() : result;
}

private static List<(int X, int Cnt)> GetUniqueList(int[] nums)
{
    var res = new List<(int X, int Cnt)>();

    for (var i = 0; i < nums.Length; ++i)
    {
        var lastIndex = res.Count - 1;
        if (res.Count > 0 && res[lastIndex].X == nums[i])
        {
            res[lastIndex] = (res[lastIndex].X, res[lastIndex].Cnt + 1);
        }
        else
        {
            res.Add((nums[i], 1));
        }
    }

    return res;
}

private static void AddToList(IList<IList<int>> list, (int X, int Cnt) p1, (int X, int Cnt) p2)
{
    for (var i = 0; i < p1.Cnt * p2.Cnt; ++i)
    {
        list.Add(new List<int> { p1.X, p2.X });
    }
}