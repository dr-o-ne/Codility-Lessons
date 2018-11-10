using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class CountSemiprimes {

		public int[] solution( int N, int[] P, int[] Q ) {

			var primeNumbers = GetPrimeNumbers( N / 2 + 1 );

			var semiPrimeNumbersSieve = GetSemiPrimeNumbersSieve( N, primeNumbers );

			var prefixSum = GetPrefixSum( N, semiPrimeNumbersSieve );

			var result = new int[P.Length];
			for( int i = 0; i < P.Length; i++ ) 
				result[i] = prefixSum[Q[i]] - prefixSum[P[i] - 1];

			return result;
		}

		private static List<int> GetPrimeNumbers( int N ) {

			var sieve = new BitArray(N);
			for( int i = 2; i < Math.Sqrt( N ); i++ )
				if( !sieve[i] )
					for( int j = i + i; j < N; j += i )
						sieve[j] = true;

			var primeNumbers = new List<int>();
			for( int i = 2; i < N; i++ )
				if( !sieve[i] )
					primeNumbers.Add( i );

			return primeNumbers;
		}

		private static BitArray GetSemiPrimeNumbersSieve( int N, List<int> primeNumbers ) {
			var sieve = new BitArray( N + 1 );
			foreach( int i in primeNumbers ) {
				foreach( int j in primeNumbers ) {
					var nextSemiPrime = i * j;
					if( nextSemiPrime >= N + 1 || nextSemiPrime < 0 ) break;
					sieve[nextSemiPrime] = true;
				}
			}
			return sieve;
		}

		private static int[] GetPrefixSum( int N, BitArray semiPrimeNumbersSieve ) {
			var prefixSum = new int[N + 1];
			for( int i = 1; i < N + 1; i++ ) {
				prefixSum[i] = prefixSum[i - 1];
				if( semiPrimeNumbersSieve[i] )
					prefixSum[i]++;
			}
			return prefixSum;
		}

		[Theory]
		[InlineData( new[] {10, 4, 0}, 26, new[] { 1, 4, 16 }, new[] { 26, 10, 20 } )]
		public void Test( int[] expected, int n, int[] p, int[] q) => Assert.Equal( expected, solution( n, p, q ) );
	}

}
