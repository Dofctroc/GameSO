﻿namespace ClienteC__Juego
{
    partial class menuPartida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid_listaInvitar = new System.Windows.Forms.DataGridView();
            this.button_partidanueva = new System.Windows.Forms.Button();
            this.button_LogOut = new System.Windows.Forms.Button();
            this.lbl_miPartida = new System.Windows.Forms.Label();
            this.datagrid_miPartida = new System.Windows.Forms.DataGridView();
            this.lbl_otrasPartridas = new System.Windows.Forms.Label();
            this.datagrid_otrasPartidas = new System.Windows.Forms.DataGridView();
            this.button_Jugar = new System.Windows.Forms.Button();
            this.button_Invitar = new System.Windows.Forms.Button();
            this.dataGrid_listaUsuarios = new System.Windows.Forms.DataGridView();
            this.btt_controlListaConectados = new System.Windows.Forms.Button();
            this.btt_eliminarInvitado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listaInvitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_miPartida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_otrasPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_listaInvitar
            // 
            this.dataGrid_listaInvitar.AllowUserToAddRows = false;
            this.dataGrid_listaInvitar.AllowUserToDeleteRows = false;
            this.dataGrid_listaInvitar.AllowUserToResizeColumns = false;
            this.dataGrid_listaInvitar.AllowUserToResizeRows = false;
            this.dataGrid_listaInvitar.ColumnHeadersHeight = 25;
            this.dataGrid_listaInvitar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid_listaInvitar.Location = new System.Drawing.Point(796, 269);
            this.dataGrid_listaInvitar.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_listaInvitar.Name = "dataGrid_listaInvitar";
            this.dataGrid_listaInvitar.ReadOnly = true;
            this.dataGrid_listaInvitar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGrid_listaInvitar.RowHeadersVisible = false;
            this.dataGrid_listaInvitar.RowHeadersWidth = 50;
            this.dataGrid_listaInvitar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid_listaInvitar.Size = new System.Drawing.Size(100, 200);
            this.dataGrid_listaInvitar.TabIndex = 20;
            this.dataGrid_listaInvitar.Visible = false;
            this.dataGrid_listaInvitar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_listaInvitar_CellClick);
            // 
            // button_partidanueva
            // 
            this.button_partidanueva.AutoSize = true;
            this.button_partidanueva.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_partidanueva.Location = new System.Drawing.Point(52, 35);
            this.button_partidanueva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_partidanueva.Name = "button_partidanueva";
            this.button_partidanueva.Size = new System.Drawing.Size(191, 39);
            this.button_partidanueva.TabIndex = 21;
            this.button_partidanueva.Text = "Partida Nueva";
            this.button_partidanueva.UseVisualStyleBackColor = true;
            this.button_partidanueva.Click += new System.EventHandler(this.button_partidanueva_Click);
            // 
            // button_LogOut
            // 
            this.button_LogOut.AutoSize = true;
            this.button_LogOut.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LogOut.Location = new System.Drawing.Point(87, 368);
            this.button_LogOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(116, 39);
            this.button_LogOut.TabIndex = 22;
            this.button_LogOut.Text = "Log Out";
            this.button_LogOut.UseVisualStyleBackColor = true;
            this.button_LogOut.Click += new System.EventHandler(this.button_LogOut_Click);
            // 
            // lbl_miPartida
            // 
            this.lbl_miPartida.AutoSize = true;
            this.lbl_miPartida.Location = new System.Drawing.Point(321, 15);
            this.lbl_miPartida.Name = "lbl_miPartida";
            this.lbl_miPartida.Size = new System.Drawing.Size(69, 16);
            this.lbl_miPartida.TabIndex = 25;
            this.lbl_miPartida.Text = "Mi partida:";
            // 
            // datagrid_miPartida
            // 
            this.datagrid_miPartida.AllowUserToAddRows = false;
            this.datagrid_miPartida.AllowUserToDeleteRows = false;
            this.datagrid_miPartida.AllowUserToResizeColumns = false;
            this.datagrid_miPartida.AllowUserToResizeRows = false;
            this.datagrid_miPartida.ColumnHeadersHeight = 25;
            this.datagrid_miPartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_miPartida.Location = new System.Drawing.Point(324, 35);
            this.datagrid_miPartida.Margin = new System.Windows.Forms.Padding(4);
            this.datagrid_miPartida.Name = "datagrid_miPartida";
            this.datagrid_miPartida.ReadOnly = true;
            this.datagrid_miPartida.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.datagrid_miPartida.RowHeadersVisible = false;
            this.datagrid_miPartida.RowHeadersWidth = 50;
            this.datagrid_miPartida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagrid_miPartida.Size = new System.Drawing.Size(310, 200);
            this.datagrid_miPartida.TabIndex = 24;
            this.datagrid_miPartida.Visible = false;
            this.datagrid_miPartida.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_miPartida_CellClick);
            // 
            // lbl_otrasPartridas
            // 
            this.lbl_otrasPartridas.AutoSize = true;
            this.lbl_otrasPartridas.Location = new System.Drawing.Point(321, 270);
            this.lbl_otrasPartridas.Name = "lbl_otrasPartridas";
            this.lbl_otrasPartridas.Size = new System.Drawing.Size(94, 16);
            this.lbl_otrasPartridas.TabIndex = 27;
            this.lbl_otrasPartridas.Text = "Otras partidas:";
            // 
            // datagrid_otrasPartidas
            // 
            this.datagrid_otrasPartidas.AllowUserToAddRows = false;
            this.datagrid_otrasPartidas.AllowUserToDeleteRows = false;
            this.datagrid_otrasPartidas.AllowUserToResizeColumns = false;
            this.datagrid_otrasPartidas.AllowUserToResizeRows = false;
            this.datagrid_otrasPartidas.ColumnHeadersHeight = 25;
            this.datagrid_otrasPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_otrasPartidas.Location = new System.Drawing.Point(324, 290);
            this.datagrid_otrasPartidas.Margin = new System.Windows.Forms.Padding(4);
            this.datagrid_otrasPartidas.Name = "datagrid_otrasPartidas";
            this.datagrid_otrasPartidas.ReadOnly = true;
            this.datagrid_otrasPartidas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.datagrid_otrasPartidas.RowHeadersVisible = false;
            this.datagrid_otrasPartidas.RowHeadersWidth = 50;
            this.datagrid_otrasPartidas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagrid_otrasPartidas.Size = new System.Drawing.Size(310, 145);
            this.datagrid_otrasPartidas.TabIndex = 26;
            this.datagrid_otrasPartidas.Visible = false;
            // 
            // button_Jugar
            // 
            this.button_Jugar.AutoSize = true;
            this.button_Jugar.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Jugar.Location = new System.Drawing.Point(87, 321);
            this.button_Jugar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Jugar.Name = "button_Jugar";
            this.button_Jugar.Size = new System.Drawing.Size(116, 39);
            this.button_Jugar.TabIndex = 28;
            this.button_Jugar.Text = "Jugar";
            this.button_Jugar.UseVisualStyleBackColor = true;
            this.button_Jugar.Click += new System.EventHandler(this.button_Jugar_Click);
            // 
            // button_Invitar
            // 
            this.button_Invitar.AutoSize = true;
            this.button_Invitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Invitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.button_Invitar.Location = new System.Drawing.Point(796, 242);
            this.button_Invitar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Invitar.Name = "button_Invitar";
            this.button_Invitar.Size = new System.Drawing.Size(100, 28);
            this.button_Invitar.TabIndex = 29;
            this.button_Invitar.Text = "Invitar";
            this.button_Invitar.UseVisualStyleBackColor = true;
            this.button_Invitar.Click += new System.EventHandler(this.button_Invitar_Click);
            // 
            // dataGrid_listaUsuarios
            // 
            this.dataGrid_listaUsuarios.AllowUserToAddRows = false;
            this.dataGrid_listaUsuarios.AllowUserToDeleteRows = false;
            this.dataGrid_listaUsuarios.AllowUserToResizeColumns = false;
            this.dataGrid_listaUsuarios.AllowUserToResizeRows = false;
            this.dataGrid_listaUsuarios.ColumnHeadersHeight = 25;
            this.dataGrid_listaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid_listaUsuarios.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGrid_listaUsuarios.Location = new System.Drawing.Point(902, 28);
            this.dataGrid_listaUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_listaUsuarios.Name = "dataGrid_listaUsuarios";
            this.dataGrid_listaUsuarios.ReadOnly = true;
            this.dataGrid_listaUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGrid_listaUsuarios.RowHeadersVisible = false;
            this.dataGrid_listaUsuarios.RowHeadersWidth = 50;
            this.dataGrid_listaUsuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid_listaUsuarios.Size = new System.Drawing.Size(200, 441);
            this.dataGrid_listaUsuarios.TabIndex = 30;
            this.dataGrid_listaUsuarios.Visible = false;
            this.dataGrid_listaUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_listaUsuarios_CellClick);
            this.dataGrid_listaUsuarios.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_listaUsuarios_CellMouseEnter);
            this.dataGrid_listaUsuarios.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_listaUsuarios_CellMouseLeave);
            // 
            // btt_controlListaConectados
            // 
            this.btt_controlListaConectados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_controlListaConectados.Location = new System.Drawing.Point(901, 3);
            this.btt_controlListaConectados.Name = "btt_controlListaConectados";
            this.btt_controlListaConectados.Size = new System.Drawing.Size(201, 23);
            this.btt_controlListaConectados.TabIndex = 31;
            this.btt_controlListaConectados.Text = "Mostrar Conectados:";
            this.btt_controlListaConectados.UseVisualStyleBackColor = true;
            this.btt_controlListaConectados.Click += new System.EventHandler(this.btt_controlListaConectados_Click);
            // 
            // btt_eliminarInvitado
            // 
            this.btt_eliminarInvitado.AutoSize = true;
            this.btt_eliminarInvitado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_eliminarInvitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btt_eliminarInvitado.Location = new System.Drawing.Point(534, 207);
            this.btt_eliminarInvitado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btt_eliminarInvitado.Name = "btt_eliminarInvitado";
            this.btt_eliminarInvitado.Size = new System.Drawing.Size(100, 28);
            this.btt_eliminarInvitado.TabIndex = 32;
            this.btt_eliminarInvitado.Text = "Eliminar";
            this.btt_eliminarInvitado.UseVisualStyleBackColor = true;
            this.btt_eliminarInvitado.Visible = false;
            this.btt_eliminarInvitado.Click += new System.EventHandler(this.btt_eliminarInvitado_Click);
            // 
            // menuPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 471);
            this.Controls.Add(this.btt_eliminarInvitado);
            this.Controls.Add(this.btt_controlListaConectados);
            this.Controls.Add(this.dataGrid_listaUsuarios);
            this.Controls.Add(this.button_Invitar);
            this.Controls.Add(this.button_Jugar);
            this.Controls.Add(this.lbl_otrasPartridas);
            this.Controls.Add(this.datagrid_otrasPartidas);
            this.Controls.Add(this.lbl_miPartida);
            this.Controls.Add(this.datagrid_miPartida);
            this.Controls.Add(this.button_LogOut);
            this.Controls.Add(this.button_partidanueva);
            this.Controls.Add(this.dataGrid_listaInvitar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "menuPartida";
            this.Text = "principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menuPartida_FormClosing);
            this.Load += new System.EventHandler(this.principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listaInvitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_miPartida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_otrasPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listaUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_listaInvitar;
        private System.Windows.Forms.Button button_partidanueva;
        private System.Windows.Forms.Button button_LogOut;
        private System.Windows.Forms.Label lbl_miPartida;
        private System.Windows.Forms.DataGridView datagrid_miPartida;
        private System.Windows.Forms.Label lbl_otrasPartridas;
        private System.Windows.Forms.DataGridView datagrid_otrasPartidas;
        private System.Windows.Forms.Button button_Jugar;
        private System.Windows.Forms.Button button_Invitar;
        private System.Windows.Forms.DataGridView dataGrid_listaUsuarios;
        private System.Windows.Forms.Button btt_controlListaConectados;
        private System.Windows.Forms.Button btt_eliminarInvitado;
    }
}