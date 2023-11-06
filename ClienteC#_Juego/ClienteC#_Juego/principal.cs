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
using System.Threading;

namespace ClienteC__Juego
{
    public partial class principal : Form
    {
        bool conectado_conServer = false;
        Socket server;
        Thread atender;
        string username;
        public principal()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
                string mensaje = "0/" + username;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                conectado_conServer = false;
                button_Desconectar.Enabled = false;
                atender.Abort();
            }
        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos el mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0].Split('/');
                int codigo = Convert.ToInt32(mensaje[0]);

                switch (codigo)
                {
                    case 11:
                        MessageBox.Show(mensaje[1]);
                        break;

                    case 12:
                        for (int i = 1; i < mensaje.Length - 1; i++)
                        {
                            MessageBox.Show("Puntuacion partida " + (i + 1) + ": " + mensaje[i]);
                        }
                        break;

                    case 13:
                        MessageBox.Show(mensaje[1]);
                        break;
                    
                }
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
            }
            else if (command_2.Checked)
            {
                string mensaje = "4/" + textbox_nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (command_3.Checked)
            {
                // Enviamos nombre y altura
                string mensaje = "5/" + textbox_partida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuUsuario menuUsuario = new menuUsuario(conectado_conServer);
            menuUsuario.ShowDialog();
            conectado_conServer = menuUsuario.GetconectadoconServer();
            server = menuUsuario.GetServer();
            username = menuUsuario.GetUsername();
            if (conectado_conServer == true)
            {
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
                MessageBox.Show("Hola");
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
