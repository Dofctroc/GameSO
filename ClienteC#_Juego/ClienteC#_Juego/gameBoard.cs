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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ClienteC__Juego
{
    public partial class gameBoard : Form
    {
        Socket server;
        string gameHost, userName, playerGuess;
        List<string> partida;
        int gameNum;

        public gameBoard(Socket server, List<string> partida, int gameNum, string gameHost, string userName)
        {
            InitializeComponent();
            this.server = server;
            this.gameHost = gameHost;
            this.gameNum = gameNum;
            this.userName = userName;
            this.partida = partida;
        }

        int rows; int columns; int cornerBoardMargin;
        int tileWidth; int tileHeight;
        int diceRoll, diceRoll1, diceRoll2;
        bool myturn;

        int countSuspect = 0;
        int countWeapon = 0;
        int countRoom = 0;

        Position myPos;         // Current position of the player in the grid
        PictureBox[,] grid;     // Grid of pictureBoxes representing each tile
        BoardDistribution boardGrids;   // Initalizes variables from custom class <BoardDistribution>
        Image[] dicesImg;       // Vector including all images a dice can have, ordered from 0 to 6 (0 being empty throw)
        Image[] playerTileImg;
        int myIndex;

        List<PictureBox> myCardsPBox;
        List<Image> cardsImageList;

        List<Card> cardsList;
        List<Card> cardsDeck;
        List<List<Card>> playersCards;
        List<Card> myCards;
        List<Card> cardsSolution;
        List<Card> guessCards;
        List<Card> guessSuspect;
        List<Card> guessWeapon;
        List<Card> guessRoom;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Game of " + gameHost + ", Player is " + userName;
            myturn = false;
            ComprovarTurno(myturn);

            // Variables assignment
            rows = 25; columns = 24;
            tileWidth = 26; tileHeight = 26;
            cornerBoardMargin = 15;
            panel_Board.Size = new Size(tileWidth*columns, tileHeight*rows);
            grid = new PictureBox[rows, columns];
            boardGrids = new BoardDistribution();
            dicesImg = new Image[] {Properties.Resources.DiceEmpty, Properties.Resources.Dice1, Properties.Resources.Dice2,
                Properties.Resources.Dice3, Properties.Resources.Dice4, Properties.Resources.Dice5, Properties.Resources.Dice6};
            playerTileImg = new Image[] { Properties.Resources.playerTile1, Properties.Resources.playerTile2, Properties.Resources.playerTile3, 
                Properties.Resources.playerTile4, Properties.Resources.playerTile5, Properties.Resources.playerTile6};
            myIndex = partida.IndexOf(userName);

            myCardsPBox = new List<PictureBox> { pBox_card1,pBox_card2,pBox_card3,pBox_card4,pBox_card5,pBox_card6, pBox_card7, pBox_card8, pBox_card9 };

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

            // DICES PANELS DESIGN
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

            // NOTEPAD ICON AND LABEL DESIGN
            pBox_notePad.Size = new Size(130, 130);
            pBox_notePad.Location = new Point(panel_Board.Location.X + panel_Board.Width + 5, panel_Board.Location.Y + panel_Board.Height - pBox_notePad.Height);
            lbl_notePad.Size = lbl_cards.Size = new Size(130, 20);
            lbl_notePad.BorderStyle = lbl_cards.BorderStyle = BorderStyle.None;
            lbl_notePad.Font = lbl_cards.Font = new Font("Arial", 11, FontStyle.Regular);
            lbl_notePad.TextAlign = lbl_cards.TextAlign = ContentAlignment.MiddleLeft;
            lbl_notePad.Location = new Point(pBox_notePad.Location.X, pBox_notePad.Location.Y - lbl_notePad.Height - 5);
            lbl_cards.Location = new Point(pBox_notePad.Location.X, panel_Board.Location.Y);

            // YOUR CARDS DESIGN
            pBox_card1.Size = pBox_card2.Size = pBox_card3.Size = pBox_card4.Size = pBox_card5.Size = pBox_card6.Size = pBox_card7.Size = pBox_card8.Size = pBox_card9.Size = new Size(130,178);
            pBox_card1.Visible = pBox_card2.Visible = pBox_card3.Visible = pBox_card4.Visible = pBox_card5.Visible = pBox_card6.Visible = pBox_card7.Visible = pBox_card8.Visible = pBox_card9.Visible = false;
            pBox_card1.BackgroundImage = pBox_card2.BackgroundImage = pBox_card3.BackgroundImage = pBox_card4.BackgroundImage = pBox_card5.BackgroundImage = pBox_card6.BackgroundImage = pBox_card7.BackgroundImage = pBox_card8.BackgroundImage = pBox_card9.BackgroundImage = null;
            pBox_card1.Location = new Point(lbl_cards.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5);
            pBox_card2.Location = new Point(lbl_cards.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5 + pBox_card1.Height + 5);
            pBox_card3.Location = new Point(lbl_cards.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5 + pBox_card1.Height + 5 + pBox_card2.Height + 5);
            pBox_card4.Location = new Point(lbl_cards.Location.X + pBox_card1.Width + 5, panel_Board.Location.Y + lbl_cards.Height + 5);
            pBox_card5.Location = new Point(pBox_card4.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5 + pBox_card4.Height + 5);
            pBox_card6.Location = new Point(pBox_card4.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5 + pBox_card4.Height + 5 + pBox_card5.Height + 5);
            pBox_card7.Location = new Point(lbl_cards.Location.X + pBox_card1.Width + 5 + pBox_card4.Width + 5, panel_Board.Location.Y + lbl_cards.Height + 5);
            pBox_card8.Location = new Point(pBox_card7.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5 + pBox_card7.Height + 5);
            pBox_card9.Location = new Point(pBox_card7.Location.X, panel_Board.Location.Y + lbl_cards.Height + 5 + pBox_card7.Height + 5 + pBox_card8.Height + 5);

            // CHAT PANEL DESIGN
            gBox_chat.Size = new Size(panel_Board.Location.X - 10 * 2, 300);
            gBox_chat.Location = new Point(10, panel_Board.Location.Y + panel_Board.Height - gBox_chat.Height);
            richtBox_read.Location = new Point(5, 15);
            richtBox_read.Size = new Size(gBox_chat.Width - 10, gBox_chat.Height - 50);
            lbl_write.Location = new Point(richtBox_read.Location.X, richtBox_read.Location.Y + richtBox_read.Height + 5);
            lbl_write.Size = new Size(35, tBox_write.Height);
            tBox_write.Width = richtBox_read.Width - lbl_write.Width - pBox_sendText.Width - 10;
            tBox_write.Location = new Point(lbl_write.Location.X + lbl_write.Width + 5, lbl_write.Location.Y);
            pBox_sendText.Location = new Point(tBox_write.Location.X + tBox_write.Width + 5, lbl_write.Location.Y);

            // GUESS PANEL DESIGN
            panel_Guess.Location = new Point(panel_Dados.Location.X, panel_Dados.Location.Y + panel_Dados.Height + 20);
            panel_Guess.Size = new Size(panel_Dados.Width, 200);
            lbl_suspect.Size = lbl_weap.Size = lbl_room.Size = new Size(85, 20);
            lbl_suspect.Location = new Point(5,5);
            lbl_weap.Location = new Point(lbl_suspect.Location.X + lbl_suspect.Width + 5, 5);
            lbl_room.Location = new Point(lbl_weap.Location.X + lbl_weap.Width + 5, 5);
            lbl_suspect.Font = lbl_weap.Font = lbl_room.Font = new Font("Arial", 10, FontStyle.Regular);
            pBox_check1.Visible = pBox_check2.Visible = pBox_check3.Visible = false;
            panel_guess1.Size = panel_guess2.Size = panel_guess3.Size = new Size(lbl_suspect.Width,130);
            panel_guess1.Location = new Point(5, lbl_suspect.Location.Y + lbl_suspect.Height + 5);
            panel_guess2.Location = new Point(panel_guess1.Location.X + panel_guess1.Width + 5, panel_guess1.Location.Y);
            panel_guess3.Location = new Point(panel_guess2.Location.X + panel_guess2.Width + 5, panel_guess1.Location.Y);
            btt_guess.Location = new Point(panel_Guess.Width / 2 - btt_guess.Width / 2, panel_guess1.Location.Y + panel_guess1.Height + 5);
            pBox_check1.Size = pBox_check2.Size = pBox_check3.Size = new Size(50, 50);
            pBox_check1.Location = pBox_check2.Location = pBox_check3.Location = new Point(panel_guess1.Width / 2 - pBox_check1.Width / 2, panel_guess1.Height / 2 - pBox_check1.Height / 2);

            // SOLVE AND END-TURN BUTTONS DESIGN
            btt_solve.Size = new Size(100,50);
            btt_solve.Location = new Point(panel_Guess.Location.X, panel_Guess.Location.Y + panel_Guess.Height + 20);
            btt_endturn.Size = new Size(100, 50);
            btt_endturn.Location = new Point(panel_Guess.Location.X + panel_Guess.Width - btt_endturn.Width, panel_Guess.Location.Y + panel_Guess.Height + 20);

            // OTHERS GUESS PANEL DESIGN
            panel_OtrosGuess.Visible = false;
            btt_guessPass.Enabled = false;
            lbl_otrosGuess.Size = new Size(panel_Guess.Width - 10, 20);
            lbl_otrosGuess.Location = new Point(5, 5);
            lbl_otrosSuspect.Size = lbl_otrosWeapon.Size = lbl_otrosRoom.Size = new Size(100, 20);
            lbl_otrosSuspect.Location = new Point(5, lbl_otrosGuess.Location.Y + lbl_otrosGuess.Height + 5);
            lbl_otrosWeapon.Location = new Point(lbl_otrosSuspect.Location.X + lbl_otrosSuspect.Width + 5, lbl_otrosSuspect.Location.Y);
            lbl_otrosRoom.Location = new Point(lbl_otrosWeapon.Location.X + lbl_otrosWeapon.Width + 5, lbl_otrosSuspect.Location.Y);
            lbl_otrosGuess.Font = new Font("Arial", 10, FontStyle.Bold);
            lbl_otrosSuspect.Font = lbl_otrosWeapon.Font = lbl_otrosRoom.Font = new Font("Arial", 9, FontStyle.Regular);
            pBox_guessCheck1.Visible = pBox_guessCheck2.Visible = pBox_guessCheck3.Visible = false;
            pBox_guessCheck1.Size = pBox_guessCheck2.Size = pBox_guessCheck3.Size = new Size(50, 50);
            pBox_guessCheck1.Location = pBox_guessCheck2.Location = pBox_guessCheck3.Location = new Point(panel_OtrosGuess1.Width / 2 - pBox_guessCheck1.Width / 2, panel_OtrosGuess1.Height / 2 - pBox_guessCheck1.Height / 2);
            panel_OtrosGuess1.Size = panel_OtrosGuess2.Size = panel_OtrosGuess3.Size = new Size(100, 150);
            panel_OtrosGuess1.Location = new Point(5, lbl_otrosSuspect.Location.Y + lbl_otrosSuspect.Height);
            panel_OtrosGuess2.Location = new Point(panel_OtrosGuess1.Location.X + panel_OtrosGuess1.Width + 5, panel_OtrosGuess1.Location.Y);
            panel_OtrosGuess3.Location = new Point(panel_OtrosGuess2.Location.X + panel_OtrosGuess2.Width + 5, panel_OtrosGuess1.Location.Y);
            lbl_otrosGuess.Size = new Size(panel_Guess.Width - 10, 20);
            lbl_guessPass.Location = new Point(5, panel_OtrosGuess1.Location.Y + panel_OtrosGuess1.Height + 5);
            lbl_guessPass.Size = new Size(panel_OtrosGuess1.Width*2 + 5, 30);
            btt_guessPass.Location = new Point(lbl_guessPass.Location.X + lbl_guessPass.Width + 5, lbl_guessPass.Location.Y);
            btt_guessPass.Size = new Size(100, 30);
            panel_OtrosGuess.Size = new Size(5 + (5 + panel_OtrosGuess1.Width) * 3, 20 + lbl_otrosGuess.Height + lbl_otrosSuspect.Height + panel_OtrosGuess1.Height + lbl_guessPass.Height);
            panel_OtrosGuess.Location = new Point(panel_Board.Location.X + (panel_Board.Width - panel_OtrosGuess.Width) / 2, panel_Board.Location.Y + (panel_Board.Height - panel_OtrosGuess.Height) / 2);
            panel_OtrosGuess.BackColor = Color.YellowGreen;
            panel_OtrosGuess.BackColor = Color.Tan;

            // INITIAL CARDS LOGIC IF HOST
            cardsSolution = new List<Card>(3);
            myCards = new List<Card>();
            CreateCards();

            if (gameHost == userName)
            {
                cardsDeck = new List<Card>(cardsList);
                Shuffle(cardsDeck);

                PrintCardsDeck(cardsDeck);

                DistributeCards(cardsDeck);

                SendCardsServer();

                DisplayMyCards(playersCards[0]);
            }

            //INITIALIZATION OF CARDS OF GUESS PER TYPE
            guessSuspect = new List<Card>();
            guessWeapon = new List<Card>();
            guessRoom = new List<Card>();
            foreach (Card card in cardsList)
            {
                if (card.type == "suspect")
                    guessSuspect.Add(card);
                if (card.type == "weapon")
                    guessWeapon.Add(card);
                if (card.type == "room")
                    guessRoom.Add(card);
            }
            panel_guess1.BackgroundImage = guessSuspect[0].image;
            panel_guess2.BackgroundImage = guessWeapon[0].image;
            panel_guess3.BackgroundImage = guessRoom[0].image;

            tbox_info.AppendText(String.Format("CartasGuess: Suspect: {0}, Weapon: {1}, Room: {2}", guessSuspect[0].ID.ToString(), guessWeapon[0].ID.ToString(), guessRoom[0].ID.ToString()) + Environment.NewLine);

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
            int num = num1 + num2;
            if (num > 0)
                lbl_diceRoll.Text = num.ToString();
            else if (num == 0)
                lbl_diceRoll.Text = "-tirar-";
        }

        private void Tile_mouseEnter(object sender, EventArgs e)
        {
            Position myPosTemp = myPos;
            Position hoveredPos = new Position(0, 0);
            PictureBox hoveredPBox = (PictureBox)sender;

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
            if ((e.Button == MouseButtons.Left) && (diceRoll != 0) && (clickedPBox.BackgroundImage == null))
            {
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
                    diceRoll = remainingMoves;
                    displayDiceNum(n1,n2);
                }

                // Case for still not have played, thus place the player in the tile selected
                else if (clickedPBox.Tag.ToString().Split('/')[0] == "Origin")
                {
                    clickedPBox.BackgroundImage = playerTileImg[myIndex];
                    myPos = clickedPos;
                }

                string msgPrePos = prePos.X.ToString() + "." + prePos.Y.ToString();
                string msgPos = myPos.X.ToString() + "." + myPos.Y.ToString();
                string mensaje = "45/" + gameHost + "/" + userName + "/" + msgPrePos + "/" + msgPos;
                Console.WriteLine("Position info sent to server:" + mensaje);
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
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
                nextPBox.BackgroundImage = playerTileImg[myIndex];
            }
            else if (nextPBox.Tag.ToString().Split('/')[0] == "door")
            {
                int doorNum = Convert.ToInt32(nextPBox.Tag.ToString().Split('/')[1]);
                grid[prePos.X, prePos.Y].BackgroundImage = null;
                myPos = boardGrids.moveToRoom(doorNum, grid);
                grid[myPos.X, myPos.Y].BackgroundImage = playerTileImg[myIndex];
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
            grid[myPos.X, myPos.Y].BackgroundImage = playerTileImg[myIndex];
            
            lbl_diceRoll.Text = "-tirar-";
            diceRoll = 0;
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

        private void pBox_notePad_Click(object sender, EventArgs e)
        {
            InGameNotes notePad = new InGameNotes(gameNum);
            notePad.Show();
        }

        // -------------------- FUNCTIONS INVOLVING CARDS LOGIC AND WORK -----------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------

        private void CreateCards()
        {
            string cardType = "room";
            cardsImageList = new List<Image> { Properties.Resources.room1, Properties.Resources.room2, Properties.Resources.room3, Properties.Resources.room4,
                Properties.Resources.room5, Properties.Resources.room6, Properties.Resources.room7, Properties.Resources.room8, Properties.Resources.room9,
                Properties.Resources.suspect1, Properties.Resources.suspect2, Properties.Resources.suspect3, Properties.Resources.suspect4, Properties.Resources.suspect5, Properties.Resources.suspect6,
                Properties.Resources.weapon1, Properties.Resources.weapon2, Properties.Resources.weapon3, Properties.Resources.weapon4, Properties.Resources.weapon5, Properties.Resources.weapon6};
            cardsList = new List<Card>();

            for (int i = 0; i < cardsImageList.Count; i++)
            {
                if (i == 9)
                    cardType = "suspect";
                if (i == 15)
                    cardType = "weapon";

                Card card = new Card(i, cardsImageList[i], cardType);
                cardsList.Add(card);
            }
        }

        private void DistributeCards(List<Card> shuffledDeck)
        {
            int count = partida.Count;

            // First select three cards that will be the solution
            bool room = false;
            bool suspect = false;
            bool weapon = false;
            List<Card> exShuffledDeck = new List<Card>(shuffledDeck);
            foreach (Card card in exShuffledDeck) {
                if (!room || !suspect || !weapon)
                {
                    if (!room && card.type == "room") {
                        cardsSolution.Add(card);
                        shuffledDeck.Remove(card);
                        room = true;
                    }
                    else if (!suspect && card.type == "suspect") {
                        cardsSolution.Add(card);
                        shuffledDeck.Remove(card);
                        suspect = true;
                    }
                    else if (!weapon && card.type == "weapon") {
                        cardsSolution.Add(card);
                        shuffledDeck.Remove(card);
                        weapon = true;
                    }
                }
                else
                    break;
            }

            tbox_info.AppendText(String.Format("Solutions cards: ") + Environment.NewLine);
            PrintCardsDeck(cardsSolution);

            // Then distribute all remaining cards
            playersCards = new List<List<Card>>(count);
            for (int i = 0; i < count; i++) {
                playersCards.Add(new List<Card>());
            }

            bool end = false;
            for (int i = 0; i < shuffledDeck.Count ; i += count)
            {
                if (end)
                    break;

                for (int j = 0; j < count; j++) {
                    if (shuffledDeck.Count > i + j)
                        playersCards[j].Add(shuffledDeck[i + j]);
                    else {
                        end = true;
                        break;
                    }
                }         
            }

            foreach (List<Card> cards in playersCards)
            {
                tbox_info.AppendText(String.Format("Deck: ") + Environment.NewLine);
                PrintCardsDeck(cards);
            }
        }

        private void Shuffle<T>(List<T> list)
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

        private void DisplayMyCards(List<Card> cards)
        {
            int count = cards.Count;

            for (int i= 0; i < count; i++)
            {
                myCardsPBox[i].Visible = true;
                myCardsPBox[i].BackgroundImage = cards[i].image;
            }
        }

        private void SendCardsServer()
        {
            string msgSolCards = cardsSolution[0].ID.ToString() + "." + cardsSolution[1].ID.ToString() + "." + cardsSolution[2].ID.ToString();

            string msgPlyCards = "";
            string msgPlyCards2 = "";
            // Solo se envia el del resto de jugadores, no el del host
            for (int i = 0; i < playersCards.Count; i++)
            {
                msgPlyCards = "";
                foreach (Card card in playersCards[i])
                {
                    msgPlyCards += card.ID.ToString() + ",";
                }
                msgPlyCards2 += msgPlyCards.ToString().Substring(0, msgPlyCards.Length - 1);
                msgPlyCards2 += ".";
            }

            string mensaje = "43/" + gameHost + "/" + msgSolCards + "/" + msgPlyCards2;
            Console.WriteLine("Deck info sent to server:" + mensaje);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void PrintCardsDeck(List<Card> deck)
        {
            foreach (Card card in deck) {
                tbox_info.AppendText(String.Format("c{0}{1}, ", card.ID, card.type));
            }
        }

        // -------------------- FUNCTIONS INVOLVING TURN LOGIC AND WORK -----------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------

        public void AtenderPartida(string[] mensaje)
        {
            int codigo, n;
            codigo = Convert.ToInt32(mensaje[0]);
            switch (codigo)
            {
                case 41:
                    myturn = true;
                    ComprovarTurno(myturn);
                    break;
                case 42:
                    break;
                case 43: // All cards info sent confirmation
                    break;
                case 44: // Solutions cards info
                    string[] cardsSolIndex = mensaje[2].Split('.');

                    // Take solution cards
                    cardsSolution = new List<Card>(3);
                    for (int i = 0; i < cardsSolIndex.Length; i++) {
                        cardsSolution.Add(cardsList[Convert.ToInt32(cardsSolIndex[i])]);
                    }
                    PrintCardsDeck(cardsSolution);

                    // Split players and players cards to search mine
                    string[] players = mensaje[3].Split('.');
                    string[] playersCards = mensaje[4].Split('.');

                    for (int i = 0; i < players.Length; i++)
                    {
                        if (players[i] == userName)
                        {
                            string[] myCardsID = playersCards[i].Split(',');
                            for (int j = 0; j < myCardsID.Length; j++)
                                myCards.Add(cardsList[Convert.ToInt32(myCardsID[j])]);
                        }
                    }
                    PrintCardsDeck(myCards);
                    DisplayMyCards(myCards);
                    break;
                case 45: // Player moved
                    string player = mensaje[2];
                    int playerIndex = partida.IndexOf(player);
                    string[] prePosition = mensaje[3].Split('.');
                    int prePosX = Convert.ToInt32(prePosition[0]);
                    int prePosY = Convert.ToInt32(prePosition[1]);
                    string[] position = mensaje[4].Split('.');
                    int posX = Convert.ToInt32(position[0]);
                    int posY = Convert.ToInt32(position[1]);

                    if (prePosX != -1 && prePosY != -1)
                        grid[prePosX, prePosY].BackgroundImage = null;
                    if (posX != -1 && posY != -1)
                        grid[posX, posY].BackgroundImage = playerTileImg[playerIndex];
                    break;
                case 46:
                    playerGuess = mensaje[2];
                    string[] cardsGuess = mensaje[3].Split('.');
                    guessCards = new List<Card> { cardsList[Convert.ToInt32(cardsGuess[0])] , cardsList[Convert.ToInt32(cardsGuess[1])] , cardsList[Convert.ToInt32(cardsGuess[2])] };

                    panel_OtrosGuess.Enabled = false;
                    panel_OtrosGuess1.BackgroundImage = guessCards[0].image;
                    panel_OtrosGuess2.BackgroundImage = guessCards[1].image;
                    panel_OtrosGuess3.BackgroundImage = guessCards[2].image;
                    lbl_otrosGuess.Text = "Player " + playerGuess + " made a guess: ";
                    panel_OtrosGuess1.Enabled = panel_OtrosGuess2.Enabled = panel_OtrosGuess3.Enabled = false;
                    pBox_guessCheck1.Visible = pBox_guessCheck1.Visible = pBox_guessCheck1.Visible = false;
                    panel_OtrosGuess.Visible = true;

                    if ((partida.IndexOf(playerGuess) + 1 == partida.IndexOf(userName)) || (partida.IndexOf(playerGuess) + 1 == partida.Count && partida.IndexOf(userName) == 0))
                    {
                        lbl_guessPass.Text = "Your Turn";
                        panel_OtrosGuess.Enabled = true;
                        btt_guessPass.Enabled = true;
                        n = 0;
                        foreach (Card card in guessCards) {
                            foreach (Card card2 in myCards)
                            {
                                if (card.ID == card2.ID)
                                {
                                    if (n == 0)
                                        panel_OtrosGuess1.Enabled = true;
                                    if (n == 1)
                                        panel_OtrosGuess2.Enabled = true;
                                    if (n == 2)
                                        panel_OtrosGuess3.Enabled = true;
                                }
                            }
                            n++;
                        }
                        if(panel_OtrosGuess1.Enabled == true || panel_OtrosGuess2.Enabled == true || panel_OtrosGuess3.Enabled == true)
                            btt_guessPass.Enabled = false;
                    }
                    break;
                case 47:
                    lbl_guessPass.Text = "Your Turn";
                    panel_OtrosGuess.Enabled = true;
                    btt_guessPass.Enabled = true;
                    n = 0;
                    foreach (Card card in guessCards)
                    {
                        foreach (Card card2 in myCards)
                        {
                            if (card.ID == card2.ID)
                            {
                                if (n == 0)
                                    panel_OtrosGuess1.Enabled = true;
                                if (n == 1)
                                    panel_OtrosGuess2.Enabled = true;
                                if (n == 2)
                                    panel_OtrosGuess3.Enabled = true;
                            }
                        }
                        n++;
                    }
                    if (panel_OtrosGuess1.Enabled == true || panel_OtrosGuess2.Enabled == true || panel_OtrosGuess3.Enabled == true)
                        btt_guessPass.Enabled = false;
                    break;
                case 48:
                    playerGuess = mensaje[2];
                    string playerResponded = mensaje[3];
                    richtBox_read.AppendText(String.Format("Player {0} answered the guess from {1}.", playerResponded, playerGuess) + Environment.NewLine);

                    panel_OtrosGuess.Visible = false;

                    // If you are the one who guessed in the first place
                    if (playerGuess == userName)
                    {
                        int answerCardID = Convert.ToInt32(mensaje[4]);
                        Card answerCard = cardsList[answerCardID];
                        if (answerCard.type == "suspect")
                            pBox_check1.Visible = true;
                        else if (answerCard.type == "weapon")
                            pBox_check2.Visible = true;
                        else if (answerCard.type == "room")
                            pBox_check3.Visible = true;
                    }
                    break;
                case 49:

                    break;
            }
        }

        private void btt_dado_Click(object sender, EventArgs e)
        {
            btt_dado.Enabled = false;

            Random random = new Random();
            // Generate a random integer between 1 and 6
            diceRoll1 = random.Next(1, 7);
            diceRoll2 = random.Next(1, 7);
            diceRoll = diceRoll1 + diceRoll2;
            lbl_diceRoll.Text = diceRoll.ToString();

            displayDiceNum(diceRoll1, diceRoll2);
        }

        private void btt_guess_Click(object sender, EventArgs e)
        {
            btt_dado.Enabled = false;
            btt_guess.Enabled = false;
            panel_Board.Enabled = false;
            btt_solve.Enabled = false;

            string suspect = guessSuspect[countSuspect].ID.ToString();
            string weapon = guessWeapon[countWeapon].ID.ToString();
            string room = guessRoom[countRoom].ID.ToString();

            string mensaje = "46/" + gameHost + "/" + userName + "/" + suspect + "." + weapon + "." + room;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        
        // Logic to iterate the guess cards selection
        private void panel_guess1_Click(object sender, EventArgs e)
        {
            pBox_check1.Visible = false;
            countSuspect++;
            if (countSuspect > 5)
                countSuspect = 0;
            panel_guess1.BackgroundImage = guessSuspect[countSuspect].image;
            
            tbox_info.AppendText(String.Format("CartasGuess: Suspect: {0}", guessSuspect[countSuspect].ID.ToString() + Environment.NewLine));
        }
        private void panel_guess2_Click(object sender, EventArgs e)
        {
            pBox_check2.Visible = false;
            countWeapon++;
            if (countWeapon > 5)
                countWeapon = 0;
            panel_guess2.BackgroundImage = guessWeapon[countWeapon].image;

            tbox_info.AppendText(String.Format("CartasGuess: Weapon: {0}", guessWeapon[countWeapon].ID.ToString() + Environment.NewLine));
        }
        private void panel_guess3_Click(object sender, EventArgs e)
        {
            pBox_check3.Visible = false;
            countRoom++;
            if (countRoom > 8)
                countRoom = 0;
            panel_guess3.BackgroundImage = guessRoom[countRoom].image;

            tbox_info.AppendText(String.Format("CartasGuess: Room: {0}", guessRoom[countRoom].ID.ToString() + Environment.NewLine));
        }

        // Events to handle response of guess
        private void btt_guessPass_Click(object sender, EventArgs e)
        {
            panel_OtrosGuess.Enabled = false;
            lbl_guessPass.Text = "Not your Turn";

            string mensaje = "47/" + gameHost + "/" + playerGuess + "/" + userName + "/" + "-1";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private void panel_OtrosGuess1_Click(object sender, EventArgs e)
        {
            panel_OtrosGuess.Enabled = false;
            pBox_guessCheck1.Visible = true;
            lbl_guessPass.Text = "Not your Turn";

            string mensaje = "47/" + gameHost + "/" + playerGuess + "/" + userName + "/" + guessCards[0].ID;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private void panel_OtrosGuess2_Click(object sender, EventArgs e)
        {
            panel_OtrosGuess.Enabled = false;
            pBox_guessCheck2.Visible = true;
            lbl_guessPass.Text = "Not your Turn";

            string mensaje = "47/" + gameHost + "/" + playerGuess + "/" + userName + "/" + guessCards[1].ID;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private void panel_OtrosGuess3_Click(object sender, EventArgs e)
        {
            panel_OtrosGuess.Enabled = false;
            pBox_guessCheck3.Visible = true;
            lbl_guessPass.Text = "Not your Turn";

            string mensaje = "47/" + gameHost + "/" + playerGuess + "/" + userName + "/" + guessCards[2].ID;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void btt_endturn_Click(object sender, EventArgs e)      //Un jugador ha acabado el turno y le toca al siguiente
        {
            displayDiceNum(0,0);
            myturn = false;
            ComprovarTurno(myturn);

            string mensaje = "42/" + gameHost + "/" + userName;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void ComprovarTurno (bool turno)
        {
            if (turno)
            {
                btt_dado.Enabled = true;
                btt_guess.Enabled = true;
                btt_solve.Enabled = true;
                panel_Board.Enabled = true;
                btt_endturn.Enabled = true;
            }
            else
            {
                btt_dado.Enabled = false;
                btt_guess.Enabled = false;
                panel_Board.Enabled = false;
                btt_solve.Enabled = false;
                btt_endturn.Enabled =false;
            }
        }
    }
}
