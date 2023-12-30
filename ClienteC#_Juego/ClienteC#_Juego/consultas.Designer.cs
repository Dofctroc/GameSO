namespace ClienteC__Juego
{
    partial class consultas
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
            this.gBox_individualInfo = new System.Windows.Forms.GroupBox();
            this.richBox_console = new System.Windows.Forms.RichTextBox();
            this.textbox_partida = new System.Windows.Forms.MaskedTextBox();
            this.textbox_nombre = new System.Windows.Forms.MaskedTextBox();
            this.command_3 = new System.Windows.Forms.RadioButton();
            this.command_1 = new System.Windows.Forms.RadioButton();
            this.command_2 = new System.Windows.Forms.RadioButton();
            this.btt_askInfo = new System.Windows.Forms.Button();
            this.lbl_Game = new System.Windows.Forms.Label();
            this.lbl_Jug = new System.Windows.Forms.Label();
            this.gBox_individualInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox_individualInfo
            // 
            this.gBox_individualInfo.BackColor = System.Drawing.Color.Tan;
            this.gBox_individualInfo.Controls.Add(this.richBox_console);
            this.gBox_individualInfo.Controls.Add(this.textbox_partida);
            this.gBox_individualInfo.Controls.Add(this.textbox_nombre);
            this.gBox_individualInfo.Controls.Add(this.command_3);
            this.gBox_individualInfo.Controls.Add(this.command_1);
            this.gBox_individualInfo.Controls.Add(this.command_2);
            this.gBox_individualInfo.Controls.Add(this.btt_askInfo);
            this.gBox_individualInfo.Controls.Add(this.lbl_Game);
            this.gBox_individualInfo.Controls.Add(this.lbl_Jug);
            this.gBox_individualInfo.Location = new System.Drawing.Point(10, 10);
            this.gBox_individualInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBox_individualInfo.Name = "gBox_individualInfo";
            this.gBox_individualInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gBox_individualInfo.Size = new System.Drawing.Size(350, 320);
            this.gBox_individualInfo.TabIndex = 0;
            this.gBox_individualInfo.TabStop = false;
            this.gBox_individualInfo.Text = "Check for Specific Information";
            // 
            // richBox_console
            // 
            this.richBox_console.Cursor = System.Windows.Forms.Cursors.Default;
            this.richBox_console.Location = new System.Drawing.Point(10, 190);
            this.richBox_console.Name = "richBox_console";
            this.richBox_console.ReadOnly = true;
            this.richBox_console.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richBox_console.Size = new System.Drawing.Size(330, 120);
            this.richBox_console.TabIndex = 1;
            this.richBox_console.Text = "";
            // 
            // textbox_partida
            // 
            this.textbox_partida.Location = new System.Drawing.Point(110, 60);
            this.textbox_partida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_partida.Name = "textbox_partida";
            this.textbox_partida.Size = new System.Drawing.Size(100, 22);
            this.textbox_partida.TabIndex = 2;
            // 
            // textbox_nombre
            // 
            this.textbox_nombre.Location = new System.Drawing.Point(110, 30);
            this.textbox_nombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_nombre.Name = "textbox_nombre";
            this.textbox_nombre.Size = new System.Drawing.Size(100, 22);
            this.textbox_nombre.TabIndex = 1;
            // 
            // command_3
            // 
            this.command_3.AutoSize = true;
            this.command_3.BackColor = System.Drawing.Color.Transparent;
            this.command_3.Location = new System.Drawing.Point(40, 150);
            this.command_3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.command_3.Name = "command_3";
            this.command_3.Size = new System.Drawing.Size(181, 20);
            this.command_3.TabIndex = 3;
            this.command_3.TabStop = true;
            this.command_3.Text = "Check winner of the Match";
            this.command_3.UseVisualStyleBackColor = false;
            // 
            // command_1
            // 
            this.command_1.AutoSize = true;
            this.command_1.BackColor = System.Drawing.Color.Transparent;
            this.command_1.Location = new System.Drawing.Point(40, 100);
            this.command_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.command_1.Name = "command_1";
            this.command_1.Size = new System.Drawing.Size(183, 20);
            this.command_1.TabIndex = 3;
            this.command_1.TabStop = true;
            this.command_1.Text = "Check total Player\'s score";
            this.command_1.UseVisualStyleBackColor = false;
            // 
            // command_2
            // 
            this.command_2.AutoSize = true;
            this.command_2.BackColor = System.Drawing.Color.Transparent;
            this.command_2.Location = new System.Drawing.Point(40, 125);
            this.command_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.command_2.Name = "command_2";
            this.command_2.Size = new System.Drawing.Size(204, 20);
            this.command_2.TabIndex = 3;
            this.command_2.TabStop = true;
            this.command_2.Text = "Check Player\'s scores history";
            this.command_2.UseVisualStyleBackColor = false;
            // 
            // btt_askInfo
            // 
            this.btt_askInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_askInfo.AutoSize = true;
            this.btt_askInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_askInfo.Location = new System.Drawing.Point(287, 140);
            this.btt_askInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btt_askInfo.Name = "btt_askInfo";
            this.btt_askInfo.Size = new System.Drawing.Size(53, 30);
            this.btt_askInfo.TabIndex = 4;
            this.btt_askInfo.Text = "INFO";
            this.btt_askInfo.UseVisualStyleBackColor = true;
            this.btt_askInfo.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // lbl_Game
            // 
            this.lbl_Game.AutoSize = true;
            this.lbl_Game.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Game.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Game.Location = new System.Drawing.Point(40, 60);
            this.lbl_Game.Name = "lbl_Game";
            this.lbl_Game.Size = new System.Drawing.Size(62, 19);
            this.lbl_Game.TabIndex = 1;
            this.lbl_Game.Text = "Match:";
            // 
            // lbl_Jug
            // 
            this.lbl_Jug.AutoSize = true;
            this.lbl_Jug.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Jug.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Jug.Location = new System.Drawing.Point(40, 30);
            this.lbl_Jug.Name = "lbl_Jug";
            this.lbl_Jug.Size = new System.Drawing.Size(64, 19);
            this.lbl_Jug.TabIndex = 0;
            this.lbl_Jug.Text = "Player:";
            // 
            // consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(373, 343);
            this.Controls.Add(this.gBox_individualInfo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "consultas";
            this.Text = "Consultations Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gBox_individualInfo.ResumeLayout(false);
            this.gBox_individualInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBox_individualInfo;
        private System.Windows.Forms.MaskedTextBox textbox_partida;
        private System.Windows.Forms.MaskedTextBox textbox_nombre;
        private System.Windows.Forms.RadioButton command_3;
        private System.Windows.Forms.RadioButton command_1;
        private System.Windows.Forms.RadioButton command_2;
        private System.Windows.Forms.Button btt_askInfo;
        private System.Windows.Forms.Label lbl_Game;
        private System.Windows.Forms.Label lbl_Jug;
        private System.Windows.Forms.RichTextBox richBox_console;
    }
}

