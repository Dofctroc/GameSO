namespace ClienteC__Juego
{
    partial class board
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
            this.button_Dado1 = new System.Windows.Forms.Button();
            this.lbl_diceRoll = new System.Windows.Forms.Label();
            this.btton_pruebas1 = new System.Windows.Forms.Button();
            this.btt_pruebas2 = new System.Windows.Forms.Button();
            this.tbox_pruebas = new System.Windows.Forms.RichTextBox();
            this.tbox_mensaje = new System.Windows.Forms.TextBox();
            this.tbox_info = new System.Windows.Forms.TextBox();
            this.pBox_mostrarConectados = new System.Windows.Forms.PictureBox();
            this.pBox_dice1 = new System.Windows.Forms.PictureBox();
            this.panel_Board = new System.Windows.Forms.Panel();
            this.dGrid_conectados = new System.Windows.Forms.DataGridView();
            this.pBox_dice2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_mostrarConectados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_conectados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Dado1
            // 
            this.button_Dado1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Dado1.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Dado1.Location = new System.Drawing.Point(66, 10);
            this.button_Dado1.Name = "button_Dado1";
            this.button_Dado1.Size = new System.Drawing.Size(100, 30);
            this.button_Dado1.TabIndex = 2;
            this.button_Dado1.Text = "Tirar Dado";
            this.button_Dado1.UseVisualStyleBackColor = true;
            this.button_Dado1.Click += new System.EventHandler(this.button_Dado1_Click);
            // 
            // lbl_diceRoll
            // 
            this.lbl_diceRoll.AutoSize = true;
            this.lbl_diceRoll.Location = new System.Drawing.Point(12, 142);
            this.lbl_diceRoll.Name = "lbl_diceRoll";
            this.lbl_diceRoll.Size = new System.Drawing.Size(37, 16);
            this.lbl_diceRoll.TabIndex = 5;
            this.lbl_diceRoll.Text = "-tirar-";
            // 
            // btton_pruebas1
            // 
            this.btton_pruebas1.Location = new System.Drawing.Point(10, 289);
            this.btton_pruebas1.Name = "btton_pruebas1";
            this.btton_pruebas1.Size = new System.Drawing.Size(75, 23);
            this.btton_pruebas1.TabIndex = 7;
            this.btton_pruebas1.Text = "TryPath";
            this.btton_pruebas1.UseVisualStyleBackColor = true;
            this.btton_pruebas1.Click += new System.EventHandler(this.btton_pruebas_Click);
            // 
            // btt_pruebas2
            // 
            this.btt_pruebas2.Location = new System.Drawing.Point(91, 289);
            this.btt_pruebas2.Name = "btt_pruebas2";
            this.btt_pruebas2.Size = new System.Drawing.Size(75, 23);
            this.btt_pruebas2.TabIndex = 9;
            this.btt_pruebas2.Text = "TryText";
            this.btt_pruebas2.UseVisualStyleBackColor = true;
            this.btt_pruebas2.Click += new System.EventHandler(this.btt_pruebas2_Click);
            // 
            // tbox_pruebas
            // 
            this.tbox_pruebas.BackColor = System.Drawing.SystemColors.Control;
            this.tbox_pruebas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbox_pruebas.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbox_pruebas.Location = new System.Drawing.Point(10, 318);
            this.tbox_pruebas.Name = "tbox_pruebas";
            this.tbox_pruebas.ReadOnly = true;
            this.tbox_pruebas.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbox_pruebas.Size = new System.Drawing.Size(487, 197);
            this.tbox_pruebas.TabIndex = 10;
            this.tbox_pruebas.Text = "";
            // 
            // tbox_mensaje
            // 
            this.tbox_mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbox_mensaje.Location = new System.Drawing.Point(10, 521);
            this.tbox_mensaje.Name = "tbox_mensaje";
            this.tbox_mensaje.Size = new System.Drawing.Size(487, 22);
            this.tbox_mensaje.TabIndex = 11;
            this.tbox_mensaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pbox_mensaje_KeyDown);
            // 
            // tbox_info
            // 
            this.tbox_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbox_info.Location = new System.Drawing.Point(285, 10);
            this.tbox_info.Multiline = true;
            this.tbox_info.Name = "tbox_info";
            this.tbox_info.ReadOnly = true;
            this.tbox_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbox_info.Size = new System.Drawing.Size(212, 129);
            this.tbox_info.TabIndex = 12;
            // 
            // pBox_mostrarConectados
            // 
            this.pBox_mostrarConectados.BackgroundImage = global::ClienteC__Juego.Properties.Resources.bottonConn1;
            this.pBox_mostrarConectados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_mostrarConectados.Location = new System.Drawing.Point(1108, 10);
            this.pBox_mostrarConectados.Name = "pBox_mostrarConectados";
            this.pBox_mostrarConectados.Size = new System.Drawing.Size(20, 40);
            this.pBox_mostrarConectados.TabIndex = 14;
            this.pBox_mostrarConectados.TabStop = false;
            this.pBox_mostrarConectados.Click += new System.EventHandler(this.pBox_mostrarConectados_Click);
            this.pBox_mostrarConectados.MouseEnter += new System.EventHandler(this.pBox_mostrarConectados_MouseEnter);
            this.pBox_mostrarConectados.MouseLeave += new System.EventHandler(this.pBox_mostrarConectados_MouseLeave);
            // 
            // pBox_dice1
            // 
            this.pBox_dice1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBox_dice1.Location = new System.Drawing.Point(11, 39);
            this.pBox_dice1.Name = "pBox_dice1";
            this.pBox_dice1.Size = new System.Drawing.Size(100, 100);
            this.pBox_dice1.TabIndex = 1;
            this.pBox_dice1.TabStop = false;
            this.pBox_dice1.Click += new System.EventHandler(this.pBox_dice_Click);
            this.pBox_dice1.MouseEnter += new System.EventHandler(this.pBox_dice_MouseEnter);
            this.pBox_dice1.MouseLeave += new System.EventHandler(this.pBox_dice_MouseLeave);
            // 
            // panel_Board
            // 
            this.panel_Board.BackgroundImage = global::ClienteC__Juego.Properties.Resources.Board;
            this.panel_Board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_Board.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Board.Location = new System.Drawing.Point(519, 10);
            this.panel_Board.Name = "panel_Board";
            this.panel_Board.Size = new System.Drawing.Size(583, 605);
            this.panel_Board.TabIndex = 0;
            // 
            // dGrid_conectados
            // 
            this.dGrid_conectados.AllowUserToAddRows = false;
            this.dGrid_conectados.AllowUserToDeleteRows = false;
            this.dGrid_conectados.AllowUserToResizeColumns = false;
            this.dGrid_conectados.AllowUserToResizeRows = false;
            this.dGrid_conectados.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dGrid_conectados.ColumnHeadersHeight = 29;
            this.dGrid_conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGrid_conectados.Location = new System.Drawing.Point(1134, 10);
            this.dGrid_conectados.Name = "dGrid_conectados";
            this.dGrid_conectados.RowHeadersVisible = false;
            this.dGrid_conectados.RowHeadersWidth = 51;
            this.dGrid_conectados.RowTemplate.Height = 24;
            this.dGrid_conectados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGrid_conectados.Size = new System.Drawing.Size(216, 605);
            this.dGrid_conectados.TabIndex = 15;
            // 
            // pBox_dice2
            // 
            this.pBox_dice2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBox_dice2.Location = new System.Drawing.Point(117, 39);
            this.pBox_dice2.Name = "pBox_dice2";
            this.pBox_dice2.Size = new System.Drawing.Size(100, 100);
            this.pBox_dice2.TabIndex = 16;
            this.pBox_dice2.TabStop = false;
            // 
            // board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1362, 627);
            this.Controls.Add(this.button_Dado1);
            this.Controls.Add(this.pBox_dice2);
            this.Controls.Add(this.dGrid_conectados);
            this.Controls.Add(this.pBox_mostrarConectados);
            this.Controls.Add(this.tbox_info);
            this.Controls.Add(this.tbox_mensaje);
            this.Controls.Add(this.tbox_pruebas);
            this.Controls.Add(this.btt_pruebas2);
            this.Controls.Add(this.btton_pruebas1);
            this.Controls.Add(this.lbl_diceRoll);
            this.Controls.Add(this.pBox_dice1);
            this.Controls.Add(this.panel_Board);
            this.Name = "board";
            this.Text = "Board";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox_mostrarConectados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_conectados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Board;
        private System.Windows.Forms.Button button_Dado1;
        private System.Windows.Forms.Label lbl_diceRoll;
        private System.Windows.Forms.Button btton_pruebas1;
        private System.Windows.Forms.PictureBox pBox_dice1;
        private System.Windows.Forms.Button btt_pruebas2;
        private System.Windows.Forms.RichTextBox tbox_pruebas;
        private System.Windows.Forms.TextBox tbox_mensaje;
        private System.Windows.Forms.TextBox tbox_info;
        private System.Windows.Forms.PictureBox pBox_mostrarConectados;
        private System.Windows.Forms.DataGridView dGrid_conectados;
        private System.Windows.Forms.PictureBox pBox_dice2;
    }
}

