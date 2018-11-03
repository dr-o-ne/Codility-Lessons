using System;
using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class Dominator {

		public int solution( int[] A ) {
			var leader = FindLeader( A );
			if( leader == -1 )
				return -1;
			return Array.IndexOf( A, leader );
		}

		/// <summary>
		/// time  O(N)
		/// space O(1)
		/// </summary>
		public static int FindLeader( ICollection<int> input ) {

			if( input == null )
				return -1;

			var candidate = int.MinValue;
			var candidateAcc = 0;

			foreach( int t in input ) {
				if( candidateAcc == 0 ) {
					candidate = t;
					candidateAcc++;
				} else {
					if( t == candidate )
						candidateAcc++;
					else
						candidateAcc--;
				}
			}

			if( candidateAcc == 0 )
				return -1;

			var cnt = 0;
			foreach( int x in input )
				if( x == candidate )
					cnt++;
			

			return 2 * cnt > input.Count ? candidate : -1;
		}

		[Theory]
		[InlineData( new[] { 0, 2, 4, 6, 7 }, new[] { 3, 4, 3, 2, 3, -1, 3, 3 } )]
		public void Test( int[] expected, int[] a ) {
			var hashSet = new HashSet<int>( expected );
			Assert.Contains( solution( a ), hashSet );
		}

		[Theory]
		[InlineData( -1, new[] { 3, 2 } )]
		[InlineData( -1, new int[0] )]
		public void NegativeTest( int expected, int[] a ) => Assert.Equal( expected, solution( a ) );

	}

}