using System;
using Xunit;

namespace CodilityLessons {

	public sealed class FrogJmp {

		public int solution( int X, int Y, int D ) => (int)Math.Ceiling( (double)( Y - X ) / D );

		[Theory]
		[InlineData( 3, 10, 85, 30 )]
		public void BaseTestCases( int expected, int x, int y, int d ) => Assert.Equal( expected, solution( x, y, d ) );

	}

}
