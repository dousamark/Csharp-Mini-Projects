using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Huffmanovo_kódování
{
	class Creator
	{
		string OutputFileName;
		SortedSet<HuffmanNode> nodeSet;
		List<HuffmanNode> NodesInPrefix = new List<HuffmanNode>();
		Dictionary<int, string> encodingDictionary = new Dictionary<int, string>();
		public Creator(string OutputFileName, SortedSet<HuffmanNode> nodeSet)
		{
			this.OutputFileName = OutputFileName;
			this.nodeSet = nodeSet;
		}
		public void EncodeTreeToFile()
		{
			WriteHeader();
			WriteTree(nodeSet.Last());
			EncodeData(nodeSet.Last());
		}

		private void EncodeData(HuffmanNode root)
		{
			giveNodesTheirEncoding(root, "");
			InitializeEncodingDictionary();
			LoadBytesAndWriteToOutputFile();
		}

		private void LoadBytesAndWriteToOutputFile()
		{

			using (FileStream fs = new FileStream(OutputFileName, FileMode.Open, FileAccess.Read))
			using (FileStream fsStream = new FileStream(OutputFileName + ".huff", FileMode.Append))
			{
				//read bytes till end of file
				int OneByte;
				StringBuilder loader = new StringBuilder();
				bool FileRead = false;
				while (!FileRead)
				{
					OneByte = fs.ReadByte();

					if (OneByte == -1)
					{
						FileRead = true;
					}
					else
					{
						loader.Append(encodingDictionary[OneByte]);
					}

					if (loader.Length >= 8)
					{
						fsStream.WriteByte(Convert.ToByte(getReversedString(loader), 2));
						loader = loader.Remove(0,8);
					}
				}
				if (loader.Length > 0)
				{
					while (loader.Length < 8)
					{
						loader.Append("0");
					}
					fsStream.WriteByte(Convert.ToByte(getReversedString(loader), 2));
				}
			}
		}

		private string getReversedString(StringBuilder v)
		{
			StringBuilder reversed = new StringBuilder();
			for (int i = 7; i >=0; i--)
			{
				reversed.Append(v[i]);
			}
			return reversed.ToString();
		}

		private void InitializeEncodingDictionary()
		{
			foreach (HuffmanNode node in NodesInPrefix)
			{
				if (node.symbol != 256) { encodingDictionary[node.symbol] = node.encoding; }
			}
		}

		private void giveNodesTheirEncoding(HuffmanNode root, string encoding)
		{
			if (root.symbol != 256) { root.encoding = encoding; }

			if (root.left != null)
			{
				giveNodesTheirEncoding(root.left, encoding + "0");
				giveNodesTheirEncoding(root.right, encoding + "1");
			}
		}

		private void WriteTree(HuffmanNode root)
		{
			getNodesByPrefix(root);

			using (FileStream fsStream = new FileStream(OutputFileName + ".huff", FileMode.Append))
			{
				foreach (HuffmanNode node in NodesInPrefix)
				{
					BitArray bits = writeNode(node);
					byte[] bytes = ConvertBitsToBytes(bits);
					foreach (byte Byte in bytes)
					{
						fsStream.WriteByte(Byte);
					}
				}
				for (int i = 0; i < 8; i++)
				{
					fsStream.WriteByte(0);
				}
			}
		}

		private byte[] ConvertBitsToBytes(BitArray bits)
		{
			//vzdy bude 8
			byte[] bytes = new byte[8];
			bits.CopyTo(bytes, 0);
			return bytes;
		}

		private BitArray writeNode(HuffmanNode node)
		{
			BitArray bitArray = new BitArray(64);

			//pokud se jedna o list nastavime prvni bit na jedna
			if (node.symbol != 256) { bitArray[0] = true; }

			BitArray middleValues = new BitArray(BitConverter.GetBytes(node.count));

			//zbaveni se poslednich 8bitu a nechani volneho mista pro prvni bit
			middleValues.LeftShift(9);
			middleValues.RightShift(8);

			bitArray.Or(middleValues);

			if (node.symbol != 256)
			{
				BitArray endValues = new BitArray(BitConverter.GetBytes((long)node.symbol));

				//posunuti na poslednich 8 bitu
				endValues.LeftShift(56);

				bitArray.Or(endValues);
			}
			return bitArray;
		}

		private void TestHowBitArrayLooks(BitArray bitArray)
		{
			for (int i = 0; i < 32; i++)
			{
				if (bitArray[i]) { Console.Write(1); }
				else { Console.Write(0); }
			}
			Console.WriteLine();
		}

		private void getNodesByPrefix(HuffmanNode root)
		{
			NodesInPrefix.Add(root);
			if (root.left != null)
			{
				getNodesByPrefix(root.left);
				getNodesByPrefix(root.right);
			}
		}

		private void WriteHeader()
		{
			byte[] headerBytes = { 0x7B, 0x68, 0x75, 0x7C, 0x6D, 0x7D, 0x66, 0x66 };
			using (FileStream fsStream = new FileStream(OutputFileName + ".huff", FileMode.Create))
			{
				foreach (byte headerByte in headerBytes)
				{
					fsStream.WriteByte(headerByte);
				}
			}
		}
	}
}
