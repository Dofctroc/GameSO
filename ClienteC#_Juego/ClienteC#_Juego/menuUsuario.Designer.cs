namespace ClienteC__Juego
{
    partial class menuUsuario
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
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.button_listausuarios = new System.Windows.Forms.Button();
            this.button_signUp = new System.Windows.Forms.Button();
            this.button_logIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.consoletextbox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(32, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "UserName";
            // 
            // textbox_password
            // 
            this.textbox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_password.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textbox_password.Location = new System.Drawing.Point(54, 102);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(130, 20);
            this.textbox_password.TabIndex = 11;
            // 
            // textbox_username
            // 
            this.textbox_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_username.Location = new System.Drawing.Point(54, 47);
            this.textbox_username.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(130, 20);
            this.textbox_username.TabIndex = 10;
            this.textbox_username.TextChanged += new System.EventHandler(this.textbox_username_TextChanged);
            // 
            // button_listausuarios
            // 
            this.button_listausuarios.AutoSize = true;
            this.button_listausuarios.Location = new System.Drawing.Point(75, 295);
            this.button_listausuarios.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_listausuarios.Name = "button_listausuarios";
            this.button_listausuarios.Size = new System.Drawing.Size(83, 23);
            this.button_listausuarios.TabIndex = 16;
            this.button_listausuarios.Text = "Lista usuarios";
            this.button_listausuarios.UseVisualStyleBackColor = true;
            // 
            // button_signUp
            // 
            this.button_signUp.AutoSize = true;
            this.button_signUp.Location = new System.Drawing.Point(53, 266);
            this.button_signUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_signUp.Name = "button_signUp";
            this.button_signUp.Size = new System.Drawing.Size(56, 23);
            this.button_signUp.TabIndex = 15;
            this.button_signUp.Text = "Sign Up";
            this.button_signUp.UseVisualStyleBackColor = true;
            this.button_signUp.Click += new System.EventHandler(this.button_signUp_Click);
            // 
            // button_logIn
            // 
            this.button_logIn.AutoSize = true;
            this.button_logIn.Location = new System.Drawing.Point(120, 266);
            this.button_logIn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_logIn.Name = "button_logIn";
            this.button_logIn.Size = new System.Drawing.Size(56, 23);
            this.button_logIn.TabIndex = 14;
            this.button_logIn.Text = "Log In";
            this.button_logIn.UseVisualStyleBackColor = true;
            this.button_logIn.Click += new System.EventHandler(this.button_logIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(32, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Password";
            // 
            // consoletextbox
            // 
            this.consoletextbox.Location = new System.Drawing.Point(12, 155);
            this.consoletextbox.Multiline = true;
            this.consoletextbox.Name = "consoletextbox";
            this.consoletextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoletextbox.Size = new System.Drawing.Size(218, 85);
            this.consoletextbox.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(306, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(345, 265);
            this.dataGridView1.TabIndex = 19;
            // 
            // menuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 397);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.consoletextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_listausuarios);
            this.Controls.Add(this.button_signUp);
            this.Controls.Add(this.button_logIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_username);
            this.Name = "menuUsuario";
            this.Text = "menuUsuario";
            this.Load += new System.EventHandler(this.menuUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.Button button_listausuarios;
        private System.Windows.Forms.Button button_signUp;
        private System.Windows.Forms.Button button_logIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox consoletextbox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}