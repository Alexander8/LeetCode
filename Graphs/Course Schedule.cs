public bool CanFinish(int numCourses, int[][] prerequisites) 
{
    if (prerequisites.Length == 0)
    {
        return true;
    }
    
    var map = new Dictionary<int, Course>();
    
    for (var i = 0; i < numCourses; ++i)
    {
        map.Add(i, new Course(i));
    }
    
    for (var i = 0; i < prerequisites.Length; ++i)
    {
        var prerequisite = prerequisites[i];
        var dep = map[prerequisite[1]];
        
        map[prerequisite[0]].Dependencies.Add(dep);
    }
    
    return !HasCycle(map.Values);
}

private static bool HasCycle(IEnumerable<Course> courses)
{        
    foreach (var course in courses)
    {
        if (HasCycle(course))
        {
            return true;
        }
    }
    
    return false;
}

private static bool HasCycle(Course course)
{             
    course.State = 1;
        
    foreach (var dep in course.Dependencies)
    {
        if (dep.State == 0)
        {
            if (HasCycle(dep))
            {
                return true;
            }
        }
        else if (dep.State == 1)
        {
            return true;
        }                
    }

    course.State = 2;
    
    return false;
}

private sealed class Course
{
    public int Num { get; }
    
    public List<Course> Dependencies { get; } = new List<Course>();
    
    public int State { get; set; }
    
    public Course(int num)
    {
        Num = num;
    }
}