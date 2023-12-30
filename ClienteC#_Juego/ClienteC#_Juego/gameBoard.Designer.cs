namespace ClienteC__Juego
{
    partial class gameBoard
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
            this.panel_Guess = new System.Windows.Forms.Panel();
            this.btt_solve = new System.Windows.Forms.Button();
            this.btt_guess = new System.Windows.Forms.Button();
            this.lbl_suspect = new System.Windows.Forms.Label();
            this.lbl_weap = new System.Windows.Forms.Label();
            this.lbl_room = new System.Windows.Forms.Label();
            this.panel_Dados = new System.Windows.Forms.Panel();
            this.panel_guess1 = new System.Windows.Forms.Panel();
            this.panel_guess2 = new System.Windows.Forms.Panel();
            this.panel_guess3 = new System.Windows.Forms.Panel();
            this.pBox_check1 = new System.Windows.Forms.PictureBox();
            this.pBox_check2 = new System.Windows.Forms.PictureBox();
            this.pBox_check3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_notePad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_dice1)).BeginInit();
            this.panel_Board.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_sendText)).BeginInit();
            this.gBox_chat.SuspendLayout();
            this.panel_Guess.SuspendLayout();
            this.panel_Dados.SuspendLayout();
            this.panel_guess1.SuspendLayout();
            this.panel_guess2.SuspendLayout();
            this.panel_guess3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_check1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_check2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_check3)).BeginInit();
            this.SuspendLayout();
            // 
            // btt_dado
            // 
            this.btt_dado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btt_dado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_dado.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_dado.Location = new System.Drawing.Point(53, 3);
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
            this.lbl_diceRoll.Location = new System.Drawing.Point(174, 17);
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
            this.pBox_card3.BackgroundImage = global::ClienteC__Juego.Properties.Resources.room1;
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
            this.pBox_card2.BackgroundImage = global::ClienteC__Juego.Properties.Resources.weapon1;
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
            this.pBox_dice2.Location = new System.Drawing.Point(121, 39);
            this.pBox_dice2.Name = "pBox_dice2";
            this.pBox_dice2.Size = new System.Drawing.Size(100, 100);
            this.pBox_dice2.TabIndex = 16;
            this.pBox_dice2.TabStop = false;
            // 
            // pBox_dice1
            // 
            this.pBox_dice1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBox_dice1.Location = new System.Drawing.Point(11, 39);
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
            this.richtBox_read.Location = new System.Drawing.Point(7, 20);
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
            this.pBox_sendText.Location = new System.Drawing.Point(196, 200);
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
            this.tBox_write.Location = new System.Drawing.Point(63, 200);
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
            this.lbl_write.Location = new System.Drawing.Point(6, 200);
            this.lbl_write.Name = "lbl_write";
            this.lbl_write.Size = new System.Drawing.Size(50, 25);
            this.lbl_write.TabIndex = 41;
            this.lbl_write.Text = "Text:";
            this.lbl_write.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gBox_chat
            // 
            this.gBox_chat.BackColor = System.Drawing.Color.Snow;
            this.gBox_chat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gBox_chat.Controls.Add(this.richtBox_read);
            this.gBox_chat.Controls.Add(this.lbl_write);
            this.gBox_chat.Controls.Add(this.pBox_sendText);
            this.gBox_chat.Controls.Add(this.tBox_write);
            this.gBox_chat.Location = new System.Drawing.Point(12, 385);
            this.gBox_chat.Name = "gBox_chat";
            this.gBox_chat.Size = new System.Drawing.Size(229, 230);
            this.gBox_chat.TabIndex = 43;
            this.gBox_chat.TabStop = false;
            this.gBox_chat.Text = "Chat";
            // 
            // panel_Guess
            // 
            this.panel_Guess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Guess.Controls.Add(this.panel_guess3);
            this.panel_Guess.Controls.Add(this.panel_guess2);
            this.panel_Guess.Controls.Add(this.panel_guess1);
            this.panel_Guess.Controls.Add(this.lbl_room);
            this.panel_Guess.Controls.Add(this.lbl_weap);
            this.panel_Guess.Controls.Add(this.lbl_suspect);
            this.panel_Guess.Controls.Add(this.btt_guess);
            this.panel_Guess.Location = new System.Drawing.Point(12, 162);
            this.panel_Guess.Name = "panel_Guess";
            this.panel_Guess.Size = new System.Drawing.Size(240, 172);
            this.panel_Guess.TabIndex = 44;
            // 
            // btt_solve
            // 
            this.btt_solve.BackColor = System.Drawing.Color.YellowGreen;
            this.btt_solve.Font = new System.Drawing.Font("Algerian", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_solve.Location = new System.Drawing.Point(72, 340);
            this.btt_solve.Name = "btt_solve";
            this.btt_solve.Size = new System.Drawing.Size(106, 39);
            this.btt_solve.TabIndex = 45;
            this.btt_solve.Text = "SOLVE";
            this.btt_solve.UseVisualStyleBackColor = false;
            // 
            // btt_guess
            // 
            this.btt_guess.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_guess.Location = new System.Drawing.Point(3, 135);
            this.btt_guess.Name = "btt_guess";
            this.btt_guess.Size = new System.Drawing.Size(229, 34);
            this.btt_guess.TabIndex = 0;
            this.btt_guess.Text = "Make your guess";
            this.btt_guess.UseVisualStyleBackColor = true;
            // 
            // lbl_suspect
            // 
            this.lbl_suspect.Location = new System.Drawing.Point(12, 9);
            this.lbl_suspect.Name = "lbl_suspect";
            this.lbl_suspect.Size = new System.Drawing.Size(68, 19);
            this.lbl_suspect.TabIndex = 4;
            this.lbl_suspect.Text = "Suspect";
            this.lbl_suspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_weap
            // 
            this.lbl_weap.Location = new System.Drawing.Point(84, 9);
            this.lbl_weap.Name = "lbl_weap";
            this.lbl_weap.Size = new System.Drawing.Size(69, 16);
            this.lbl_weap.TabIndex = 5;
            this.lbl_weap.Text = "Weapon";
            this.lbl_weap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_room
            // 
            this.lbl_room.Location = new System.Drawing.Point(159, 9);
            this.lbl_room.Name = "lbl_room";
            this.lbl_room.Size = new System.Drawing.Size(44, 16);
            this.lbl_room.TabIndex = 6;
            this.lbl_room.Text = "Room";
            this.lbl_room.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Dados
            // 
            this.panel_Dados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Dados.Controls.Add(this.btt_dado);
            this.panel_Dados.Controls.Add(this.pBox_dice1);
            this.panel_Dados.Controls.Add(this.lbl_diceRoll);
            this.panel_Dados.Controls.Add(this.pBox_dice2);
            this.panel_Dados.Location = new System.Drawing.Point(12, 10);
            this.panel_Dados.Name = "panel_Dados";
            this.panel_Dados.Size = new System.Drawing.Size(240, 146);
            this.panel_Dados.TabIndex = 46;
            // 
            // panel_guess1
            // 
            this.panel_guess1.BackColor = System.Drawing.Color.Transparent;
            this.panel_guess1.BackgroundImage = global::ClienteC__Juego.Properties.Resources.suspect5;
            this.panel_guess1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_guess1.Controls.Add(this.pBox_check1);
            this.panel_guess1.Location = new System.Drawing.Point(15, 31);
            this.panel_guess1.Name = "panel_guess1";
            this.panel_guess1.Size = new System.Drawing.Size(65, 100);
            this.panel_guess1.TabIndex = 7;
            // 
            // panel_guess2
            // 
            this.panel_guess2.BackgroundImage = global::ClienteC__Juego.Properties.Resources.weapon4;
            this.panel_guess2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_guess2.Controls.Add(this.pBox_check2);
            this.panel_guess2.Location = new System.Drawing.Point(86, 31);
            this.panel_guess2.Name = "panel_guess2";
            this.panel_guess2.Size = new System.Drawing.Size(65, 100);
            this.panel_guess2.TabIndex = 8;
            // 
            // panel_guess3
            // 
            this.panel_guess3.BackgroundImage = global::ClienteC__Juego.Properties.Resources.room4;
            this.panel_guess3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_guess3.Controls.Add(this.pBox_check3);
            this.panel_guess3.Location = new System.Drawing.Point(156, 31);
            this.panel_guess3.Name = "panel_guess3";
            this.panel_guess3.Size = new System.Drawing.Size(65, 100);
            this.panel_guess3.TabIndex = 8;
            // 
            // pBox_check1
            // 
            this.pBox_check1.BackgroundImage = global::ClienteC__Juego.Properties.Resources.Cross;
            this.pBox_check1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_check1.Location = new System.Drawing.Point(25, 58);
            this.pBox_check1.Name = "pBox_check1";
            this.pBox_check1.Size = new System.Drawing.Size(40, 40);
            this.pBox_check1.TabIndex = 0;
            this.pBox_check1.TabStop = false;
            // 
            // pBox_check2
            // 
            this.pBox_check2.BackColor = System.Drawing.Color.Transparent;
            this.pBox_check2.BackgroundImage = global::ClienteC__Juego.Properties.Resources.Cross;
            this.pBox_check2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_check2.Location = new System.Drawing.Point(25, 57);
            this.pBox_check2.Name = "pBox_check2";
            this.pBox_check2.Size = new System.Drawing.Size(40, 40);
            this.pBox_check2.TabIndex = 1;
            this.pBox_check2.TabStop = false;
            // 
            // pBox_check3
            // 
            this.pBox_check3.BackColor = System.Drawing.Color.Transparent;
            this.pBox_check3.BackgroundImage = global::ClienteC__Juego.Properties.Resources.Cross;
            this.pBox_check3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_check3.Location = new System.Drawing.Point(22, 57);
            this.pBox_check3.Name = "pBox_check3";
            this.pBox_check3.Size = new System.Drawing.Size(40, 40);
            this.pBox_check3.TabIndex = 2;
            this.pBox_check3.TabStop = false;
            // 
            // gameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(960, 627);
            this.Controls.Add(this.panel_Dados);
            this.Controls.Add(this.btt_solve);
            this.Controls.Add(this.panel_Guess);
            this.Controls.Add(this.gBox_chat);
            this.Controls.Add(this.lbl_notePad);
            this.Controls.Add(this.lbl_cards);
            this.Controls.Add(this.pBox_card3);
            this.Controls.Add(this.pBox_card2);
            this.Controls.Add(this.pBox_card1);
            this.Controls.Add(this.pBox_notePad);
            this.Controls.Add(this.panel_Board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "gameBoard";
            this.Text = "Game of \"Host\"";
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
            this.panel_Guess.ResumeLayout(false);
            this.panel_Dados.ResumeLayout(false);
            this.panel_Dados.PerformLayout();
            this.panel_guess1.ResumeLayout(false);
            this.panel_guess2.ResumeLayout(false);
            this.panel_guess3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBox_check1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_check2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_check3)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel_Guess;
        private System.Windows.Forms.Label lbl_room;
        private System.Windows.Forms.Label lbl_weap;
        private System.Windows.Forms.Label lbl_suspect;
        private System.Windows.Forms.Button btt_guess;
        private System.Windows.Forms.Button btt_solve;
        private System.Windows.Forms.Panel panel_Dados;
        private System.Windows.Forms.Panel panel_guess3;
        private System.Windows.Forms.Panel panel_guess2;
        private System.Windows.Forms.Panel panel_guess1;
        private System.Windows.Forms.PictureBox pBox_check3;
        private System.Windows.Forms.PictureBox pBox_check2;
        private System.Windows.Forms.PictureBox pBox_check1;
    }
}

