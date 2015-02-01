using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AStarPathfinding {
	public class NodeDataCollection {

		private List< NodeData > nodes;
		private NodeData startNode;
		private NodeData goalNode;
		private Point startPoint;
		private Point goalPoint;

		public NodeData Start {
			get {
				return startNode;
			}
		}
		public NodeData Goal {
			get {
				return goalNode;
			}
		}

		public void Create( Point start_point, Point goal_point ) {
			nodes = new List<NodeData>();

			startPoint = start_point;
			goalPoint = goal_point;
		}

		public void Add( NodeData data ) {
			nodes.Add( data );

			if ( data.Position == startPoint ) {
				startNode = data;
			}
			if ( data.Position == goalPoint ) {
				goalNode = data;
			}

		}

		private NodeData[] getNeighborhoodNodes( NodeData node ) {

			int x = node.Position.x;
			int y = node.Position.y;

			NodeData[] neighborhood_nodes = new NodeData[ 4 ];

			neighborhood_nodes[ 0 ] = nodes.Find( n => ( ( n.Position.x == x - 1 ) && ( n.Position.y == y     ) ) );
			neighborhood_nodes[ 1 ] = nodes.Find( n => ( ( n.Position.x == x     ) && ( n.Position.y == y + 1 ) ) );
			neighborhood_nodes[ 2 ] = nodes.Find( n => ( ( n.Position.x == x + 1 ) && ( n.Position.y == y     ) ) );
			neighborhood_nodes[ 3 ] = nodes.Find( n => ( ( n.Position.x == x     ) && ( n.Position.y == y - 1 ) ) );

			return neighborhood_nodes;
		}

		public void Commit() {

			// ノード間連結
			foreach ( NodeData node in nodes ) {

				NodeData[] sibling_nodes = getNeighborhoodNodes( node );

				node.Left = sibling_nodes[ 0 ];
				node.Top = sibling_nodes[ 1 ];
				node.Right = sibling_nodes[ 2 ];
				node.Bottom = sibling_nodes[ 3 ];

			}

		}

	}
}
