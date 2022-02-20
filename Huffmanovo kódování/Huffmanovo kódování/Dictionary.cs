using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffmanovo_kódování
{
	public static class Dictionary
	{
		public static Dictionary<int, long> dictionary = new Dictionary<int, long>();
		internal static void AddToDictionary(int oneByte)
		{
			if (dictionary.ContainsKey(oneByte)) { dictionary[oneByte]++; }
			else { dictionary.Add(oneByte, 1); }
		}
	}
}
