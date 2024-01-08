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
    public partial class consultas : Form
    {
        Socket server;

        public consultas(Socket server)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.server = server;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gBox_individualInfo.BackColor = Color.FromArgb(100, Color.Gray);
        }

        public void responseReceived(string[] mensaje, int caso)
        {
            if (caso == 11)
            {
                if (mensaje[1] == "-1")
                    richBox_console.AppendText(String.Format("El jugador ~{0}~ no existe en la base de datos", textbox_nombre.Text) + Environment.NewLine);
                else
                    richBox_console.AppendText(String.Format("Puntuación total de {0}: {1}", textbox_nombre.Text, mensaje[1]) + Environment.NewLine);
            }
            if (caso == 12)
            {
                if (mensaje[1] == "NULL")
                    richBox_console.AppendText(String.Format("El jugador ~{0}~ no existe en la base de datos", textbox_nombre.Text) + Environment.NewLine);
                else
                    for (int i = 1; i < mensaje.Length; i++)
                        richBox_console.AppendText(String.Format("Puntuación en la partida {0}: {1}", i, mensaje[i]) + Environment.NewLine);
            }
            if (caso == 13)
            {
                if (mensaje[1] == "NULL")
                    richBox_console.AppendText(String.Format("La partida ~{0}~ no existe en la base de datos", textbox_partida.Text) + Environment.NewLine);
                else
                    richBox_console.AppendText(String.Format("Ganador de la partida {0}: {1}", textbox_partida.Text, mensaje[1]) + Environment.NewLine);
            }
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            if (command_1.Checked && textbox_nombre.Text != "")
            {
                string mensaje = "11/" + textbox_nombre.Text + "*";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (command_2.Checked && textbox_nombre.Text != "")
            {
                string mensaje = "12/" + textbox_nombre.Text + "*";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (command_3.Checked && textbox_partida.Text != "")
            {
                // Enviamos nombre y altura
                string mensaje = "13/" + textbox_partida.Text + "*";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }
    }
}
