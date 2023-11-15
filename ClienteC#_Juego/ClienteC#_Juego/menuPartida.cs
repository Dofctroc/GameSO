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

namespace ClienteC__Juego
{
    public partial class menuPartida : Form
    {
        string password, username;
        menuUsuario menuUsuario;
        Socket server;
        public menuPartida(Socket server, string username)
        {
            InitializeComponent();
            this.server = server;
            this.username = username;

        }

        private void principal_Load(object sender, EventArgs e)
        {
            // Data grid de la lista de usuarios
            dataGrid_listaUsuarios.Visible = true;

            dataGrid_listaUsuarios.ColumnCount = 2;
            dataGrid_listaUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font(dataGrid_listaUsuarios.Font, FontStyle.Bold);

            dataGrid_listaUsuarios.Columns[0].Name = "column_Username";
            dataGrid_listaUsuarios.Columns[0].HeaderText = "Username";
            dataGrid_listaUsuarios.Columns[1].Name = "column_Status";
            dataGrid_listaUsuarios.Columns[1].HeaderText = "Status";

            dataGrid_listaUsuarios.Columns[0].Width = 80;
            dataGrid_listaUsuarios.Columns[1].Width = dataGrid_listaUsuarios.Width - dataGrid_listaUsuarios.Columns[0].Width - 2;
            dataGrid_listaUsuarios.Rows.Clear();

            // Data grid de mi Partida
            datagrid_miPartida.Visible = true;

            datagrid_miPartida.ColumnCount = 2;
            datagrid_miPartida.ColumnHeadersDefaultCellStyle.Font = new Font(datagrid_miPartida.Font, FontStyle.Bold);

            datagrid_miPartida.Columns[0].Name = "column_ID";
            datagrid_miPartida.Columns[0].HeaderText = "ID";
            datagrid_miPartida.Columns[1].Name = "column_Jugador";
            datagrid_miPartida.Columns[1].HeaderText = "Jugador";

            datagrid_miPartida.Columns[1].Width = 50;
            datagrid_miPartida.Columns[1].Width = datagrid_miPartida.Width - datagrid_miPartida.Columns[0].Width - 2;
            datagrid_miPartida.Rows.Clear();

            // Data grid de personas a Invitar
            dataGrid_listaInvitar.Visible = true;

            dataGrid_listaInvitar.ColumnCount = 2;
            dataGrid_listaInvitar.ColumnHeadersDefaultCellStyle.Font = new Font(dataGrid_listaInvitar.Font, FontStyle.Bold);

            dataGrid_listaInvitar.Columns[0].Name = "username";
            dataGrid_listaInvitar.Columns[0].HeaderText = "Username";

            dataGrid_listaInvitar.Columns[0].Width = dataGrid_listaInvitar.Width - 2;
            dataGrid_listaInvitar.Rows.Clear();
        }

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            dataGrid_listaInvitar.Rows.Clear();
            Close();
        }

        private void button_partidanueva_Click(object sender, EventArgs e)
        {
            string mensaje = "5/" + username;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button_Invitar_Click(object sender, EventArgs e)
        {
            if (dataGrid_listaInvitar.RowCount > 0)
            {
                string jugador;
                string jugadoresInvitar = "";
                string jugadoresInvitar1 = ".";
                foreach (DataGridViewRow fila in dataGrid_listaInvitar.Rows)
                {
                    if (fila.Cells[0].Value != null)
                    {
                        jugador = fila.Cells[0].Value.ToString();
                        jugadoresInvitar = jugadoresInvitar1 + jugador + ".";
                        jugadoresInvitar1 = jugadoresInvitar;
                    }
                }

                string mensaje = "3/" + username + jugadoresInvitar;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
                MessageBox.Show("No hay nadie seleccionado a invitar");
        }

        public void listaConectados(string mensaje)
        {
            string[] mensajeCodificado = mensaje.Split('.');
            dataGrid_listaUsuarios.Rows.Clear();

            string status;
            for (int i = 0; i < mensajeCodificado.Length - 1; i += 2)
            {
                if (Int32.Parse(mensajeCodificado[i + 1]) == 0)
                    status = "InMenu";
                else
                    status = "InGame";
                dataGrid_listaUsuarios.Rows.Add(mensajeCodificado[i], status);
            }
            dataGrid_listaUsuarios.ClearSelection();
        }

        public void listaMiPartida(string jugadores)
        {
            string[] vectorJugadores = jugadores.Split('.');
            datagrid_miPartida.Rows.Clear();

            datagrid_miPartida.Rows.Add("Host", vectorJugadores[0]);
            for (int i = 1; i < vectorJugadores.Length -1; i ++) {
                datagrid_miPartida.Rows.Add(i, vectorJugadores[i]);
            }
            datagrid_miPartida.ClearSelection();
        }

        private void button_Jugar_Click(object sender, EventArgs e)
        {
        }

        private void dataGrid_listaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool nuevo = true;
            string contenido;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dataGrid_listaUsuarios.Rows[e.RowIndex];
                contenido = filaSeleccionada.Cells[0].Value.ToString();
                if (contenido != username)
                {
                    foreach (DataGridViewRow fila in dataGrid_listaInvitar.Rows)
                    {
                        if (fila.Cells[0].Value != null)
                        {
                            string valorCelda = fila.Cells[0].Value.ToString();
                            if (valorCelda == contenido)
                                nuevo = false;
                        }
                    }
                    if (nuevo == true)
                        dataGrid_listaInvitar.Rows.Add(contenido);
                }
            }
            datagrid_miPartida.ClearSelection();
        }

        private void dataGrid_listaInvitar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.RowIndex < dataGrid_listaInvitar.Rows[e.RowIndex].Height / 2)
                    dataGrid_listaInvitar.Rows.RemoveAt(e.RowIndex);
            }
            datagrid_miPartida.ClearSelection();
        }

        public void onResponse(string[] mensaje)
        {
            if (Convert.ToInt32(mensaje[0]) == 20) {
                if (Convert.ToInt32(mensaje[1]) == 0)
                {
                    datagrid_miPartida.Rows.Add("Host", username);
                }
                else
                    MessageBox.Show("Error al crear la partida, vuelva a intentarlo.");
            }

            else if (Convert.ToInt32(mensaje[0]) == 21)
            {
                dataGrid_listaInvitar.Rows.Clear();
            }

            else if (Convert.ToInt32(mensaje[0]) == 22)
            {
                string host = mensaje[1];
                DialogResult result = MessageBox.Show("El usuario " + host + " te ha invitado a una partida",
                        "Incoming Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string mensaje2 = "4/" + host + "/" + username + "/Yes";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                    server.Send(msg);
                }
                else
                {
                    string mensaje2 = "4/" + mensaje[1] + "/" + username + "/No";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                    server.Send(msg);
                }
            }

            else if (Convert.ToInt32(mensaje[0]) == 23)
            {
                string invitado = mensaje[1];
                string decision = mensaje[2];
            }

            else if (Convert.ToInt32(mensaje[0]) == 24)
            {
                listaMiPartida(mensaje[1]);
            }
        }
    }
}
