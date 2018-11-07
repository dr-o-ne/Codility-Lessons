using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class CountNonDivisible {

		public int[] solution( int[] A ) {

			var length = A.Length;
			var result = new int[length];

			var acc = new Dictionary<int, int>();
			for( int i = 0; i < length; i++ ) {
				int value;
				acc[A[i]] = acc.TryGetValue( A[i], out value ) ? ++value : 1;
			}

			var sieve = new int[length * 2 + 1];
			for( int i = 0; i < length; i++ )
				sieve[A[i]] = length;
			
			foreach( var kvp in acc ) {
				var item = kvp.Key;
				var value = kvp.Value;
				for( int j = item; j < sieve.Length; j += item )
					sieve[j] -= value;
			}
			
			for( int i = 0; i < length; i++ )
				result[i] = sieve[A[i]];
			
			return result;

		}

		[Theory]
		[InlineData( new[] { 1, 0 }, new[] { 1, 3 } )]
		[InlineData( new[] { 0, 0 }, new[] { 2, 2 } )]
		[InlineData( new[] { 1, 1 }, new[] { 2, 3 } )]
		[InlineData( new[] { 0, 0 }, new[] { 1, 1 } )]
		[InlineData( new[] { 2, 4, 3, 2, 0 }, new[] { 3, 1, 2, 3, 6 } )]
		public void Test( int[] expected, int[] a ) => Assert.Equal( expected, solution( a ) );
	}

}