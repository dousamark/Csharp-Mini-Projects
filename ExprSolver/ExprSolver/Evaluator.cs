using System;
using System.Collections.Generic;
using System.Text;

namespace ExprSolver
{

	class Evaluator
	{
		public Symbol[] expr;



		internal void createList(string[] StringExpr)
		{
			expr = new Symbol[StringExpr.Length];
			for (int i = 0; i < expr.Length; i++)
			{
				if (isNumber(StringExpr[i]))
				{
					expr[i] = new Number(int.Parse(StringExpr[i]));
				}
				else
				{
					expr[i] = new Operator(char.Parse(StringExpr[i]));
				}
			}
		}

		internal bool isLegit(string[] expr)
		{
			foreach(string op in expr)
			{
				if (!isNumber(op))
				{
					if (!isOperand(op))
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool isOperand(string op)
		{
			if (op.Length != 1) { return false; }
			char c = char.Parse(op);
			if (c == '+' || c == '-' || c == '*' || c == '/' || c == '~')
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		internal bool isNumber(string num)
		{
			if (int.TryParse(num, out _)) { return true; }
			else { return false; }
		}
		internal string EvalateExprWithStack()
		{
			Stack<int> Stack = new Stack<int>();

			for (int j = expr.Length - 1; j >= 0; j--)
			{
				//if its a number
				if (expr[j] is Number)
				{
					//creating holder only for functional purposes
					Number num = (Number)expr[j];

					//if previous symbol is ~  then number is negative
					if (expr[j-1] is Operator)
					{
						Operator op = (Operator)expr[j-1];
						if(op.op == '~')
						{
							Stack.Push(num.number*(-1));
							j--;
						}
						else { Stack.Push(num.number); }
					}
					else { Stack.Push(num.number); }
				}

				else
				{
					// Operator encountered 
					// Pop two elements from Stack 
					int o1 = Stack.Peek();
					Stack.Pop();
					int o2 = Stack.Peek();
					Stack.Pop();

					//creating holder only for functional purposes
					Operator op = (Operator)expr[j];
					switch (op.op)
					{
						case '+':
							try
							{
								Stack.Push(checked(o1 + o2));
							}
							catch (OverflowException)
							{
								return "Overflow Error";
							}
							break;

						case '-':
							try
							{
								Stack.Push(checked(o1 - o2));
							}
							catch (OverflowException)
							{
								return "Overflow Error";
							}
							break;
						case '*':
							try
							{
								Stack.Push(checked(o1 * o2));
							}
							catch (OverflowException)
							{
								return "Overflow Error";
							}
							break;
						case '/':
							if (o2 == 0) { return "Divide Error"; }
							Stack.Push(o1 / o2);
							break;
						default:
							break;
					}
				}
			}

			//contains only the result
			if (Stack.Count == 1)
			{
				return Stack.Peek().ToString();
			}
			else
			{
				return "Format Error";
			}
			
		}
	}
}
