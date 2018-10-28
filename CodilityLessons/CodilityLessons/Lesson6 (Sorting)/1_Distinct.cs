using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class Distinct {

		public int solution( int[] A ) => new HashSet<int>( A ).Count;

		[Theory]
		[InlineData( 3, new[] { 2, 1, 1, 2, 3, 1 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}