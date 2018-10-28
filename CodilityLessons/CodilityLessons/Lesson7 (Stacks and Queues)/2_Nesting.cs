using Xunit;

namespace CodilityLessons {

	public sealed class Nesting {

		/// <summary>
		/// Special case of Brackets problem, but for this case no need to create a stack. Just need to check "stack" size 
		/// </summary>
		public int solution( string S ) {

			var acc = 0;

			foreach( var item in S ) {

				if( item == '(' )      acc++;
				else if( item == ')' ) acc--;

				if( acc < 0 )
					return 0;
			}

			return acc == 0 ? 1 : 0;
		}

		[Theory]
		[InlineData( 0, "())" )]
		[InlineData( 1, "(()(())())" )]
		public void Test( int expected, string input ) => Assert.Equal( expected, solution( input ) );

	}

}
