using Xunit;

namespace CodilityLessons {

	public sealed class PassingCars {

		public int solution( int[] A ) {

			var result = 0;
			var acc = 0;

			foreach( var item in A ) {
				if( item == 0 )
					acc++;
				else {
					result += acc;
					if( result > 1000000000 )
						return -1;
				}
			}

			return result;
		}

		[Theory]
		[InlineData( 1, new[] { 1, 0, 1, 0, 0 } )]
		[InlineData( 5, new[] { 0, 1, 0, 1, 1 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}