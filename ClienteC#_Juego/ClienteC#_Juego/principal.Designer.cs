﻿namespace ClienteC__Juego
{
    partial class principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textbox_partida = new System.Windows.Forms.MaskedTextBox();
            this.textbox_nombre = new System.Windows.Forms.MaskedTextBox();
            this.command_3 = new System.Windows.Forms.RadioButton();
            this.command_1 = new System.Windows.Forms.RadioButton();
            this.command_2 = new System.Windows.Forms.RadioButton();
            this.button_enviar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Desconectar = new System.Windows.Forms.Button();
            this.button_listausuarios = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.textbox_partida);
            this.groupBox1.Controls.Add(this.textbox_nombre);
            this.groupBox1.Controls.Add(this.command_3);
            this.groupBox1.Controls.Add(this.command_1);
            this.groupBox1.Controls.Add(this.command_2);
            this.groupBox1.Controls.Add(this.button_enviar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(276, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textbox_partida
            // 
            this.textbox_partida.Location = new System.Drawing.Point(97, 51);
            this.textbox_partida.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textbox_partida.Name = "textbox_partida";
            this.textbox_partida.Size = new System.Drawing.Size(76, 20);
            this.textbox_partida.TabIndex = 7;
            // 
            // textbox_nombre
            // 
            this.textbox_nombre.Location = new System.Drawing.Point(97, 29);
            this.textbox_nombre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textbox_nombre.Name = "textbox_nombre";
            this.textbox_nombre.Size = new System.Drawing.Size(76, 20);
            this.textbox_nombre.TabIndex = 6;
            // 
            // command_3
            // 
            this.command_3.AutoSize = true;
            this.command_3.Location = new System.Drawing.Point(18, 131);
            this.command_3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.command_3.Name = "command_3";
            this.command_3.Size = new System.Drawing.Size(152, 17);
            this.command_3.TabIndex = 5;
            this.command_3.TabStop = true;
            this.command_3.Text = "Dime ganador de la partida";
            this.command_3.UseVisualStyleBackColor = true;
            // 
            // command_1
            // 
            this.command_1.AutoSize = true;
            this.command_1.Location = new System.Drawing.Point(18, 90);
            this.command_1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.command_1.Name = "command_1";
            this.command_1.Size = new System.Drawing.Size(183, 17);
            this.command_1.TabIndex = 4;
            this.command_1.TabStop = true;
            this.command_1.Text = "Dime puntuacion total del jugador";
            this.command_1.UseVisualStyleBackColor = true;
            // 
            // command_2
            // 
            this.command_2.AutoSize = true;
            this.command_2.Location = new System.Drawing.Point(18, 110);
            this.command_2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.command_2.Name = "command_2";
            this.command_2.Size = new System.Drawing.Size(247, 17);
            this.command_2.TabIndex = 3;
            this.command_2.TabStop = true;
            this.command_2.Text = "Dime puntuacion en las partidas que ha jugado";
            this.command_2.UseVisualStyleBackColor = true;
            // 
            // button_enviar
            // 
            this.button_enviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_enviar.AutoSize = true;
            this.button_enviar.Enabled = false;
            this.button_enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_enviar.Location = new System.Drawing.Point(210, 153);
            this.button_enviar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(63, 26);
            this.button_enviar.TabIndex = 2;
            this.button_enviar.Text = "Solicitar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Partida:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // button_Desconectar
            // 
            this.button_Desconectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Desconectar.AutoSize = true;
            this.button_Desconectar.Enabled = false;
            this.button_Desconectar.Location = new System.Drawing.Point(240, 276);
            this.button_Desconectar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_Desconectar.Name = "button_Desconectar";
            this.button_Desconectar.Size = new System.Drawing.Size(78, 23);
            this.button_Desconectar.TabIndex = 2;
            this.button_Desconectar.Text = "Desconectar";
            this.button_Desconectar.UseVisualStyleBackColor = true;
            this.button_Desconectar.Click += new System.EventHandler(this.button_Desconectar_Click);
            // 
            // button_listausuarios
            // 
            this.button_listausuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_listausuarios.AutoSize = true;
            this.button_listausuarios.Location = new System.Drawing.Point(235, 249);
            this.button_listausuarios.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_listausuarios.Name = "button_listausuarios";
            this.button_listausuarios.Size = new System.Drawing.Size(83, 23);
            this.button_listausuarios.TabIndex = 10;
            this.button_listausuarios.Text = "Lista usuarios";
            this.button_listausuarios.UseVisualStyleBackColor = true;
            this.button_listausuarios.Click += new System.EventHandler(this.button_listausuarios_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(327, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.listaUsuariosToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 22);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.usuarioToolStripMenuItem.Text = "Menu usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // listaUsuariosToolStripMenuItem
            // 
            this.listaUsuariosToolStripMenuItem.Name = "listaUsuariosToolStripMenuItem";
            this.listaUsuariosToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.listaUsuariosToolStripMenuItem.Text = "Lista usuarios";
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 308);
            this.Controls.Add(this.button_listausuarios);
            this.Controls.Add(this.button_Desconectar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "principal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox textbox_partida;
        private System.Windows.Forms.MaskedTextBox textbox_nombre;
        private System.Windows.Forms.RadioButton command_3;
        private System.Windows.Forms.RadioButton command_1;
        private System.Windows.Forms.RadioButton command_2;
        private System.Windows.Forms.Button button_enviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Desconectar;
        private System.Windows.Forms.Button button_listausuarios;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaUsuariosToolStripMenuItem;
    }
}
