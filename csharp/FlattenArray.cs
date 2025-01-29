using System.Text.Json;

namespace Algorithms;

//https://leetcode.com/problems/flatten-deeply-nested-array/description/

public class FlattenArray
{
    public void run()
    {
        var inputs = new List<Tuple<string, string, string>>()
        {
            Tuple.Create("[1, 2, 3, [4, 5, 6], [7, 8, [9, 10, 11], 12], [13, 14, 15]]", "n = 0", "[1, 2, 3, [4, 5, 6], [7, 8, [9, 10, 11], 12], [13, 14, 15]]"),
            Tuple.Create("[1, 2, 3, [4, 5, 6], [7, 8, [9, 10, 11], 12], [13, 14, 15]]", "n = 1", "[1, 2, 3, 4, 5, 6, 7, 8, [9, 10, 11], 12, 13, 14, 15]"),
            Tuple.Create("[[1, 2, 3], [4, 5, 6], [7, 8, [9, 10, 11], 12], [13, 14, 15]]", "n = 2", "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]")
        };

        foreach (var input in inputs)
        {
            Console.WriteLine($"Input: {input.Item1}");
            Console.WriteLine("Output with Json: " + string.Join(' ',FlattenUsingJson(input.Item1)));
            Console.WriteLine("Output with Stack: " + string.Join(' ',FlattenWithStack(JsonDocument.Parse(input.Item1))));
        }
    }

    /// <summary>
    /// Brute Force Solution
    /// </summary>
    public List<int[]> BruteForce(int[][] input, int n)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Flatten using json document
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public IList<int> FlattenUsingJson(string input)
    {
        var result = new List<int>();
        using (JsonDocument document = JsonDocument.Parse(input))
        {
            FlattenJsonHelperRecursive(document.RootElement, result);
        }
        return result;
    }

    /// <summary>
    /// Flatten to the lowest level usin JsonElements   
    /// </summary>
    /// <param name="element"></param>
    /// <param name="result"></param>
    private void FlattenJsonHelperRecursive(JsonElement element, List<int> result)
    {
        if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
            {
                FlattenJsonHelperRecursive(item, result);
            }
        }
        else if (element.ValueKind == JsonValueKind.Number)
            result.Add(element.GetInt32());
    }

    /// <summary>
    /// Flatten solution using stacks
    /// </summary>
    /// <param name="nestedList"></param>
    /// <returns></returns>
    public IList<int> FlattenWithStack(IList<object> nestedList)
    {
        var result = new List<int>();
        var stack = new Stack<IEnumerator<object>>();
        stack.Push(nestedList.GetEnumerator());

        while (stack.Count > 0)
        {
            if (!stack.Peek().MoveNext())
            {
                stack.Pop();
            }
            else
            {
                var current = stack.Peek().Current;
                if (current is int num)
                {
                    result.Add(num);
                }
                else if (current is IList<object> list)
                {
                    stack.Push(list.GetEnumerator());
                }
            }
        }
        return result;
    }


    /// <summary>
    /// convert string into n depth multidimensional array - or into 
    /// list of objects, so multimensionality can be represented in c#
    /// </summary>
    /// <param name="multidimensionalArray"></param>
    /// <returns></returns>
    private List<object> ConvertStringIntoMultidimensionalArray(string input)
    {
        //input = input.Trim(' ');
        //Stack<char> squared = new Stack<char>();
        //List<object> result = new List<object>();

        //for (int i=0; i < input.Length; i++)
        //{
        //    if ('[' == input[i])
        //    {
        //        squared.Push(input[i]);
        //    }
        //    else if (squared.Count != 0 && int.Parse(input[i]))
        //    {
        //        result.add
        //    }
        //}

        //return new List<object> { input };

        throw new NotImplementedException();
    }

}

