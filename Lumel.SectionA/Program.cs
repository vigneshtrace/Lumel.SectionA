class Program
{
    public static void Main()
    {
        var input1 = new List<(int, int)>() { (1,2),(2,6),(2,10),(3,4),(4,5)};

        InputOrchestrator(input1,"input 1 : ");
        
       
        var input2 = new List<(int, int)>() { (900, 1030), (1000, 1100), (1030, 1130), (1100, 1200) };
        InputOrchestrator(input2, "input 2 : ");
    }
    public static int maxCount = 1;
    private static void InputOrchestrator(List<(int,int)> input1,string label)
    {
        maxCount = 1;
        input1 = input1.OrderBy(x => x.Item1).ToList();
        for (int i = 0; i < input1.Count; i++)
            FindMaximumPossibleInterval_(input1, i, 1);
        Console.WriteLine(label + maxCount);
    }
    private static int FindMaximumPossibleInterval_(List<(int,int)> intervals,int start,int count)
    {
        var (startTime, endTime) = intervals[start];
        
        for (int i = start+1; i < intervals.Count; i++)
        {
            if (intervals[i].Item1 >=endTime)
                FindMaximumPossibleInterval_(intervals,i,count+1);
        }
        maxCount = Math.Max(maxCount,count);
        return count;
    }
}