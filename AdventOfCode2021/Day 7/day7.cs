//You've got crabs!
//You have a list of the horizontal positions of each crab
//Which horizontal postion is the closest to all of them?
//And how much "fuel" would it cost to move all the crabs there?
//TODO: Find average (median?), compute sum, steal code from penguin
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home
{
	class day7
	{
		static List<int> input = File.ReadAllText("input").Split(',').Select(int.Parse).ToList();
		static void Main(string[] args)
		{
			//? Part 1 Steps(?) 1. Find average 2. Round to nearest int 3. Compute sum of differences
			//// Finding the average didn't work. Maybe try median?
			//* Median worked!

			//input.Sort();
			//int med = input[(input.Count() - 1) / 2];
			//int sum = 0;
			//foreach (int n in input)
			//{
			//	sum += Math.Abs(med - n);
			//}
			//Console.WriteLine(sum);
			//! End of part 1

			//? Part 2
			//Instead, each change of 1 step in horizontal position costs 1 more unit 
			//of fuel than the last: the first step costs 1, the second step costs 2, 
			//the third step costs 3, and so on.
			//? Why must you hurt me this way?

			input.Sort();//Perhaps I need coffee, but the only way I can think of is brute force
		}
	}
}