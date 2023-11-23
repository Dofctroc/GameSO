using ClienteC__Juego.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Threading;

namespace ClienteC__Juego
{
    public partial class menuPartida : Form
    {
        string password, username, invitadoEliminado, host;
        bool hosting_gameLobby, in_gameLobby;
        menuUsuario menuUsuario;
        Socket server;
        PictureBox pbox_Invite = new PictureBox();
        Thread atender;
        public menuPartida(menuUsuario menuUsuario, Socket server, Thread atender, string username)
        {
            InitializeComponent();
            this.server = server;
            this.username = username;
            this.atender = atender;
            this.menuUsuario = menuUsuario;
        }

        private void principal_Load(object sender, EventArgs e)
        {
            bool isEnterKeyPressed = false;
            lbl_userName.Text = "Usuario: " + username;

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

            // Data grid de mi Partida
            dgrid_miPartida.Visible = true;

            dgrid_miPartida.ColumnCount = 2;
            dgrid_miPartida.ColumnHeadersDefaultCellStyle.Font = new Font(dgrid_miPartida.Font, FontStyle.Bold);

            dgrid_miPartida.Columns[0].Name = "column_ID";
            dgrid_miPartida.Columns[0].HeaderText = "ID";
            dgrid_miPartida.Columns[1].Name = "column_Jugador";
            dgrid_miPartida.Columns[1].HeaderText = "Jugador";

            dgrid_miPartida.Columns[1].Width = 50;
            dgrid_miPartida.Columns[1].Width = dgrid_miPartida.Width - dgrid_miPartida.Columns[0].Width - 2;
            dgrid_miPartida.Rows.Clear();

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
            pBox_mostrarConn.Size = new Size(20, 40);
            dgrid_listaUsuarios.Location = new Point(pBox_mostrarConn.Location.X + pBox_mostrarConn.Width + 4, pBox_mostrarConn.Location.Y);
            dgrid_listaUsuarios.Size = new Size(160,460);
            dgrid_listaUsuarios.Visible = false;
            lbl_write.BackColor = Color.FromArgb(150, Color.White);

            CenterFormOnScreen();
        }

        private void menuPartida_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hosting_gameLobby)
            {
                string mensaje = "26/" + username;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                hosting_gameLobby = false;
            }
            else if (in_gameLobby)
            {

            }
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
            this.Location = new Point(x, y);
        }

        // -------------------- Acciones de Button Click --------------------
        // ------------------------------------------------------------------

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            dgrid_listaInvitar.Rows.Clear();
            Close();
        }

        private void button_partidanueva_Click(object sender, EventArgs e)
        {
            if (!hosting_gameLobby)
            {
                string mensaje = "20/" + username;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                host = username;
                hosting_gameLobby = true;
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

        private void button_Jugar_Click(object sender, EventArgs e)
        {
        }

        private void btt_eliminarInvitado_Click(object sender, EventArgs e)
        {
            if (invitadoEliminado != null)
            {
                string mensaje = "24/" + username + "/" + invitadoEliminado;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                invitadoEliminado = null;
            }
        }

        // -------------------- Respuestas a mensajes servidor --------------------
        // ------------------------------------------------------------------------

        public void onResponse(string[] mensaje)
        {
            int codigo = Convert.ToInt32(mensaje[0]);
            string invitado, hostmensaje;
            switch (codigo)
            {
                case 20:
                    if (Convert.ToInt32(mensaje[1]) == 0)
                    {
                        dgrid_miPartida.Rows.Add("Host", username);
                        dgrid_miPartida.ClearSelection();
                        hosting_gameLobby = true;
                    }
                    else
                        MessageBox.Show("Error al crear la partida, vuelva a intentarlo.");
                    break;
                case 21:
                    dgrid_listaInvitar.Rows.Clear();
                    break;
                case 22:
                    hostmensaje = mensaje[1];
                    invitado = mensaje[2];
                    DialogResult result = MessageBox.Show("El usuario " + hostmensaje + " te ha invitado a una partida",
                            "Incoming Message", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string mensaje2 = "23/" + hostmensaje + "/" + username + "/Yes";
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                        server.Send(msg);
                        tbox_read.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                        tbox_read.SelectionColor = Color.Crimson;
                        tbox_read.AppendText("El usuario " + invitado + "se ha unido a la partida");
                    }
                    else
                    {
                        string mensaje2 = "23/" + hostmensaje + "/" + username + "/No";
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                        server.Send(msg);
                    }
                    break;
                case 23:
                    if (mensaje.Length == 4)
                    {
                        invitado = mensaje[2];
                        string decision = mensaje[3];
                        if (decision == "Yes")
                        {
                            listaMiPartida(invitado, true);
                            DialogResult showInvite = MessageBox.Show(username + ", El usuario " + invitado + " se ha unido a la partida",
                                "Incoming Message", MessageBoxButtons.OK);

                        }
                        else if (username == dgrid_miPartida.Rows[0].Cells[1].Value.ToString())
                        {
                            DialogResult showInvite = MessageBox.Show("El usuario " + invitado + " ha rechazado tu invitacion",
                                "Incoming Message", MessageBoxButtons.OK);
                        }
                    }
                    else if (mensaje[1] != "0")
                    {
                        Console.WriteLine(mensaje[1] + " es el host");
                        listaMiPartida(mensaje[1]);
                        host = mensaje[1].Split('.')[0];
                    }
                    break;
                case 24:    // El host de la partida te ha expulsado
                    hostmensaje = mensaje[1];
                    string expulsado = mensaje[2];
                    if (username != expulsado)
                    {
                        tbox_read.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                        tbox_read.SelectionColor = Color.Crimson;
                        tbox_read.AppendText("El usuario " + username + "ha sido expulsado de la partida");
                        host = null;
                        listaMiPartida(expulsado, false);
                    }
                    else
                    {
                        DialogResult resultado = MessageBox.Show("El usuario " + hostmensaje + " te ha expulsado de la partida",
                            "Incoming Message", MessageBoxButtons.OK);
                        dgrid_miPartida.Rows.Clear();
                        dgrid_miPartida.Rows.Clear();
                    }
                    break;
                case 25:

                    break;
                case 26:
                    if (mensaje[1] == username)
                    {
                        dgrid_miPartida.Rows.Clear();
                        host = null;
                        menuUsuario.serverShutdown();
                        menuUsuario.Show();
                    }
                    else
                    {
                        DialogResult showGameDeleted = MessageBox.Show("El usuario " + mensaje[1] + " te ha expulsado de la partida",
                                "Incoming Message", MessageBoxButtons.OK);
                        dgrid_miPartida.Rows.Clear();
                        host = null;
                        in_gameLobby = false;
                    }
                    break;
                case 27:
                    break;
            }
            if (Convert.ToInt32(mensaje[0]) == 20) {
                
            }

            else if (Convert.ToInt32(mensaje[0]) == 21)
            {
            }

            else if (Convert.ToInt32(mensaje[0]) == 22)
            {
            }

            else if (Convert.ToInt32(mensaje[0]) == 23)
            {
            }

            else if (Convert.ToInt32(mensaje[0]) == 24)
            {
            }

            else if (Convert.ToInt32(mensaje[0]) == 25)
            {
            }

            else if (Convert.ToInt32(mensaje[0]) == 27)
            {
                tbox_read.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                tbox_read.SelectionColor = Color.DarkBlue;
                tbox_read.AppendText(mensaje[2] + ": ");
                tbox_read.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                tbox_read.SelectionColor = Color.Black;
                tbox_read.AppendText(mensaje[3]);
                tbox_read.AppendText(Environment.NewLine);
            }
        }


        // -------------------- Actualizaciones de Datagrid --------------------
        // ---------------------------------------------------------------------

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

        public void listaMiPartida(string jugador, bool afegir) 
        {
            if (afegir)
            {
                dgrid_miPartida.Rows.Add(dgrid_miPartida.RowCount, jugador);
            }
            else
            {
                for (int i = 1; i < dgrid_miPartida.RowCount; i++)
                {
                    if (dgrid_miPartida.Rows[i].Cells[1].Value.ToString() == jugador)
                        dgrid_miPartida.Rows.RemoveAt(i);
                }
            }
            dgrid_miPartida.ClearSelection();
        }

        public void listaMiPartida(string jugadores)
        {
            string[] vectorJugadores = jugadores.Split('.');       
            dgrid_miPartida.Rows.Clear();
            
            dgrid_miPartida.Rows.Add("Host", vectorJugadores[0]);
            for (int i = 1; i < vectorJugadores.Length - 1; i++)
            {
                dgrid_miPartida.Rows.Add(i, vectorJugadores[i]);
            }
            dgrid_miPartida.ClearSelection();
        }

        // -------------------- Interacciones con Datagrid --------------------
        // --------------------------------------------------------------------

        private void dgrid_listaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool nuevo = true;
            string contenido;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgrid_listaUsuarios.Rows[e.RowIndex];
                contenido = filaSeleccionada.Cells[0].Value.ToString();
                if (contenido != username)
                {
                    foreach (DataGridViewRow fila in dgrid_listaInvitar.Rows)
                    {
                        if (fila.Cells[0].Value != null)
                        {
                            string valorCelda = fila.Cells[0].Value.ToString();
                            if (valorCelda == contenido)
                                nuevo = false;
                        }
                    }
                    if (nuevo == true)
                        dgrid_listaInvitar.Rows.Add(contenido);
                }
            }
            dgrid_listaUsuarios.ClearSelection();
            dgrid_listaInvitar.ClearSelection();
        }

        private void dgrid_listaInvitar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex < dgrid_listaInvitar.Rows[e.RowIndex].Height / 2)
                    dgrid_listaInvitar.Rows.RemoveAt(e.RowIndex);
            }
            dgrid_listaInvitar.ClearSelection();
        }

        private void dgrid_miPartida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 1)
            {
                dgrid_miPartida.ClearSelection();
                btt_eliminarInvitado.Visible = true;
                invitadoEliminado = dgrid_miPartida.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else
                btt_eliminarInvitado.Visible = false;
        }

        // -------------------- Chat & Conn related interactions ---------------------
        // ---------------------------------------------------------------------------

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

        private void pBox_sendText_Click(object sender, EventArgs e)
        {
            if (textBox_write.Text != "")
            {
                Console.WriteLine(textBox_write.Text);
                string men = textBox_write.Text;
                string mensaje = "27/" + host + "/" + username + "/" + men;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            textBox_write.Text = "";
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
                if (textBox_write.Text != "")
                {
                    e.SuppressKeyPress = true;
                    string men = textBox_write.Text;
                    string mensaje = "27/" + host + "/" + username + "/" + men;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    textBox_write.Clear();
                }
                else
                {
                    e.SuppressKeyPress = true;
                    textBox_write.Clear();
                }
            }
        }
    }
}
