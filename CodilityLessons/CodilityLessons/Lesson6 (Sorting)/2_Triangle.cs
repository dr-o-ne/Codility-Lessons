using System;
using Xunit;

namespace CodilityLessons {

	public sealed class Triangle {

		public int solution( int[] A ) {

			Array.Sort( A );

			for( int i = 0; i < A.Length - 2; i++ )
				if( A[i + 2] - A[i + 1] < A[i] ) // the same as A[i+2] < A[i+1] + A[i] but prevents overflow
					return 1;

			return 0;

		}

		[Theory]
		[InlineData( 0, new[] { 10, 50, 5, 1 } )]
		[InlineData( 1, new[] { 10, 2, 5, 1, 8, 20 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}