public class Solution 
{
    public IList<int> PathInZigZagTree(int label) 
    {
        var targetLevel = (int)Math.Log(label, 2);
        var levelCounts = new Dictionary<int, int> 
        {
            { 0, 1 }
        };
        
        for (var i = 1; i <= targetLevel; ++i)
            levelCounts[i] = levelCounts[i - 1] * 2;
        
        var path = new List<int>();
        path.Insert(0, label);
        
        for (var i = targetLevel; i > 0; --i)
        {
            var leftToRight = i % 2 == 0;        
            var currLevelCount = levelCounts[i];
            var parentLevelCount = levelCounts[i - 1];
            var parentNodeIdx = (label - currLevelCount) / 2;
            
            parentNodeIdx = parentLevelCount - parentNodeIdx - 1;
            
            label = parentLevelCount + parentNodeIdx;
            
            path.Insert(0, label);
        }
        
        return path;
    }
}