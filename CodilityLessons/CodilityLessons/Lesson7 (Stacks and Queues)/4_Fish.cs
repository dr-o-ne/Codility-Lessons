using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class Fish {

		public int solution( int[] A, int[] B ) {

			var n = A.Length;

			var live = 0;
			var upstream = new Stack<int>();
			for( var i = 0; i < n; i++ ) {

				var size = A[i];
				var direction = B[i];

				if( direction == 1 )
					upstream.Push( size );
				else {
					while( upstream.Count > 0 && upstream.Peek() < size )
						upstream.Pop();
					if( upstream.Count == 0 )
						live++;
				}

			}

			return live + upstream.Count;
		}

		[Theory]
		[InlineData( 2, new[] { 4, 3, 2, 1, 5 }, new[] { 0, 1, 0, 0, 0 } )]
		[InlineData( 1, new[] { 42 }, new[] { 1 } )]
		[InlineData( 1, new[] { 42 }, new[] { 0 } )]
		[InlineData( 1, new[] { 6, 3, 2, 1, 5 }, new[] { 1, 1, 0, 0, 0 } )]
		[InlineData( 1, new[] { 3, 2, 1 }, new[] { 1, 0, 0 } )]
		public void Test( int expected, int[] a, int[] b ) => Assert.Equal( expected, solution( a, b ) );

	}
}