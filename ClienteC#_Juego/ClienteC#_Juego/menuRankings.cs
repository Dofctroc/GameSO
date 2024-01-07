using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClienteC__Juego
{
    public partial class menuRankings : Form
    {
        Socket server;
        int activeBox;
        string userName;

        public menuRankings(Socket server, string userName)
        {
            InitializeComponent();
            this.server = server;
            this.userName = userName;
        }

        private void menuRankings_Load(object sender, EventArgs e)
        {
            gBox_Ind.Location = gBox_Rank.Location = gBox_OtherInfo.Location = new Point(btt_IndInfo.Width + 20, 10);
            gBox_Ind.Visible = gBox_OtherInfo.Visible = false;
            activeBox = 0;

            gBox_Rank.Size = gBox_Ind.Size = new Size(200*2 + 30, 280 + 50);
            gBox_OtherInfo.Size = new Size(700, 280 + 50);

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
            dGrid_user.ColumnCount = 3;
            dGrid_game.ColumnCount = 2;
            dGrid_user.ColumnHeadersDefaultCellStyle.Font = dGrid_game.ColumnHeadersDefaultCellStyle.Font = new Font(dGrid_user.Font, FontStyle.Bold);
            dGrid_user.ColumnHeadersHeight = dGrid_game.ColumnHeadersHeight = 30;

            dGrid_user.Columns[0].Name = "col_ID"; 
            dGrid_user.Columns[0].HeaderText = "Game ID"; 
            dGrid_user.Columns[1].Name = "col_Pos";
            dGrid_user.Columns[1].HeaderText = "Pos";
            dGrid_user.Columns[2].Name = "col_Score";
            dGrid_user.Columns[2].HeaderText = "Score";

            dGrid_game.Columns[0].Name = "col_Title";
            dGrid_game.Columns[0].HeaderText = "Title";
            dGrid_game.Columns[1].Name = "col_Info";
            dGrid_game.Columns[1].HeaderText = "Information";

            dGrid_user.Size = dGrid_game.Size = new Size(200, 250);
            dGrid_user.Location = new Point(10, 60);
            lbl_userName.Location = new Point(dGrid_user.Location.X, 20);
            tBox_username.Location = new Point(dGrid_user.Location.X, 35);
            dGrid_game.Location = new Point(10 + dGrid_user.Width + 10, 60);
            lbl_gameID.Location = new Point(dGrid_game.Location.X, 20);
            tBox_gameID.Location = new Point(dGrid_game.Location.X, 35);
            dGrid_user.Columns[0].Width = 106;
            dGrid_user.Columns[1].Width = 40;
            dGrid_user.Columns[2].Width = 51;
            dGrid_game.Columns[0].Width = 66;
            dGrid_game.Columns[1].Width = 197 - dGrid_game.Columns[0].Width;
            dGrid_user.Rows.Clear(); dGrid_game.Rows.Clear();

            dGrid_user.RowHeadersVisible = dGrid_game.RowHeadersVisible = false;
            dGrid_user.ColumnHeadersHeight = dGrid_game.ColumnHeadersHeight = 30;

            //Datagrids others
            dGrid_otherusers.ColumnCount = 1;
            dGrid_otherplayer.ColumnCount = 4;
            dGrid_othertime.ColumnCount = 2;
            dGrid_otherusers.ColumnHeadersDefaultCellStyle.Font = dGrid_othertime.ColumnHeadersDefaultCellStyle.Font = dGrid_otherplayer.ColumnHeadersDefaultCellStyle.Font =new Font(dGrid_totScore.Font, FontStyle.Bold);
            dGrid_otherusers.ColumnHeadersHeight = dGrid_othertime.ColumnHeadersHeight = dGrid_otherplayer.ColumnHeadersHeight = 30;

            dGrid_otherusers.Columns[0].Name = "col_username";
            dGrid_otherusers.Columns[0].HeaderText = "Username";

            dGrid_otherplayer.Columns[0].Name = dGrid_othertime.Columns[0].Name = "col_Game";
            dGrid_otherplayer.Columns[0].HeaderText = dGrid_othertime.Columns[0].HeaderText = "Game";
            dGrid_otherplayer.Columns[1].Name = "col_dayplayed";
            dGrid_otherplayer.Columns[1].HeaderText = "Day played";
            dGrid_otherplayer.Columns[2].Name = "col_duration";
            dGrid_otherplayer.Columns[2].HeaderText = "Duration";
            dGrid_othertime.Columns[1].Name = dGrid_otherplayer.Columns[3].Name = "col_winner";
            dGrid_othertime.Columns[1].HeaderText = dGrid_otherplayer.Columns[3].HeaderText = "Winner";

            dGrid_otherusers.Size = new Size(100, 250);
            dGrid_othertime.Size = new Size(200, 250);
            dGrid_otherplayer.Size = new Size(300, 250);
            dGrid_otherusers.Location = new Point(10, 60);
            lbl_otherusers.Location = new Point(dGrid_otherusers.Location.X, 20);
            tBox_otherusers.Location = new Point(dGrid_otherusers.Location.X, 35);

            dGrid_otherplayer.Location = new Point(10 + dGrid_otherusers.Width + dGrid_otherusers.Location.X + 10, 60);
            lbl_otherplayer.Location = new Point(dGrid_otherplayer.Location.X, 20);
            tBox_otherplayer.Location = new Point(dGrid_otherplayer.Location.X, 35);

            dGrid_othertime.Location = new Point(10 + dGrid_otherplayer.Location.X + dGrid_otherplayer.Width, 60);
            lbl_othertime.Location = new Point(dGrid_othertime.Location.X, 20);
            tBox_othertime.Location = new Point(dGrid_othertime.Location.X, 35);

            dGrid_otherusers.Columns[0].Width = 100;
            dGrid_otherplayer.Columns[0].Width = 100;
            dGrid_othertime.Columns[0].Width = 100;
            dGrid_othertime.Columns[1].Width = 300;
            dGrid_otherplayer.Columns[0].Width = 40;
            dGrid_otherplayer.Columns[1].Width = 100;
            dGrid_otherplayer.Columns[2].Width = 100;
            dGrid_otherplayer.Columns[3].Width = dGrid_otherplayer.Width - dGrid_otherplayer.Columns[2].Width - dGrid_otherplayer.Columns[1].Width - dGrid_otherplayer.Columns[0].Width;
            dGrid_otherusers.Rows.Clear(); dGrid_otherplayer.Rows.Clear(); dGrid_othertime.Rows.Clear();

            dGrid_otherusers.RowHeadersVisible = dGrid_otherplayer.RowHeadersVisible = dGrid_othertime.RowHeadersVisible = false;
            dGrid_otherusers.ColumnHeadersHeight = dGrid_otherplayer.ColumnHeadersHeight = dGrid_othertime.ColumnHeadersHeight = 30;

            // Extra
            btt_Refresh.Size = new Size(70, 30);
            btt_Refresh.Location = new Point((gBox_Rank.Location.X - btt_Refresh.Width) / 2, this.ClientSize.Height - btt_Refresh.Height - 10);

            string mensaje = "14/" + "*" + "15/" + "*"; 
            byte[] msg = Encoding.UTF8.GetBytes(mensaje);
            server.Send(msg);

            // string mensaje2 = "15/" + "*";
            // byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
            // server.Send(msg2);
        }

        private void btt_IndInfo_Click(object sender, EventArgs e)
        {
            gBox_Ind.Visible = true;
            gBox_Rank.Visible = false;
            gBox_OtherInfo.Visible = false;
            activeBox = 1;
        }

        private void btt_Rankings_Click(object sender, EventArgs e)
        {
            gBox_Rank.Visible = true;
            gBox_Ind.Visible = false;
            gBox_OtherInfo.Visible = false;
            activeBox = 0;
        }
        private void btt_otherinfo_Click(object sender, EventArgs e)
        {
            gBox_Rank.Visible = false;
            gBox_Ind.Visible = false;
            gBox_OtherInfo.Visible = true;
            activeBox = 2;
        }

        private void btt_Refresh_Click(object sender, EventArgs e)
        {
            if (activeBox == 0)
            {
                string mensaje = "14/" + "*" + "15/" + "*";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // string mensaje2 = "15/" + "*";
                // byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                // server.Send(msg2);
            }

            else if (activeBox == 1)
            {
                if (tBox_username.Text != "")
                {
                    string mensaje = "16/" + tBox_username.Text + "*";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }

                if (tBox_gameID.Text != "")
                {
                    string mensaje2 = "17/" + tBox_gameID.Text + "*";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                    server.Send(msg2);
                }
            }
            else
            {
                if (tBox_otherusers.Text != "")
                {
                    string mensaje = "7/" + tBox_otherusers.Text + "*";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                if (tBox_otherplayer.Text != "")
                {
                    string mensaje = "8/" + userName + "/" + tBox_otherplayer.Text + "*";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                if (tBox_othertime.Text != "")
                {
                    //string[] fechas = tBox_othertime.Text.Split('.');
                    //string inicio = fechas[0];
                    //string final = fechas[1];
                    string mensaje = "9/" + tBox_othertime.Text + "*";   //Teniendo en cuenta que el formato del mensaje es: yy-mm-dd/yy-mm-dd (inicio/final periodo)
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
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
                        dGrid_user.Height = 250;
                        break;
                    case 17:
                        dGrid_game.Rows.Clear();
                        dGrid_game.Height = 250;
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
                    case 7:
                        listaMiPartida(dGrid_otherusers, mensaje[1]);
                        break;
                    case 8:
                        listaMiPartida(dGrid_otherplayer, mensaje[1]);
                        break;
                    case 9:
                        listaMiPartida(dGrid_othertime, mensaje[1]);
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
            else if (dataGrid == dGrid_user)
            {
                for (int i = 0; i < vectorInfo.Length - 2; i += 3)
                    dataGrid.Rows.Add(vectorInfo[i], vectorInfo[i + 1], vectorInfo[i + 2]);

                int totalRowHeight = dGrid_user.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
                int headerHeight = dGrid_user.ColumnHeadersVisible ? dGrid_user.ColumnHeadersHeight : 0;
                if (totalRowHeight + headerHeight <= 250)
                    dGrid_user.Height = totalRowHeight + headerHeight + 3;
            }
            else if (dataGrid == dGrid_game)
            {
                int i = 0;
                while (vectorInfo[i] != "0")
                {
                    dataGrid.Rows.Add("Player " + (i+1).ToString(), vectorInfo[i]);
                    i++;
                }
                int totalSeconds = Convert.ToInt32(vectorInfo[i + 2]);
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;
                string[] vectorDay = vectorInfo[i + 3].Split(',');
                int day = int.Parse(vectorDay[0]);
                int month = int.Parse(vectorDay[1]);
                int year = int.Parse(vectorDay[2]);
                DateTime parsedDate = new DateTime(2000 + year, month, day);

                dataGrid.Rows.Add("Winner ", vectorInfo[i+1]);
                dataGrid.Rows.Add("Duration ", minutes + " mins, " + seconds + " secs");
                dataGrid.Rows.Add("Day Played ", day + " of " + parsedDate.ToString("MMMM") + " " + parsedDate.Year);

                int totalRowHeight = dGrid_game.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
                int headerHeight = dGrid_game.ColumnHeadersVisible ? dGrid_game.ColumnHeadersHeight : 0;

                dGrid_game.Height = totalRowHeight + headerHeight;
            }
            else if (dataGrid == dGrid_otherusers)
            {
                int n = 1;
                for (int i = 0; i < vectorInfo.Length - 1; i ++)
                {
                    dataGrid.Rows.Add(vectorInfo[i]);
                    n++;
                }
            }
            else if (dataGrid == dGrid_othertime)
            {
                for (int i = 0; i < vectorInfo.Length - 1; i += 2)
                {
                    dataGrid.Rows.Add(vectorInfo[i], vectorInfo[i + 1]);
                }
            }
            else if (dataGrid == dGrid_otherplayer)
            {
                for (int i = 0; i < vectorInfo.Length - 1; i += 4)
                {
                    dataGrid.Rows.Add(vectorInfo[i], vectorInfo[i + 1], vectorInfo[i + 2], vectorInfo[i + 3]);
                }
            }

            dataGrid.ClearSelection();
        }


    }
}
