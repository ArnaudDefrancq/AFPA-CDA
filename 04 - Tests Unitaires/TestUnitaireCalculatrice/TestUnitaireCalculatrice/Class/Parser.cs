using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestUnitaireCalculatrice.Class
{
	#region
	//public class Parser
	//{

	//	protected string[]? tokens;
	//	protected int pos;
	//	protected Stack<int> memory;
	//	protected Stack<int> stateStack;
	//	protected Stack<ASTree> forest;


	//	public Parser()
	//	{
	//		this.memory = new Stack<int>();
	//		this.stateStack = new Stack<int>();
	//		this.forest = new Stack<ASTree>();
	//	}


	//	//public static ASTree? Parse(string input)
	//	//{
	//	//	Parser p = new Parser();

	//	//	if (p.ParseInput(input))
	//	//	{
	//	//		// return AST
	//	//		return ASTree p = new ASTree();
	//	//	}
	//	//	else
	//	//	{
	//	//		return null;
	//	//	}
	//	//}

	//	// 30 + 2 * 5
	//	// ou
	//	// (3 + 2) * 5

	//	protected bool HasToken() // Permet de savoir si il y a un token
	//	{
	//		return this.tokens != null && this.pos < this.tokens.Length;
	//	}

	//	protected string Token()
	//	{
	//		if (this.HasToken())
	//		{
	//			return this.tokens[this.pos];
	//		}

	//		return string.Empty;
	//	}

	//	protected void NextToken()
	//	{
	//		if (this.HasToken())
	//		{
	//			this.pos++;
	//		}
	//	}

	//	public bool ParseInput(string input)
	//	{
	//		string regexp = @"\s*(\+|\*|-|/|%|\(|\))\s*";
	//		this.tokens = Regex.Split(input.Trim(), regexp)
	//						.Where(c => c != String.Empty).ToArray();
	//		this.pos = 0;

	//		return this.Arith_Expr();
	//	}


	//	protected bool Arith_Expr()
	//	{
	//		return this.End_Arith_Expr(this.Term());
	//	}

	//	protected bool End_Arith_Expr(bool hasTerm)
	//	{
	//		if (!hasTerm)
	//		{
	//			return false;
	//		}

	//		string token = this.Token();

	//		if (token == "+" || token == "-")
	//		{

	//			this.NextToken();
	//			return this.Arith_Expr();
	//		}

	//		return true;
	//		/*
	//		  switch(token){
	//			case '+':
	//			case '-':
	//			  this.NextToken();
	//			  return this.Arith_Expr();
	//			  break;
	//			default:
	//			  return true;
	//			  break;
	//		  }
	//		*/
	//	}

	//	protected bool Term()
	//	{
	//		return this.End_Term(this.Unary_Minus());
	//	}

	//	protected bool End_Term(bool hasUnaryMinus)
	//	{
	//		if (!hasUnaryMinus)
	//		{
	//			return false;
	//		}

	//		string token = this.Token();

	//		if (token == "*" || token == "/" || token == "%")
	//		{
	//			this.NextToken();
	//			return this.Term();
	//		}

	//		return true;
	//	}

	//	protected bool Unary_Minus()
	//	{
	//		string token = this.Token();

	//		if (token == "-")
	//		{
	//			this.NextToken();
	//			return this.Unary_Minus();
	//		}

	//		return this.Factor();
	//	}

	//	protected bool Factor()
	//	{
	//		string token = this.Token();

	//		if (token == "(")
	//		{
	//			this.NextToken();
	//			bool retour = this.Arith_Expr();
	//			if (retour && this.Token() == ")")
	//			{
	//				this.NextToken();
	//				return true;
	//			}
	//			return false;
	//		}
	//		return this.Numeric();
	//	}
	//	protected bool Numeric()
	//	{
	//		return this.End_Numeric(this.Int_Part());
	//	}

	//	protected bool End_Numeric(bool hasNumeric)
	//	{
	//		if (!hasNumeric)
	//		{
	//			return false;
	//		}

	//		string token = this.Token();

	//		if (token == ".")
	//		{
	//			this.NextToken();
	//			return this.Int_Part();
	//		}

	//		return true;
	//	}

	//	protected bool Int_Part()
	//	{
	//		return this.End_Int_Part(this.Digit());
	//	}

	//	protected bool End_Int_Part(bool hasIntPart)
	//	{
	//		if (!hasIntPart)
	//		{
	//			return false;
	//		}

	//		if (this.Int_Part())
	//		{
	//			this.NextToken();
	//			return this.Int_Part();

	//		}
	//		return true;

	//	}
	//	protected bool Digit()
	//	{
	//		Regex regex = new Regex(@"[0-9]");
	//		string token = this.Token();

	//		if (regex.IsMatch(token))
	//		{
	//			this.NextToken();
	//			return true;
	//		}

	//		return false;
	//	}


	//	/*
	//	// a * x * x + b * x + c
	//	<ARITH_EXPR>      := <TERM> <END_ARITH_EXPR>

	//	// + b * x + c
	//	<END_ARITH_EXPR>  := '+' <ARITH_EXPR>
	//					  := '-' <ARITH_EXPR>
	//					  :=

	//	// b * x
	//	<TERM>            := <UNARY_MINUS> <END_TERM>
	//	<END_TERM>        := '*' <TERM>
	//					  := '/' <TERM>
	//					  := '%' <TERM>
	//					  :=
	//	// -4 ou 4
	//	<UNARY_MINUS>     := '-' <UNARY_MINUS>
	//					  := <FACTOR>

	//	// b ou x
	//	<FACTOR>          := <NUMERIC>
	//					  := '(' <ARITH_EXPR> ')'

	//	// 1 ou 12 ou 1.2 ou 0.1
	//	<NUMERIC>        := <INT_PART> <END_NUMERIC>
	//	<END_NUMERIC>    := '.' <INT_PART>
	//					 :=

	//	<INT_PART>       := <DIGIT> <END_INT_PART>
	//	<END_INT_PART>   := <INT_PART>
	//					 :=

	//	<DIGIT>          := [0-9]
	//	*/


	//}
	#endregion
	public class Parser
	{

		protected string[]? tokens;
		protected int pos;
		protected Stack<int> memory;
		protected Stack<int> stateStack;
		protected Stack<ASTree> forest;

		Parser()
		{
			this.memory = new Stack<int>();
			this.stateStack = new Stack<int>();
			this.forest = new Stack<ASTree>();
		}

		public static ASTree? Parse(string input)
		{
			Parser p = new Parser();

			if (p.ParseInput(input))
			{
				return this.forest.Pop();
			}
			else
			{
				return null;
			}
		}

		// 30 + 2 * 5
		// ou
		// (3 + 2) * 5

		protected bool HasToken()
		{
			return this.tokens != null && this.pos < this.tokens.Length;
		}

		protected string Token()
		{
			if (this.HasToken())
			{
				return this.tokens[this.pos];
			}

			return string.Empty;
		}

		protected void NextToken()
		{
			if (this.HasToken())
			{
				this.pos++;
			}
		}

		public bool ParseInput(string input)
		{
			string regexp = @"\s*(\+|\*|-|/|%|\(|\))\s*";
			this.tokens = Regex.Split(input.Trim(), regexp)
							.Where(c => c != String.Empty).ToArray();
			this.pos = 0;

			return this.Arith_Expr();
		}


		// a * x * x + b * x + c
		// <ARITH_EXPR>      := <TERM> <END_ARITH_EXPR>
		protected bool Arith_Expr()
		{
			return this.End_Arith_Expr(this.Term());
		}

		// + b * x + c
		// <END_ARITH_EXPR>  := '+' <ARITH_EXPR>
		//                   := '-' <ARITH_EXPR>
		//                   :=
		protected bool End_Arith_Expr(bool hasTerm) // Reste plus que ca
		{
			if (!hasTerm)
			{
				return false;
			}

			string token = this.Token();

			if (token == "+" || token == "-")
			{
				ASTree rightChild = this.forest.Pop();
				ASTree leftChild = this.forest.Pop();
				this.forest.Push(new ASTree(ASType.BINARYOP, token, new List<ASTree>() { leftChild, rightChild }));// Ajouter test pour verifier l'arbre
				this.NextToken();
				return this.Arith_Expr();
			}

			return true;
			/*
			  switch(token){
				case "+":
				case "-":
				  this.NextToken();
				  return this.Arith_Expr();
				  break;
				default:
				  return true;
				  break;
			  }
			*/
		}

		// b * x
		// <TERM>            := <UNARY_MINUS> <END_TERM>
		protected bool Term()
		{
			return this.End_Term(this.Unary_Minus());
		}

		// <END_TERM>        := '*' <TERM>
		//                   := '/' <TERM>
		//                   := '%' <TERM>
		//                   :=
		protected bool End_Term(bool hasMinus)
		{
			if (!hasMinus)
			{
				return false;
			}

			string token = this.Token();
			if (token == "*" || token == "/" || token == "%")
			{
				this.NextToken();
				if (this.Term())
				{
					ASTree rightChild = this.forest.Pop();
					ASTree leftChild = this.forest.Pop();
					this.forest.Push(new ASTree(ASType.BINARYOP, token, new List<ASTree>() { leftChild, rightChild }));// Ajouter test pour verifier l'arbre
					return true;
				}
				return this.Term();
			}
			return true;
		}

		// -4 ou 4
		// <UNARY_MINUS>     := '-' <UNARY_MINUS>
		//                   := <FACTOR>
		protected bool Unary_Minus()
		{
			if (this.Token() == "-")
			{
				this.Memorize();
				this.NextToken();
				if (this.Unary_Minus())
				{
					ASTree leftChlid = this.forest.Pop();
					this.forest.Push(new ASTree(ASType.UNARYOP, "-", new List<ASTree>() { leftChlid }));
					return this.Unary_Minus();
				}
				this.Recall();
			}

			return this.Factor();
		}

		// b ou x
		// <FACTOR>          := <NUMERIC>
		//                   := '(' <ARITH_EXPR> ')'
		protected bool Factor()
		{
			if (this.Token() == "(")
			{
				this.NextToken();
				bool retour = this.Arith_Expr();
				if (retour && this.Token() == ")")
				{
					this.NextToken();
					return true;
				}
				// TO SEE
				return false;
			}

			return this.Numeric();
		}


		// 1 ou 12 ou 1.2 ou 0.1
		// <NUMERIC>        := <INT_PART> <END_NUMERIC>
		// <END_NUMERIC>    := '.' <INT_PART>
		//                  :=
		// <INT_PART>       := <DIGIT> <END_INT_PART>
		// <END_INT_PART>   := <INT_PART>
		//                  :=
		// <DIGIT>          := [0-9]
		protected bool Numeric()
		{
			if (Regex.IsMatch(this.Token(), @"^[0-9]+(\.[0-9]*)?|\.[0-9]+$"))
			{
				ASTree numeric = new ASTree(ASType.NUMERIC, this.Token());
				this.NextToken();
				this.forest.Push(numeric);
				return true;
			}

			return false;
		}

		protected void Memorize()
		{
			this.memory.Push(this.pos);
			this.stateStack.Push(this.forest.Count);
		}

		protected void Recall()
		{
			this.pos = this.memory.Pop();
			int state = this.stateStack.Pop();
			while (this.forest.Count > state)
			{
				this.forest.Pop();
			}

		}
	}
}
