using System;

namespace ExprSolver
{
	class Program
	{
		static void Main()
		{
			Evaluator eval = new Evaluator();
			string[] expr = Reader.ReadExpr();
			if(eval.isLegit(expr)) 
			{
				eval.createList(expr);
				Console.WriteLine(eval.EvalateExprWithStack()); 
			}
			else { Console.WriteLine("Format Error"); }
		}
	}
}
