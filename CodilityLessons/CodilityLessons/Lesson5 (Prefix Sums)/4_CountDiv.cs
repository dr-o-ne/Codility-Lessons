using Xunit;

namespace CodilityLessons {

	public sealed class CountDiv {

		public int solution( int A, int B, int K ) {

			var result = B / K - A / K;
			if( A % K == 0 )
				result++;

			return result;

		}

		[Theory]
		[InlineData( 1, 100, 150, 60 )]
		[InlineData( 20, 11, 345, 17 )]
		[InlineData( 3, 6, 11, 2 )]
		public void Test( int expected, int a, int b, int k ) => Assert.Equal( expected, solution( a, b, k ) );

	}

}