using System;
using Xunit;

namespace CodilityLessons {

	public sealed class MaxProductOfThree {

		public int solution( int[] A ) {

			int n = A.Length;
			Array.Sort( A );

			return Math.Max(
				A[0] * A[1] * A[n - 1],
				A[n - 1] * A[n - 2] * A[n - 3]
			);
		}

		[Theory]
		[InlineData( 60, new[] { -3, 1, 2, -2, 5, 6 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}