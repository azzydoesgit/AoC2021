// Each line of vents is given as a line segment in the format x1,y1 -> x2,y2
//// Potential solution: turn input into a bunch of "line" objects
//// Also, probably go steal some code for parsing the input
//* Done! ^
// TODO: Consider only horizontal and vertical lines. At how many points do at least two lines overlap?
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace home
{
	class day5
	{
		public List<(int x1, int y1, int x2, int y2)> lines = File.ReadLines("input").ToArray().Select(l => Regex.Match(l, @"(\d+),(\d+) -> (\d+),(\d+)"))
			.Select(m => (
				x1: Convert.ToInt32(m.Groups[1].Value), //Stolen from viceroypenguin on github,
				y1: Convert.ToInt32(m.Groups[2].Value), //parses our input into a list of objects,
				x2: Convert.ToInt32(m.Groups[3].Value), //where each object is a line with attributes
				y2: Convert.ToInt32(m.Groups[4].Value)))//x1, y1, x2, and y2, callable with... something
			.ToList();
		static void Main(string[] args)
		{
			day5 part1 = new day5(); //? Part One
			/**Potential steps
			 * 1. Remove all non-straight lines
			 * 1½. Turn it into a list of objects so I can add attributes without fucking things up
			 * 2. Make a list (for each line) of all points a line crosses through
			 * 3. use LINQ to look at each list, group lines by points they share
			 * 4. Count number of groups where the members is greater than 1
			 */
			part1.lines.RemoveAll(x => (x.x1 != x.x2 && x.y1 != x.y2));//Step 1

			//? Part Two. Same code, different criteria for removing lines.
			day5 part2 = new day5();

			part2.lines.RemoveAll(x => (
				x.x1 != x.x2 && x.y1 != x.y2 &&
				Math.Abs(x.x2 - x.x1) != Math.Abs(x.y2 - x.y1))
			);//Keeps lines that are verticle/horizontal, or ones where rise = run (45 deg)

			List<line> lineList = new List<line>();

			for (int i = 0; i < part2.lines.Count; i++)//Step 2 Turns the List part1.lines into a List<line> (objects)
			{
				int[] inLine = { part2.lines[i].x1, part2.lines[i].y1, part2.lines[i].x2, part2.lines[i].y2 };
				lineList.Add(new line(inLine));
			}
			//Can't figure out how to make LinQ work, that's fine, I can make a shitty version
			List<string> uniquePoints = new List<string>();//Why strings? They're not reference types, unlike arrays
			List<string> sharedPoints = new List<string>();//Why strings? They're not reference types, unlike arrays
			foreach (line l in lineList)//! Step 3, works, but takes like 30 seconds to run
			{
				foreach (string point in l.points)
				{
					if (!sharedPoints.Contains(point))//If point is not already known to be shared
					{
						if (!uniquePoints.Contains(point))//If point is unique (so far)
						{
							uniquePoints.Add(point);
						}
						else//Point has been logged, but only once (move to sharedPoints)
						{
							sharedPoints.Add(point);
						}
					}
				}
			}
			Console.WriteLine(sharedPoints.Count());
		}
	}

	class line
	{
		public List<string> points = new List<string>();//Why strings? They're not a reference type
		public line(int[] inLine)//Constructor, makes a List<string> of every point a line hits
		{
			int x1 = inLine[0];
			int x2 = inLine[2];
			int y1 = inLine[1];
			int y2 = inLine[3];
			if (x1 == x2)//Case for verticle lines
			{
				if (y1 < y2)//Case for lines "going" up
				{
					for (int i = y1; i <= y2; i++)
					{
						string point = x1.ToString() + " " + i.ToString();
						this.points.Add(point);
					}
				}
				else//Case for lines "going" down
				{
					for (int i = y1; i >= y2; i--)
					{
						string point = x1.ToString() + " " + i.ToString();
						this.points.Add(point);
					}
				}
			}
			else if (y1 == y2)//Case for horizontal lines
			{
				if (x1 < x2)//Case for lines "going" right
				{
					for (int i = x1; i <= x2; i++)
					{
						string point = i.ToString() + " " + y1.ToString();
						this.points.Add(point);
					}
				}
				else//Case for lines "going left"
				{
					for (int i = x1; i >= x2; i--)
					{
						string point = i.ToString() + " " + y1.ToString();
						this.points.Add(point);
					}
				}
			}
			else//Case for diagonal lines
			{
				int xDir = Math.Sign(x2 - x1);//1 if line is going "up", -1 if it's going "down"
				int yDir = Math.Sign(y2 - y1);//Same
				for (int i = 0; i <= (Math.Abs(x2 - x1)); i++)
				{
					string point = (x1 + (xDir * i)).ToString() + " " + (y1 + (yDir * i)).ToString();
					this.points.Add(point);
				}
			}
		}
	}
}