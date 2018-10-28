using Xunit;

namespace CodilityLessons {

	public sealed class GenomicRangeQuery {

		public int[] solution( string S, int[] P, int[] Q ) {

			var n = P.Length;

			var a = CreatePrefixSum( S, 'A' );
			var c = CreatePrefixSum( S, 'C' );
			var g = CreatePrefixSum( S, 'G' );
			var t = CreatePrefixSum( S, 'T' );

			var result = new int[n];

			for( int i = 0; i < n; i++ ) {
				var p = P[i];
				var q = Q[i];

				var value = -1;

				if( a[q] >= p && a[q] <= q ) value = 1;
				else if( c[q] >= p && c[q] <= q ) value = 2;
				else if( g[q] >= p && g[q] <= q ) value = 3;
				else if( t[q] >= p && t[q] <= q ) value = 4;

				result[i] = value;
			}

			return result;
		}

		private static int[] CreatePrefixSum( string input, char pattern ) {
			var result = new int[input.Length];

			var value = -1;
			for( int i = 0; i < input.Length; i++ ) {
				if( pattern == input[i] )
					value = i;
				result[i] = value;
			}

			return result;
		}

		[Theory]
		[InlineData( new[] { 2, 4, 1 }, "CAGCCTA", new[] { 2, 5, 0 }, new[] { 4, 5, 6 } )]
		public void Test( int[] expected, string s, int[] p, int[] q ) => Assert.Equal( expected, solution( s, p, q ) );

	}

}
