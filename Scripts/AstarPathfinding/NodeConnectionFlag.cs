using UnityEngine;
using System.Collections;

namespace AStarPathfinding {

	[System.Flags]
	public enum NodeConnectionFlag {
		Left   = 0x01,
		Top    = 0x02,
		Right  = 0x04,
		Bottom = 0x08,
	}

}
