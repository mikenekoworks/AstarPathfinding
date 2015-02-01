using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Point {

	public int x, y;

	public Point( int px, int py ) {
		x = px;
		y = py;
	}

	public static bool operator ==( Point a, Point b ) {
		if ( ( a.x == b.x ) && ( a.y == b.y ) ) {
			return true;
		}
		return false;
	}

	public static bool operator !=( Point a, Point b ) {
		if ( ( a.x != b.x ) && ( a.y != b.y ) ) {
			return true;
		}
		return false;
	}

	public override bool Equals( object obj ) {

		Point? p = obj as Point?;
		if ( p == null ) {
			return false;
		}

		if ( ( p.Value.x == x ) && ( p.Value.y == y ) ) {
			return true;
		} 

		return false;
	}

	public override int GetHashCode() {
		return x ^ y;
	}

}

