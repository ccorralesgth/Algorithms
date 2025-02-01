using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

internal class ValidAnagram
{


    /// <summary>
    /// 
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public bool SolutionWithSorting(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        //if (s1.Equals(s2)) return false;

        char[] c1 = s1.ToCharArray();
        char[] c2 = s2.ToCharArray();

        Array.Sort(c1);
        Array.Sort(c2);

        if (c1.SequenceEqual(c2))
            return true;
        return false;
    }

    /// summary>
    /// Solution using a dictionary 
    /// Time Complexity: O(n)
    /// Space Complexity: O(1)
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public bool SolutionWithDictionary(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        //if (!s1.Equals(s2)) return false;

        var countS1 = new Dictionary<char, int>();
        var countS2 = new Dictionary<char, int>();

        for (int i = 0; i < s1.Length; i++)
        {
            countS1[s1[i]] = countS1.GetValueOrDefault(s1[i], 0) + 1;
            countS2[s2[i]] = countS2.GetValueOrDefault(s2[i], 0) + 1;
        }

        return countS1.Count == countS2.Count && !countS1.Except(countS2).Any();
    }

    /// <summary>
    /// Solution using 
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    private bool SolutionWithHashTableOptimal(string s1, string s2)
    {
        if (s1.Length != s2.Length) { return false; }

        int[] count = new int[26];// Fixed array for 26 English letters
        for (int i = 0; i < s1.Length; i++)
        {
            count[s1[i] - 'a']++;  // Increment count for character in s1
            count[s2[i] - 'a']--;  // Decrement count for character in s2
        }

        foreach (int item in count)
        {
            if (item != 0)
                return false; // If any letter count is not balanced, it's not an anagram
        }
        return true;
    }



    public void run()
    {
        List<Tuple<string, string, string>> inputs = new List<Tuple<string, string, string>>()
        {
            Tuple.Create("listen","silent","true"),
            Tuple.Create("earth","heart","true"),
            Tuple.Create("car","tar","false"),
            Tuple.Create("car","kiar","false"),
            Tuple.Create("pis","pis","false")
        };

        foreach (var input in inputs)
        {
            Console.WriteLine($"Inputs: [{input.Item1}, {input.Item2}] - {input.Item3} | Answer {SolutionWithHashTableOptimal(input.Item1, input.Item2)}");
        }
    }
}
