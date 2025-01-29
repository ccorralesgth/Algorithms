using System;

namespace Algorithms.Stacks; // pattern type

//https://neetcode.io/problems/validate-parentheses

public class ValidParentheses
{
	List<Tuple<string,bool>> inputs = new List<Tuple<string,bool>>(){
		Tuple.Create("()",true),
		Tuple.Create("()[]{}",true),
		Tuple.Create("(]",false),
		Tuple.Create("([)]",false),
		Tuple.Create("{[]}",true) ,       
		Tuple.Create("{[[[[]]]]}",true) ,       
		Tuple.Create("{[[[[]]]]",false) ,       
		Tuple.Create("{[[[[]]]])",false), 
		Tuple.Create("[[[[[]]]]]",true) 
	};

	public void run(){

		for (int i = 0; i < inputs.Count; i++)
		{

			Console.WriteLine($"Input: {inputs[i].Item1}  {inputs[i].Item2} | {ValidParenthesesStack(inputs[i].Item1)}");
			
			
		}
	}


	public bool ValidParenthesesBruteForce(string s){
		// validate input
		if (!string.IsNullOrEmpty(s)) return false;
		if (!s[0].Equals("(") || !s[0].Equals("{") || !s[0].Equals("[")) return false;
		if (!s[s.Length].Equals(")") || !s[0].Equals("}") || !s[0].Equals("]")) return false;
		if (s.Length%2 != 0) return false; 
		
		//logic 
		bool isValid = false;
				
		for (int i = 0; i < s.Length; i++)
		{
			bool isOpenFound = false;						
			for (int j = i+1; j < s.Length; j++)
			{
				//if(s[])
				
			}
		}
		
		//return output        
		return isValid;
	}

	public bool ValidParenthesesStack(string s)
	{
		bool isValid = false;

		// validate input
		if (string.IsNullOrEmpty(s)) return isValid;
		if (s.Length%2 != 0) return isValid; 
		if (!"([{".Contains(s[0])) return isValid;
		if (s.Length%2 == 0 && !")]}".Contains(s[s.Length-1]) )return isValid;
		
		//logic 
		Stack<Tuple<char,CharType>> openCharacters = new Stack<Tuple<char,CharType>>();

		for (int i = 0; i < s.Length; i++)
		{
			if (IsAnOpenCharacter(s[i]))
				openCharacters.Push(Tuple.Create(s[i], (CharType)GetChartType(s[i])));
			else
			{
				var popedItem = openCharacters.Pop();
				//if item is not same type
				if (popedItem.Item2 != (CharType)GetChartType(s[i]))
				{
					isValid = false;
					break;
				}
				else 
					isValid = true;
			}
		}

		return isValid;
	}

	public bool IsAnOpenCharacter(char c)
	{		
		return c.Equals('(') || c.Equals('[') || c.Equals('{');
	}
	public bool IsACloseCharacter(char c)
	{
		return c.Equals(')') || c.Equals(']') || c.Equals('}');
	}

	public int GetChartType(char c)
	{		
		if (c.Equals('(') || c.Equals(')')) return 0;
		else if (c.Equals('{') || c.Equals('}')) return 1;
		else if(c.Equals('[') || c.Equals(']')) return 2;
		else return -1;
	}

	public enum CharType {
		Parentheses = 0,
		SquareBrackets,
		CurlyBrace
	}
}
