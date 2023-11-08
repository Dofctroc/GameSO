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
        bool conectado_conServer;
        Socket server;
        string username;
        public principal(bool conectado_conServer, Socket server)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.conectado_conServer = conectado_conServer;
            this.server = server;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void responseReceived(string[] mensaje, int caso)
        {
            if (caso == 11)
                consoleTextBox.AppendText(String.Format("Puntuacion total de {0}: {1}", textbox_nombre.Text, mensaje[1]) + Environment.NewLine);
            if (caso == 12)
                for (int i = 1; i < mensaje.Length - 1; i++)
                    consoleTextBox.AppendText(String.Format("Puntuacion en la partida {0}: {1}", i, mensaje[i]) + Environment.NewLine);
            if (caso == 13)
                consoleTextBox.AppendText(String.Format("Ganador de la partida {0}: {1}", textbox_partida.Text, mensaje[1]) + Environment.NewLine);
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
    }
}
