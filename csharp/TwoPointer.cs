namespace Algorithms.TwoPointer; //pattern type

// https://leetcode.com/problems/trapping-rain-water/
// https://neetcode.io/problems/trapping-rain-water/
public class TrappingRainWater
{
    // Notes:
    // input: height = [0,1,0,2,1,0,1,3,2,1,2,1] = 6
    // input: height = [4,2,0,3,2,5] = 9

    // when water is trapped?:
    // when we find 2 extreme non consecutives values that are greater 
    // than inside values

    // how much water is trapped? 
    // lower bar extreme - [n-inside values]
    //iterate array twice moving internal j value
    //until we found 2 non consecutive extremes with lower values inside
    //sum total watter trapped
    public int TrapBruteForce(int[] heights)
    {
        int[] h = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];

        int totalW = 0;
        int trappedW = 0;
        for (int i = 0; i < h.Length; i++)
        {
            int leftB = h[i];
            int rightB = -1;

            if (leftB == 0) continue;
            else
            {
                for (int j = i + 1; j < h.Length; j++)
                {

                    if (leftB > h[j])
                    {
                        trappedW += Math.Min(leftB, h[j]) - h[j]; // sum possible contained watter
                    }
                    else
                    {
                        //found right border                    
                        if (trappedW > 0)
                        {
                            totalW += trappedW;
                            trappedW = 0;
                            i = j - 1;
                            rightB = h[j]; // found right border                            
                        }
                        break;
                    }

                }
            }

            //add break condition for when no right border is found                        
            if (rightB == -1 && i == h.Length -1) // no right border found
            {
                break;
            }
        }
        return totalW;
    }

    public int TrapWithHashSet(int[] heights = default!)
    {
        // this algorithm solutions has a time complexity of 
        // O(n^2) + O(n) = O(n^2)
        // and a space complexity of O(1)

        int[] h = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];

        int totalW = 0;
        HashSet<Tuple<int, int>> borders = new HashSet<Tuple<int, int>>();

        for (int i = 0; i < h.Length; i++){
            int leftB = h[i];
            if (leftB == 0) continue;
            else
            {
                for (int j = i + 1; j < h.Length; j++)
                { 
                    if (h[j] >= leftB)
                    {
                        borders.Add(new Tuple<int, int>(i, j));
                        i = j-1;
                        break;
                    }
                }
            }
        }

        for (int i = 0; i < borders.Count; i++)
        {
            Tuple<int, int> border = borders.ElementAt(i);
            int leftB = h[border.Item1];
            int rightB = h[border.Item2];
            int trappedW = 0;
            for (int j = border.Item1 + 1; j < border.Item2; j++)
            {
                trappedW += Math.Min(leftB, rightB) - h[j];
            }
            totalW += trappedW;
        }
        
        //return total watter
        return totalW;
    }

    public void run()
    {
        var trw = new TrappingRainWater();

        List<Tuple<int[], int>> inputs = new List<Tuple<int[], int>>
    {
        Tuple.Create(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6),
        Tuple.Create(new int[] { 4, 2, 0, 3, 2, 5 }, 9)
    };

        //run all inputs
        for (int i = 0; i < inputs.Count; i++)
        {
            Console.WriteLine($"Input:[{string.Join(",", inputs[i].Item1)}] Result: {inputs[i].Item2} \n");
            //run each function 
            Console.WriteLine($"TrapBruteForce Method Result: " + trw.TrapBruteForce(inputs[i].Item1) + "\n");
            Console.WriteLine($"TrapBruteForce Method Result: " + trw.TrapWithHashSet(inputs[i].Item1) + "\n");
        }
    }
}