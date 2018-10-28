using System.Linq;
using Xunit;

namespace CodilityLessons {

	public sealed class OddOccurrencesInArray {

		public int solution( int[] A ) => A.Aggregate( ( acc, i ) => acc ^ i );

		[Theory]
		[InlineData( 7, new[] { 9, 3, 9, 3, 9, 7, 9 } )]
		public void BaseTestCases( int expected, int[] input ) => Assert.Equal( expected, solution( input ) );

	}

}
