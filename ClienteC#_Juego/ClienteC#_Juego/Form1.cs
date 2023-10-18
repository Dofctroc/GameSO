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
    public partial class Form1 : Form
    {
        bool conectado_conServer = false;
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_signUp_Click(object sender, EventArgs e)
        {
            serverConnect();

            string mensaje = "1/" + textbox_username.Text + "/" + textbox_password.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            MessageBox.Show(mensaje);

            serverShutdown();
        }

        private void button_logIn_Click(object sender, EventArgs e)
        {
            serverConnect();

            string mensaje = "2/" + textbox_username.Text + "/" + textbox_password.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            string[] mensajeCodificado = mensaje.Split('/');
            MessageBox.Show(mensajeCodificado[1]);
            if (Int32.Parse(mensajeCodificado[0]) != 0)
                serverShutdown();
            else { 
                button_enviar.Enabled = true;
                button_logIn.Enabled = false;
                button_signUp.Enabled = false;
            }

        }

        private void button_Desconectar_Click(object sender, EventArgs e)
        {
            serverShutdown();
            button_enviar.Enabled = false;
            button_logIn.Enabled = true;
            button_signUp.Enabled = true;
        }

        private void serverConnect()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9060);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            conectado_conServer = true;
            button_Desconectar.Enabled = true;
        }

        private void serverShutdown()
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

        private void button_listausuarios_Click(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuUsuario menuUsuario = new menuUsuario();
            menuUsuario.Show();

        }
    }
}
