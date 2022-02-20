using System;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Huffmanovo_kódování_testy")]

namespace Huffmanovo_kódování
{
	class Program
	{
		static void Main(string[] args)
		{
			if (ArgsValidization.ArgsValid(args))
			{
				Processor.ProcessData(args);
			}
		}
		/*[TestClass]
			public class MSTest
			{
				[TestMethod]
				public void NotRightLength()
				{
					//arrange
					string[] args = { "simple.in", "simple.in" };
					//act
					bool TestValidityOutput = ArgsValidization.ArgsValid(args);
					//assert
					Assert.AreEqual(false, TestValidityOutput);
				}
				[TestMethod]
				public void NotExistingFile()
				{
					//arrange
					string[] args = { "neexistuje.in" };
					//act
					bool TestValidityOutput = ArgsValidization.ArgsValid(args);
					//assert
					Assert.AreEqual(false, TestValidityOutput);
				}
				[TestMethod]
				public void RightLenghtAndExistingFile()
				{
					//arrange

					string[] args = { "Test data\\simple.in" };
					//act
					bool TestValidityOutput = ArgsValidization.ArgsValid(args);
					//assert
					Assert.AreEqual(true, TestValidityOutput);
				}
			}*/
	}
}
