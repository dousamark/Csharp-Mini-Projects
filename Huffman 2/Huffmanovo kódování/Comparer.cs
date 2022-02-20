using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Huffmanovo_kódování
{
	class Comparer : IComparer<HuffmanNode>
	{
		public int Compare( HuffmanNode x, HuffmanNode y)
		{
			if (x.count.CompareTo(y.count) != 0)
			{
				return x.count.CompareTo(y.count);
			}
			else if (x.symbol.CompareTo(y.symbol) != 0)
			{
				return (x.symbol.CompareTo(y.symbol));
			}
			else
			{
				return (x.round.CompareTo(y.round));
			}
		}
	}
}
