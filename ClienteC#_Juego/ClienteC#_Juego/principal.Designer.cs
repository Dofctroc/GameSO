namespace ClienteC__Juego
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
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(368, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario Solicitud";
            // 
            // textbox_partida
            // 
            this.textbox_partida.Location = new System.Drawing.Point(129, 63);
            this.textbox_partida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_partida.Name = "textbox_partida";
            this.textbox_partida.Size = new System.Drawing.Size(100, 22);
            this.textbox_partida.TabIndex = 2;
            // 
            // textbox_nombre
            // 
            this.textbox_nombre.Location = new System.Drawing.Point(129, 36);
            this.textbox_nombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_nombre.Name = "textbox_nombre";
            this.textbox_nombre.Size = new System.Drawing.Size(100, 22);
            this.textbox_nombre.TabIndex = 1;
            // 
            // command_3
            // 
            this.command_3.AutoSize = true;
            this.command_3.Location = new System.Drawing.Point(24, 161);
            this.command_3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.command_3.Name = "command_3";
            this.command_3.Size = new System.Drawing.Size(192, 20);
            this.command_3.TabIndex = 3;
            this.command_3.TabStop = true;
            this.command_3.Text = "Dime ganador de la partida";
            this.command_3.UseVisualStyleBackColor = true;
            // 
            // command_1
            // 
            this.command_1.AutoSize = true;
            this.command_1.Location = new System.Drawing.Point(24, 111);
            this.command_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.command_1.Name = "command_1";
            this.command_1.Size = new System.Drawing.Size(227, 20);
            this.command_1.TabIndex = 3;
            this.command_1.TabStop = true;
            this.command_1.Text = "Dime puntuacion total del jugador";
            this.command_1.UseVisualStyleBackColor = true;
            // 
            // command_2
            // 
            this.command_2.AutoSize = true;
            this.command_2.Location = new System.Drawing.Point(24, 135);
            this.command_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.command_2.Name = "command_2";
            this.command_2.Size = new System.Drawing.Size(308, 20);
            this.command_2.TabIndex = 3;
            this.command_2.TabStop = true;
            this.command_2.Text = "Dime puntuacion en las partidas que ha jugado";
            this.command_2.UseVisualStyleBackColor = true;
            // 
            // button_enviar
            // 
            this.button_enviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_enviar.AutoSize = true;
            this.button_enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_enviar.Location = new System.Drawing.Point(269, 184);
            this.button_enviar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(95, 37);
            this.button_enviar.TabIndex = 4;
            this.button_enviar.Text = "Solicitar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Partida:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(13, 243);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleTextBox.Size = new System.Drawing.Size(250, 86);
            this.consoleTextBox.TabIndex = 12;
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 343);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "principal";
            this.Text = "Pagina Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox consoleTextBox;
    }
}

