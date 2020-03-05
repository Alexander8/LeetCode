public class Solution 
{
    public int CompareVersion(string version1, string version2) 
    {
        var v1 = new Version(version1);
        var v2 = new Version(version2);
        
        var res = Version.Compare(v1, v2);
        if (res > 0) return 1;
        if (res < 0) return -1;
        return 0;
    }
    
    private sealed class Version
    {
        private readonly int _major;
        private readonly int _minor;
        private readonly int _patch;
        private readonly int _build;
        
        public Version(string s)
        {
            var parts = s.Split(new[] { '.' });
            
            _major = parts.Length > 0 ? int.Parse(parts[0]) : 0;
            _minor = parts.Length > 1 ? int.Parse(parts[1]) : 0;
            _patch = parts.Length > 2 ? int.Parse(parts[2]) : 0;
            _build = parts.Length > 3 ? int.Parse(parts[3]) : 0;
        }
        
        public static int Compare(Version v1, Version v2)
        {
            if (v1._major != v2._major)
                return v1._major - v2._major;
            
            if (v1._minor != v2._minor)
                return v1._minor - v2._minor;
            
            if (v1._patch != v2._patch)
                return v1._patch - v2._patch;

            return v1._build - v2._build;
        }
    }
}