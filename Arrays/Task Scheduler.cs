public class Solution 
{
    public int LeastInterval(char[] tasks, int n)
    {
        var cnt = 0;
        var groupedTasks = tasks
            .GroupBy(c => c)
            .Select(gr => new Task(gr.Key, gr.Count()));

        var sorted = new SortedSet<Task>(groupedTasks, new DescendingComparer());

        var prevIdle = 0;

        while (sorted.Count > 0)
        {
            var tasksToSchedule = Math.Min(sorted.Count, n + 1);

            cnt += prevIdle;
            cnt += tasksToSchedule;

            if (tasksToSchedule - 1 < n)
                prevIdle = n - tasksToSchedule + 1;

            var takenTasks = sorted.Take(tasksToSchedule).ToArray();

            foreach (var task in takenTasks)
            {
                sorted.Remove(task);

                if (task.Count > 1)
                {
                    task.Count -= 1;
                    sorted.Add(task);
                }
            }
        }

        return cnt;
    }

    private sealed class Task
    {
        public readonly char Alfa;

        public int Count;

        public Task(char alfa, int count)
        {
            Alfa = alfa;
            Count = count;
        }
    }

    private sealed class DescendingComparer : IComparer<Task>
    {
        public int Compare(Task x, Task y)
        {
            if (y.Count != x.Count) return y.Count - x.Count;

            return y.Alfa.CompareTo(x.Alfa);
        }
    }
}