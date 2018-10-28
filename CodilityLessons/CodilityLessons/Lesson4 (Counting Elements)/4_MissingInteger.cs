using System.Collections;
using Xunit;

namespace CodilityLessons {

	public sealed class MissingInteger {

		public int solution( int[] A ) {

			var n = A.Length;
			var acc = new BitArray( n + 1 );

			foreach( int item in A )
				if( item >= 0 && item <= n )
					acc[item] = true;

			for( int i = 1; i < n + 1; i++ )
				if( acc[i] == false )
					return i;

			return n + 1;
		}

		[Theory]
		[InlineData( new[] { 1 }, 2 )]
		[InlineData( new[] { 2 }, 1 )]
		[InlineData( new[] { 1, 3, 6, 4, 1, 2 }, 5 )]
		public void Test( int[] input, int expected ) => Assert.Equal( expected, solution( input ) );

	}

}