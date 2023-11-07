namespace DSA.Utils;

public class In
{
    public static async IAsyncEnumerable<int> ReadIntsAsync(string filePath)
    {
        using StreamReader sr = new(filePath);
        while (await sr.ReadLineAsync() is string line)
        {
            if (int.TryParse(line, out int result))
            {
                yield return result;
            }
        }
    }
}
