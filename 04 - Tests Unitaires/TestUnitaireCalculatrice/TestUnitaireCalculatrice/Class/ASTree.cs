using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaireCalculatrice.Class
{
	public enum ASType { NUMERIC, BINARYOP, UNARYOP };


	public class ASTree
	{
		public string Root { get; set; }
		public ASType Type { get; set; }
		public List<ASTree>? Children { get; set; }

		public ASTree(ASType type, string root = "", List<ASTree>? children = null) // Ajout compare to pour check les ASTree
		{
			this.Type = type;
			this.Root = root;
			this.Children = children;
		}

		public void AddChild(ASTree son)
		{
			if (this.Children == null)
			{
				Children = new List<ASTree>();
			}

			this.Children.Add(son);
		}

		public bool HasAtLeastChildren(int n = 0)
		{
			if (n == 0)
			{
				return true;
			}

			return this.Children != null && this.Children.Count >= n;
		}

	}

}
