using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClienteC__Juego
{
    public partial class board : Form
    {
        public board()
        {
            InitializeComponent();
        }

        int Rows; int Columns; int Margin;
        int TileWidth; int TileHeight;
        int diceRoll, diceRoll1, diceRoll2;
        int inRoom;
        Position myPos;
        PictureBox[,] grid;
        BoardDistribution boardGrids;
        Image[] dicesImg;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Variables
            Rows = 25; Columns = 24;
            TileWidth = 26; TileHeight = 26;
            Margin = 15;
            panel_Board.Size = new Size(TileWidth*Columns, TileHeight*Rows);
            grid = new PictureBox[Rows, Columns];
            boardGrids = new BoardDistribution();

            dicesImg = new Image[] {Properties.Resources.DiceEmpty, Properties.Resources.Dice1, Properties.Resources.Dice2,
                Properties.Resources.Dice3, Properties.Resources.Dice4, Properties.Resources.Dice5, Properties.Resources.Dice6};

            myPos = new Position(-1, -1);
            inRoom = 0;

            // All related with the board
            for (int row = 0; row < Rows; row++) {
                for (int col = 0; col < Columns; col++) {
                    grid[row, col] = new PictureBox();
                    grid[row, col].Location = new Point(Margin - 1 + TileWidth + col * TileWidth, Margin - 1 + TileHeight + row * TileHeight);
                    grid[row, col].Size = new Size(TileWidth, TileHeight);
                    grid[row, col].BorderStyle = BorderStyle.None;
                    grid[row, col].BackColor = Color.Transparent;
                    grid[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    grid[row, col].MouseEnter += Tile_mouseEnter;
                    grid[row, col].MouseLeave += Tile_mouseLeave;
                    grid[row, col].MouseClick += Tile_mouseClick;
                    grid[row, col].Tag = boardGrids.setTileTag(row,col);
                    // Set other properties as needed
                    panel_Board.Controls.Add(grid[row, col]);
                }
            }

            // Other things
            panel_Board.Size = new Size(TileWidth*Columns + 2*(TileWidth + Margin), TileHeight*Rows + 2*(TileHeight + Margin));
            pBox_dice1.BackgroundImageLayout = ImageLayout.Stretch;
            pBox_dice1.BackColor = Color.Transparent;
            pBox_dice2.BackgroundImageLayout = ImageLayout.Stretch;
            pBox_dice2.BackColor = Color.Transparent;

            pBox_mostrarConectados.Location = new Point(panel_Board.Location.X + panel_Board.Width + 10, panel_Board.Location.Y);
            pBox_mostrarConectados.Size = new Size(15,30);
            dGrid_conectados.Location = new Point(pBox_mostrarConectados.Location.X + pBox_mostrarConectados.Width + 4, pBox_mostrarConectados.Location.Y);
            dGrid_conectados.Size = new Size(160,panel_Board.Height);
            dGrid_conectados.Visible = false;

            dGrid_conectados.ColumnCount = 2;
            dGrid_conectados.ColumnHeadersDefaultCellStyle.Font = new Font(dGrid_conectados.Font, FontStyle.Bold);

            dGrid_conectados.Columns[0].Name = "column_Username";
            dGrid_conectados.Columns[0].HeaderText = "Username";
            dGrid_conectados.Columns[1].Name = "column_Status";
            dGrid_conectados.Columns[1].HeaderText = "Status";

            dGrid_conectados.Columns[0].Width = 80;
            dGrid_conectados.Columns[1].Width = dGrid_conectados.Width - dGrid_conectados.Columns[0].Width - 2;
            dGrid_conectados.Rows.Clear();

            for (int i = 0; i < 60;  i++)
                dGrid_conectados.Rows.Add("Asier", "InGame");

            CenterFormOnScreen();
        }

        private void CenterFormOnScreen()
        {
            // Calculate the center position
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;

            int x = (screenWidth - formWidth) / 2;
            int y = (screenHeight - formHeight) / 2;

            // Set the form's location
            this.Location = new Point(50, y);
        }

        private void button_Dado1_Click(object sender, EventArgs e)
        {
        }

        private void pBox_dice_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            // Generate a random integer between 1 and 6
            diceRoll1 = random.Next(1, 7);
            diceRoll2 = random.Next(1, 7);
            diceRoll = diceRoll1 + diceRoll2;
            lbl_diceRoll.Text = diceRoll.ToString();

            displayDiceNum(diceRoll1, diceRoll2);
        }

        private void displayDiceNum(int num1, int num2)
        {
            pBox_dice1.BackgroundImage = dicesImg[num1];
            pBox_dice2.BackgroundImage = dicesImg[num2];
        }

        private void Tile_mouseEnter(object sender, EventArgs e)
        {
            Position myPosTemp = myPos;
            Position hoveredPos = new Position(0, 0);
            PictureBox hoveredPBox = (PictureBox)sender;

            int diceRoll;
            if (lbl_diceRoll.Text != "-tirar-")
                diceRoll = Convert.ToInt32(lbl_diceRoll.Text);
            else
                diceRoll = 0;

            if ((myPosTemp.X != -1) && (hoveredPBox.Tag.ToString() == "hway" || hoveredPBox.Tag.ToString().Split('/')[0] == "door"))
            {
                PictureBox myPBox = grid[myPosTemp.X, myPosTemp.Y];
                bool found = false;

                // Loop to find where the hovered pBox is at
                for (int row = 0; row < Rows; row++) {
                    for (int col = 0; col < Columns; col++) 
                    {
                        if (grid[row, col] == hoveredPBox)
                        {
                            hoveredPos = new Position(row, col);
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }

                // Si estas dentro de una habitacion primero te situa en la puerta mas cercana a tu destino
                if (myPBox.Tag.ToString().Split('/')[0] == "room")
                {
                    int doorNum = Convert.ToInt32(myPBox.Tag.ToString().Split('/')[1]);
                    myPosTemp = boardGrids.closestDoorToNextPos(hoveredPos, doorNum);
                    myPBox = grid[myPosTemp.X, myPosTemp.Y];
                }

                // Pathfinding desde mi posicion hasta posicion hovereada
                List<Position> positionsPath = null;
                if (hoveredPBox.Tag.ToString().Split('/')[0] == "door")
                {
                    Position startPos = boardGrids.positionsBoard[myPosTemp.X, myPosTemp.Y];
                    Position endPos = boardGrids.positionsBoard[hoveredPos.X, hoveredPos.Y];
                    positionsPath = myPosTemp.FindPath(startPos, endPos, boardGrids.positionsBoard);
                }
                else
                {
                    Position startPos = boardGrids.positionsNoDoorsBoard[myPosTemp.X, myPosTemp.Y];
                    Position endPos = boardGrids.positionsNoDoorsBoard[hoveredPos.X, hoveredPos.Y];
                    positionsPath = myPosTemp.FindPath(startPos, endPos, boardGrids.positionsNoDoorsBoard);
                }

                // Display visual del camino
                if (positionsPath != null)
                    displayPathToNextPos(positionsPath, myPBox, diceRoll);
            }
            else
            {
                // When still not have played, display colours depending on location
                if (hoveredPBox.Tag.ToString() == "hway")
                    hoveredPBox.BackColor = Color.FromArgb(90, Color.Green);
                else if (hoveredPBox.Tag.ToString().Split('/')[0] == "Origin")
                    hoveredPBox.BackColor = Color.FromArgb(90, Color.Yellow);
                else if (hoveredPBox.Tag.ToString().Split('/')[0] == "door")
                    hoveredPBox.BackColor = Color.FromArgb(90, Color.Brown);
                else if (hoveredPBox.Tag.ToString().Split('/')[0] == "wall")
                    hoveredPBox.BackColor = Color.FromArgb(90, Color.Black);
                else if (hoveredPBox.Tag.ToString().Split('/')[0] == "room")
                    hoveredPBox.BackColor = Color.FromArgb(90, Color.DarkGray);
                else if (hoveredPBox.Tag.ToString().Split('/')[0] == "Teleport")
                    hoveredPBox.BackColor = Color.FromArgb(90, Color.Red);
                else if (hoveredPBox.Tag.ToString() == "void")
                    hoveredPBox.BackColor = Color.FromArgb(90, Color.DarkGreen);
            }
        }

        private void Tile_mouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            for (int row = 0; row < Rows; row++) {
                for (int col = 0; col < Columns; col++) {
                    grid[row,col].BackColor = Color.Transparent;
                }
            }
        }

        private void Tile_mouseClick(object sender, MouseEventArgs e)
        {
            PictureBox clickedPBox = (PictureBox)sender;
            Position clickedPos = new Position(0, 0);
            Position prePos = myPos;
            tbox_info.AppendText(String.Format("Posicion Previa: {0},{1}", myPos.X.ToString(), myPos.Y.ToString()) + Environment.NewLine);

            // Left click and when you have throws left
            if ((e.Button == MouseButtons.Left) && (lbl_diceRoll.Text != "-tirar-"))
            {
                int diceRoll = Convert.ToInt32(lbl_diceRoll.Text);
                int remainingMoves = diceRoll;

                // Search positon clicked
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Columns; col++)
                    {
                        // Position clicked found, save the position
                        if (grid[row, col] == clickedPBox)
                        {
                            clickedPos = new Position(row, col);
                            tbox_info.AppendText(String.Format("Posicion clicada: {0},{1}", clickedPos.X.ToString(), clickedPos.Y.ToString()) + Environment.NewLine);
                            tbox_info.AppendText(String.Format("Tipo de celda: {0}", grid[row, col].Tag) + Environment.NewLine);
                        }
                    }
                }

                // Case for already playing, thus player on board
                if (myPos.X != -1)
                {
                    PictureBox myPBox = grid[myPos.X, myPos.Y];

                    if (myPBox.Tag.ToString().Split('/')[0] == "room")
                    {
                        int roomNum = Convert.ToInt32(myPBox.Tag.ToString().Split('/')[1]);

                        if ((clickedPBox.Tag.ToString().Split('/')[0] == "Teleport") && (Convert.ToInt32(clickedPBox.Tag.ToString().Split('/')[1]) == roomNum))
                        {
                            int tpNum = Convert.ToInt32(clickedPBox.Tag.ToString().Split('/')[1]);
                            teleportPlayer(tpNum, roomNum);
                            return;
                        }
                        else
                        {
                            myPos = boardGrids.closestDoorToNextPos(clickedPos, roomNum);
                            myPBox = grid[myPos.X, myPos.Y];
                        }
                    }

                    // Pathfinding desde mi posicion hasta posicion clicada
                    Position startPos = boardGrids.positionsBoard[myPos.X, myPos.Y];
                    Position endPos = boardGrids.positionsBoard[clickedPos.X, clickedPos.Y];
                    List<Position> positionsPath = myPos.FindPath(startPos, endPos, boardGrids.positionsBoard);

                    if (positionsPath != null)
                    {
                        int totSteps = positionsPath.Count;
                        if (totSteps < diceRoll)
                        {
                            movePlayer(prePos, clickedPBox, clickedPos);
                            remainingMoves = diceRoll - totSteps;
                        }
                        else
                        {
                            Position nextPos = positionsPath[diceRoll - 1];
                            PictureBox nextPBox = grid[nextPos.X,nextPos.Y];

                            movePlayer(prePos, nextPBox, nextPos);
                            remainingMoves = 0;

                            // Display new path from position to next Pos
                            startPos = boardGrids.positionsBoard[myPos.X, myPos.Y];
                            endPos = boardGrids.positionsBoard[clickedPos.X, clickedPos.Y];
                            positionsPath = myPos.FindPath(startPos, endPos, boardGrids.positionsBoard);

                            displayPathToNextPos(positionsPath,myPBox,remainingMoves);
                        }

                        if (remainingMoves > 0)
                            lbl_diceRoll.Text = remainingMoves.ToString();
                        else if (remainingMoves == 0)
                            lbl_diceRoll.Text = "-tirar-";
                    }

                    int n1, n2;
                    if (remainingMoves >= 6)
                    {
                        n1 = 6;
                        n2 = remainingMoves - 6;
                    }
                    else
                    {
                        n1 = remainingMoves;
                        n2 = 0;
                    }
                    displayDiceNum(n1,n2);
                }

                // Case for still not have played, thus place the player in the tile selected
                else if (clickedPBox.Tag.ToString().Split('/')[0] == "Origin")
                {
                    clickedPBox.BackgroundImage = Properties.Resources.playerTile1;
                    myPos = clickedPos;
                }
            }

            else if (e.Button == MouseButtons.Right)
            {
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Columns; col++)
                    {
                        if ((grid[row, col] == clickedPBox) && (grid[row, col].BackgroundImage == null))
                            grid[row, col].BackgroundImage = Properties.Resources.playerTile2;
                        else if ((grid[row, col] == clickedPBox) && (grid[row, col].BackgroundImage != null))
                            grid[row, col].BackgroundImage = null;
                    }
                }
            }
        }

        private void movePlayer(Position prePos, PictureBox nextPBox, Position clickedPos)
        {
            if (nextPBox.Tag.ToString().Split('/')[0] == "hway")
            {
                grid[prePos.X, prePos.Y].BackgroundImage = null;
                myPos = clickedPos;
                nextPBox.BackgroundImage = Properties.Resources.playerTile1;
            }
            else if (nextPBox.Tag.ToString().Split('/')[0] == "door")
            {
                int doorNum = Convert.ToInt32(nextPBox.Tag.ToString().Split('/')[1]);
                inRoom = doorNum;
                grid[prePos.X, prePos.Y].BackgroundImage = null;
                myPos = boardGrids.moveToRoom(doorNum, grid);
                grid[myPos.X, myPos.Y].BackgroundImage = Properties.Resources.playerTile1;
            }

            // Clear all background from previous path
            for (int row = 0; row < Rows; row++) {
                for (int col = 0; col < Columns; col++) {
                    grid[row, col].BackColor = Color.Transparent;
                }
            }
        }

        private void teleportPlayer(int tpNum, int roomNum)
        {
            // Teleports go: 7 <-> 3 and 9 <-> 1
            int nextRoomNum = 0;
            switch (tpNum)
            {
                case 1:
                    tbox_info.AppendText(String.Format("Teleported to room: 9") + Environment.NewLine);
                    nextRoomNum = 9;
                    break;
                case 9:
                    tbox_info.AppendText(String.Format("Teleported to room: 1") + Environment.NewLine);
                    nextRoomNum = 1;
                    break;
                case 3:
                    tbox_info.AppendText(String.Format("Teleported to room: 7") + Environment.NewLine);
                    nextRoomNum = 7;
                    break;
                case 7:
                    tbox_info.AppendText(String.Format("Teleported to room: 3") + Environment.NewLine);
                    nextRoomNum = 3;
                    break;
            }
            inRoom = roomNum;
            grid[myPos.X, myPos.Y].BackgroundImage = null;
            myPos = boardGrids.moveToRoom(nextRoomNum, grid);
            grid[myPos.X, myPos.Y].BackgroundImage = Properties.Resources.playerTile1;
            
            lbl_diceRoll.Text = "-tirar-";
            displayDiceNum(0,0);
        }

        private void displayPathToNextPos(List<Position> positionsPath, PictureBox myPBox, int diceRoll)
        {
            if (positionsPath != null)
            {
                int step = 0;
                int totSteps = positionsPath.Count;

                foreach (Position pathPos in positionsPath)
                {
                    myPBox.BackColor = Color.FromArgb(20, Color.Green);

                    if (step < diceRoll - 1)
                    {
                        grid[pathPos.X, pathPos.Y].BackColor = Color.FromArgb(50, Color.Green);
                    }
                    else if (step == diceRoll - 1)
                    {
                        grid[pathPos.X, pathPos.Y].BackColor = Color.FromArgb(50, Color.Violet);
                    }
                    else if (step < totSteps - 1)
                    {
                        grid[pathPos.X, pathPos.Y].BackColor = Color.FromArgb(50, Color.Red);
                    }
                    else
                    {
                        grid[pathPos.X, pathPos.Y].BackColor = Color.FromArgb(50, Color.DarkViolet);
                    }
                    step++;
                }
            }
        }

        private void btton_pruebas_Click(object sender, EventArgs e)
        {
            int gridSizeX = 5;
            int gridSizeY = 5;

            // Initialize the grid
            Position[,] grid = new Position[gridSizeX, gridSizeY];

            // Populate the grid with nodes
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    // For simplicity, assume all nodes are walkable initially
                    bool isWalkable = true;

                    // Block some nodes
                    if ((x == 1 && y <= 3) || (x == 3 && y >= 1))
                    {
                        isWalkable = false;
                    }

                    // Create the node and add it to the grid
                    grid[x, y] = new Position(x, y, isWalkable);
                }
            }

            // Mark the start and end nodes (for testing purposes)
            Position startPosition = grid[0, 0];
            Position endPosition = grid[gridSizeX - 1, gridSizeY - 1];

            // Example: Output the grid
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (grid[x, y] == startPosition) {
                        Console.Write("S ");  // Start node
                    }
                    else if (grid[x, y] == endPosition) {
                        Console.Write("E ");  // End node
                    }
                    else if (grid[x, y].IsWalkable) {
                        Console.Write(". ");  // Blocked node
                    }
                    else {
                        Console.Write("X ");  // Walkable node
                    }
                }
                Console.WriteLine();
            }


            List<Position> path = startPosition.FindPath(startPosition, endPosition, grid);
            foreach (Position pathPosition in path)
            {
                Console.Write(pathPosition.X + "," + pathPosition.Y);
                Console.Write(" -> ");
            }
            Console.WriteLine();
        }

        private void pBox_dice_MouseEnter(object sender, EventArgs e)
        {
            PictureBox dice = (PictureBox)sender;
            dice.BackColor = Color.FromArgb(20, Color.Green);
        }

        private void pBox_dice_MouseLeave(object sender, EventArgs e)
        {
            PictureBox dice = (PictureBox)sender;
            dice.BackColor = Color.Transparent;
        }

        private void btt_pruebas2_Click(object sender, EventArgs e)
        {
            tbox_pruebas.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
            tbox_pruebas.SelectionColor = Color.Red;
            tbox_pruebas.AppendText("Prueba de texto:");

            tbox_pruebas.AppendText(Environment.NewLine);
            tbox_pruebas.AppendText(Environment.NewLine);

            tbox_pruebas.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
            tbox_pruebas.SelectionColor = Color.Black;
            tbox_pruebas.AppendText("Hola, aquí la prueba, esto ha de ser negro, y pequeño.");
        }

        private void pbox_mensaje_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (tbox_mensaje.Text != ""))
            {
                tbox_pruebas.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                tbox_pruebas.SelectionColor = Color.DarkBlue;
                tbox_pruebas.AppendText("[All] Asier: ");

                tbox_pruebas.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                tbox_pruebas.SelectionColor = Color.Black;
                tbox_pruebas.AppendText(tbox_mensaje.Text);
                tbox_pruebas.AppendText(Environment.NewLine);

                tbox_pruebas.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                tbox_pruebas.SelectionColor = Color.Firebrick;
                tbox_pruebas.AppendText("Asier has left the lobby");
                tbox_pruebas.AppendText(Environment.NewLine);

                tbox_mensaje.Text = "";
            }
        }

        private void pBox_mostrarConectados_MouseEnter(object sender, EventArgs e)
        {
            PictureBox arrowConn = (PictureBox)sender;
            arrowConn.BackColor = Color.FromArgb(20, Color.Green);
        }

        private void pBox_mostrarConectados_MouseLeave(object sender, EventArgs e)
        {
            PictureBox arrowConn = (PictureBox)sender;
            arrowConn.BackColor = Color.Transparent;
        }

        private void pBox_mostrarConectados_Click(object sender, EventArgs e)
        {
            PictureBox arrowConn = (PictureBox)sender;
            if (!dGrid_conectados.Visible)
            {
                dGrid_conectados.Visible = true;
                arrowConn.BackgroundImage = Properties.Resources.bottonConn2;
            }
            else
            {
                dGrid_conectados.Visible = false;
                arrowConn.BackgroundImage = Properties.Resources.bottonConn1;
            }    
        }
    }
}
