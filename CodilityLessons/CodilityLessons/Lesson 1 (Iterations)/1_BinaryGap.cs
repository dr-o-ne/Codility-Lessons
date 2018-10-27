using System;
using Xunit;

namespace CodilityLessons {

	public sealed class BinaryGap {

		public int solution( int N ) {

			int result = 0;
			int acc = 0;

			var binaryString = Convert.ToString( N, 2 );
			foreach( char c in binaryString ) {
				if( c == '0' ) 
					acc++;
				else {
					result = Math.Max( result, acc );
					acc = 0;
				}
			}

			return result;

		}

		[Theory]
		[InlineData( 0, 0 )]
		[InlineData( 0, 1 )]
		[InlineData( 2, 9 )]
		[InlineData( 4, 529 )]
		[InlineData( 1, 20 )]
		[InlineData( 0, 15 )]
		[InlineData( 0, 2147483647 )]
		public void Test( int expected, int input ) => Assert.Equal( expected, solution( input ) );

	}


}
