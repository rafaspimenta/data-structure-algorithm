using static DSA.DSAModule.Algorithm;

namespace DSA.DSAModule
{
    public class Algorithm
    {
        static int[] _primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        public static int FindBinarySearch(int value)
        {
            var minIdx = 0;
            var maxIdx = _primes.Length - 1;

            for (int i = minIdx; i < maxIdx; i++)
            {
                var guessIdx = (minIdx + maxIdx) / 2;
                var guess = _primes[guessIdx];
                if (value == guess)
                {
                    return guessIdx;
                }
                else if (value == _primes[i])
                {
                    return i;
                }
                else if (value == _primes[maxIdx])
                {
                    return maxIdx;
                }
                else if (guess > value)
                {
                    minIdx = guessIdx + 1;
                }
                else if (guess < value)
                {
                    maxIdx = guessIdx - 1;
                }
            }

            return -1;
        }

        public static int SlidingWindow()
        {
            var stocks = new int[] { 7, 1, 5, 3, 6, 4 };
            var maxProfit = 0;
            var l = 0;

            for (int r = 1; r < stocks.Length; r++)
            {
                var profit = stocks[l] - stocks[r];
                if (profit < 0)
                {
                    l = r;
                }
                else
                {
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }

            return maxProfit;
        }

        public static void Recursive(int n, int exitFlag)
        {
            if (n == exitFlag)
            {
                return;
            }

            Console.WriteLine(n);
            Recursive(n + 1, exitFlag);
            Console.WriteLine("finish");
        }

        public static int Fibonacci(int number)
        {
            if (number <= 1)
                return number;

            var fib1 = Fibonacci(number - 1);
            var fib2 = Fibonacci(number - 2);

            var result = fib1 + fib2;
            return result;
        }

        public static bool CheckIfPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (word[left] != word[right])
                {
                    return false;
                }

                left++;
                right--;
            }
            return true;
        }

        public static int SumTwoOrderedNumber(int target)
        {
            var numbers = new int[] { 1, 2, 4, 6, 8, 9, 14, 15 };

            int left = 0;
            int right = numbers.Length - 1;
            int sum = 0;
            while (left < right)
            {
                sum = numbers[left] + numbers[right];
                if (sum == target)
                {
                    return sum;
                }
                else if (sum > target)
                {
                    right--;
                }
                else if (sum < target)
                {
                    left++;
                }
            }
            return sum;
        }

        public static int[] CombineSortedArrays()
        {
            var arr1 = new int[] { 1, 2, 4, 6, 8, 9, 14, 15 };
            var arr2 = new int[] { 3, 7, 10, 17, 20 };

            var ans = new int[arr1.Length + arr2.Length];

            var arr1Idx = 0;
            var arr2Idx = 0;
            var ansIdx = 0;

            while (arr1Idx < arr1.Length && arr2Idx < arr2.Length)
            {
                if (arr1[arr1Idx] < arr2[arr2Idx])
                {
                    ans[ansIdx] = arr1[arr1Idx];
                    arr1Idx++;
                }
                else
                {
                    ans[ansIdx] = arr2[arr2Idx];
                    arr2Idx++;
                }
                ansIdx++;
            }

            while (arr1Idx < arr1.Length)
            {
                ans[ansIdx] = arr1[arr1Idx];
                ansIdx++;
                arr1Idx++;
            }

            while (arr2Idx < arr2.Length)
            {
                ans[ansIdx] = arr2[arr2Idx];
                ansIdx++;
                arr2Idx++;
            }

            return ans;
        }

        public static bool IsSubsequence(string s, string text)
        {
            var sIdx = 0;

            for (int textIdx = 0; textIdx < text.Length; textIdx++)
            {
                if (s[sIdx] == text[textIdx])
                {
                    sIdx++;
                }
            }
            return (sIdx == s.Length);
        }

        public static int[] SortedSquares(int[] nums)
        {

            var result = new int[nums.Length];
            var resultIdx = nums.Length - 1;

            var left = 0;
            var right = nums.Length - 1;
            while (left < right)
            {
                if (Math.Abs(nums[left]) < nums[right])
                {
                    result[resultIdx] = nums[right] * nums[right];
                    right--;
                }
                else
                {
                    result[resultIdx] = nums[left] * nums[left];
                    left++;
                }
                resultIdx--;
            }
            result[resultIdx] = nums[left];

            return result;
        }

        public static IList<string> FizzBuzz(int n)
        {
            var result = new string[n];
            var fizz = "Fizz";
            var buzz = "Buzz";

            for (int i = 1; i <= n; i++)
            {
                var value = "";
                if (i % 3 == 0)
                {
                    value = fizz;
                }
                if (i % 5 == 0)
                {
                    value += buzz;
                }

                if (string.IsNullOrEmpty(value))
                {
                    value = i.ToString();
                }

                result[i - 1] = value;
            }


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            return result;
        }


        //nums = [3, 2, 1, 3, 1, 1] and k = 5.
        //nums = [7, 2, 1, 3, 1, 4] and k = 5.
        //nums = [7, 2, 1, 3, 1, 3] and k = 5.
        public static int FindLongestSubArrayLessThanOrEqualTo(int[] nums, int target)
        {
            int left = 0;
            int sum = 0;
            int answer = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];

                while (sum > target)
                {
                    sum -= nums[left];
                    left++;
                }
                var subArrayLength = right - left + 1;
                answer = Math.Max(answer, subArrayLength);
            }

            return answer;
        }

        // "1101100111"
        public static int FindLength(int[] ints)
        {
            int left = 0;
            int ans = 0;
            int count = 0;
            for (int right = 0; right < ints.Length; right++)
            {

                if (ints[right] == 0)
                {
                    count++;
                }

                if (count > 1)
                {
                    left = right;
                    count--;
                }

                ans = Math.Max(ans, right - left + 1);
            }
            return ans;
        }

        public static int NumSubArrayProductLessThan(int[] nums, int target)
        {
            int ans = 0;
            int left = 0;
            int curr = 1;

            if (target <= 1)
            {
                return 0;
            }

            for (int right = 0; right < nums.Length; right++)
            {
                curr *= nums[right];

                if (curr >= target)
                {
                    curr /= nums[left];
                    left++;
                }

                ans += right - left + 1;
            }

            return ans;
        }

        public static int FindLargestSumSubArray(int[] nums, int k)
        {
            int curr = 0;
            for (int i = 0; i < k; i++)
            {
                curr += nums[i];
            }

            var ans = curr;
            for (int i = k; i < nums.Length; i++)
            {
                curr += nums[i] - nums[i - k];
                ans = Math.Max(ans, curr);
            }

            return ans;
        }

        public static double FindMaxAverage(int[] nums, int k)
        {
            double currSum = 0;
            for (int i = 0; i < k; i++)
            {
                currSum += nums[i];
            }

            var currAvg = currSum / k;
            var ansAvg = currAvg;
            for (int i = k; i < nums.Length; i++)
            {
                currAvg += (double)(nums[i] - nums[i - k]) / k;
                ansAvg = Math.Max(ansAvg, currAvg);
            }

            return ansAvg;
        }
        // [0,0]->0  [0,1]->2  [0,2]2
        // [1,0]->3  [1,1]->5  [1,2]4
        public static int LongestOnes(int[] nums, int k)
        {
            int left = 0;
            int ans = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    k--;
                }

                while (k < 0)
                {
                    if (nums[left] == 0)
                    {
                        k++;
                    }
                    left++;
                }

                ans = Math.Max(ans, right - left + 1);
            }
            return ans;
        }


        //int rows = matrix.GetLength(0); // rows is 3
        //int columns = matrix.GetLength(1); // columns is 2

        //nums = [1, 6, 3, 2, 7, 2], queries = [[0, 3], [2, 5], [2, 4]], and limit = 13
        public static bool[] AnswerQueries(int[] nums, int[,] queries, int limit)
        {

            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i] + nums[i - 1];
            }

            var ans = new bool[queries.GetLength(0)];
            for (int i = 0; i < queries.GetLength(0); i++)
            {
                int left = queries[i, 0];
                int right = queries[i, queries.GetLength(1) - 1];
                var sum = nums[right] - nums[left];
                ans[i] = sum < limit;
            }

            return ans;
        }


        public static int WaysToSplitArray(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }

            int validSplits = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                var left = nums[i];
                var right = nums[nums.Length - 1] - left; //nums.Length - 

                validSplits += right >= left ? 1 : 0;
            }

            return validSplits;
        }

        public static int[] RunningSum(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }

            return nums;
        }

        public void Dic()
        {
            var nums = new Dictionary<int, string>(100);

            var one = nums[1];

            KeyValuePair<int, string> two = nums.SingleOrDefault(x => x.Key == 2);
        }

        //[5,2,7,10,3,9] t-> 8
        public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dic.ContainsKey(complement))
                {
                    return new int[] { dic[complement], i };
                }
            }

            return new int[] { -1, -1 };
        }

        public char FirstCharAppearTwice()
        {
            var str = "abcdeabcde";

            var dic = new Dictionary<int, char>();
            for (int i = 0; i < str.Length; i++)
            {
                var @char = str[i];
                if (dic.ContainsKey(i))
                {
                    return @char;
                }
                else
                {
                    dic.Add(i, @char);
                }
            }
            return ' ';
        }

        public bool IsPangram(string sentence)
        {
            var alphabetSize = "abcdefghijklmnopqrstuvwxyz".Length;
            var dic = new HashSet<char>();

            for (int i = 0; i < sentence.Length; i++)
            {
                var letter = sentence[i];
                if (!dic.Contains(letter))
                {
                    dic.Add(letter);
                }
            }

            return dic.Count == alphabetSize;
        }

        public static int FindMissingNumber(int[] nums)
        {
            var dic = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dic.Add(nums[i]);
            }

            for (int i = 0; i <= nums.Length; i++)
            {
                if (!dic.Contains(i))
                {
                    return i;
                }
            }

            return -1;
        }

        //Input: arr = [1,2,3]
        //Output: 2
        public static int CountElements(int[] arr)
        {
            var count = 0;
            var dic = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                dic.Add(arr[i]);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (dic.Contains(arr[i] + 1))
                {
                    count++;
                }
            }
            return count;
        }

        public static int FindLongestSubstring(string text, int k)
        {
            int ans = 0;
            int left = 0;
            var dic = new Dictionary<char, int>();
            for (int right = 0; right < text.Length; right++)
            {
                var rightKey = text[right];
                if (!dic.ContainsKey(text[right]))
                {
                    dic.Add(rightKey, 1);
                }
                else
                {
                    dic[rightKey]++;
                }

                while (dic.Count > k)
                {
                    var leftKey = text[left];
                    dic[leftKey]--;

                    if (dic[leftKey] == 0)
                    {
                        dic.Remove(leftKey);
                    }
                    left++;

                }
                ans = Math.Max(ans, right - left + 1);
            }

            return ans;
        }

        public void ReverseLinkedList()
        {
            var list = new LinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

        }

        public static int LongestPath(TreeNode<int> node)
        {
            if (node == null)
            {
                return 0;
            }

            var left = LongestPath(node.Left);
            var right = LongestPath(node.Right);


            return Math.Max(left, right) + 1;
        }

        public static bool HasPathSum(TreeNode<int> node, int t)
        {
            bool SumPath(TreeNode<int> node, int sum)
            {
                if (node == null)
                {
                    return false;
                }

                if (node.Left == null && node.Right == null)
                {
                    return sum + node.Data == t;
                }
                var left = SumPath(node.Left, sum + node.Data);
                var right = SumPath(node.Right, sum + node.Data);
                return left || right;
            }

            return SumPath(node, 0);
        }

        public static int RangeSumBST(TreeNode<int> node, int low, int high)
        {
            if (node == null)
            {
                return 0;
            }

            var ans = 0;
            if (low <= node.Data && node.Data <= high)
            {
                ans += node.Data;
            }

            if (low < node.Data)
            {
                ans += RangeSumBST(node.Left, low, high);
            }
            if (high > node.Data)
            {
                ans += RangeSumBST(node.Right, low, high);
            }

            return ans;
        }

        public static string? ReverseString(string text)
        {
            var ans = new char[text.Length];
            for (int i = 0; i < Math.Ceiling((double)text.Length / 2); i++)
            {
                var left = text[i];
                var right = text[text.Length - 1 - i];
                ans[i] = right;
                ans[text.Length - 1 - i] = left;
            }
            return new string(ans);
        }


        public static string GridChallenge(List<string> grid)
        {
            var cols = grid[0].Length;
            char[]? previews = null;

            for (int i = 0; i < cols; i++)
            {
                var chars = grid[i].ToList();
                chars.Sort();
                grid[i] = string.Concat(chars);

                if (previews != null)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (previews[j] > chars[j])
                        {
                            return "NO";
                        }
                    }
                }
                previews = chars.ToArray();
            }

            return "YES";
        }

        public abstract class NumberStrategy
        {
            public NumberSymbol Symbol { get; protected set; }
            public double SumValues { get; set; }
            public int Quantity { get; protected set; }
            public void AddValue(double value)
            {
                SumValues += value;
                Quantity++;
            }

        }
        public class Positive : NumberStrategy
        {
            public Positive()
            {
                Symbol = NumberSymbol.Positive;
            }
        }

        public class Negative : NumberStrategy
        {
            public Negative()
            {
                Symbol = NumberSymbol.Negative;
            }
        }

        public class Zero : NumberStrategy
        {
            public Zero()
            {
                Symbol = NumberSymbol.Zero;
            }
        }

        public enum NumberSymbol
        {
            Positive,
            Negative,
            Zero
        }

        public class MyNumbers
        {
            public Positive Positive { get; set; } = new();
            public Negative Negative { get; set; } = new();
            public Zero Zero { get; set; } = new();
        }

        public static void PlusMinus(List<int> arr)
        {
            var numbers = new MyNumbers();

            foreach (double item in arr)
            {
                if (item > 0)
                {
                    numbers.Positive.AddValue(item);
                }
                else if (item < 0)
                {
                    numbers.Negative.AddValue(item);
                }
                else
                {
                    numbers.Zero.AddValue(item);
                }
            }

            Console.WriteLine($"{(double)numbers.Positive.Quantity / arr.Count:0.000000}");
            Console.WriteLine($"{(double)numbers.Negative.Quantity / arr.Count:0.000000}");
            Console.WriteLine($"{(double)numbers.Zero.Quantity / arr.Count:0.000000}");
        }


        public static int Lonelyinteger(List<int> a)
        {
            var dic = new Dictionary<int, int>();

            // Count the occurrences of each element in the array
            foreach (int num in a)
            {
                if (dic.ContainsKey(num))
                {
                    dic[num]++;
                }
                else
                {
                    dic[num] = 1;
                }
            }

            // Find the element with a count of 1
            foreach (var entry in dic)
            {
                if (entry.Value == 1)
                {
                    return entry.Key;
                }
            }

            // Handle the case when there is no unique element
            throw new InvalidOperationException("No unique element found");
        }
    }

    public class MyLinkedList<T>
    {
        public MyLinkedList(MyLinkedListNode<T> root)
        {
            First = root;
        }

        public MyLinkedListNode<T> First { get; private set; }

        public void AddFirst(T data)
        {
            var node = new MyLinkedListNode<T>(data)
            {
                Next = First
            };
            First = node;
        }

        public void AddLast(T data)
        {
            var newLastNode = new MyLinkedListNode<T>(data)
            {
                Next = null
            };

            var curr = First;
            while (curr != null)
            {
                if (curr.Next == null)
                {
                    curr.Next = newLastNode;
                    break;
                }
                curr = curr.Next;
            }
        }

        public void RemoveFirst()
        {
            var curr = First;
            if (curr.Next != null)
            {
                var next = curr.Next;
                curr.Next = null;

                First = next;
            }
        }

        public void Reversing()
        {
            MyLinkedListNode<T>? prev = null;
            MyLinkedListNode<T>? curr = First;

            while (curr != null)
            {
                var nextNode = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = nextNode;
            }
            First = prev;
        }

        public void Transverse()
        {
            var curr = First;
            while (curr != null)
            {
                Console.WriteLine(curr.Data);
                curr = curr.Next;
            }
        }
    }

    public class MyLinkedListNode<T>
    {
        public T Data { get; set; }
        public MyLinkedListNode<T>? Next { get; set; }

        public MyLinkedListNode(T data)
        {
            Data = data;
        }
    }


    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Data = value;
        }

        public T Data { get; set; }
        public TreeNode<T>? Left { get; set; }
        public TreeNode<T>? Right { get; set; }
    }
}