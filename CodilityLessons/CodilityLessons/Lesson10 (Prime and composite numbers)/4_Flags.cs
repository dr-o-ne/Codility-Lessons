using System;
using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class Flags {

		/*
			Solution:
			1) Find peak indexes
			2) Find max possible amount of flags: lets assume we have K flags. 
			   The difference between 2 flags should be greated or equal K. Therefore K * K <= n 
			3) Try to set flags, starting from first peak   
		*/

		public int solution( int[] A ) {

			int n = A.Length;

			var peakIndexes = new List<int>();
			for( int i = 1; i < n - 1; i++ )
				if( A[i] > A[i - 1] && A[i] > A[i + 1] )
					peakIndexes.Add( i );

			if( peakIndexes.Count == 0 ) return 0;
			if( peakIndexes.Count == 1 ) return 1;

			var flagsMaxCnt = (int)Math.Ceiling( Math.Sqrt( n ) );
			flagsMaxCnt = Math.Min( flagsMaxCnt, peakIndexes.Count );

			for( var i = flagsMaxCnt; i > 0; i-- ) {
				var startPeak = peakIndexes[0];
				var cnt = 1;

				for( int j = 1; j < peakIndexes.Count; j++ ) {
					var nextPeak = peakIndexes[j];
					if( i > Math.Abs( nextPeak - startPeak ) ) continue;
					startPeak = nextPeak;
					cnt++;
					if( cnt == i )
						return cnt;
				}

			}

			throw new Exception();
		}

		[Theory]
		[InlineData( 2, new[] { 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 } )]
		[InlineData( 0, new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } )]
		[InlineData( 1, new[] { 1, 1, 1, 1, 1, 9, 1, 1, 1, 1, 1, 1 } )]
		[InlineData( 3, new[] { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 } )]
		public void Test( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );
	}

}