using Xunit;

namespace CodilityLessons {

	public sealed class PermMissingElem {

		public int solution( int[] A ) {

			long result = (long)( A.Length + 1 ) * ( A.Length + 2 ) / 2;

			foreach( int item in A )
				result -= item;

			return (int)result;

		}

		[Theory]
		[InlineData( 2, new[] { 1 } )]
		[InlineData( 4, new[] { 2, 3, 1, 5 } )]
		public void Test( int expected, int[] input ) => Assert.Equal( expected, solution( input ) );
	}

}
