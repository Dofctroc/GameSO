using ClienteC__Juego.Properties;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace ClienteC__Juego
{
    public partial class menuPartida : Form
    {
        string username;
        string[] selectedPlayerToKick;
        bool hostingGame;

        int displayedGame;      // Corresponds to the currently shown on screen game
        List<string> partida1, partida2;        // Vectors of each game where all players are state, first one is the host. Ex: partida1[0] = host
        List<List<string>> partidas;            // Vector including both previous game vectors partidas[0] = game 1 & partidas[1] = game 2
        List<string> pendingInvitation;         // Vector of players from whom you await a response
        List<System.Windows.Forms.Button> partidasButtons;      // Vector of the two Buttons for displaying each game groupBox
        List<GroupBox> partidasGroups;                          // Vector of the two GroupBoxes that contain all the display of each game. Each contains: (dataGrid, kick button, chatBox, etc)
        List<DataGridView> partidasDataGrids;                   // Vector of the two datagridViews displaying the players of each game
        List<RichTextBox> partidasChats;                        // Vector of the two chatTextBox of each game
        List<PictureBox> partidasNotifPanels;
        List<System.Windows.Forms.Button> partidasKickButtons;

        List<Panel> invitacionesPaneles;
        List<System.Windows.Forms.Timer> invitacionesTimers;

        menuUsuario menuUsuario;
        Socket server;

        menuRankings menu_rankings;
        gameBoard tablero0;
        gameBoard tablero1;
        List<gameBoard> tableros;

        private Color[] coloresCharacters = { Color.Yellow, Color.Cyan, Color.Black, Color.Brown, Color.DarkBlue, Color.Crimson };

        public menuPartida(menuUsuario menuUsuario, Socket server, string username)
        {
            InitializeComponent();
            this.server = server;
            this.username = username;
            this.menuUsuario = menuUsuario;
        }

        private void principal_Load(object sender, EventArgs e)
        {
            // Variables declaration
            partida1 = new List<string>();
            partida2 = new List<string>();
            partidas = new List<List<string>> { partida1, partida2 }; ;
            pendingInvitation = new List<string>();
            partidasDataGrids = new List<DataGridView> { dgrid_miPartida0, dgrid_miPartida1 };
            partidasButtons = new List<System.Windows.Forms.Button> { btt_partida0, btt_partida1 };
            partidasKickButtons = new List<System.Windows.Forms.Button> { btt_kickPlayer0, btt_kickPlayer1 };
            partidasGroups = new List<GroupBox> { gBox_partida0, gBox_partida1 };
            partidasChats = new List<RichTextBox> { tbox_read0, tbox_read1 };
            partidasNotifPanels = new List<PictureBox> { pBox_notif0, pBox_notif1 };
            selectedPlayerToKick = new string[2];

            invitacionesPaneles = new List<Panel> (10);
            invitacionesTimers = new List<System.Windows.Forms.Timer> (10);

            tableros = new List<gameBoard> { tablero0, tablero1 };

            lbl_userName.Text = "Usuario: " + username;
            displayedGame = 0;

            // Data grid de la lista de usuarios
            dgrid_listaUsuarios.ColumnCount = 2;
            dgrid_listaUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font(dgrid_listaUsuarios.Font, FontStyle.Bold);

            dgrid_listaUsuarios.Columns[0].Name = "column_Username";
            dgrid_listaUsuarios.Columns[0].HeaderText = "Username";
            dgrid_listaUsuarios.Columns[1].Name = "column_Status";
            dgrid_listaUsuarios.Columns[1].HeaderText = "Status";

            dgrid_listaUsuarios.Width = 160;
            dgrid_listaUsuarios.Columns[0].Width = 80;
            dgrid_listaUsuarios.Columns[1].Width = dgrid_listaUsuarios.Width - dgrid_listaUsuarios.Columns[0].Width - 2;
            dgrid_listaUsuarios.Rows.Clear();

            // Data grid de mi Partida0 & Partida1
            dgrid_miPartida0.Visible = dgrid_miPartida1.Visible = true;

            dgrid_miPartida0.ColumnCount = dgrid_miPartida1.ColumnCount = 3;
            dgrid_miPartida0.ColumnHeadersDefaultCellStyle.Font = dgrid_miPartida1.ColumnHeadersDefaultCellStyle.Font = new Font(dgrid_miPartida0.Font, FontStyle.Bold);

            dgrid_miPartida0.Columns[0].Name = dgrid_miPartida1.Columns[0].Name = "column_ID";
            dgrid_miPartida0.Columns[0].HeaderText = dgrid_miPartida1.Columns[0].HeaderText = "ID";
            dgrid_miPartida0.Columns[1].Name = dgrid_miPartida1.Columns[1].Name = "column_Jugador";
            dgrid_miPartida0.Columns[1].HeaderText = dgrid_miPartida1.Columns[1].HeaderText = "Jugador";
            dgrid_miPartida0.Columns[2].Name = dgrid_miPartida1.Columns[2].Name = "column_Color";
            dgrid_miPartida0.Columns[2].HeaderText = dgrid_miPartida1.Columns[2].HeaderText = "Color";

            dgrid_miPartida0.Columns[0].Width = dgrid_miPartida1.Columns[0].Width = 40;
            dgrid_miPartida0.Columns[2].Width = dgrid_miPartida1.Columns[2].Width = 60;
            dgrid_miPartida0.Columns[1].Width = dgrid_miPartida1.Columns[1].Width = dgrid_miPartida0.Width - dgrid_miPartida0.Columns[0].Width - dgrid_miPartida0.Columns[2].Width - 2;
            dgrid_miPartida0.Rows.Clear();
            dgrid_miPartida1.Rows.Clear();

            // Data grid de personas a Invitar
            dgrid_listaInvitar.Visible = true;

            dgrid_listaInvitar.ColumnCount = 2;
            dgrid_listaInvitar.ColumnHeadersDefaultCellStyle.Font = new Font(dgrid_listaInvitar.Font, FontStyle.Bold);

            dgrid_listaInvitar.Columns[0].Name = "username";
            dgrid_listaInvitar.Columns[0].HeaderText = "Username";
            dgrid_listaInvitar.ColumnHeadersHeight = 20;

            dgrid_listaInvitar.Columns[0].Width = dgrid_listaInvitar.Width - 2;
            dgrid_listaInvitar.Rows.Clear();

            // Other properties
            gBox_partida0.Visible = false;
            gBox_partida1.Visible = false;
            gBox_partida1.Location = gBox_partida0.Location = new Point(btt_partida0.Location.X + 30, 10);
            gBox_partida0.BackColor = gBox_partida1.BackColor = Color.FromArgb(100, Color.White);
            btt_kickPlayer0.Visible = btt_kickPlayer1.Visible = false;
            gBox_partida0.Controls.Add(btt_kickPlayer0); gBox_partida1.Controls.Add(btt_kickPlayer1);
            btt_kickPlayer0.BringToFront(); btt_kickPlayer1.BringToFront();
            this.Controls.Add(gBox_partida0);
            this.Controls.Add(gBox_partida1);

            pBox_mostrarConn.Size = new Size(20, 40);
            lbl_write0.BackColor = Color.FromArgb(150, Color.White);

            dgrid_listaUsuarios.Location = new Point(pBox_mostrarConn.Location.X + pBox_mostrarConn.Width + 4, pBox_mostrarConn.Location.Y);
            dgrid_listaUsuarios.Size = new Size(160,gBox_partida0.Height);
            dgrid_listaUsuarios.Visible = false;

            pBox_notif0.Visible = pBox_notif1.Visible = false;
            btt_partida0.Visible = btt_partida1.Visible = false;

            hostingGame = false;

            CenterFormOnScreen();
        }

        private void menuPartida_FormClosing(object sender, FormClosingEventArgs e)
        {
            // The logic behind when disconnecting, sending messages of disconnection to other users is on the server
            menuUsuario.serverShutdown();
        }

        /// <summary>
        /// Function that when called changes current form's position on screen to the exact center
        /// </summary>
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
            this.Location = new Point(x, y);
        }

        // -------------------- ACTIONS EXECUTED BY BUTTONS WHEN CLICKED --------------------------------------------
        // ----------------------------------------------------------------------------------------------------------

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_partidanueva_Click(object sender, EventArgs e)
        {
            if ((partida1.Count == 0 || partida2.Count == 0) && !hostingGame)
            {
                string mensaje = "20/" + username;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void button_Invitar_Click(object sender, EventArgs e)
        {
            if (dgrid_listaInvitar.RowCount > 0)
            {
                string jugador;
                string jugadoresInvitar = "";
                string jugadoresInvitar1 = ".";
                foreach (DataGridViewRow fila in dgrid_listaInvitar.Rows)
                {
                    if (fila.Cells[0].Value != null)
                    {
                        jugador = fila.Cells[0].Value.ToString();
                        jugadoresInvitar = jugadoresInvitar1 + jugador + ".";
                        jugadoresInvitar1 = jugadoresInvitar;
                    }
                }

                string mensaje = "21/" + username + jugadoresInvitar;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
                MessageBox.Show("No hay nadie seleccionado a invitar");
        }

        private void btt_kickPlayer_Click(object sender, EventArgs e)
        {
            // Solo se podra dar click a eliminar si eres el host (condicional presente en cell click de miPartida)
            if (selectedPlayerToKick[displayedGame] != null)
            {
                string mensaje = "24/" + username + "/" + selectedPlayerToKick[displayedGame];
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                selectedPlayerToKick = null;
                btt_kickPlayer0.Visible = false;
            }
        }

        private void button_Jugar_Click(object sender, EventArgs e)
        {
            if (partidas[displayedGame].Count >= 2 && partidas[displayedGame][0] == username)
            {
                string mensaje = "40/" + username;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void btt_partida0_Click(object sender, EventArgs e)
        {
            displayedGame = 0;
            pBox_notif0.Visible = false;
            if (gBox_partida0.Visible)
                gBox_partida0.Visible = false;
            else
            {
                gBox_partida0.Visible = true;
                gBox_partida1.Visible = false;
            }
        }

        private void btt_partida1_Click(object sender, EventArgs e)
        {
            displayedGame = 1;
            pBox_notif1.Visible = false;
            if (gBox_partida1.Visible)
                gBox_partida1.Visible = false;
            else
            {
                gBox_partida1.Visible = true;
                gBox_partida0.Visible = false;
            }
        }

        private void pBox_sendText_Click(object sender, EventArgs e)
        {
            if (textBox_write0.Text != "")
            {
                Console.WriteLine(textBox_write0.Text);
                string men = textBox_write0.Text;
                string mensaje = "27/" + partidas[displayedGame][0] + "/" + username + "/" + men;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            textBox_write0.Text = "";
        }

        private void pBox_mostrarConn_Click(object sender, EventArgs e)
        {
            PictureBox arrowConn = (PictureBox)sender;
            if (!dgrid_listaUsuarios.Visible)
            {
                dgrid_listaUsuarios.Visible = true;
                arrowConn.BackgroundImage = Properties.Resources.bottonConn2;
            }
            else
            {
                dgrid_listaUsuarios.Visible = false;
                arrowConn.BackgroundImage = Properties.Resources.bottonConn1;
            }
        }

        /// <summary>
        /// Shows on console status of local variables for all games. <para>
        /// Also displays the buttons to access the game lobbies you are in. </para>
        /// </summary>
        private void updateStatusPartidas()
        {
            Console.WriteLine("     ----------------------      ");
            int n = 0;
            foreach (List<string> partida in partidas)
            {
                if (partida.Count == 0)
                    Console.WriteLine("Partida {0} nula.", n);
                else
                {
                    Console.WriteLine("Partida {0} no nula:", n);
                    for (int i = 0; i < partida.Count; i++)
                        Console.WriteLine("Jugador {0}: {1}", i, partida[i]);
                }
                n++;
            }
            Console.WriteLine("Pending invitations:");
            for (int i = 0; i < pendingInvitation.Count; i++)
                Console.WriteLine("Jugador {0}: {1}", i, pendingInvitation[i]);
            Console.WriteLine("     ----------------------      ");

            // Each time a msg arrives from server, at the end, it checks which game lobbies you are in and displays its corresponding button
            hostingGame = false;
            for (int b = 0; b < 2; b++)
            {
                if (partidas[b].Count != 0)
                {
                    partidasButtons[b].Visible = true;
                    if (partidas[b][0] == username)
                        hostingGame = true;
                }
                else
                    partidasButtons[b].Visible = false;
            }
        }

        // -------------------- ALL DATAGRID UPDATES -------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Updates the whole connected players dataGrid (receives information of every connected player each time).
        /// </summary>
        /// <param name="mensaje"> Input in the form of: Player1.Status1.Player2.Status2... </param>
        public void listaConectados(string mensaje)
        {
            string[] mensajeCodificado = mensaje.Split('.');
            dgrid_listaUsuarios.Rows.Clear();

            string status;
            for (int i = 0; i < mensajeCodificado.Length - 1; i += 2)
            {
                if (Int32.Parse(mensajeCodificado[i + 1]) == 0)
                    status = "InMenu";
                else
                    status = "InGame";

                dgrid_listaUsuarios.Rows.Add(mensajeCodificado[i], status);
            }
            dgrid_listaUsuarios.ClearSelection();
        }

        /// <summary>
        /// When called, adds in order all players from the input string in the corresponding game dataGrid.
        /// </summary>
        /// <param name="p"> Number representing the game of which the incoming information is from. Can be 0 or 1. </param>
        /// <param name="jugadores"> String including all players separated by a '.' . </param>
        public void listaMiPartida(int p, string jugadores, string colores)
        {
            string[] vectorJugadores = jugadores.Split('.');
            string[] vectorColores = colores.Split('.');
            partidasDataGrids[p].Rows.Clear();

            partidasDataGrids[p].Rows.Add("Host", vectorJugadores[0]);
            partidasDataGrids[p].Rows[0].Cells[2].Style.BackColor = coloresCharacters[Convert.ToInt32(vectorColores[0])];
            for (int i = 1; i < vectorJugadores.Length - 1; i++)
            {
                partidasDataGrids[p].Rows.Add(i, vectorJugadores[i], "");
                partidasDataGrids[p].Rows[i].Cells[2].Style.BackColor = coloresCharacters[Convert.ToInt32(vectorColores[i])];
            }
            partidasDataGrids[p].ClearSelection();
        }

        /// <summary>
        /// When called, depending on the input it adds or deletes a player from the corresponding game dataGrid.
        /// </summary>
        /// <param name="p"> Number representing the game of which the incoming information is from. Can be 0 or 1. </param>
        /// <param name="jugador"> Name of the player. </param>
        /// <param name="afegir"> Determines if said player will be added or deleted. TRUE: added. FALSE: deleted. </param>
        public void listaMiPartida(int p, string jugador, bool afegir, string colores) 
        {
            if (afegir)
            {
                if (partidas[p].Count == 1)
                {
                    string[] vectorColores = colores.Split('.');
                    partidasDataGrids[p].Rows.Add("Host", jugador, "");

                    int colorID = Convert.ToInt32(vectorColores[partidas[p].IndexOf(jugador)]);
                    partidasDataGrids[p].Rows[0].Cells[2].Style.BackColor = coloresCharacters[colorID];
                }
                else
                {
                    string[] vectorColores = colores.Split('.');
                    partidasDataGrids[p].Rows.Add(partidasDataGrids[p].RowCount, jugador, "");

                    int colorID = Convert.ToInt32(vectorColores[partidas[p].IndexOf(jugador)]);
                    partidasDataGrids[p].Rows[partidas[p].IndexOf(jugador)].Cells[2].Style.BackColor = coloresCharacters[colorID];
                }
            }
            else
            {
                int n = partidas[p].IndexOf(jugador);
                partidasDataGrids[p].Rows.RemoveAt(n);
            }
            partidasDataGrids[p].ClearSelection();
        }

        // -------------------- INTERACTIONS WITH DATAGRIDS -----------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// When the dataGrid of all users connected is clicked, this method determines: <para>
        /// - If you are the host of the displayed game </para> <para>
        /// - If the clicked player is not currently in your game </para>
        /// If both conditions are met, the clicked player will be displayed in the invitations dataGrid
        /// to be able to invite them.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void dgrid_listaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool nuevo = true;
            bool invitable = true;
            string playerName;

            if (((partida1.Count > 0 && partida1[0] == username) || (partida2.Count > 0 && partida2[0] == username)) && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgrid_listaUsuarios.Rows[e.RowIndex];
                playerName = filaSeleccionada.Cells[0].Value.ToString();

                // Busca si estic esperant resposta del jugador encara
                foreach (string jugador in pendingInvitation)
                    if (jugador == playerName)
                        invitable = false;

                // Busca si el jugador ja esta a la meva partida
                foreach (List<string> partida in partidas) {
                    if (partida.Count != 0 && partida[0] == username) {
                        foreach (string jugador in partida)
                            if (jugador == playerName)
                                invitable = false;
                        break;
                    }
                }

                // Comprova que no t'invitis a tu mateix
                if (playerName != username && invitable)
                {
                    foreach (DataGridViewRow fila in dgrid_listaInvitar.Rows)
                        if (fila.Cells[0].Value != null)
                            if (fila.Cells[0].Value.ToString() == playerName)
                                nuevo = false;
                    if (nuevo == true)
                        dgrid_listaInvitar.Rows.Add(playerName);
                }
            }
        }

        private void dgrid_listaInvitar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex < dgrid_listaInvitar.Rows[e.RowIndex].Height / 2)
                    dgrid_listaInvitar.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgrid_miPartida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (e.RowIndex > 0 && e.ColumnIndex < 2 && ((partida1.Count > 0 && partida1[0] == username) || (partida2.Count > 0 && partida2[0] == username)))
            {
                partidasKickButtons[displayedGame].Visible = true;
                selectedPlayerToKick[displayedGame] = partidasDataGrids[displayedGame].Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else
                btt_kickPlayer0.Visible = false;

            if (e.ColumnIndex == 2 && e.RowIndex == partidas[displayedGame].IndexOf(username))
            {
                Color colorActual = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
                int indiceColor = Array.IndexOf(coloresCharacters, colorActual);
                int indiceNuevoColor = (indiceColor + 1) % coloresCharacters.Length;

                bool freeColor = true;
                int color = indiceNuevoColor;

                for (color = indiceNuevoColor; color < coloresCharacters.Length; color = (color + 1) % coloresCharacters.Length)
                {
                    freeColor = true;

                    for (int i = 0; i < partidas[displayedGame].Count; i++)
                    {
                        if (i != partidas[displayedGame].IndexOf(username))
                        {
                            if (partidasDataGrids[displayedGame].Rows[i].Cells[2].Style.BackColor == coloresCharacters[color])
                            {
                                freeColor = false;
                                break; // Salir del bucle interior si se encuentra un color ocupado
                            }
                        }
                    }

                    if (freeColor)
                    {
                        break; // Salir del bucle exterior si se encuentra un color libre
                    }
                }

                Color nuevoColor = coloresCharacters[color];
                partidasDataGrids[displayedGame].Rows[e.RowIndex].Cells[2].Style.BackColor = nuevoColor;

                string mensaje = "28/" + partidas[displayedGame][0] + "/" + username + "/" + color;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        // -------------------- CHAT AND CONNECTED INFO RELATED FUNCTIONS ----------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------

        private void pBox_mostrarConn_MouseEnter(object sender, EventArgs e)
        {
            PictureBox arrowConn = (PictureBox)sender;
            arrowConn.BackColor = Color.FromArgb(20, Color.Green);
        }

        private void pBox_mostrarConn_MouseLeave(object sender, EventArgs e)
        {
            PictureBox arrowConn = (PictureBox)sender;
            arrowConn.BackColor = Color.Transparent;
        }

        private void pBox_sendText_MouseEnter(object sender, EventArgs e)
        {
            PictureBox arrowConn = (PictureBox)sender;
            arrowConn.BackColor = Color.FromArgb(20, Color.Green);
        }

        private void pBox_sendText_MouseLeave(object sender, EventArgs e)
        {
            PictureBox arrowConn = (PictureBox)sender;
            arrowConn.BackColor = Color.Transparent;
        }

        private void textBox_write_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox_write0.Text != "")
                {
                    e.SuppressKeyPress = true;
                    string men = textBox_write0.Text;
                    string mensaje = "27/" + partidas[displayedGame][0] + "/" + username + "/" + men;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    textBox_write0.Clear();
                }
                else
                {
                    e.SuppressKeyPress = true;
                    textBox_write0.Clear();
                }

                if (textBox_write1.Text != "")
                {
                    e.SuppressKeyPress = true;
                    string men = textBox_write1.Text;
                    string mensaje = "27/" + partidas[displayedGame][0] + "/" + username + "/" + men;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    textBox_write1.Clear();
                }
                else
                {
                    e.SuppressKeyPress = true;
                    textBox_write1.Clear();
                }
            }
        }

        /// <summary>
        /// Writes a user's sent message in the corresponding game chat.
        /// </summary>
        /// <param name="c"> Number representing the game of which the incoming information is from. Can be 0 or 1. </param>
        /// <param name="chatMSG"> String representing the message to be written. </param>
        /// <param name="color"> Color of the written message. </param>
        private void WriteInChatTITLE(int c, string chatMSG, Color color)
        {
            partidasChats[c].SelectionFont = new Font("Arial", 10, FontStyle.Regular);
            partidasChats[c].SelectionColor = color;
            partidasChats[c].AppendText(chatMSG);
            partidasChats[c].AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Writes a user's sent message in the corresponding game chat.
        /// </summary>
        /// <param name="c"> Number representing the game of which the incoming information is from. Can be 0 or 1. </param>
        /// <param name="name"> Name of the player that sends said message. </param>
        /// <param name="chatMSG"> String representing the message to be written. </param>
        /// <param name="color"> Color of the written message. </param>
        private void WriteInChatMESSAGE(int c, string name, string chatMSG, Color color)
        {
            partidasChats[c].SelectionFont = new Font("Arial", 10, FontStyle.Regular);
            partidasChats[c].SelectionColor = Color.DarkBlue;
            partidasChats[c].AppendText(name + ": ");
            partidasChats[c].SelectionFont = new Font("Calibri", 10, FontStyle.Regular);
            partidasChats[c].SelectionColor = color;
            partidasChats[c].AppendText(chatMSG);
            partidasChats[c].AppendText(Environment.NewLine);
        }

        // -------------------- FUNCTION THAT PROCESSES ALL INCOMING DATA FROM SERVER ----------------------------------------
        // -------------------------------------------------------------------------------------------------------------------

        public void onResponse(string[] mensaje)
        {
            string invitado, nameHost, chatMSG; int codigo, gameIndex;

            gameIndex = -1; // Si es -1, no tens cap partida
            codigo = Convert.ToInt32(mensaje[0]);
            nameHost = mensaje[1];

            // Buscar a quina partida esta aquest host i si no esta a cap, l'index es -1
            foreach (List<string> partida in partidas)
            {
                if (partida.Count != 0 && partida[0] == nameHost)
                {
                    gameIndex = partidas.IndexOf(partida);
                    break;
                }
            }

            switch (codigo)
            {
                case 14:
                    menu_rankings.onReceive_DisplayInfo(mensaje);
                    break;
                case 15:
                    menu_rankings.onReceive_DisplayInfo(mensaje);
                    break;
                case 16:
                    menu_rankings.onReceive_DisplayInfo(mensaje);
                    break;
                case 17:
                    menu_rankings.onReceive_DisplayInfo(mensaje);
                    break;
                case 20: // Servidor confirma la creación de partida en que tu eres host
                    if (Convert.ToInt32(mensaje[2]) == 0)
                    {
                        foreach (List<string> partida in partidas)
                        {
                            if (partida.Count == 0)
                            {
                                partida.Add(username);
                                gameIndex = partidas.IndexOf(partida);
                                break;
                            }
                        }
                        listaMiPartida(gameIndex, username, true, mensaje[3]);

                        displayedGame = gameIndex;
                        for (int i = 0; i < partidasGroups.Count; i++)
                            if (i == gameIndex)
                                partidasGroups[i].Visible = true;
                            else
                                partidasGroups[i].Visible = false;

                        partidasChats[gameIndex].Text = "";
                        chatMSG = "Has creado una nueva partida";
                        WriteInChatTITLE(gameIndex, chatMSG, Color.DarkGreen);
                    }
                    else
                        MessageBox.Show("Error al crear la partida, vuelva a intentarlo.");
                    break;
                case 21: // Servidor confirma que se ha invitado a los seleccionados
                    if (Convert.ToInt32(mensaje[2]) == 0)
                    {
                        for (int i = 0; i < dgrid_listaInvitar.RowCount; i++)
                            pendingInvitation.Add(dgrid_listaInvitar.Rows[i].Cells[0].Value.ToString());
                        dgrid_listaInvitar.Rows.Clear();
                    }
                    else
                    {
                    }
                    break;
                case 22: // Te llega una invitación de un host
                    this.Invoke(new Action(() => { CreateInvitationPanel(nameHost); }));
                    break;
                case 23: // Respuesta cuando un jugador ha aceptado o no una invitación
                         // Mensaje que le llega a todos los jugadores en partida
                    invitado = mensaje[2];
                    string decision = mensaje[3];
                    if (decision == "Yes")
                    {
                        partidas[gameIndex].Add(invitado);
                        listaMiPartida(gameIndex, invitado, true, mensaje[4]);

                        chatMSG = "El usuario " + invitado + " se ha unido a la partida";
                        WriteInChatTITLE(gameIndex, chatMSG, Color.ForestGreen);

                        if (displayedGame != gameIndex)
                            partidasNotifPanels[gameIndex].Visible = true;
                    }
                    else
                    {
                        DialogResult showInvite = MessageBox.Show("El usuario " + invitado + " ha rechazado tu invitacion",
                            "Incoming Message", MessageBoxButtons.OK);
                    }
                    pendingInvitation.Remove(invitado);
                    break;
                case 24: // El host de la partida te ha expulsado
                    string expulsado = mensaje[2];
                    if (username == expulsado)
                    {
                        partidas[gameIndex].Clear();
                        partidasDataGrids[gameIndex].Rows.Clear();

                        // partidasGroups[gameIndex].Visible = false;

                        chatMSG = "El host " + nameHost + " te ha expulsado de la partida";
                        WriteInChatTITLE(gameIndex, chatMSG, Color.Crimson);

                        displayedGame = gameIndex;
                        for (int i = 0; i < partidasGroups.Count; i++)
                            if (i == gameIndex)
                                partidasGroups[i].Visible = true;
                            else
                                partidasGroups[i].Visible = false;
                    }
                    else
                    {
                        listaMiPartida(gameIndex, expulsado, false, "nada");
                        partidas[gameIndex].Remove(expulsado);

                        chatMSG = "El usuario " + expulsado + " ha sido expulsado de la partida";
                        WriteInChatTITLE(gameIndex, chatMSG, Color.Crimson);

                        if (displayedGame != gameIndex)
                            partidasNotifPanels[gameIndex].Visible = true;
                    }
                    break;
                case 25: // Jugador abandona partida voluntariamente

                    break;
                case 26: // La partida ha sido eliminada por el host
                    if (nameHost == username)
                    {
                        // Add if in other game, it MUST exit it before shutdown !!!!!!!!!!!!
                        // menuUsuario.serverShutdown();
                    }
                    else
                    {
                        partidas[gameIndex].Clear();
                        partidasDataGrids[gameIndex].Rows.Clear();

                        chatMSG = "El host " + nameHost + " ha eliminado la partida";
                        WriteInChatTITLE(gameIndex, chatMSG, Color.Crimson);
                    }
                    break;
                case 27: // Mensaje del chat
                    string sender = mensaje[2];
                    chatMSG = mensaje[3];
                    WriteInChatMESSAGE(gameIndex, sender, chatMSG, Color.Black);

                    if (displayedGame != gameIndex)
                        partidasNotifPanels[gameIndex].Visible = true;

                    break;
                case 28:
                    string player = mensaje[2];
                    int colorID = Convert.ToInt32(mensaje[3]);

                    partidasDataGrids[gameIndex].Rows[partidas[gameIndex].IndexOf(player)].Cells[2].Style.BackColor = coloresCharacters[colorID];
                    break;
                case 30:
                    if (mensaje[2] != "0")
                    {
                        List<string> jugadores = new List<string>(mensaje[2].Split('.'));
                        foreach (List<string> partida in partidas)
                        {
                            if (partida.Count == 0)
                            {
                                for (int i = 0; i < jugadores.Count - 1; i++)
                                    partida.Add(jugadores[i]);
                                gameIndex = partidas.IndexOf(partida);
                                break;
                            }
                        }
                        listaMiPartida(gameIndex, mensaje[2], mensaje[3]);

                        displayedGame = gameIndex;
                        for (int i = 0; i < partidasGroups.Count; i++)
                            if (i == gameIndex)
                                partidasGroups[i].Visible = true;
                            else
                                partidasGroups[i].Visible = false;

                        partidasChats[gameIndex].Text = "";
                        chatMSG = "Te has unido a la partida de " + nameHost;
                        WriteInChatTITLE(gameIndex, chatMSG, Color.DarkGreen);
                    }
                    break;
                case 40:
                    this.Invoke(new Action(() => { StartNewGame(nameHost, gameIndex, username, displayedGame); }));
                    break;
                case 41:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 42:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 43:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 44:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 45:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 46:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 47:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 48:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 49:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 50:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 51:
                    tableros[gameIndex].AtenderPartida(mensaje);
                    break;
                case 52:
                    tableros[gameIndex].AtenderPartida(mensaje);

                    partidas[gameIndex].Clear();
                    partidasDataGrids[gameIndex].Rows.Clear();

                    chatMSG = "The game has ended!";
                    WriteInChatTITLE(gameIndex, chatMSG, Color.Crimson);
                    break;
            }
            if (codigo == 52 || codigo != 27 && codigo < 40)
                updateStatusPartidas();
        }

        private void StartNewGame(string gameHost, int gameNum, string username, int dispGame)
        {
            string chatMSG = "Host has started the game!";
            WriteInChatTITLE(gameNum, chatMSG, Color.Indigo);

            tableros[gameNum] = new gameBoard(server, partidas[displayedGame], gameNum, gameHost, username);
            tableros[gameNum].Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;

            object hostName = timer.Tag;
            string mensaje2 = "23/" + hostName + "/" + username + "/No";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje2);
            server.Send(msg);

            invitacionesPaneles[0].Dispose();
            invitacionesPaneles.RemoveAt(0);

            timer.Stop();
            timer.Dispose();
            invitacionesTimers.RemoveAt(0);

            if (invitacionesPaneles.Count > 0)
            {
                int posX = this.ClientSize.Width - invitacionesPaneles[0].Width - 10;
                int posY = this.ClientSize.Height - invitacionesPaneles[0].Height - 10;

                for (int i = 0; i < invitacionesPaneles.Count; i++)
                {
                    invitacionesPaneles[i].Location = new Point(posX, posY - i * (invitacionesPaneles[i].Height + 2));
                }
            }
        }

        private void CreateInvitationPanel(string host)
        {
            int b = 60;
            int h = 20;

            Panel panel = new Panel();
            panel.Tag = host;
            panel.BackColor = Color.PaleGoldenrod; // Set background color if needed
            panel.Size = new Size(b*2 + 30, h + 30); // Adjust the size as needed
            panel.Location = new Point(this.ClientSize.Width - panel.Width - 10, this.ClientSize.Height - panel.Height - 10 - (panel.Height + 2) * invitacionesPaneles.Count);

            // Create the green PictureBox on the bottom left
            PictureBox greenPictureBox = new PictureBox();
            greenPictureBox.Cursor = Cursors.Hand;
            greenPictureBox.BackColor = Color.Green;
            greenPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            greenPictureBox.Size = new Size(b, h); // Adjust the size as needed
            greenPictureBox.Location = new Point(10, panel.Height - greenPictureBox.Height - 5);
            greenPictureBox.MouseEnter += pBox_invitacion_Enter;
            greenPictureBox.MouseLeave += pBox_invitacion_Leave;
            greenPictureBox.MouseClick += pBox_invitacion_Click;
            panel.Controls.Add(greenPictureBox);

            // Create the red PictureBox on the bottom right
            PictureBox redPictureBox = new PictureBox();
            redPictureBox.Cursor = Cursors.Hand;
            redPictureBox.BackColor = Color.Red;
            redPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            redPictureBox.Tag = invitacionesPaneles.Count;
            redPictureBox.Size = new Size(b, h); // Adjust the size as needed
            redPictureBox.Location = new Point(panel.Width - redPictureBox.Width - 10, panel.Height - redPictureBox.Height - 5);
            redPictureBox.MouseEnter += pBox_invitacion_Enter;
            redPictureBox.MouseLeave += pBox_invitacion_Leave;
            redPictureBox.MouseClick += pBox_invitacion_Click;
            panel.Controls.Add(redPictureBox);

            // Create the label on top of both PictureBoxes
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = "Invited by: " + host;
            label.Font = new Font("Modern No. 20", 10, FontStyle.Regular);
            label.AutoSize = true;
            label.BackColor = Color.Transparent; // Make label background transparent
            label.Location = new Point(5, 5); // Adjust the location as needed
            panel.Controls.Add(label);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000; // Set the interval to 10000 milliseconds (10 seconds)
            timer.Tag = host;
            timer.Tick += timer_Tick;

            this.Controls.Add(panel);
            panel.BringToFront();
            invitacionesPaneles.Add(panel); 
            invitacionesTimers.Add(timer);

            timer.Start();
        }

        private void pBox_invitacion_Click(object sender, EventArgs e)
        {
            PictureBox clickedPBox = (PictureBox)sender;
            Panel parentPanel = (Panel)clickedPBox.Parent;

            object hostName = parentPanel.Tag;

            if (clickedPBox.BackColor == Color.Green)
            {
                string mensaje2 = "23/" + hostName + "/" + username + "/Yes";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                server.Send(msg);
            }
            else
            {
                string mensaje2 = "23/" + hostName + "/" + username + "/No";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                server.Send(msg);
            }

            for (int i = invitacionesPaneles.Count - 1; i >= 0; i--)
            {
                if (invitacionesPaneles[i].Tag == hostName)
                {
                    invitacionesPaneles[i].Dispose();
                    invitacionesTimers[i].Stop();
                    invitacionesTimers[i].Dispose();

                    invitacionesPaneles.RemoveAt(i);
                    invitacionesTimers.RemoveAt(i);

                    if (invitacionesPaneles.Count > 0)
                    {
                        int posX = this.ClientSize.Width - invitacionesPaneles[0].Width - 10;
                        int posY = this.ClientSize.Height - invitacionesPaneles[0].Height - 10;

                        for (int j = 0; j < invitacionesPaneles.Count; j++)
                            invitacionesPaneles[j].Location = new Point(posX, posY - j * (invitacionesPaneles[j].Height + 2));
                    }

                    break;
                }
            }
        }

        private void pBox_invitacion_Enter(object sender, EventArgs e)
        {
            PictureBox hoveredPBox = (PictureBox)sender;
            if (hoveredPBox.BackColor == Color.Green)
                hoveredPBox.BackgroundImage = Properties.Resources.Accept;
            else
                hoveredPBox.BackgroundImage = Properties.Resources.Cross;
        }

        private void strip1_Ranking_Click(object sender, EventArgs e)
        {
            menu_rankings = new menuRankings(server);
            menu_rankings.Show();
        }

        private void pBox_invitacion_Leave(object sender, EventArgs e)
        {
            PictureBox hoveredPBox = (PictureBox)sender;
            hoveredPBox.BackgroundImage = null;
        }

        private void dgrid_dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgrid = (DataGridView)sender;
            dgrid.ClearSelection();
        }
    }
}
