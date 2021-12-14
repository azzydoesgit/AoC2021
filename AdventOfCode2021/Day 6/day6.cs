using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace home
{
	public class day6
	{
		static string input = "1,3,3,4,5,1,1,1,1,1,1,2,1,4,1,1,1,5,2,2,4,3,1,1,2,5,4,2,2,3,1,2,3,2,1,1,4,4,2,4,4,1,2,4,3,3,3,1,1,3,4,5,2,5,1,2,5,1,1,1,3,2,3,3,1,4,1,1,4,1,4,1,1,1,1,5,4,2,1,2,2,5,5,1,1,1,1,2,1,1,1,1,3,2,3,1,4,3,1,1,3,1,1,1,1,3,3,4,5,1,1,5,4,4,4,4,2,5,1,1,2,5,1,3,4,4,1,4,1,5,5,2,4,5,1,1,3,1,3,1,4,1,3,1,2,2,1,5,1,5,1,3,1,3,1,4,1,4,5,1,4,5,1,1,5,2,2,4,5,1,3,2,4,2,1,1,1,2,1,2,1,3,4,4,2,2,4,2,1,4,1,3,1,3,5,3,1,1,2,2,1,5,2,1,1,1,1,1,5,4,3,5,3,3,1,5,5,4,4,2,1,1,1,2,5,3,3,2,1,1,1,5,5,3,1,4,4,2,4,2,1,1,1,5,1,2,4,1,3,4,4,2,1,4,2,1,3,4,3,3,2,3,1,5,3,1,1,5,1,2,2,4,4,1,2,3,1,2,1,1,2,1,1,1,2,3,5,5,1,2,3,1,3,5,4,2,1,3,3,4";
		//Fuck you, it wouldn't work otherwise.
		static void Main(string[] args)
		{
			//I have to write the boilerplate because I don't know how to use LinQ
			List<string> stick = input.Split(',').ToList();
			List<ulong> fish = new List<ulong>();
			for (int i = 0; i < 9; i++)//Look at this fucking bullshit. Counts occurrences of each number, puts it at that index of List<ulong> fish
			{
				string str = i.ToString();
				fish.Add((ulong)stick.FindAll(x => x.Equals(str)).Count());
			}
			//* Actual code below! Change numDays to see growth
			int numDays = 256;

			for (int i = 0; i < numDays; i++)
			{
				ulong[] dummyList = fish.ToArray();//Reference types sure are annoying...
				for (int j = 0; j < 6; j++)
				{
					fish[j] = dummyList[j + 1];// handles past ages 1-5
				}
				fish[6] = dummyList[7] + dummyList[0];//Age 7 moves to 6, ages 0 moves to six
				fish[7] = dummyList[8];
				fish[8] = dummyList[0];
			}
			Console.WriteLine("Days: " + numDays + "  Fish: " + addUlong(fish));
		}

		static ulong addUlong(List<ulong> list)
		{
			ulong u = new ulong();
			u = 0;
			foreach (ulong uwu in list)
			{
				u += uwu;
			}
			return u;
		}
	}
}