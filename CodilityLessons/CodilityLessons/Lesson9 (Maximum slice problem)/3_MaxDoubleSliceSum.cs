using System;
using Xunit;

namespace CodilityLessons {

	public sealed class MaxDoubleSliceSum {

		public int solution( int[] A ) {

			var length = A.Length;

			A[0] = A[length - 1] = 0;

			var left2right = new long[length];
			var right2left = new long[length];

			for( int i = 1; i < length; i++ )
				left2right[i] = Math.Max( 0, left2right[i - 1] + A[i] );

			for( int i = length - 2; i > 0; i-- )
				right2left[i] = Math.Max( 0, right2left[i + 1] + A[i] );

			var result = long.MinValue;
			for( int i = 1; i < length - 1; i++ ) 
				result = Math.Max( result, left2right[i - 1] + right2left[i + 1] );
			
			return (int)result;
		}


		[Theory]
		[InlineData( 17, new[] { 3, 2, 6, -1, 4, 5, -1, 2 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}