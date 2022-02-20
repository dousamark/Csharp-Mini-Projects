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
				long[] readArray = new long[256];
				while ((OneByte = fs.ReadByte()) != -1)
				{
					readArray[OneByte]++;
				}
				Dictionary.AddToDictionary(readArray);
			}
			HuffmanTree huffmanTree = new HuffmanTree();
			huffmanTree.AddNodes();
			huffmanTree.BuildTree();
			huffmanTree.Encode(args[0]);
		}
	}
}
