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
            this.btt_dado = new System.Windows.Forms.Button();
            this.lbl_diceRoll = new System.Windows.Forms.Label();
            this.tbox_info = new System.Windows.Forms.TextBox();
            this.lbl_cards = new System.Windows.Forms.Label();
            this.lbl_notePad = new System.Windows.Forms.Label();
            this.pBox_card3 = new System.Windows.Forms.PictureBox();
            this.pBox_card2 = new System.Windows.Forms.PictureBox();
            this.pBox_card1 = new System.Windows.Forms.PictureBox();
            this.pBox_notePad = new System.Windows.Forms.PictureBox();
            this.pBox_dice2 = new System.Windows.Forms.PictureBox();
            this.pBox_dice1 = new System.Windows.Forms.PictureBox();
            this.panel_Board = new System.Windows.Forms.Panel();
            this.richtBox_read = new System.Windows.Forms.RichTextBox();
            this.pBox_sendText = new System.Windows.Forms.PictureBox();
            this.tBox_write = new System.Windows.Forms.TextBox();
            this.lbl_write = new System.Windows.Forms.Label();
            this.gBox_chat = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_notePad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice1)).BeginInit();
            this.panel_Board.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_sendText)).BeginInit();
            this.gBox_chat.SuspendLayout();
            this.SuspendLayout();
            // 
            // btt_dado
            // 
            this.btt_dado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btt_dado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_dado.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_dado.Location = new System.Drawing.Point(75, 10);
            this.btt_dado.Name = "btt_dado";
            this.btt_dado.Size = new System.Drawing.Size(119, 30);
            this.btt_dado.TabIndex = 2;
            this.btt_dado.Text = "Throw dices";
            this.btt_dado.UseVisualStyleBackColor = true;
            this.btt_dado.Click += new System.EventHandler(this.button_Dado1_Click);
            // 
            // lbl_diceRoll
            // 
            this.lbl_diceRoll.AutoSize = true;
            this.lbl_diceRoll.Location = new System.Drawing.Point(196, 24);
            this.lbl_diceRoll.Name = "lbl_diceRoll";
            this.lbl_diceRoll.Size = new System.Drawing.Size(37, 16);
            this.lbl_diceRoll.TabIndex = 5;
            this.lbl_diceRoll.Text = "-tirar-";
            // 
            // tbox_info
            // 
            this.tbox_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbox_info.Location = new System.Drawing.Point(357, -1);
            this.tbox_info.Multiline = true;
            this.tbox_info.Name = "tbox_info";
            this.tbox_info.ReadOnly = true;
            this.tbox_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbox_info.Size = new System.Drawing.Size(225, 93);
            this.tbox_info.TabIndex = 12;
            // 
            // lbl_cards
            // 
            this.lbl_cards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_cards.Location = new System.Drawing.Point(847, 10);
            this.lbl_cards.Name = "lbl_cards";
            this.lbl_cards.Size = new System.Drawing.Size(100, 25);
            this.lbl_cards.TabIndex = 21;
            this.lbl_cards.Text = "Your cards:";
            this.lbl_cards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_notePad
            // 
            this.lbl_notePad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_notePad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_notePad.Location = new System.Drawing.Point(848, 487);
            this.lbl_notePad.Name = "lbl_notePad";
            this.lbl_notePad.Size = new System.Drawing.Size(100, 25);
            this.lbl_notePad.TabIndex = 22;
            this.lbl_notePad.Text = "Your NotePad:";
            this.lbl_notePad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBox_card3
            // 
            this.pBox_card3.BackgroundImage = global::ClienteC__Juego.Properties.Resources.weapon1;
            this.pBox_card3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_card3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBox_card3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBox_card3.Location = new System.Drawing.Point(847, 330);
            this.pBox_card3.Name = "pBox_card3";
            this.pBox_card3.Size = new System.Drawing.Size(100, 140);
            this.pBox_card3.TabIndex = 20;
            this.pBox_card3.TabStop = false;
            this.pBox_card3.Click += new System.EventHandler(this.pBox_card3_Click);
            // 
            // pBox_card2
            // 
            this.pBox_card2.BackgroundImage = global::ClienteC__Juego.Properties.Resources.room1;
            this.pBox_card2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_card2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBox_card2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBox_card2.Location = new System.Drawing.Point(847, 184);
            this.pBox_card2.Name = "pBox_card2";
            this.pBox_card2.Size = new System.Drawing.Size(100, 140);
            this.pBox_card2.TabIndex = 19;
            this.pBox_card2.TabStop = false;
            this.pBox_card2.Click += new System.EventHandler(this.pBox_card2_Click);
            // 
            // pBox_card1
            // 
            this.pBox_card1.BackgroundImage = global::ClienteC__Juego.Properties.Resources.suspect1;
            this.pBox_card1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_card1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBox_card1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBox_card1.Location = new System.Drawing.Point(847, 38);
            this.pBox_card1.Name = "pBox_card1";
            this.pBox_card1.Size = new System.Drawing.Size(100, 140);
            this.pBox_card1.TabIndex = 18;
            this.pBox_card1.TabStop = false;
            this.pBox_card1.Click += new System.EventHandler(this.pBox_card1_Click);
            // 
            // pBox_notePad
            // 
            this.pBox_notePad.BackgroundImage = global::ClienteC__Juego.Properties.Resources.notepad_Icon;
            this.pBox_notePad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_notePad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBox_notePad.Location = new System.Drawing.Point(847, 515);
            this.pBox_notePad.Name = "pBox_notePad";
            this.pBox_notePad.Size = new System.Drawing.Size(100, 100);
            this.pBox_notePad.TabIndex = 17;
            this.pBox_notePad.TabStop = false;
            this.pBox_notePad.Click += new System.EventHandler(this.pBox_notePad_Click);
            this.pBox_notePad.MouseEnter += new System.EventHandler(this.pBox_notePad_MouseEnter);
            this.pBox_notePad.MouseLeave += new System.EventHandler(this.pBox_notePad_MouseLeave);
            // 
            // pBox_dice2
            // 
            this.pBox_dice2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBox_dice2.Location = new System.Drawing.Point(133, 46);
            this.pBox_dice2.Name = "pBox_dice2";
            this.pBox_dice2.Size = new System.Drawing.Size(100, 100);
            this.pBox_dice2.TabIndex = 16;
            this.pBox_dice2.TabStop = false;
            // 
            // pBox_dice1
            // 
            this.pBox_dice1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBox_dice1.Location = new System.Drawing.Point(27, 46);
            this.pBox_dice1.Name = "pBox_dice1";
            this.pBox_dice1.Size = new System.Drawing.Size(100, 100);
            this.pBox_dice1.TabIndex = 1;
            this.pBox_dice1.TabStop = false;
            // 
            // panel_Board
            // 
            this.panel_Board.BackgroundImage = global::ClienteC__Juego.Properties.Resources.Board;
            this.panel_Board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_Board.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Board.Controls.Add(this.tbox_info);
            this.panel_Board.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_Board.Location = new System.Drawing.Point(258, 10);
            this.panel_Board.Name = "panel_Board";
            this.panel_Board.Size = new System.Drawing.Size(583, 605);
            this.panel_Board.TabIndex = 0;
            // 
            // richtBox_read
            // 
            this.richtBox_read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richtBox_read.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richtBox_read.Location = new System.Drawing.Point(7, 17);
            this.richtBox_read.Margin = new System.Windows.Forms.Padding(4);
            this.richtBox_read.Name = "richtBox_read";
            this.richtBox_read.ReadOnly = true;
            this.richtBox_read.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richtBox_read.Size = new System.Drawing.Size(214, 172);
            this.richtBox_read.TabIndex = 40;
            this.richtBox_read.Text = "";
            // 
            // pBox_sendText
            // 
            this.pBox_sendText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBox_sendText.BackgroundImage = global::ClienteC__Juego.Properties.Resources.Icono_Enviar;
            this.pBox_sendText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_sendText.Location = new System.Drawing.Point(196, 197);
            this.pBox_sendText.Name = "pBox_sendText";
            this.pBox_sendText.Size = new System.Drawing.Size(25, 25);
            this.pBox_sendText.TabIndex = 42;
            this.pBox_sendText.TabStop = false;
            // 
            // tBox_write
            // 
            this.tBox_write.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tBox_write.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBox_write.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_write.Location = new System.Drawing.Point(63, 197);
            this.tBox_write.Margin = new System.Windows.Forms.Padding(4);
            this.tBox_write.Multiline = true;
            this.tBox_write.Name = "tBox_write";
            this.tBox_write.Size = new System.Drawing.Size(126, 25);
            this.tBox_write.TabIndex = 39;
            this.tBox_write.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_write_KeyDown);
            // 
            // lbl_write
            // 
            this.lbl_write.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_write.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_write.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbl_write.Location = new System.Drawing.Point(6, 197);
            this.lbl_write.Name = "lbl_write";
            this.lbl_write.Size = new System.Drawing.Size(50, 25);
            this.lbl_write.TabIndex = 41;
            this.lbl_write.Text = "Text:";
            this.lbl_write.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gBox_chat
            // 
            this.gBox_chat.Controls.Add(this.richtBox_read);
            this.gBox_chat.Controls.Add(this.lbl_write);
            this.gBox_chat.Controls.Add(this.pBox_sendText);
            this.gBox_chat.Controls.Add(this.tBox_write);
            this.gBox_chat.Location = new System.Drawing.Point(12, 388);
            this.gBox_chat.Name = "gBox_chat";
            this.gBox_chat.Size = new System.Drawing.Size(229, 227);
            this.gBox_chat.TabIndex = 43;
            this.gBox_chat.TabStop = false;
            this.gBox_chat.Text = "Chat";
            // 
            // board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(960, 627);
            this.Controls.Add(this.gBox_chat);
            this.Controls.Add(this.lbl_notePad);
            this.Controls.Add(this.lbl_cards);
            this.Controls.Add(this.pBox_card3);
            this.Controls.Add(this.pBox_card2);
            this.Controls.Add(this.pBox_card1);
            this.Controls.Add(this.pBox_notePad);
            this.Controls.Add(this.btt_dado);
            this.Controls.Add(this.pBox_dice2);
            this.Controls.Add(this.lbl_diceRoll);
            this.Controls.Add(this.pBox_dice1);
            this.Controls.Add(this.panel_Board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "board";
            this.Text = "Board";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_notePad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice1)).EndInit();
            this.panel_Board.ResumeLayout(false);
            this.panel_Board.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_sendText)).EndInit();
            this.gBox_chat.ResumeLayout(false);
            this.gBox_chat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Board;
        private System.Windows.Forms.Button btt_dado;
        private System.Windows.Forms.Label lbl_diceRoll;
        private System.Windows.Forms.PictureBox pBox_dice1;
        private System.Windows.Forms.TextBox tbox_info;
        private System.Windows.Forms.PictureBox pBox_dice2;
        private System.Windows.Forms.PictureBox pBox_notePad;
        private System.Windows.Forms.PictureBox pBox_card1;
        private System.Windows.Forms.PictureBox pBox_card2;
        private System.Windows.Forms.PictureBox pBox_card3;
        private System.Windows.Forms.Label lbl_cards;
        private System.Windows.Forms.Label lbl_notePad;
        private System.Windows.Forms.RichTextBox richtBox_read;
        private System.Windows.Forms.PictureBox pBox_sendText;
        private System.Windows.Forms.TextBox tBox_write;
        private System.Windows.Forms.Label lbl_write;
        private System.Windows.Forms.GroupBox gBox_chat;
    }
}

