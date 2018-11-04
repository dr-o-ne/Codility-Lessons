using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class Peaks {

		public int solution( int[] A ) {

			int length = A.Length;

			var peakIndexes = new List<int>();
			for( int i = 1; i < A.Length - 1; i++ )
				if( A[i] > A[i - 1] && A[i] > A[i + 1] )
					peakIndexes.Add( i );

			for(int blockSize = 1; blockSize <= length; blockSize++ ) {

				if( length % blockSize != 0 ) continue;

				var blockCount = length / blockSize;
				if( blockCount > peakIndexes.Count ) continue; // at least 1 peak for a block

				var blockStatuses = new BitArray( blockCount );
				foreach( var peak in peakIndexes )
					blockStatuses[peak / blockSize] = true;

				bool isSolution = true;
				foreach( bool blockStatus in blockStatuses ) {
					if( !blockStatus ) {
						isSolution = false;
						break;
					}
				}

				if( isSolution )
					return blockCount;

			}

			return 0;
		}

		[Theory]
		[InlineData( 1, new[] { 1, 2, 1 } )]
		[InlineData( 3, new[] { 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );
	}

}