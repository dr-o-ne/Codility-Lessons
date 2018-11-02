using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class StoneWall {

		public int solution( int[] H ) {

			var result = 0;
			var stack = new Stack<int>();

			foreach( var item in H ) {
				while( stack.Count != 0 && stack.Peek() > item )
					stack.Pop();
				if( stack.Count != 0 && stack.Peek() == item )
					continue;
				stack.Push( item );
				result++;
			}

			return result;
		}

		[Theory]
		[InlineData( 2, new[] { 1, 2, 1 } )]
		[InlineData( 1, new[] { 3 } )]
		[InlineData( 1, new[] { 3, 3 } )]
		[InlineData( 2, new[] { 2, 4 } )]
		[InlineData( 2, new[] { 4, 2 } )]
		[InlineData( 7, new[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 } )]
		public void Test( int expected, int[] h ) => Assert.Equal( expected, solution( h ) );

	}

}
