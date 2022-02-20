using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffmanovo_kódování
{
	public static class Dictionary
	{
		public static Dictionary<int, long> dictionary = new Dictionary<int, long>();
		internal static void AddToDictionary(long[] readArray)
		{
			for (int i = 0; i < readArray.Length; i++)
			{
				if (readArray[i]!=0) { dictionary.Add(i, readArray[i]); }
			}
		}
	}
}
