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
using System.IO;
using System.Xml.Linq;

namespace ClienteC__Juego
{
    public partial class menuUsuario : Form
    {
        string txtGrid;
        string txtGrid2;
        string txtBox;

        bool conectado_conServer = false;
        Socket server;
        Thread atender;
        consultas consultas;
        menuPartida menuPartida;
        int entry;
        string username;
        string password;
        delegate void Delegado(string[] mensaje);
        string msge;

        public menuUsuario()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void menuUsuario_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                txtGrid = AppDomain.CurrentDomain.BaseDirectory + @"\notepad_tiles_" + i + ".txt";
                txtGrid2 = AppDomain.CurrentDomain.BaseDirectory + @"\notepad_names_" + i + ".txt";
                txtBox = AppDomain.CurrentDomain.BaseDirectory + @"\NotePad_notes_" + i + ".txt";
                File.WriteAllLines(txtGrid, new string[0]);
                File.WriteAllLines(txtGrid2, new string[0]);
                File.WriteAllLines(txtBox, new string[0]);
            }
            textbox_password.Text = password;
            textbox_username.Text = username;

            lbl_controlPanel.Visible = false;
            richBox_Control.Visible = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(1000, 620);

            richBox_Control.Size = new Size(200, this.Height - 60);

            richBox_Control.Location = new Point(this.Width - richBox_Control.Width - 20, 20);
            lbl_controlPanel.Location = new Point(richBox_Control.Left, richBox_Control.Top - lbl_controlPanel.Height);

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
            if (username != "" &&  password != "")
            {
                int err = serverConnect();

                if (err == 0)
                {
                    string mensaje = "2/" + textbox_username.Text + "/" + textbox_password.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
        }

        private void button_signUp_Click(object sender, EventArgs e)
        {
            username = textbox_username.Text;
            password = textbox_password.Text;
            int err = serverConnect();
            if (username != "" && password != "")
            {
                if (err == 0)
                {
                    string mensaje = "1/" + textbox_username.Text + "/" + textbox_password.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }  
        }

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            msge = String.Format("~{0}~ Ha cerrado sesión.", username);
            WriteConsole(entry, msge);

            serverShutdown();
            Close();
        }

        private void button_signOut_Click(object sender, EventArgs e)
        {
            username = textbox_username.Text;
            password = textbox_password.Text;
            int err = serverConnect();
            if (username != "" && password != "")
            {
                if (err == 0)
                {
                    string mensaje = "3/" + textbox_username.Text + "/" + textbox_password.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
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

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_controlPanel.Visible = !lbl_controlPanel.Visible;
            richBox_Control.Visible = !richBox_Control.Visible;
        }

        private void tableroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameBoard tablero = new gameBoard(server, new List<string> { "Asier","Gu"} ,0 , "Asier", textbox_username.Text);
            tablero.Show();
        }

        private void notePadEXPERIMENTALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InGameNotes notePad = new InGameNotes(0);
            notePad.Show();
        }

        // -------------------- Funciones del formulario --------------------
        // ------------------------------------------------------------------

        public int serverConnect()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor al que deseamos conectarnos
            //Puertos de acceso a Shiva des de 50075 hasta 50079

            //string IP = "10.4.119.5";  int puerto = 50075;     //Shiva
            string IP = "192.168.56.102"; int puerto = 9078;     //Linux

            IPAddress direc = IPAddress.Parse(IP);
            IPEndPoint ipep = new IPEndPoint(direc, puerto);

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep); //Intentamos conectar el socket
                msge = "Te has conectado con el servidor con éxito.";
                WriteConsole(entry, msge);
            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return
                msge = String.Format("No se ha podido conectar con el servidor. Error: {0}", ex.Message);
                WriteConsole(entry, msge);
                return 1;
            }
            conectado_conServer = true;
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

        public void serverShutdown(string userName)
        {
            if (conectado_conServer)
            {
                conectado_conServer = false;

                //Mensaje de desconexión
                string mensaje = "0/" + userName;
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
                    {
                        msge = String.Format("El usuario ~{0}~ se ha creado correctamente.", textbox_username.Text);
                        WriteConsole(entry, msge);
                    }
                    else
                    {
                        msge = "El nombre de usuario ya existe, pruebe otro nombre.";
                        WriteConsole(entry, msge);
                    }
                    serverShutdown();
                    break;

                case 2:     // Log in
                    if (mensaje[1] == "0")
                    {
                        msge = String.Format("El usuario {0} se ha conectado correctamente.", textbox_username.Text);
                        WriteConsole(entry, msge);
                    }
                    else
                    {
                        msge = mensaje[1];
                        WriteConsole(entry, msge);
                        serverShutdown();
                    }
                    break;
                case 3:
                    if (mensaje[1] == "0")
                    {
                        msge = String.Format("El usuario {0} se ha borrado correctamente.", textbox_username.Text);
                        WriteConsole(entry, msge);
                    }
                    else
                    {
                        msge = mensaje[1];
                        WriteConsole(entry, msge);
                        serverShutdown();
                    }
                    break;
                case 10:
                    msge = "Visualiza la lista de usuarios.";
                    WriteConsole(entry, msge);
                    break;
            }
        }

        private void OpenNewForm()
        {
            // Create and show the new form
            menuPartida = new menuPartida(this, server, username);
            menuPartida.Show();
            //this.Hide();
        }

        private void WriteConsole(int entryNum, string msg)
        {
            richBox_Control.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
            richBox_Control.SelectionColor = Color.Goldenrod;
            richBox_Control.AppendText(String.Format("Entry {0}: ", entryNum));
            richBox_Control.SelectionFont = new Font("Calibri", 11, FontStyle.Regular);
            richBox_Control.SelectionColor = Color.White;
            richBox_Control.AppendText(msg);
            richBox_Control.AppendText(Environment.NewLine);

            entry++;
        }

        // -------------------- Thread general del Programa --------------------
        // ---------------------------------------------------------------------

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos el mensaje del servidor
                byte[] msg2 = new byte[200];
                server.Receive(msg2);
                string msje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                Console.WriteLine(msje);
                string[] mensaje = msje.Split('/');
                int codigo = Convert.ToInt32(mensaje[0]);
                Delegado delegado = new Delegado(textoconsola);

                switch (codigo)
                {
                    case 1:     // Sign up
                        richBox_Control.Invoke(delegado, new object[] { mensaje });
                        serverShutdown();
                        break;
                    case 2:     // Log in
                        richBox_Control.Invoke(delegado, new object[] { mensaje });
                        if (mensaje[1] == "0")
                            this.Invoke((MethodInvoker)delegate { OpenNewForm(); });
                        else
                            serverShutdown();
                        break;
                    case 3:
                        richBox_Control.Invoke(delegado, new object[] { mensaje });
                        if (mensaje[1] == "0")
                            serverShutdown();
                        break;
                        // Connected information
                    case 10:
                        menuPartida.listaConectados(mensaje[1]);
                        richBox_Control.Invoke(delegado, new object[] { mensaje });
                        break;
                        // Consultations
                    case 11:
                        consultas.responseReceived(mensaje, codigo);
                        break;
                    case 12:
                        consultas.responseReceived(mensaje, codigo);
                        break;
                    case 13:
                        consultas.responseReceived(mensaje, codigo);
                        break;
                        // Four ranking Consultations
                    case 14:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 15:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 16:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 17:
                        menuPartida.onResponse(mensaje);
                        break;
                        // In game lobby
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
                    case 40:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 41:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 42:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 43:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 44:
                        menuPartida.onResponse(mensaje);
                        break;
                    case 45:
                        menuPartida.onResponse(mensaje);
                        break;
                }
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

        private void rankingsEXPERIMENTALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuRankings rankings = new menuRankings(server);
            rankings.Show();
        }
    }
}
