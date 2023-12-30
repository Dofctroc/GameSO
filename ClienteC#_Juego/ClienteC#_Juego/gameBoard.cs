using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClienteC__Juego
{
    public partial class gameBoard : Form
    {
        Socket server;
        string gameHost;
        int gameNum;

        public gameBoard(Socket server, int gameNum, string gameHost)
        {
            InitializeComponent();
            this.server = server;
            this.gameHost = gameHost;
            this.gameNum = gameNum;
        }

        int rows; int columns; int cornerBoardMargin;
        int tileWidth; int tileHeight;
        int diceRoll, diceRoll1, diceRoll2;
        Position myPos;         // Current position of the player in the grid
        PictureBox[,] grid;     // Grid of pictureBoxes representing each tile
        BoardDistribution boardGrids;   // Initalizes variables from custom class <BoardDistribution>
        Image[] dicesImg;       // Vector including all images a dice can have, ordered from 0 to 6 (0 being empty throw)

        List<Image> cardsOrderedDeck;
        List<Image> cardsDeck;
        List<Image> roomCards;
        List<Image> suspectCards;
        List<Image> weaponCards;


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Game of " + gameNum;

            cardsOrderedDeck = new List<Image> { Properties.Resources.room1, Properties.Resources.room2, Properties.Resources.room3, Properties.Resources.room4,
                Properties.Resources.room5, Properties.Resources.room6, Properties.Resources.room7, Properties.Resources.room8, Properties.Resources.room9,
                Properties.Resources.suspect1, Properties.Resources.suspect2, Properties.Resources.suspect3, Properties.Resources.suspect4, Properties.Resources.suspect5, Properties.Resources.suspect6,
                Properties.Resources.weapon1, Properties.Resources.weapon2, Properties.Resources.weapon3, Properties.Resources.weapon4, Properties.Resources.weapon5, Properties.Resources.weapon6};

            roomCards = new List<Image> (9);
            suspectCards = new List<Image>(6);
            weaponCards = new List<Image>(6);

            // Variables assignment
            rows = 25; columns = 24;
            tileWidth = 26; tileHeight = 26;
            cornerBoardMargin = 15;
            panel_Board.Size = new Size(tileWidth*columns, tileHeight*rows);
            grid = new PictureBox[rows, columns];
            boardGrids = new BoardDistribution();
            dicesImg = new Image[] {Properties.Resources.DiceEmpty, Properties.Resources.Dice1, Properties.Resources.Dice2,
                Properties.Resources.Dice3, Properties.Resources.Dice4, Properties.Resources.Dice5, Properties.Resources.Dice6};

            myPos = new Position(-1, -1);

            // Creation of the board picture boxes grid
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < columns; col++) {
                    grid[row, col] = new PictureBox();
                    grid[row, col].Location = new Point(cornerBoardMargin - 1 + tileWidth + col * tileWidth, cornerBoardMargin - 1 + tileHeight + row * tileHeight);
                    grid[row, col].Size = new Size(tileWidth, tileHeight);
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

            // All buttons arrangement in the form
            panel_Board.Size = new Size(tileWidth*columns + 2*(tileWidth + cornerBoardMargin), tileHeight*rows + 2*(tileHeight + cornerBoardMargin));
            panel_Board.Location = new Point(300,10);

            panel_Dados.Size = new Size(panel_Board.Location.X - 20, 130);
            panel_Dados.Location = new Point(panel_Board.Location.X / 2 - panel_Dados.Width / 2, panel_Board.Location.Y);

            btt_dado.Size = new Size(120, 25);
            lbl_diceRoll.Size = new Size(60, 20);
            btt_dado.Font = new Font("Arial", 10, FontStyle.Bold);
            btt_dado.Location = new Point(panel_Dados.Width / 2 - btt_dado.Width / 2, panel_Board.Location.Y);
            lbl_diceRoll.Location = new Point(btt_dado.Location.X + btt_dado.Width + 5, btt_dado.Location.Y + btt_dado.Height - lbl_diceRoll.Height);

            pBox_dice1.Size = pBox_dice2.Size = new Size(80, 80);
            pBox_dice1.Location = new Point(panel_Dados.Width / 2 - 5 - pBox_dice1.Width, btt_dado.Location.Y + btt_dado.Height + 5);
            pBox_dice2.Location = new Point(panel_Dados.Width / 2 + 5, pBox_dice1.Location.Y);
            pBox_dice1.BackgroundImageLayout = pBox_dice2.BackgroundImageLayout = ImageLayout.Stretch;
            pBox_dice1.BackColor = pBox_dice2.BackColor = Color.Transparent;

            pBox_notePad.Size = new Size(130, 130);
            pBox_notePad.Location = new Point(panel_Board.Location.X + panel_Board.Width + 5, panel_Board.Location.Y + panel_Board.Height - pBox_notePad.Height);

            lbl_notePad.Size = lbl_cards.Size = new Size(130, 20);
            lbl_notePad.BorderStyle = lbl_cards.BorderStyle = BorderStyle.None;
            lbl_notePad.Font = lbl_cards.Font = new Font("Arial", 11, FontStyle.Regular);
            lbl_notePad.TextAlign = lbl_cards.TextAlign = ContentAlignment.MiddleLeft;
            lbl_notePad.Location = new Point(pBox_notePad.Location.X, pBox_notePad.Location.Y - lbl_notePad.Height - 5);
            lbl_cards.Location = new Point(pBox_notePad.Location.X, panel_Board.Location.Y);

            pBox_card1.Size = pBox_card2.Size = pBox_card3.Size = new Size(130,178);
            pBox_card1.Location = new Point(lbl_cards.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5);
            pBox_card2.Location = new Point(lbl_cards.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5 + pBox_card1.Height + 5);
            pBox_card3.Location = new Point(lbl_cards.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5 + pBox_card1.Height + 5 + pBox_card2.Height + 5);

            gBox_chat.Size = new Size(panel_Board.Location.X - 10 * 2, 300);
            gBox_chat.Location = new Point(10, panel_Board.Location.Y + panel_Board.Height - gBox_chat.Height);
            richtBox_read.Location = new Point(5, 15);
            richtBox_read.Size = new Size(gBox_chat.Width - 10, gBox_chat.Height - 50);
            lbl_write.Location = new Point(richtBox_read.Location.X, richtBox_read.Location.Y + richtBox_read.Height + 5);
            lbl_write.Size = new Size(35, tBox_write.Height);
            tBox_write.Width = richtBox_read.Width - lbl_write.Width - pBox_sendText.Width - 10;
            tBox_write.Location = new Point(lbl_write.Location.X + lbl_write.Width + 5, lbl_write.Location.Y);
            pBox_sendText.Location = new Point(tBox_write.Location.X + tBox_write.Width + 5, lbl_write.Location.Y);

            panel_Guess.Location = new Point(panel_Dados.Location.X, panel_Dados.Location.Y + panel_Dados.Height + 20);
            panel_Guess.Size = new Size(panel_Dados.Width, 200);
            lbl_suspect.Size = lbl_weap.Size = lbl_room.Size = new Size(85, 20);
            lbl_suspect.Location = new Point(5,5);
            lbl_weap.Location = new Point(lbl_suspect.Location.X + lbl_suspect.Width + 5, 5);
            lbl_room.Location = new Point(lbl_weap.Location.X + lbl_weap.Width + 5, 5);
            lbl_suspect.Font = lbl_weap.Font = lbl_room.Font = new Font("Arial", 10, FontStyle.Regular);
            panel_guess1.Size = panel_guess2.Size = panel_guess3.Size = new Size(lbl_suspect.Width,130);
            panel_guess1.Location = new Point(5, lbl_suspect.Location.Y + lbl_suspect.Height + 5);
            panel_guess2.Location = new Point(panel_guess1.Location.X + panel_guess1.Width + 5, panel_guess1.Location.Y);
            panel_guess3.Location = new Point(panel_guess2.Location.X + panel_guess2.Width + 5, panel_guess1.Location.Y);
            btt_guess.Location = new Point(panel_Guess.Width / 2 - btt_guess.Width / 2, panel_guess1.Location.Y + panel_guess1.Height + 5);
            pBox_check1.Size = pBox_check2.Size = pBox_check3.Size = new Size(50, 50);
            pBox_check1.Location = pBox_check2.Location = pBox_check3.Location = new Point(panel_guess1.Width / 2 - pBox_check1.Width / 2, panel_guess1.Height / 2 - pBox_check1.Height / 2);

            btt_solve.Size = new Size(100,50);
            btt_solve.Location = new Point(panel_Board.Location.X / 2 - btt_solve.Width / 2, panel_Guess.Location.Y + panel_Guess.Height + 20);
            // Cards logic

            string cardTypeName = "room";
            int n = 1;
            foreach (Image card in cardsOrderedDeck)
            {
                card.Tag = cardTypeName;
                if (n == 9)
                    cardTypeName = "suspect";
                if (n == 15)
                    cardTypeName = "weapon";
                n++;
            }

            cardsDeck = cardsOrderedDeck;
            Shuffle(cardsDeck);

            foreach (Image card in cardsDeck)
            {
                if (card.Tag.ToString() == "room")
                    roomCards.Add(card); 
                else if (card.Tag.ToString() == "suspect")
                    suspectCards.Add(card);
                else if (card.Tag.ToString() == "weapon")
                    weaponCards.Add(card);
            }

            pBox_card1.BackgroundImage = suspectCards[0];
            pBox_card2.BackgroundImage = weaponCards[1];
            pBox_card3.BackgroundImage = roomCards[2];

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
                for (int row = 0; row < rows; row++) {
                    for (int col = 0; col < columns; col++) 
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
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < columns; col++) {
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
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
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
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
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
                grid[prePos.X, prePos.Y].BackgroundImage = null;
                myPos = boardGrids.moveToRoom(doorNum, grid);
                grid[myPos.X, myPos.Y].BackgroundImage = Properties.Resources.playerTile1;
            }

            // Clear all background from previous path
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < columns; col++) {
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

        private void pBox_notePad_MouseEnter(object sender, EventArgs e)
        {
            PictureBox notepad = (PictureBox)sender;
            notepad.BackgroundImage = Properties.Resources.notepad_IconHovered;
        }

        private void pBox_notePad_MouseLeave(object sender, EventArgs e)
        {
            PictureBox notepad = (PictureBox)sender;
            notepad.BackgroundImage = Properties.Resources.notepad_Icon;
        }

        private void pBox_card1_Click(object sender, EventArgs e)
        {
            PictureBox card = (PictureBox)sender;
        }

        private void pBox_card2_Click(object sender, EventArgs e)
        {
            PictureBox card = (PictureBox)sender;
        }

        private void pBox_card3_Click(object sender, EventArgs e)
        {
            PictureBox card = (PictureBox)sender;
        }

        private void tBox_write_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                string text = tBox_write.Text;
                if (text != "")
                {
                    e.SuppressKeyPress = true;
                    richtBox_read.SelectionFont = new Font("Calibri", 10, FontStyle.Regular);
                    richtBox_read.SelectionColor = Color.Black;
                    richtBox_read.AppendText(text);
                    richtBox_read.AppendText(Environment.NewLine);
                    tBox_write.Clear();
                }
                else
                {
                    e.SuppressKeyPress = true;
                    tBox_write.Clear();
                }
            }
        }

        private void button_Dado1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            // Generate a random integer between 1 and 6
            diceRoll1 = random.Next(1, 7);
            diceRoll2 = random.Next(1, 7);
            diceRoll = diceRoll1 + diceRoll2;
            lbl_diceRoll.Text = diceRoll.ToString();

            displayDiceNum(diceRoll1, diceRoll2);
        }

        private void pBox_notePad_Click(object sender, EventArgs e)
        {
            InGameNotes notePad = new InGameNotes(gameNum);
            notePad.Show();
        }

        // -------------------- FUNCTIONS INVOLVING CARDS LOGIC AND WORK -----------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------

        static void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
