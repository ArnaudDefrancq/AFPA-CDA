using TestUnitaireCalculatrice.Class;

namespace Tests
{
	public class UnitTest1
	{
		public class ParserTest
		{
			[Theory]
			[InlineData("1")]
			[InlineData("1+2")]
			[InlineData(" 1 + 2")]
			[InlineData("1+2*3")]
			[InlineData("0.1")]
			[InlineData("(1 + 2) * 3")]
			[InlineData("1 * (2 + 3)")]
			[InlineData("1+-2")]
			[InlineData("1.")]
			[InlineData(".2")]
			[InlineData("1 + ---3")]
			public void AcceptedExpression(string value)
			{
				Parser p = new Parser();
				Assert.True(p.ParseInput(value));
			}

			[Theory]
			[InlineData("1+*2")]
			[InlineData("1++1")]
			[InlineData("1**2")]
			[InlineData("()")]
			public void RefusedExpression(string value)
			{
				Parser p = new Parser();
				Assert.False(p.ParseInput(value));
			}
		}
	}
}