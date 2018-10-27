using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class FrogRiverOne {

		public int solution1( int X, int[] A ) {

			var set = new HashSet<int>();
			
			for( var i = 0; i < A.Length; i++ ) {
				set.Add( A[i] );
				if( set.Count == X ) return i;
			}
			
			return -1;
		}

		// A bit more efficient solution
		public int solution2( int X, int[] A ) {

			var positions = new BitArray(1 + X);
			var acc = ( X + 1 ) * X / 2;

			for( int i = 0; i < A.Length; i++ ) {

				if( positions[A[i]] ) continue;

				positions[A[i]] = true;
				acc -= A[i];

				if( acc == 0 ) return i;
			}

			return -1;
		}


		[Theory]
		[InlineData( 6, 5, new[] { 1, 3, 1, 4, 2, 3, 5, 4 } )]
		public void Test1( int expected, int x, int[] input ) => Assert.Equal( expected, solution1( x, input ) );

		[Theory]
		[InlineData( 6, 5, new[] { 1, 3, 1, 4, 2, 3, 5, 4 } )]
		public void Test2( int expected, int x, int[] input ) => Assert.Equal( expected, solution2( x, input ) );

	}
}
