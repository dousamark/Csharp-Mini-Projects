using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Huffmanovo_kódování
{
	class Processor
	{
		internal static void ProcessData(string[] args)
		{
			using (FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.Read))
			{
				//read bytes till end of file
				int OneByte;
				while ((OneByte = fs.ReadByte()) != -1)
				{
					Dictionary.AddToDictionary(OneByte);
				}
			}
			HuffmanTree huffmanTree = new HuffmanTree();
			huffmanTree.AddNodes();
			huffmanTree.BuildTree();
			huffmanTree.PrintTreeByPrefix(huffmanTree.NodeSet.Last());
		}
	}
}
