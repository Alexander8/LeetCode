public class Solution 
{
    public bool IsPossibleDivide(int[] nums, int k) 
    {
        if (nums.Length % k != 0) return false;

        var grFound = 0;
        var grCnt = nums.Length / k;
        var groupedNums = nums.GroupBy(n => n).ToDictionary(gr => gr.Key, gr => gr.Count());
        var sortedSet = new SortedList<int, int>(groupedNums);

        for (var i = 0; i < grCnt && sortedSet.Count > 0; ++i)
        {
            var expectedItem = -1;
            var j = 0;

            for (; j < k && sortedSet.Count > 0; ++j)
            {
                if (j == 0)
                {
                    var currItem = sortedSet.Keys.First();
                    var currCnt = sortedSet[currItem];

                    if (currCnt == 1) sortedSet.Remove(currItem);
                    else sortedSet[currItem] = currCnt - 1;

                    expectedItem = currItem + 1;
                }
                else
                {
                    if (!sortedSet.ContainsKey(expectedItem)) return false;

                    var expectedCnt = sortedSet[expectedItem];

                    if (expectedCnt == 1) sortedSet.Remove(expectedItem);
                    else sortedSet[expectedItem] = expectedCnt - 1;

                    expectedItem += 1;
                }
            }

            if (j == k) ++grFound;
        }

        return grFound == grCnt;
    }
}