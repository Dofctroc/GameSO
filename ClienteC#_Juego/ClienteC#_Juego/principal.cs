using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteC__Juego
{
    public partial class principal : Form
    {
        bool conectado_conServer = false;
        Socket server;
        public principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Desconectar_Click(object sender, EventArgs e)
        {
            serverShutdown();
            button_enviar.Enabled = false;
        }

        public void serverShutdown()
        {
            if (conectado_conServer)
            {
                //Mensaje de desconexión
                string mensaje = "0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                conectado_conServer = false;
                button_Desconectar.Enabled = false;
            }
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            if (command_1.Checked)
            {
                string mensaje = "3/" + textbox_nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show(mensaje);
            }
            else if (command_2.Checked)
            {
                string mensaje = "4/" + textbox_nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                string[] mensajePuntos = mensaje.Split('/');
                for (int i = 0; i < mensajePuntos.Length - 1; i++)
                {
                    MessageBox.Show("Puntuacion partida " + (i+1) + ": " + mensajePuntos[i]);
                }

            }
            else if (command_3.Checked)
            {
                // Enviamos nombre y altura
                string mensaje = "5/" + textbox_partida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show(mensaje);
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuUsuario menuUsuario = new menuUsuario(conectado_conServer);
            menuUsuario.ShowDialog();
            conectado_conServer = menuUsuario.GetconectadoconServer();
            server = menuUsuario.GetServer();
            if (conectado_conServer == true)
            {
                button_Desconectar.Enabled = true;
                button_enviar.Enabled = true;
            }
        }

        private void principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverShutdown();
        }
    }
}
