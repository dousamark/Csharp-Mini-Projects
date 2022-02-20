using System;
using System.Collections.Generic;
using System.Text;

namespace ExprSolver
{
	class Number : Symbol
	{
		public int number;
		public Number(int v)
		{
			this.number = v;
		}
	}
}
