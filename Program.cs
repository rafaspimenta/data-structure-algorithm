using DSA.DSAModule;
using System.Diagnostics;
using static DSA.DSAModule.Algorithm;
using static System.Net.Mime.MediaTypeNames;

namespace DSA;
internal class Program
{
    //recursive 
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        graph.AddNode(1);
        graph.AddNode(2);
        graph.AddNode(3);
        graph.AddNode(4);

        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 1);

        graph.PrintGraph();

        //Algorithm.Recursive(0, 1_000_000);
        //var fib = Algorithm.Fibonacci(2);
        //var sum = Algorithm.SumTwoOrderedNumber(13);
        //var result = Algorithm.CombineSortedArrays();
        //var result = Algorithm.IsSubsequence("abcc", "ddahbgdcffffeyrc");
        //var result = Algorithm.SortedSquares(new int[] { -7, -3, 2, 3, 11, 12 });        
        //var result = Algorithm.FizzBuzz(15);
        //var result = Algorithm.FindLength1(new int[] { 1, 1, 0, 1, 1, 0, 0, 1, 1, 1 });
        //var result = Algorithm.NumSubArrayProductLessThan(new int[] { 10, 5, 2, 6 }, 100);
        //var result = Algorithm.FindLargestSumSubArray(new int[] { 3, -1, 4, 12, -8, 5, 6 }, 4);
        //var result = Algorithm.FindMaxAverage(new int[] { 1, 12, -5, -6, 50, 3 }, 4);
        //var result = Algorithm.LongestOnes(new int[] { 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1 }, 2);

        //nums = [1, 6, 3, 2, 7, 2], queries = [[0, 3], [2, 5], [2, 4]], and limit = 13
        //var result = Algorithm.AnswerQueries(new int[] { 1, 6, 3, 2, 7, 2 }, new int[,] { { 0, 3 }, { 2, 5 }, { 2, 4 } }, 13);
        //var result = Algorithm.WaysToSplitArray(new int[] { 10, 4, -8, 7 });
        //var result = Algorithm.FindMissingNumber(new int[] { 3, 0, 1 });
        //var result = Algorithm.CountElements(new int[] { 1, 2, 3 });
        //var result = Algorithm.FindLongestSubstring("eceba", 2);

        //var result = Algorithm.ReverseString("abc");
        //string r = Algorithm.ReverseString("rafael");
        /*var root = new TreeNode<int>(10)
        {
            Left = new TreeNode<int>(5),
            Right = new TreeNode<int>(15)
        };
        root.Left.Left = new TreeNode<int>(3);
        root.Left.Right = new TreeNode<int>(7);
        root.Right.Right = new TreeNode<int>(15);
        root.Right.Right.Right = new TreeNode<int>(18);

        var result = RangeSumBST(root, 3, 5);*/

        //var r = GridChallenge(new List<string>() { "ebacd", "fghij", "olmkn", "trpqs", "xywuv" });

        //PlusMinus(new List<int> { -4, 3, -9, 0, 4, 1 });
    }

    // binary search
    /*static void Main(string[] args)
    {
       var idx = Algorithm.FindBinarySearch(2);
        Console.WriteLine($"index: {idx}");
    }*/

    // Race condition
    /*static async Task Main(string[] args)
    {
        var makeCoffeeTask = Task.Run(MakeCoffee);
        var makeCoffeeTask1 = Task.FromResult(MakeCoffee);
        await MakeCoffeeAsync();

        await makeCoffeeTask;
    }*/

    public static string BoilerWater()
    {
        Console.WriteLine("1 Start the kettle");
        Console.WriteLine("1 waiting the kettle boiler the water");

        Thread.Sleep(5000);

        Console.WriteLine("1 Finished boiled in the kettle");

        return "water";
    }

    public static string MakeCoffee()
    {
        var watch = Stopwatch.StartNew();
        Console.WriteLine("1 Place the strainer on the coffee bottle");
        Console.WriteLine("1 Put the coffee in the strainer");
        Console.WriteLine("1 Waiting to finish putting the coffee in the strainer");
        Thread.Sleep(2000);
        Console.WriteLine("1 Finished put the coffee in the strainer");

        Console.WriteLine("1 waiting for the kettle");
        var water = BoilerWater();

        Console.WriteLine($"1 Put the {water} in the strainer");

        Console.WriteLine("1 Coffee is ready");

        watch.Stop();
        Console.WriteLine($"1 time {watch.Elapsed.TotalSeconds}");
        return "coffee";
    }

    public static async Task<string> BoilerWaterAsync()
    {
        Console.WriteLine("2 Start the kettle");
        Console.WriteLine("2 waiting the kettle boiler the water");
        await Task.Delay(5000);

        Console.WriteLine("2 Finished boiled in the kettle");

        return "water";
    }

    public static async Task<string> MakeCoffeeAsync()
    {
        var watch = Stopwatch.StartNew();

        var waterTask = BoilerWaterAsync();

        Console.WriteLine("2 Place the strainer on the coffee bottle");
        Console.WriteLine("2 Put the coffee in the strainer");
        Console.WriteLine("2 Waiting to finish putting the coffee in the strainer");
        await Task.Delay(2000);
        Console.WriteLine("2 Finished put the coffee in the strainer");

        Console.WriteLine("2 waiting for the kettle");
        var water = await waterTask;

        Console.WriteLine($"2 Put the {water} in the strainer");

        Console.WriteLine("2 Coffee is ready");

        Console.WriteLine($"2 time {watch.Elapsed.TotalSeconds}");
        return "2 coffee";
    }
}
