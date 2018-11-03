using System.Collections.Generic;
using Xunit;

namespace CodilityLessons {

	public sealed class Brackets {

		public int solution( string S ) {

			var stack = new Stack<char>();
			foreach( var item in S ) {
				switch( item ) {
					case '}':
						if( stack.Count == 0 || stack.Pop() != '{' ) return 0;
						break;
					case ']':
						if( stack.Count == 0 || stack.Pop() != '[' ) return 0;
						break;
					case ')':
						if( stack.Count == 0 || stack.Pop() != '(' ) return 0;
						break;
					default:
						stack.Push( item );
						break;
				}
			}

			return stack.Count == 0 ? 1 : 0;
		}

		[Theory]
		[InlineData( 0, "}{" )]
		[InlineData( 1, "{[()()]}" )]
		[InlineData( 0, "([)()]" )]
		public void Test( int expected, string input ) => Assert.Equal( expected, solution( input ) );

	}

}