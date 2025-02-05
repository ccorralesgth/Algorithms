using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    //https://leetcode.com/problems/contains-duplicate/
    public class HasDuplicates
    {
        public static void run()
        {

        }

        /// <summary>
        /// Brute Force Solution with time complexity O(n^2)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>boolean</returns>        
        public static bool BruteForceSolution(int[] input)
        {
            //validate input edge case 
            if (input is null || input.Length == 0)
                return false;
            
            //add logic
            for (int i=0; i < input.Length ; i++ )
            {
                for (int j = i+1; j < input.Length;)
                {
                    if (input[i] == input[j])
                        return true;
                }
            }
            
            //return boolean
            return false;                    
        }

        /// <summary>
        /// Sorting solution with Time Complexity O(nlogn)
        /// </summary>
        /// <returns>boolean</returns>        
        public static bool SortingSolution(int[] input)
        {
            //validate input edge case 
            if (input is null || input.Length == 0)
                return false;


            Array.Sort(input);
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == input[i+1])
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Solution with HashSet Time Complexity O(n)
        /// </summary>
        /// <returns></returns>
        public static bool HashSetSolution(int[] input)
        {
            //validate input edge case 
            if (input is null || input.Length == 0)
                return false;


            var setSeen = new HashSet<int>();
            foreach (var item in input)
            {                
                setSeen.Add(item); //when using HasSet will not add duplicates 
            }
            return setSeen.Count < input.Length ;
        }

        /// <summary>
        /// Solution with HashSet using obj reflexion constructor, Time Complexity O(n)
        /// </summary>
        /// <returns></returns>
        public static bool HashSetLenghtSolution(int[] input)
        {
            //validate input edge case 
            if (input is null || input.Length == 0)
                return false;


            return new HashSet<int>(input).Count < input.Length;
        }
    }
}
