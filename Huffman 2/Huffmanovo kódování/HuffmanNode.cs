using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace Huffmanovo_kódování
{
	class HuffmanNode
	{
		public HuffmanNode left;
		public HuffmanNode right;
		public int round;
		public int symbol;
		public long count;
		public string encoding;
		public HuffmanNode(HuffmanNode leftSon, HuffmanNode rightSon, int round, int symbol,long count)
		{
			this.left = leftSon;
			this.right = rightSon;
			this.round = round;
			this.symbol = symbol;
			this.count = count;
		}
	}
}
