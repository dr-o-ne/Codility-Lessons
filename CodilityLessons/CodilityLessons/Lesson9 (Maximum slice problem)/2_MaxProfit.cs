using System;
using Xunit;

namespace CodilityLessons {

	public sealed class MaxProfit {

		public int solution( int[] A ) {

			var result = 0;
			var minimum = int.MaxValue;

			foreach( var item in A ) {
				minimum = Math.Min( minimum, item );
				result = Math.Max( result, item - minimum );
			}

			return result;
		}

		[Theory]
		[InlineData( 356, new[] { 23171, 21011, 21123, 21366, 21013, 21367 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}
