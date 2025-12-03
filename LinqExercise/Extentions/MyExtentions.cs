using LinqExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise.Extentions
{
	public static class MyExtentions
	{
		public static void TalIsTheBest<T>(this IComparable<T> comparer)
		{
			Console.WriteLine("Tal Simon is the best!");
		}

		public static void YudAlef<T>(this IEnumerable<T> list)
		{
			Console.WriteLine("Yud Alef 10 Metro West is the best Megama ever!");
		}
		public static int MaxBy<T>(this IEnumerable<T> lst, Func<T, int> parameter)
		{
			int max = int.MinValue;
			foreach (var item in lst)
			{
				max = Math.Max(max, parameter(item));
			}
			return max;
        }
	}
}
