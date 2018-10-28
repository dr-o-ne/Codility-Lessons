using Xunit;

namespace CodilityLessons {

	public sealed class MinAvgTwoSlice {

		public int solution( int[] A ) {

			var n = A.Length;

			var min = double.MaxValue;
			var minIndex = int.MaxValue;

			// check pairs
			for( var i = 0; i < n - 1; i++ ) {
				double value = 1.0 * ( A[i] + A[i + 1] ) / 2;
				if( value >= min ) continue;
				min = value;
				minIndex = i;
			}

			//check triples
			for( var i = 0; i < n - 2; i++ ) {
				double value = 1.0 * ( A[i] + A[i + 1] + A[i + 2] ) / 3;
				if( value >= min ) continue;
				min = value;
				minIndex = i;
			}

			return minIndex;
		}

		[Theory]
		[InlineData( 1, new[] { 4, 2, 2, 5, 1, 5, 8 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}