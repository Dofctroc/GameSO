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

namespace ClienteC__Juego
{
    public partial class menuUsuario : Form
    {
        bool conectado_conServer;
        Socket server;
        principal principal;
        int entry;
        public menuUsuario(bool conectado_conServer)
        {
            InitializeComponent();
            this.conectado_conServer = conectado_conServer;
        }

        private void menuUsuario_Load(object sender, EventArgs e)
        {
            this.Width = 360;
        }

        public bool GetconectadoconServer()
        {
            return this.conectado_conServer;
        }

        public Socket GetServer()
        {
            return this.server;
        }

        public void serverConnect()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9060);


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
                return;
            }
            conectado_conServer = true;
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
            }
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
            if (Int32.Parse(mensajeCodificado[0]) == 1)
            {
                serverShutdown();
                consoletextbox.AppendText(String.Format("Entry {0}: {1}", entry, mensajeCodificado[1]) + Environment.NewLine);
                entry++;
            }
            else if (Int32.Parse(mensajeCodificado[0]) == 2)
            {
                serverShutdown();
                consoletextbox.AppendText(String.Format("Entry {0}: {1}", entry, mensajeCodificado[1]) + Environment.NewLine);
                entry++;
            }
            else
            {
                consoletextbox.AppendText(String.Format("Entry {0}: El usuario {1} se ha conectado correctamente.", entry, textbox_username.Text) + Environment.NewLine);
                entry++;
            }
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

            string[] mensajeCodificado = mensaje.Split('/');
            if (Int32.Parse(mensajeCodificado[0]) == 1)
            {
                serverShutdown();
                consoletextbox.AppendText(String.Format("Entry {0}: {1}", entry, mensajeCodificado[1]) + Environment.NewLine);
                entry++;
            }
            else
            {
                consoletextbox.AppendText(String.Format("Entry {0}: El usuario {1} se ha creado correctamente.", entry, textbox_username.Text) + Environment.NewLine);
                entry++;
            }

            serverShutdown();
        }

        private void button_listausuarios_Click(object sender, EventArgs e)
        {

            if (conectado_conServer)
            {
                string mensaje = "6/";
                // Enviamos al servidor el demana
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show(mensaje);
                //--------------------------------------------

                //string mensaje = "Asier/In Menu/Julia/Ingame/Gu/Ingame/";
                string[] mensajeCodificado = mensaje.Split('/');

                this.Width = 850;
                label_listaUsuarios.Visible = true;
                dataGrid_listaUsuarios.Visible = true;

                dataGrid_listaUsuarios.ColumnCount = 2;
                dataGrid_listaUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font(dataGrid_listaUsuarios.Font, FontStyle.Bold);

                dataGrid_listaUsuarios.Columns[0].Name = "column_Username";
                dataGrid_listaUsuarios.Columns[0].HeaderText = "Username";

                dataGrid_listaUsuarios.Columns[1].Name = "column_Status";
                dataGrid_listaUsuarios.Columns[1].HeaderText = "Status";

                dataGrid_listaUsuarios.Columns[1].Width = 50;
                dataGrid_listaUsuarios.Columns[1].Width = dataGrid_listaUsuarios.Width - dataGrid_listaUsuarios.Columns[0].Width - 2;
                for (int i = 0; i < mensajeCodificado.Length - 1; i += 2)
                {
                    dataGrid_listaUsuarios.Rows.Add(mensajeCodificado[i], mensajeCodificado[i + 1]);
                }
            }
            else
            {
                consoletextbox.AppendText(String.Format("Entry {0}: *ERROR* Inicie sesion para visualizar la lista de usuarios.", entry) + Environment.NewLine);
                entry++;
            }
        }
    }
}
