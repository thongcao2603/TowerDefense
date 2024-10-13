// using System;
// using System.Collections.Generic;
// using System.Linq;

// public static class Astar
// {
//    private static Dictionary<Point, Node> nodes;

//    private static void CreateNode()
//    {
//       nodes = new Dictionary<Point, Node>();
//       foreach (TileScript tile in LevelManager.Instance.Tiles.Values)
//       {
//          nodes.Add(tile.GridPosition, new Node(tile));
//       }
//    }

//    public static void GetPath(Point start, Point goal)
//    {
//       if (nodes == null)
//       {
//          CreateNode();
//       }

//       HashSet<Node> openList = new HashSet<Node>();
//       HashSet<Node> closeList = new HashSet<Node>();

//       Node currentNode = nodes[start];
//       openList.Add(currentNode);

//       for (int x = -1; x <= 1; x++)
//       {
//          for (int y = -1; y <= 1; y++)
//          {
//             Point neighbourPos = new Point(currentNode.GridPosition.X - x, currentNode.GridPosition.Y - y);
//             if (LevelManager.Instance.Tiles[neighbourPos].IsTower)
//             {

//                int gCost = 0;
//                if (Math.Abs(x - y) == 1)
//                {
//                   gCost = 10;
//                }
//                else
//                {
//                   gCost = 14;
//                }
//                Node neighbour = nodes[neighbourPos];

//                if (LevelManager.Instance.InBouns(neighbourPos) && !openList.Contains(neighbour))
//                {
//                   openList.Add(neighbour);
//                }

//                neighbour.CalcValues(currentNode, nodes[goal], gCost);
//             }
//          }
//       }
//       openList.Remove(currentNode);
//       closeList.Add(currentNode);

//       Node neughbour = nodes[neighbourPos];

//       if (!closeList.Contains(neighbour))
//       {
//          openList.Add(neighbour);
//       }
//       if (openList.Count > 0)
//       {
//          currentNode = openList.OrderBy(n => n.F).First();
//       }
//    }
// }
