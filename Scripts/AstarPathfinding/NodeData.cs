using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AStarPathfinding {

	public class NodeData {

		public NodeConnectionFlag ConnectionFlags;
		public Point Position;

		public NodeData Parent;

		public NodeData Left;
		public NodeData Top;
		public NodeData Right;
		public NodeData Bottom;

		public int Cost;			// 移動コスト
		public int HeuristicValue;	// ヒューリスティック値

		public delegate int DelegateCalcCost( Point p );
		public DelegateCalcCost CostCaluculateFunction;

		public delegate bool DelegateIsPassable();
		public DelegateIsPassable IsPassableFunction;

		public NodeData() {
			CostCaluculateFunction = delegate( Point p )
			{
				return 1;
			};

			IsPassableFunction = delegate()
			{
				return true;
			};
		}

		public int Score {
			get {
				return Cost + HeuristicValue;
			}
		}

		public bool IsPassable() {
			return IsPassableFunction();
		}

		public void CalcCost() {
			NodeData current_cell = this.Parent;
			int cost = 0;

			cost += CostCaluculateFunction( Position );

			while ( current_cell != null ) {
				cost += current_cell.Cost;
				current_cell = current_cell.Parent;
			}

			Cost = cost;
		}

		public NodeData[] GetNeighborhoodNodes() {

			List< NodeData > neighborhood_notes = new List<NodeData>();

			string debug_string = "";

			if ( Top != null ) {
				neighborhood_notes.Add( Top );

				debug_string += "Top: ";
			}
			if ( Left != null ) {
				neighborhood_notes.Add( Left );
				debug_string += "Left: ";
			}
			if ( Right != null ) {
				neighborhood_notes.Add( Right );
				debug_string += "Right: ";
			}
			if ( Bottom != null ) {
				neighborhood_notes.Add( Bottom );
				debug_string += "Bottom: ";
			}

			Debug.Log( debug_string );

			return neighborhood_notes.ToArray();
		}
	}

}
