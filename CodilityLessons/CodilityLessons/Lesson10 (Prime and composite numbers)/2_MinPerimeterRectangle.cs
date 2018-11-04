using System;
using Xunit;

namespace CodilityLessons {

	public sealed class MinPerimeterRectangle {

		public int solution( int N ) {

			for( int i = (int)Math.Sqrt( N ); ; i-- )
				if( N % i == 0 )
					return 2 * ( i + N / i );

		}

		[Theory]
		[InlineData( 204, 101 )]
		[InlineData( 4, 1 )]
		[InlineData( 20, 25 )]
		[InlineData( 22, 30 )]
		public void Test( int expected, int n ) => Assert.Equal( expected, solution( n ) );

	}

}
