using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClienteC__Juego
{
    internal class BoardDistribution
    {
        public string[,] stringsBoard;
        public Position[,] positionsBoard;
        public Position[,] positionsNoDoorsBoard;
        public Position[,] positionsPlusCenterBoard;

        public int gridSizeX = 25;
        public int gridSizeY = 24;

        public BoardDistribution()
        {
            // Teleports go: 7 <-> 3 and 9 <-> 1
            stringsBoard = new string[,] {
                {"__", "__", "__", "__", "__", "__", "__", "__", "__", "O1", "__", "__", "__", "__", "O2", "__", "__", "__", "__", "__", "__", "__", "__", "__"} ,
                {"r1", "r1", "r1", "r1", "r1", "t1", "__", "hw", "hw", "hw", "r2", "r2", "r2", "r2", "hw", "hw", "hw", "__", "r3", "r3", "r3", "r3", "r3", "r3"} ,
                {"r1", "r1", "r1", "r1", "r1", "r1", "hw", "hw", "r2", "r2", "r2", "r2", "r2", "r2", "r2", "r2", "hw", "hw", "r3", "r3", "r3", "r3", "r3", "r3"} ,
                {"r1", "r1", "r1", "r1", "r1", "r1", "hw", "hw", "r2", "r2", "r2", "r2", "r2", "r2", "r2", "r2", "hw", "hw", "r3", "r3", "r3", "r3", "r3", "r3"} ,
                {"r1", "r1", "r1", "r1", "r1", "r1", "hw", "hw", "r2", "r2", "r2", "r2", "r2", "r2", "r2", "r2", "hw", "hw", "d3", "r3", "r3", "r3", "r3", "r3"} ,
                {"r1", "r1", "r1", "r1", "r1", "r1", "hw", "hw", "d2", "r2", "r2", "r2", "r2", "r2", "r2", "d2", "hw", "hw", "hw", "r3", "r3", "r3", "t3", "__"} ,
                {"__", "r1", "r1", "r1", "d1", "r1", "hw", "hw", "r2", "r2", "r2", "r2", "r2", "r2", "r2", "r2", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "O3"} ,
                {"hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "r2", "d2", "r2", "r2", "r2", "r2", "d2", "r2", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "__"} ,
                {"__", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "r5", "r5", "r5", "r5", "r5", "r5"} ,
                {"r4", "r4", "r4", "r4", "r4", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "d5", "r5", "r5", "r5", "r5", "r5"} ,
                {"r4", "r4", "r4", "r4", "r4", "r4", "r4", "r4", "hw", "hw", "ct", "ct", "ct", "ct", "ct", "hw", "hw", "hw", "r5", "r5", "r5", "r5", "r5", "r5"} ,
                {"r4", "r4", "r4", "r4", "r4", "r4", "r4", "r4", "hw", "hw", "ct", "Ct", "Ct", "Ct", "ct", "hw", "hw", "hw", "r5", "r5", "r5", "r5", "r5", "r5"} ,
                {"r4", "r4", "r4", "r4", "r4", "r4", "r4", "d4", "hw", "hw", "ct", "Ct", "Ct", "Ct", "ct", "hw", "hw", "hw", "r5", "r5", "r5", "r5", "d5", "r5"} ,
                {"r4", "r4", "r4", "r4", "r4", "r4", "r4", "r4", "hw", "hw", "ct", "Ct", "Ct", "Ct", "ct", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "__"} ,
                {"r4", "r4", "r4", "r4", "r4", "r4", "r4", "r4", "hw", "hw", "ct", "Ct", "Ct", "Ct", "ct", "hw", "hw", "hw", "r6", "r6", "d6", "r6", "r6", "__"} ,
                {"r4", "r4", "r4", "r4", "r4", "r4", "d4", "r4", "hw", "hw", "ct", "Ct", "Ct", "Ct", "ct", "hw", "hw", "r6", "r6", "r6", "r6", "r6", "r6", "r6"} ,
                {"__", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "ct", "ct", "ct", "ct", "ct", "hw", "hw", "d6", "r6", "r6", "r6", "r6", "r6", "r6"} ,
                {"O6", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "r6", "r6", "r6", "r6", "r6", "r6", "r6"} ,
                {"__", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "r8", "r8", "d8", "d8", "r8", "r8", "hw", "hw", "hw", "r6", "r6", "r6", "r6", "r6", "__"} ,
                {"t7", "r7", "r7", "r7", "r7", "r7", "d7", "hw", "hw", "r8", "r8", "r8", "r8", "r8", "r8", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "O4"} ,
                {"r7", "r7", "r7", "r7", "r7", "r7", "r7", "hw", "hw", "r8", "r8", "r8", "r8", "r8", "d8", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "hw", "__"} ,
                {"r7", "r7", "r7", "r7", "r7", "r7", "r7", "hw", "hw", "r8", "r8", "r8", "r8", "r8", "r8", "hw", "hw", "d9", "r9", "r9", "r9", "r9", "r9", "t9"} ,
                {"r7", "r7", "r7", "r7", "r7", "r7", "r7", "hw", "hw", "r8", "r8", "r8", "r8", "r8", "r8", "hw", "hw", "r9", "r9", "r9", "r9", "r9", "r9", "r9"} ,
                {"r7", "r7", "r7", "r7", "r7", "r7", "r7", "hw", "hw", "r8", "r8", "r8", "r8", "r8", "r8", "hw", "hw", "r9", "r9", "r9", "r9", "r9", "r9", "r9"} ,
                {"r7", "r7", "r7", "r7", "r7", "r7", "__", "O5", "__", "r8", "r8", "r8", "r8", "r8", "r8", "__", "hw", "__", "r9", "r9", "r9", "r9", "r9", "r9"}
            };

            positionsBoard = new Position[25,24];
            positionsNoDoorsBoard = new Position[25, 24];
            positionsPlusCenterBoard = new Position[25, 24];

            for (int x = 0; x < gridSizeX; x++) {
                for (int y = 0; y < gridSizeY;  y++)
                {
                    if ((stringsBoard[x, y] == "hw") || (stringsBoard[x, y][0] == 'd'))
                        positionsBoard[x, y] = new Position(x,y,true);
                    else
                        positionsBoard[x, y] = new Position(x,y,false);
                }
            }

            for (int x = 0; x < gridSizeX; x++) {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (stringsBoard[x, y] == "hw")
                        positionsNoDoorsBoard[x, y] = new Position(x, y, true);
                    else
                        positionsNoDoorsBoard[x, y] = new Position(x, y, false);
                }
            }

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (stringsBoard[x, y] == "hw" || stringsBoard[x, y] == "ct" || stringsBoard[x, y][0] == 'd')
                        positionsPlusCenterBoard[x, y] = new Position(x, y, true);
                    else
                        positionsPlusCenterBoard[x, y] = new Position(x, y, false);
                }
            }
        }

        public string setTileTag(int row, int col)
        {
            if (stringsBoard[row, col] == "hw")
                return "hway";
            else if (stringsBoard[row, col] == "ct")
                return "center";
            else if (stringsBoard[row, col] == "Ct")
                return "deep";
            else if (stringsBoard[row, col][0] == 'O')
                return "Origin" + "/" + stringsBoard[row, col][1];
            else if (stringsBoard[row, col][0] == 'd')
                return "door" + "/" + stringsBoard[row, col][1];
            else if (stringsBoard[row, col][0] == 'r')
                return "room" + "/" + stringsBoard[row, col][1];
            else if (stringsBoard[row, col][0] == 't')
                return "Teleport" + "/" + stringsBoard[row, col][1];
            else if (stringsBoard[row, col] == "__")
                return "void";
            else
                return "None";
        }

        public Position moveToRoom(int doorNum, PictureBox[,] grid)
        {
            int[] roomCenters = {0, 3,2, 4,11, 2,21, 12,2, 10,21, 16,20, 22,2, 22,11, 23,21};
            Position newPos = new Position(0,0);

            int x = roomCenters[2 * doorNum - 1];
            int y = roomCenters[2 * doorNum];
            if (grid[x, y].BackgroundImage == null)
                newPos = new Position(x, y);
            else
                for (int i = x + 1; i > x - 2; i--)
                    for (int j = y + 1; j > y - 2; j--)
                        if (grid[i, j].BackgroundImage == null)
                            newPos = new Position(i, j);
            return newPos;
        }

        public Position closestDoorToNextPos(Position nextPos, int doorNum)
        {
            Position doorPos;
            if (stringsBoard[nextPos.X,nextPos.Y] == "ct")
            {
                string tag = "d" + doorNum;
                int lowestDist = 50;
                Position finalPos = positionsPlusCenterBoard[nextPos.X, nextPos.Y];
                doorPos = new Position(0, 0);
                for (int i = 0; i < gridSizeX; i++)
                {
                    for (int j = 0; j < gridSizeY; j++)
                    {
                        if (stringsBoard[i, j] == tag)
                        {
                            Position pos = positionsPlusCenterBoard[i, j];
                            List<Position> positions = nextPos.FindPath(pos, finalPos, positionsPlusCenterBoard);
                            if (positions.Count < lowestDist)
                            {
                                doorPos = new Position(i, j);
                                lowestDist = positions.Count;
                            }
                        }
                    }
                }
            }
            else
            {
                string tag = "d" + doorNum;
                int lowestDist = 50;
                Position finalPos = positionsBoard[nextPos.X, nextPos.Y];
                doorPos = new Position(0, 0);
                for (int i = 0; i < gridSizeX; i++)
                {
                    for (int j = 0; j < gridSizeY; j++)
                    {
                        if (stringsBoard[i, j] == tag)
                        {
                            Position pos = positionsBoard[i, j];
                            List<Position> positions = nextPos.FindPath(pos, finalPos, positionsBoard);
                            if (positions.Count < lowestDist)
                            {
                                doorPos = new Position(i, j);
                                lowestDist = positions.Count;
                            }
                        }
                    }
                }
            }
            return doorPos;
        }

        public Position closestCenterToMyPos(Position myPos)
        {
            Position closestPos = new Position(0, 0);
            int lowestDist = 50;
            int length;

            for (int i = 0; i < gridSizeX; i++) {
                for (int j = 0; j < gridSizeY; j++)
                {
                    if (stringsBoard[i, j] == "ct")
                    {
                        Position pos = positionsBoard[i, j];
                        length = myPos.calculateMovesLength(pos);
                        if (length < lowestDist)
                        {
                            closestPos = new Position(i, j);
                            lowestDist = length;
                        }
                    }
                }
            }
            return closestPos;
        }
    }
}
