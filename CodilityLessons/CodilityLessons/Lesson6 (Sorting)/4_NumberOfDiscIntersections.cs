using System;
using Xunit;

namespace CodilityLessons {

	public sealed class NumberOfDiscIntersections {

		public int solution( int[] A ) {

			var n = A.Length;

			var start = new long[A.Length];
			var end = new long[A.Length];

			for( long i = 0; i < n; i++ ) {
				start[Math.Max( 0, i - A[i] )]++;		// compress -->
				end[Math.Min( n - 1, i + A[i] )]++;		// compress <--
			}

			long value = 0;
			long result = 0;

			for( long i = 0; i < n; i++ ) {

				result += value * start[i];
				result += ( start[i] - 1 ) * start[i] / 2;

				value += start[i];
				value -= end[i];

				if( result > 10000000 )
					return -1;
			}

			return (int)result;

		}

		[Theory]
		[InlineData( 4, new[] { 0, 0, 2, 0, 0 } )]
		[InlineData( 11, new[] { 1, 5, 2, 1, 4, 0 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}
