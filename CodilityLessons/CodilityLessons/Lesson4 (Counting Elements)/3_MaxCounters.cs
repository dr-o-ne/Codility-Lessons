using System;
using Xunit;

namespace CodilityLessons {

	public sealed class MaxCounters {

		public int[] solution( int N, int[] A ) {

			var acc = new int[N];
			var min = 0;
			var max = 0;

			for( int i = 0; i < A.Length; i++ ) {
				var operation = A[i] - 1;
				if( operation == N ) 
					min = max;
				else {
					acc[operation] = Math.Max( min, acc[operation] ) + 1;
					max = Math.Max( max, acc[operation] );
				}
			}

			for( int index = 0; index < acc.Length; index++ )
				acc[index] = Math.Max( acc[index], min );

			return acc;
		}

		[Theory]
		[InlineData( new[] { 3, 2, 2, 4, 2 }, new[] { 3, 4, 4, 6, 1, 4, 4 }, 5 )]
		public void Test( int[] expected, int[] operations, int length ) => Assert.Equal( expected, solution( length, operations ) );

	}

}