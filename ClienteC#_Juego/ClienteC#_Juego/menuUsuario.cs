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
        delegate void Delegado(string[] mensaje);

        public menuUsuario()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void menuUsuario_Load(object sender, EventArgs e)
        {
            textbox_password.Text = password;
            textbox_username.Text = username;

            lbl_controlPanel.Visible = false;
            consoletextbox.Visible = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(1000, 620);
            CenterFormOnScreen();
        }

        private void menuUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverShutdown();
        }

        // -------------------- Acciones de Button Click --------------------
        // ------------------------------------------------------------------
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

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conectado_conServer)
            {
                consultas = new consultas(conectado_conServer, server);
                consultas.ShowDialog();
            }
        }

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            consoletextbox.AppendText(String.Format("Entry {0}: ~{1}~ Ha cerrado sesion.", entry, username) + Environment.NewLine);
            entry++;
            serverShutdown();
            Close();
        }

        // -------------------- Funciones del formulario --------------------
        // ------------------------------------------------------------------

        public int serverConnect()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor al que deseamos conectarnos
            //Puertos de acceso a Shiva des de 50075 hasta 50079

            //string IP = "10.4.119.5";  int puerto = 50075;     //Shiva
            string IP = "192.168.56.102"; int puerto = 9075;     //Linux

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
                conectado_conServer = false;

                //Mensaje de desconexión
                string mensaje = "0/" + username;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                atender.Abort();

                textbox_password.Text = "";
                textbox_username.Text = "";
            }
        }

        public void textoconsola(string[] mensaje)
        {
            int codigo = Convert.ToInt32(mensaje[0]);
            switch (codigo)
            {
                case 1:     // Sign up
                    if (mensaje[1] == "0")
                        consoletextbox.AppendText(String.Format("Entry {0}: El usuario ~{1}~ se ha creado correctamente.", entry, textbox_username.Text) + Environment.NewLine);
                    else
                        consoletextbox.AppendText(String.Format("Entry {0}: El nombre de usuario ya existe, pruebe otro nombre.", entry) + Environment.NewLine);
                    serverShutdown();
                    break;

                case 2:     // Log in
                    if (mensaje[1] == "0")
                        consoletextbox.AppendText(String.Format("Entry {0}: El usuario {1} se ha conectado correctamente.", entry, textbox_username.Text) + Environment.NewLine);
                    else {
                        consoletextbox.AppendText(String.Format("Entry {0}: {1}", entry, mensaje[1]) + Environment.NewLine);
                        serverShutdown();
                    }
                    break;
                case 10:
                    consoletextbox.AppendText(String.Format("Entry {0}: Visualiza la lista de usuarios.", entry) + Environment.NewLine);
                    break;
            }
            entry++;
        }

        private void OpenNewForm()
        {
            // Create and show the new form
            menuPartida = new menuPartida(this, server, atender, username);
            menuPartida.Show();
            //this.Hide();
        }

        // -------------------- Thread general del Programa --------------------
        // ---------------------------------------------------------------------

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos el mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0].Split('/');
                int codigo = Convert.ToInt32(mensaje[0]);
                Delegado delegado = new Delegado(textoconsola);

                switch (codigo)
                {
                    case 1:     // Sign up
                        consoletextbox.Invoke(delegado, new object[] { mensaje });
                        serverShutdown();
                        break;
                    case 2:     // Log in
                        consoletextbox.Invoke(delegado, new object[] { mensaje });
                        if (mensaje[1] == "0")
                            this.Invoke((MethodInvoker)delegate { OpenNewForm(); });
                        else
                            serverShutdown();
                        break;
                    case 10:
                        menuPartida.listaConectados(mensaje[1]);
                        consoletextbox.Invoke(delegado, new object[] { mensaje });
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
                    case 25:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 26:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 27:
                        menuPartida.onResponse(mensaje);
                        break;
                }
            }
        }

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_controlPanel.Visible = !lbl_controlPanel.Visible;
            consoletextbox.Visible = !consoletextbox.Visible;
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
    }
}
