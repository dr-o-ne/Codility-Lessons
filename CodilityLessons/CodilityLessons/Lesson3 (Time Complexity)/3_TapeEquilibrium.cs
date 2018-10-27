using System;
using System.Linq;
using Xunit;

namespace CodilityLessons {

	public sealed class TapeEquilibrium {

		public int solution( int[] A ) {

			int result = int.MaxValue;

			int acc1 = 0;
			int acc2 = A.Sum();

			for( int index = 0; index < A.Length - 1; index++ ) {
				acc1 += A[index];
				acc2 -= A[index];

				result = Math.Min( result, Math.Abs( acc1 - acc2 ) );
			}

			return result;
		}

		[Theory]
		[InlineData( 2000, new[] { -1000, 1000 } )]
		[InlineData( 1, new[] { 3, 1, 2, 4, 3 } )]
		public void Test( int expected, int[] input ) => Assert.Equal( expected, solution( input ) );

	}

}