using System;
using Xunit;

namespace CodilityLessons {

	public sealed class CountFactors {

		public int solution( int N ) {

			var result = 0;

			var sqrt = (int)Math.Sqrt( N );

			for( int i = 1; i <= sqrt; i++ )
				if( N % i == 0 )
					result += 2;

			if( sqrt * sqrt == N )
				result--;

			return result;
		}

		[Theory]
		[InlineData( 8, 24 )]
		[InlineData( 3, 9 )]
		[InlineData( 1, 1 )]
		public void Test( int expected, int n ) => Assert.Equal( expected, solution( n ) );

	}

}