namespace ClienteC__Juego
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
            this.dgrid_listaInvitar = new System.Windows.Forms.DataGridView();
            this.button_partidanueva = new System.Windows.Forms.Button();
            this.button_LogOut = new System.Windows.Forms.Button();
            this.lbl_miPartida = new System.Windows.Forms.Label();
            this.dgrid_miPartida = new System.Windows.Forms.DataGridView();
            this.button_Jugar = new System.Windows.Forms.Button();
            this.button_Invitar = new System.Windows.Forms.Button();
            this.dgrid_listaUsuarios = new System.Windows.Forms.DataGridView();
            this.btt_eliminarInvitado = new System.Windows.Forms.Button();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.textBox_write = new System.Windows.Forms.TextBox();
            this.tbox_read = new System.Windows.Forms.RichTextBox();
            this.pBox_mostrarConn = new System.Windows.Forms.PictureBox();
            this.lbl_write = new System.Windows.Forms.Label();
            this.pBox_sendText = new System.Windows.Forms.PictureBox();
            this.gBox_chat = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_listaInvitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_miPartida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_listaUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_mostrarConn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_sendText)).BeginInit();
            this.gBox_chat.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrid_listaInvitar
            // 
            this.dgrid_listaInvitar.AllowUserToAddRows = false;
            this.dgrid_listaInvitar.AllowUserToDeleteRows = false;
            this.dgrid_listaInvitar.AllowUserToResizeColumns = false;
            this.dgrid_listaInvitar.AllowUserToResizeRows = false;
            this.dgrid_listaInvitar.ColumnHeadersHeight = 25;
            this.dgrid_listaInvitar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrid_listaInvitar.Location = new System.Drawing.Point(892, 338);
            this.dgrid_listaInvitar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgrid_listaInvitar.Name = "dgrid_listaInvitar";
            this.dgrid_listaInvitar.ReadOnly = true;
            this.dgrid_listaInvitar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgrid_listaInvitar.RowHeadersVisible = false;
            this.dgrid_listaInvitar.RowHeadersWidth = 50;
            this.dgrid_listaInvitar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrid_listaInvitar.Size = new System.Drawing.Size(112, 246);
            this.dgrid_listaInvitar.TabIndex = 20;
            this.dgrid_listaInvitar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_listaInvitar_CellClick);
            // 
            // button_partidanueva
            // 
            this.button_partidanueva.AutoSize = true;
            this.button_partidanueva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button_partidanueva.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_partidanueva.Location = new System.Drawing.Point(54, 66);
            this.button_partidanueva.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_partidanueva.Name = "button_partidanueva";
            this.button_partidanueva.Size = new System.Drawing.Size(220, 52);
            this.button_partidanueva.TabIndex = 21;
            this.button_partidanueva.Text = "Partida Nueva";
            this.button_partidanueva.UseVisualStyleBackColor = false;
            this.button_partidanueva.Click += new System.EventHandler(this.button_partidanueva_Click);
            // 
            // button_LogOut
            // 
            this.button_LogOut.AutoSize = true;
            this.button_LogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_LogOut.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LogOut.Location = new System.Drawing.Point(98, 460);
            this.button_LogOut.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(138, 52);
            this.button_LogOut.TabIndex = 22;
            this.button_LogOut.Text = "Log Out";
            this.button_LogOut.UseVisualStyleBackColor = false;
            this.button_LogOut.Click += new System.EventHandler(this.button_LogOut_Click);
            // 
            // lbl_miPartida
            // 
            this.lbl_miPartida.AutoSize = true;
            this.lbl_miPartida.Location = new System.Drawing.Point(362, 18);
            this.lbl_miPartida.Name = "lbl_miPartida";
            this.lbl_miPartida.Size = new System.Drawing.Size(82, 20);
            this.lbl_miPartida.TabIndex = 25;
            this.lbl_miPartida.Text = "Mi partida:";
            // 
            // dgrid_miPartida
            // 
            this.dgrid_miPartida.AllowUserToAddRows = false;
            this.dgrid_miPartida.AllowUserToDeleteRows = false;
            this.dgrid_miPartida.AllowUserToResizeColumns = false;
            this.dgrid_miPartida.AllowUserToResizeRows = false;
            this.dgrid_miPartida.ColumnHeadersHeight = 25;
            this.dgrid_miPartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrid_miPartida.Location = new System.Drawing.Point(364, 42);
            this.dgrid_miPartida.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgrid_miPartida.Name = "dgrid_miPartida";
            this.dgrid_miPartida.ReadOnly = true;
            this.dgrid_miPartida.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgrid_miPartida.RowHeadersVisible = false;
            this.dgrid_miPartida.RowHeadersWidth = 50;
            this.dgrid_miPartida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrid_miPartida.Size = new System.Drawing.Size(366, 249);
            this.dgrid_miPartida.TabIndex = 24;
            this.dgrid_miPartida.Visible = false;
            this.dgrid_miPartida.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_miPartida_CellClick);
            // 
            // button_Jugar
            // 
            this.button_Jugar.AutoSize = true;
            this.button_Jugar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_Jugar.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Jugar.Location = new System.Drawing.Point(98, 401);
            this.button_Jugar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_Jugar.Name = "button_Jugar";
            this.button_Jugar.Size = new System.Drawing.Size(130, 52);
            this.button_Jugar.TabIndex = 28;
            this.button_Jugar.Text = "Jugar";
            this.button_Jugar.UseVisualStyleBackColor = false;
            this.button_Jugar.Click += new System.EventHandler(this.button_Jugar_Click);
            // 
            // button_Invitar
            // 
            this.button_Invitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Invitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Invitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.button_Invitar.Location = new System.Drawing.Point(892, 299);
            this.button_Invitar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_Invitar.Name = "button_Invitar";
            this.button_Invitar.Size = new System.Drawing.Size(112, 35);
            this.button_Invitar.TabIndex = 29;
            this.button_Invitar.Text = "Invitar";
            this.button_Invitar.UseVisualStyleBackColor = true;
            this.button_Invitar.Click += new System.EventHandler(this.button_Invitar_Click);
            // 
            // dgrid_listaUsuarios
            // 
            this.dgrid_listaUsuarios.AllowUserToAddRows = false;
            this.dgrid_listaUsuarios.AllowUserToDeleteRows = false;
            this.dgrid_listaUsuarios.AllowUserToResizeColumns = false;
            this.dgrid_listaUsuarios.AllowUserToResizeRows = false;
            this.dgrid_listaUsuarios.ColumnHeadersHeight = 25;
            this.dgrid_listaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrid_listaUsuarios.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgrid_listaUsuarios.Location = new System.Drawing.Point(1011, 9);
            this.dgrid_listaUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgrid_listaUsuarios.Name = "dgrid_listaUsuarios";
            this.dgrid_listaUsuarios.ReadOnly = true;
            this.dgrid_listaUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgrid_listaUsuarios.RowHeadersVisible = false;
            this.dgrid_listaUsuarios.RowHeadersWidth = 50;
            this.dgrid_listaUsuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgrid_listaUsuarios.Size = new System.Drawing.Size(225, 575);
            this.dgrid_listaUsuarios.TabIndex = 30;
            this.dgrid_listaUsuarios.Visible = false;
            this.dgrid_listaUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_listaUsuarios_CellClick);
            // 
            // btt_eliminarInvitado
            // 
            this.btt_eliminarInvitado.AutoSize = true;
            this.btt_eliminarInvitado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_eliminarInvitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btt_eliminarInvitado.Location = new System.Drawing.Point(618, 252);
            this.btt_eliminarInvitado.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btt_eliminarInvitado.Name = "btt_eliminarInvitado";
            this.btt_eliminarInvitado.Size = new System.Drawing.Size(112, 39);
            this.btt_eliminarInvitado.TabIndex = 32;
            this.btt_eliminarInvitado.Text = "Eliminar";
            this.btt_eliminarInvitado.UseVisualStyleBackColor = true;
            this.btt_eliminarInvitado.Visible = false;
            this.btt_eliminarInvitado.Click += new System.EventHandler(this.btt_eliminarInvitado_Click);
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Location = new System.Drawing.Point(14, 9);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(72, 20);
            this.lbl_userName.TabIndex = 33;
            this.lbl_userName.Text = "Usuario: ";
            // 
            // textBox_write
            // 
            this.textBox_write.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_write.Location = new System.Drawing.Point(83, 245);
            this.textBox_write.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_write.Multiline = true;
            this.textBox_write.Name = "textBox_write";
            this.textBox_write.Size = new System.Drawing.Size(240, 31);
            this.textBox_write.TabIndex = 34;
            this.textBox_write.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_write_KeyDown);
            // 
            // tbox_read
            // 
            this.tbox_read.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbox_read.Location = new System.Drawing.Point(8, 20);
            this.tbox_read.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbox_read.Name = "tbox_read";
            this.tbox_read.ReadOnly = true;
            this.tbox_read.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbox_read.Size = new System.Drawing.Size(345, 214);
            this.tbox_read.TabIndex = 35;
            this.tbox_read.Text = "";
            // 
            // pBox_mostrarConn
            // 
            this.pBox_mostrarConn.BackColor = System.Drawing.Color.Transparent;
            this.pBox_mostrarConn.BackgroundImage = global::ClienteC__Juego.Properties.Resources.bottonConn1;
            this.pBox_mostrarConn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_mostrarConn.Location = new System.Drawing.Point(982, 9);
            this.pBox_mostrarConn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pBox_mostrarConn.Name = "pBox_mostrarConn";
            this.pBox_mostrarConn.Size = new System.Drawing.Size(22, 50);
            this.pBox_mostrarConn.TabIndex = 36;
            this.pBox_mostrarConn.TabStop = false;
            this.pBox_mostrarConn.Click += new System.EventHandler(this.pBox_mostrarConn_Click);
            this.pBox_mostrarConn.MouseEnter += new System.EventHandler(this.pBox_mostrarConn_MouseEnter);
            this.pBox_mostrarConn.MouseLeave += new System.EventHandler(this.pBox_mostrarConn_MouseLeave);
            // 
            // lbl_write
            // 
            this.lbl_write.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_write.Location = new System.Drawing.Point(7, 245);
            this.lbl_write.Name = "lbl_write";
            this.lbl_write.Size = new System.Drawing.Size(69, 31);
            this.lbl_write.TabIndex = 37;
            this.lbl_write.Text = "Text:";
            this.lbl_write.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBox_sendText
            // 
            this.pBox_sendText.BackgroundImage = global::ClienteC__Juego.Properties.Resources.Icono_Enviar;
            this.pBox_sendText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_sendText.Location = new System.Drawing.Point(325, 245);
            this.pBox_sendText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pBox_sendText.Name = "pBox_sendText";
            this.pBox_sendText.Size = new System.Drawing.Size(28, 31);
            this.pBox_sendText.TabIndex = 38;
            this.pBox_sendText.TabStop = false;
            this.pBox_sendText.Click += new System.EventHandler(this.pBox_sendText_Click);
            this.pBox_sendText.MouseEnter += new System.EventHandler(this.pBox_sendText_MouseEnter);
            this.pBox_sendText.MouseLeave += new System.EventHandler(this.pBox_sendText_MouseLeave);
            // 
            // gBox_chat
            // 
            this.gBox_chat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gBox_chat.BackColor = System.Drawing.Color.Transparent;
            this.gBox_chat.Controls.Add(this.tbox_read);
            this.gBox_chat.Controls.Add(this.pBox_sendText);
            this.gBox_chat.Controls.Add(this.textBox_write);
            this.gBox_chat.Controls.Add(this.lbl_write);
            this.gBox_chat.Location = new System.Drawing.Point(364, 299);
            this.gBox_chat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBox_chat.Name = "gBox_chat";
            this.gBox_chat.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBox_chat.Size = new System.Drawing.Size(366, 285);
            this.gBox_chat.TabIndex = 39;
            this.gBox_chat.TabStop = false;
            this.gBox_chat.Text = "Chat Box";
            // 
            // menuPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::ClienteC__Juego.Properties.Resources.fondoDetectiveTile;
            this.ClientSize = new System.Drawing.Size(1242, 591);
            this.Controls.Add(this.gBox_chat);
            this.Controls.Add(this.pBox_mostrarConn);
            this.Controls.Add(this.lbl_userName);
            this.Controls.Add(this.btt_eliminarInvitado);
            this.Controls.Add(this.dgrid_listaUsuarios);
            this.Controls.Add(this.button_Invitar);
            this.Controls.Add(this.button_Jugar);
            this.Controls.Add(this.lbl_miPartida);
            this.Controls.Add(this.dgrid_miPartida);
            this.Controls.Add(this.button_LogOut);
            this.Controls.Add(this.button_partidanueva);
            this.Controls.Add(this.dgrid_listaInvitar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "menuPartida";
            this.Text = "principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menuPartida_FormClosing);
            this.Load += new System.EventHandler(this.principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_listaInvitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_miPartida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_listaUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_mostrarConn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_sendText)).EndInit();
            this.gBox_chat.ResumeLayout(false);
            this.gBox_chat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrid_listaInvitar;
        private System.Windows.Forms.Button button_partidanueva;
        private System.Windows.Forms.Button button_LogOut;
        private System.Windows.Forms.Label lbl_miPartida;
        private System.Windows.Forms.DataGridView dgrid_miPartida;
        private System.Windows.Forms.Button button_Jugar;
        private System.Windows.Forms.Button button_Invitar;
        private System.Windows.Forms.DataGridView dgrid_listaUsuarios;
        private System.Windows.Forms.Button btt_eliminarInvitado;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.TextBox textBox_write;
        private System.Windows.Forms.RichTextBox tbox_read;
        private System.Windows.Forms.PictureBox pBox_mostrarConn;
        private System.Windows.Forms.Label lbl_write;
        private System.Windows.Forms.PictureBox pBox_sendText;
        private System.Windows.Forms.GroupBox gBox_chat;
    }
}