using System;
using Xunit;

namespace CodilityLessons {

	public sealed class MaxProfit {

		public int solution( int[] A ) {

			long result = int.MinValue;
			long slice = int.MinValue;

			foreach( var item in A ) {
				slice = Math.Max( item, slice + item );
				result = Math.Max( result, slice );
			}

			return (int)result;
		}

		[Theory]
		[InlineData( -10, new[] { -10 } )]
		[InlineData( 5, new[] { 3, 2, -6, 4, 0 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}
