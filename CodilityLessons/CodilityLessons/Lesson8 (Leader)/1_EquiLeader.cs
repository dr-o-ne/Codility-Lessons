using System.Collections.Generic;

namespace CodilityLessons {

	public sealed class EquiLeader {

		public int solution( int[] A ) {

			var leader = FindLeader( A );
			if( leader == -1 )
				return 0;

			var result = 0;
			var leftLeaderCnt = 0;
			var rightLeaderCnt = 0;
			foreach( int x in A ) 
				if( x == leader )
					rightLeaderCnt++;
			

			for( int i = 0; i < A.Length; i++ ) {
				if( A[i] == leader ) {
					leftLeaderCnt++;
					rightLeaderCnt--;
				}
				if( leftLeaderCnt > ( i + 1 ) / 2 && rightLeaderCnt > ( A.Length - i - 1 ) / 2 )
					result++;
			}

			return result;
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

	}

}