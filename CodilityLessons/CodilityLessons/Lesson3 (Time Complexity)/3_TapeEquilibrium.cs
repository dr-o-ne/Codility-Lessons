using System;
using System.Linq;
using Xunit;

namespace CodilityLessons {

	public sealed class TapeEquilibrium {

		public int solution( int[] A ) {

			long result = long.MaxValue;

			long acc1 = 0;
			long acc2 = A.Sum();



			for( int index = 0; index < A.Length - 1; index++ ) {
				int item = A[index];
				acc1 += item;
				acc2 -= item;

				result = Math.Min( result, Math.Abs( acc1 - acc2 ) );
			}

			return (int)result;

		}

		[Theory]
		[InlineData( 2000, new[] { -1000, 1000 } )]
		[InlineData( 1, new[] { 3, 1, 2, 4, 3 } )]
		public void Test( int expected, int[] input ) => Assert.Equal( expected, solution( input ) );

	}

}
