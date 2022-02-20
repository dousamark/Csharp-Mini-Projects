using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffmanovo_kódování
{
	internal class HuffmanTree
	{
		public SortedSet<HuffmanNode> NodeSet;

		public HuffmanTree()
		{
			NodeSet = new SortedSet<HuffmanNode>(new Comparer());
		}

		internal void PrintTreeByPrefix(HuffmanNode root)
		{
			if (root.symbol == 256)
			{
				Console.Write(root.count);
			}
			else
			{
				Console.Write("*" + root.symbol + ":" + root.count);
			}
			Console.Write(" ");

			//staci kontrolovat pouze jeden, protoze ma vzdy bud 2 nebo 0 synu
			if (root.left != null)
			{
				PrintTreeByPrefix(root.left);
				PrintTreeByPrefix(root.right);
			}
		}

		internal void Encode(string OutputFileName)
		{
			Creator creator = new Creator(OutputFileName,NodeSet);
			creator.EncodeTreeToFile();
		}

		internal void BuildTree()
		{
			int rounds = 1;
			while (NodeSet.Count > 1)
			{
				HuffmanNode firstNode = NodeSet.First();
				NodeSet.Remove(firstNode);
				HuffmanNode secondNode = NodeSet.First();
				NodeSet.Remove(secondNode);

				//do spojenych pridavam do symbolu hodnotu 256 pro rozliseni od listu protoze symbol bude maximalne 255
				HuffmanNode mergedNode = new HuffmanNode(firstNode, secondNode, rounds, 256, firstNode.count + secondNode.count);
				NodeSet.Add(mergedNode);

				rounds++;
			}
		}

		internal void AddNodes()
		{
			for (int i = 0; i < Dictionary.dictionary.Count; i++)
			{
				NodeSet.Add(new HuffmanNode(null, null, 0, Dictionary.dictionary.ElementAt(i).Key, Dictionary.dictionary.ElementAt(i).Value));
			}
		}
	}
}