using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ClienteC__Juego
{
    public partial class menuRankings : Form
    {
        Socket server;
        int activeBox;

        public menuRankings(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void menuRankings_Load(object sender, EventArgs e)
        {
            gBox_Ind.Location = gBox_Rank.Location = new Point(btt_IndInfo.Width + 20, 10);
            gBox_Ind.Visible = false;
            activeBox = 0;

            gBox_Rank.Size = gBox_Ind.Size = new Size(200*2 + 30, 280 + 50);

            // Datagrids rankings
            dGrid_totScore.ColumnCount = dGrid_totGames.ColumnCount = 3;
            dGrid_totScore.ColumnHeadersDefaultCellStyle.Font = dGrid_totGames.ColumnHeadersDefaultCellStyle.Font = new Font(dGrid_totScore.Font, FontStyle.Bold);
            dGrid_totScore.ColumnHeadersHeight = dGrid_totGames.ColumnHeadersHeight = 30;

            dGrid_totScore.Columns[0].Name = dGrid_totGames.Columns[0].Name = "col_Pos";
            dGrid_totScore.Columns[0].HeaderText = dGrid_totGames.Columns[0].HeaderText = "Pos";
            dGrid_totScore.Columns[1].Name = dGrid_totGames.Columns[1].Name = "col_Player";
            dGrid_totScore.Columns[1].HeaderText = dGrid_totGames.Columns[1].HeaderText = "Username";
            dGrid_totScore.Columns[2].Name = "col_Score"; dGrid_totGames.Columns[2].Name = "col_Games";
            dGrid_totScore.Columns[2].HeaderText = "Score"; dGrid_totGames.Columns[2].HeaderText = "Games";

            dGrid_totScore.Size = dGrid_totGames.Size = new Size(200, 280);
            dGrid_totScore.Location = new Point(10, 40);
            lbl_scoreR.Location = new Point(dGrid_totScore.Location.X, dGrid_totScore.Location.Y - 20);
            dGrid_totGames.Location = new Point(10 + dGrid_totScore.Width + 10, 40);
            lbl_gamesR.Location = new Point(dGrid_totGames.Location.X, dGrid_totGames.Location.Y - 20);
            dGrid_totScore.Columns[0].Width = dGrid_totGames.Columns[0].Width = 40;
            dGrid_totScore.Columns[1].Width = dGrid_totGames.Columns[1].Width = 106;
            dGrid_totScore.Columns[2].Width = dGrid_totGames.Columns[2].Width = 51;
            dGrid_totScore.Rows.Clear(); dGrid_totGames.Rows.Clear();

            dGrid_totScore.RowHeadersVisible = dGrid_totGames.RowHeadersVisible = false;
            dGrid_totScore.ColumnHeadersHeight = dGrid_totGames.ColumnHeadersHeight = 30;

            // Datagrids individuales
            dGrid_user.ColumnCount = dGrid_game.ColumnCount = 3;
            dGrid_user.ColumnHeadersDefaultCellStyle.Font = dGrid_game.ColumnHeadersDefaultCellStyle.Font = new Font(dGrid_user.Font, FontStyle.Bold);
            dGrid_user.ColumnHeadersHeight = dGrid_game.ColumnHeadersHeight = 30;

            dGrid_user.Columns[0].Name = "col_ID"; dGrid_game.Columns[0].Name = "col_user";
            dGrid_user.Columns[0].HeaderText = "Game ID"; dGrid_game.Columns[0].HeaderText = "Username";
            dGrid_user.Columns[1].Name = dGrid_game.Columns[1].Name = "col_Pos";
            dGrid_user.Columns[1].HeaderText = dGrid_game.Columns[1].HeaderText = "Pos";
            dGrid_user.Columns[2].Name = dGrid_game.Columns[2].Name = "col_Score";
            dGrid_user.Columns[2].HeaderText = dGrid_game.Columns[2].HeaderText = "Score";

            dGrid_user.Size = dGrid_game.Size = new Size(200, 250);
            dGrid_user.Location = new Point(10, 60);
            lbl_scoreR.Location = new Point(dGrid_user.Location.X, 20);
            tBox_username.Location = new Point(dGrid_user.Location.X, 35);
            dGrid_game.Location = new Point(10 + dGrid_user.Width + 10, 60);
            lbl_gamesR.Location = new Point(dGrid_game.Location.X, 20);
            tBox_gameID.Location = new Point(dGrid_game.Location.X, 35);
            dGrid_user.Columns[0].Width = dGrid_game.Columns[0].Width = 106;
            dGrid_user.Columns[1].Width = dGrid_game.Columns[1].Width = 40;
            dGrid_user.Columns[2].Width = dGrid_game.Columns[2].Width = 51;
            dGrid_user.Rows.Clear(); dGrid_game.Rows.Clear();

            dGrid_user.RowHeadersVisible = dGrid_game.RowHeadersVisible = false;
            dGrid_user.ColumnHeadersHeight = dGrid_game.ColumnHeadersHeight = 30;

            // Extra
            btt_Refresh.Size = new Size(70, 30);
            btt_Refresh.Location = new Point((gBox_Rank.Location.X - btt_Refresh.Width) / 2, this.ClientSize.Height - btt_Refresh.Height - 10);

            string mensaje = "14/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            string mensaje2 = "15/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
            server.Send(msg2);
        }

        private void btt_IndInfo_Click(object sender, EventArgs e)
        {
            gBox_Ind.Visible = true;
            gBox_Rank.Visible = false;
            activeBox = 1;
        }

        private void btt_Rankings_Click(object sender, EventArgs e)
        {
            gBox_Rank.Visible = true;
            gBox_Ind.Visible = false;
            activeBox = 0;
        }

        private void btt_Refresh_Click(object sender, EventArgs e)
        {
            if (activeBox == 0)
            {
                string mensaje = "14/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                string mensaje2 = "15/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                server.Send(msg2);
            }

            else
            {
                if (tBox_username.Text != "")
                {
                    string mensaje = "16/" + tBox_username.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }

                if (tBox_gameID.Text != "")
                {
                    string mensaje2 = "17/" + tBox_gameID.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                    server.Send(msg2);
                }
            }
        }

        public void onReceive_DisplayInfo(string[] mensaje)
        {
            int codigo;
            codigo = Convert.ToInt32(mensaje[0]);

            if (mensaje[1] == "0")
            {
                // Display error message or delete info
                switch (codigo)
                {
                    case 16:
                        dGrid_user.Rows.Clear();
                        break;
                    case 17:
                        dGrid_game.Rows.Clear();
                        break;
                }
            }
            else
            {
                switch (codigo)
                {
                    case 14:
                        listaMiPartida(dGrid_totScore, mensaje[1]);
                        break;
                    case 15:
                        listaMiPartida(dGrid_totGames, mensaje[1]);
                        break;
                    case 16:
                        listaMiPartida(dGrid_user, mensaje[1]);
                        break;
                    case 17:
                        listaMiPartida(dGrid_game, mensaje[1]);
                        break;
                }
            }
        }

        public void listaMiPartida(DataGridView dataGrid, string info)
        {
            string[] vectorInfo = info.Split('.');
            dataGrid.Rows.Clear();

            if (dataGrid == dGrid_totScore || dataGrid == dGrid_totGames)
            {
                int n = 1;
                for (int i = 0; i < vectorInfo.Length - 1; i += 2)
                {
                    dataGrid.Rows.Add(n, vectorInfo[i], vectorInfo[i + 1]);
                    n++;
                }
            }
            else
            {
                for (int i = 0; i < vectorInfo.Length - 2; i += 3)
                    dataGrid.Rows.Add(vectorInfo[i], vectorInfo[i + 1], vectorInfo[i + 2]);
            }

            dataGrid.ClearSelection();
        }
    }
}
