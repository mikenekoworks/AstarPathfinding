using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AStarPathfinding {

	public static class Finder {

		public static List< NodeData > Search( NodeDataCollection collection ) {

			NodeData start_node = collection.Start;
			NodeData goal_node = collection.Goal;

			List< NodeData > open_list = new List< NodeData >();
			List< NodeData > close_list = new List< NodeData >();

			open_list.Add( start_node );

			bool route_find = false;

			while ( open_list.Count > 0 ) {

				NodeData current_cell = open_list.FindMin( node => node.Score );

				if ( current_cell == goal_node ) {

					route_find = true;

					break;
				}

				NodeData[] neighborhood_nodes = current_cell.GetNeighborhoodNodes();

				open_list.Remove( current_cell );
				close_list.Add( current_cell );

				foreach ( NodeData node in neighborhood_nodes ) {

					if ( ( open_list.Contains( node ) == false ) && ( close_list.Contains( node ) == false ) ) {

						if ( node.IsPassable() == true ) {

							node.Parent = current_cell;
							node.CalcCost();
							node.HeuristicValue = Mathf.Abs( goal_node.Position.x - node.Position.x ) + Mathf.Abs( goal_node.Position.y - node.Position.y );

							open_list.Add( node );

						}

					}

				}
			}


			// 袋小路だ！
			if ( route_find == false ) {
				return null;
			}

			// 見つかった場合はゴールから遡る。
			List< NodeData > find_route = new List<NodeData>();
			{
				NodeData current_cell = goal_node;
				while ( current_cell.Parent != null ) {

					find_route.Add( current_cell );

					current_cell = current_cell.Parent;
				}
			}

			return find_route;

		}
	}

}
