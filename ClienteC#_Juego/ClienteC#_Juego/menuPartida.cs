using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClienteC__Juego
{
    public partial class menuPartida : Form
    {
        string password, username;
        menuUsuario menuUsuario;
        public menuPartida()
        {
            InitializeComponent();
        }

        private void principal_Load(object sender, EventArgs e)
        {
            dataGrid_listaUsuarios.Visible = true;

            dataGrid_listaUsuarios.ColumnCount = 2;
            dataGrid_listaUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font(dataGrid_listaUsuarios.Font, FontStyle.Bold);

            dataGrid_listaUsuarios.Columns[0].Name = "column_Username";
            dataGrid_listaUsuarios.Columns[0].HeaderText = "Username";

            dataGrid_listaUsuarios.Columns[1].Name = "column_Status";
            dataGrid_listaUsuarios.Columns[1].HeaderText = "Status";

            dataGrid_listaUsuarios.Columns[1].Width = 50;
            dataGrid_listaUsuarios.Columns[1].Width = dataGrid_listaUsuarios.Width - dataGrid_listaUsuarios.Columns[0].Width - 2;
            dataGrid_listaUsuarios.Rows.Clear();
        }

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            dataGrid_listaUsuarios.Rows.Clear();
            Close();
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
        }
    }
}
