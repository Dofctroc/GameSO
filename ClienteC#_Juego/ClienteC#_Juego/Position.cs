using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClienteC__Juego
{
    internal class Position
    {
        public int X { get; }
        public int Y { get; }
        public bool IsWalkable { get; set; }
        public int GCost { get; set; }  // Cost from the start node to this node
        public int HCost { get; set; }  // Heuristic cost (estimated cost to the goal)
        public int FCost => GCost + HCost;  // Total cost
        public Position Parent { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            IsWalkable = true;
        }

        public Position(int x, int y, bool isWalkable)
        {
            X = x;
            Y = y;
            IsWalkable = isWalkable;
        }

        public int calculateMovesLength(Position other)
        {
            int rowDistance = Math.Abs(X - other.X);
            int columnDistance = Math.Abs(Y - other.Y);
            int moves = rowDistance + columnDistance;
            return moves;
        }

        public int GetDistance(Position other)
        {
            int rowDistance = Math.Abs(X - other.X);
            int columnDistance = Math.Abs(Y - other.Y);
            int moves = rowDistance + columnDistance;
            return moves;
        }

        // Calculate Manhattan distance between two positions
        public bool validMove(Position other, int distance)
        {
            int xDistance = Math.Abs(X - other.X);
            int yDistance = Math.Abs(Y - other.Y);
            if (xDistance + yDistance > distance)
                return false;
            return true;
        }

        public int remainingMoves(Position other, int moves)
        {
            int xDistance = Math.Abs(X - other.X);
            int yDistance = Math.Abs(Y - other.Y);
            int remaining_moves = moves - xDistance - yDistance;
            return remaining_moves;
        }

        public List<Position> FindPath(Position startPosition, Position endPosition, Position[,] grid)
        {
            List<Position> openSet = new List<Position>();
            HashSet<Position> closedSet = new HashSet<Position>();

            openSet.Add(startPosition);

            while (openSet.Count > 0)
            {
                Position currentPosition = openSet[0];

                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].FCost < currentPosition.FCost || (openSet[i].FCost == currentPosition.FCost && openSet[i].HCost < currentPosition.HCost))
                    {
                        currentPosition = openSet[i];
                    }
                }

                openSet.Remove(currentPosition);
                closedSet.Add(currentPosition);

                if (currentPosition == endPosition)
                {
                    return RetracePath(startPosition, endPosition);
                }

                foreach (Position neighbor in GetNeighbors(currentPosition, grid))
                {
                    if (!neighbor.IsWalkable || closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    int newCostToNeighbor = currentPosition.GCost + currentPosition.GetDistance(neighbor);

                    if (newCostToNeighbor < neighbor.GCost || !openSet.Contains(neighbor))
                    {
                        neighbor.GCost = newCostToNeighbor;
                        neighbor.HCost = currentPosition.GetDistance(neighbor);
                        neighbor.Parent = currentPosition;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }
            return null;  // No path found
        }

        public List<Position> RetracePath(Position startPosition, Position endPosition)
        {
            List<Position> path = new List<Position>();
            Position currentPosition = endPosition;

            while (currentPosition != startPosition)
            {
                path.Add(currentPosition);
                currentPosition = currentPosition.Parent;
            }

            path.Reverse();
            return path;
        }

        public List<Position> GetNeighbors(Position node, Position[,] grid)
        {
            List<Position> neighbors = new List<Position>();

            // Define the possible movement directions (assuming 4-way movement: up, down, left, right)
            int[] deltaX = { 0, 0, -1, 1 };
            int[] deltaY = { -1, 1, 0, 0 };

            for (int i = 0; i < deltaX.Length; i++)
            {
                int neighborX = node.X + deltaX[i];
                int neighborY = node.Y + deltaY[i];

                // Check if the neighbour coordinates are within the grid bounds
                if (IsWithinBounds(neighborX, neighborY, grid))
                {
                    neighbors.Add(grid[neighborX, neighborY]);
                }
            }

            return neighbors;
        }

        private bool IsWithinBounds(int x, int y, Position[,] grid)
        {
            // Check if the given coordinates are within the grid bounds
            return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1);
        }
    }


}
