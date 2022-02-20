using System;
using System.Collections.Generic;
using System.Text;

namespace ExprSolver
{
	class Operator : Symbol
	{
		public char op;
		public Operator(char v)
		{
			this.op = v;
		}
	}
}
