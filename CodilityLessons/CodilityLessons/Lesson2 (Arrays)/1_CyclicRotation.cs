using System;
using Xunit;

namespace CodilityLessons {

	public sealed class CyclicRotation {

		public int[] solution( int[] A, int K ) {

			if( A.Length == 0 ) return new int[0];

			var result = new int[A.Length];

			K %= A.Length;
			Array.Copy( A, A.Length - K, result, 0, K );
			Array.Copy( A, 0, result, K, A.Length - K );

			return result;

		}

		[Theory]
		[InlineData( new[] { 3, 8, 9, 7, 6 }, new[] { 3, 8, 9, 7, 6 }, 0 )]
		[InlineData( new[] { 6, 3, 8, 9, 7 }, new[] { 3, 8, 9, 7, 6 }, 1 )]
		[InlineData( new[] { 7, 6, 3, 8, 9 }, new[] { 3, 8, 9, 7, 6 }, 2 )]
		[InlineData( new[] { 9, 7, 6, 3, 8 }, new[] { 3, 8, 9, 7, 6 }, 3 )]
		[InlineData( new[] { 8, 9, 7, 6, 3 }, new[] { 3, 8, 9, 7, 6 }, 4 )]
		[InlineData( new[] { 3, 8, 9, 7, 6 }, new[] { 3, 8, 9, 7, 6 }, 5 )]
		[InlineData( new[] { 6, 3, 8, 9, 7 }, new[] { 3, 8, 9, 7, 6 }, 6 )]
		public void Test( int[] expected, int[] input, int K ) => Assert.Equal( expected, solution( input, K ) );

		[Fact]
		public void EmptyArgumentTest() => Assert.Equal( new int[0], solution( new int[0], 1 ) );

	}

}
