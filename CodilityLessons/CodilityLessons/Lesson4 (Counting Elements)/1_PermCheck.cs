using System.Collections;
using Xunit;

namespace CodilityLessons {

	public sealed class PermCheck {

		public int solution( int[] A ) {

			var acc = new BitArray( A.Length + 1 );

			foreach( var item in A ) {
				if( item < 1 || item > A.Length ) return 0;
				if( acc[item] ) return 0;

				acc[item] = true;
			}

			return 1;

		}

		[Theory]
		[InlineData( 1, new[] { 4, 1, 3, 2 } )]
		[InlineData( 0, new[] { 4, 1, 3 } )]
		[InlineData( 0, new[] { 1, 1, 1 } )]	
		public void Test( int expected, int[] input ) => Assert.Equal( expected, solution( input ) );

	}
}
