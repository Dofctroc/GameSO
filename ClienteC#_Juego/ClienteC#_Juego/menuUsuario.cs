using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ClienteC__Juego
{
    public partial class menuUsuario : Form
    {
        bool conectado_conServer = false;
        Socket server;
        Thread atender;
        consultas consultas;
        menuPartida menuPartida;
        int entry;
        string username;
        string password;

        public menuUsuario()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void menuUsuario_Load(object sender, EventArgs e)
        {
            textbox_password.Text = password;
            textbox_username.Text = username;
        }

        public int serverConnect()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor al que deseamos conectarnos
            //Puertos de acceso a Shiva des de 50075 hasta 50079

            //string IP = "10.4.119.5";  int puerto = 50075;     //Shiva
            string IP = "192.168.56.102"; int puerto = 9070;     //Linux

            IPAddress direc = IPAddress.Parse(IP);
            IPEndPoint ipep = new IPEndPoint(direc, puerto);

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep); //Intentamos conectar el socket
                consoletextbox.AppendText(String.Format("Entry {0}: Te has conectado con el servidor con exito.", entry) + Environment.NewLine);
                entry++;
            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                consoletextbox.AppendText(String.Format("Entry {0}: No se ha podido conectar con el servidor.", entry) + Environment.NewLine);
                entry++;
                return 1;
            }
            conectado_conServer = true;
            button_LogOut.Enabled = true;
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
            return 0;
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
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                atender.Abort();

                conectado_conServer = false;
                button_LogOut.Enabled = false;
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
                    case 1:     // Sign up correct
                        consoletextbox.AppendText(String.Format("Entry {0}: El usuario ~{1}~ se ha creado correctamente.", entry, textbox_username.Text) + Environment.NewLine);
                        serverShutdown();
                        entry++;
                        break;

                    case 2:     // Sign up incorrecto
                        consoletextbox.AppendText(String.Format("Entry {0}: {1}", entry, mensaje[1]) + Environment.NewLine);
                        serverShutdown();
                        entry++;
                        break;

                    case 3:     // Log in correcto
                        consoletextbox.AppendText(String.Format("Entry {0}: El usuario {1} se ha conectado correctamente.", entry, textbox_username.Text) + Environment.NewLine);
                        entry++;
                        break;
                    case 4:     // Log in incorrecto
                        consoletextbox.AppendText(String.Format("Entry {0}: {1}", entry, mensaje[1]) + Environment.NewLine);
                        serverShutdown();
                        entry++;
                        break;

                    case 5:     // Log in incorrecto
                        consoletextbox.AppendText(String.Format("Entry {0}: {1}", entry, mensaje[1]) + Environment.NewLine);
                        serverShutdown();
                        entry++;
                        break;
                    case 20:    // Has podido crear partida bien o no
                        menuPartida.onResponse(mensaje);
                        break;
                    case 21:    // Has podido invitar bien o no
                        menuPartida.onResponse(mensaje);
                        break;
                    case 22:    // Te han invitado
                        menuPartida.onResponse(mensaje);
                        break;
                    case 23:    // Te han respondido la invitacion
                        menuPartida.onResponse(mensaje);
                        break;
                    case 24:    // Te has unido o no a la partida
                        menuPartida.onResponse(mensaje);
                        break;
                    case 10:
                        menuPartida.listaConectados(mensaje[1]);
                        consoletextbox.AppendText(String.Format("Entry {0}: Visualiza la lista de usuarios.", entry) + Environment.NewLine);
                        entry++;
                        break;
                    case 11:
                        consultas.responseReceived(mensaje, codigo);
                        break;
                    case 12:
                        consultas.responseReceived(mensaje, codigo);
                        break;
                    case 13:
                        consultas.responseReceived(mensaje, codigo);
                        break;
                }
            }
        }
        private void button_logIn_Click(object sender, EventArgs e)
        {
            username = textbox_username.Text;
            password = textbox_password.Text;
            int err = serverConnect();

            if (err == 0)
            {
                string mensaje = "2/" + textbox_username.Text + "/" + textbox_password.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            menuPartida = new menuPartida(server, username);
            menuPartida.ShowDialog();
            serverShutdown();
        }

        private void button_signUp_Click(object sender, EventArgs e)
        {
            username = textbox_username.Text;
            int err = serverConnect();

            if (err == 0)
            {
                string mensaje = "1/" + textbox_username.Text + "/" + textbox_password.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void button_listausuarios_Click(object sender, EventArgs e)
        {
            if (conectado_conServer)
            {
                string mensaje = "6/";
                // Enviamos al servidor el demana
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                consoletextbox.AppendText(String.Format("Entry {0}: *ERROR* Inicie sesion para visualizar la lista de usuarios.", entry) + Environment.NewLine);
                entry++;
            }
        }

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            serverShutdown();
            Close();
            consoletextbox.AppendText(String.Format("Entry {0}: ~{1}~ Ha cerrado sesion.", entry, username) + Environment.NewLine);
            entry++;
        }

        private void menuUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverShutdown();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conectado_conServer)
            {
                consultas = new consultas(conectado_conServer, server);
                consultas.ShowDialog();
            }
        }
    }
}
