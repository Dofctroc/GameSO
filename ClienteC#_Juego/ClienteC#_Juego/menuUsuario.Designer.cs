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
            this.dataGrid_listaUsuarios = new System.Windows.Forms.DataGridView();
            this.button_LogOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_listaUsuarios = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "UserName";
            // 
            // textbox_password
            // 
            this.textbox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_password.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textbox_password.Location = new System.Drawing.Point(177, 50);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(125, 22);
            this.textbox_password.TabIndex = 2;
            // 
            // textbox_username
            // 
            this.textbox_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_username.Location = new System.Drawing.Point(26, 50);
            this.textbox_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(125, 22);
            this.textbox_username.TabIndex = 1;
            // 
            // button_listausuarios
            // 
            this.button_listausuarios.AutoSize = true;
            this.button_listausuarios.Location = new System.Drawing.Point(103, 358);
            this.button_listausuarios.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_listausuarios.Name = "button_listausuarios";
            this.button_listausuarios.Size = new System.Drawing.Size(111, 28);
            this.button_listausuarios.TabIndex = 5;
            this.button_listausuarios.Text = "Lista usuarios";
            this.button_listausuarios.UseVisualStyleBackColor = true;
            this.button_listausuarios.Click += new System.EventHandler(this.button_listausuarios_Click);
            // 
            // button_signUp
            // 
            this.button_signUp.AutoSize = true;
            this.button_signUp.Location = new System.Drawing.Point(34, 322);
            this.button_signUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_signUp.Name = "button_signUp";
            this.button_signUp.Size = new System.Drawing.Size(75, 28);
            this.button_signUp.TabIndex = 3;
            this.button_signUp.Text = "Sign Up";
            this.button_signUp.UseVisualStyleBackColor = true;
            this.button_signUp.Click += new System.EventHandler(this.button_signUp_Click);
            // 
            // button_logIn
            // 
            this.button_logIn.AutoSize = true;
            this.button_logIn.Location = new System.Drawing.Point(123, 322);
            this.button_logIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_logIn.Name = "button_logIn";
            this.button_logIn.Size = new System.Drawing.Size(75, 28);
            this.button_logIn.TabIndex = 4;
            this.button_logIn.Text = "Log In";
            this.button_logIn.UseVisualStyleBackColor = true;
            this.button_logIn.Click += new System.EventHandler(this.button_logIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Password";
            // 
            // consoletextbox
            // 
            this.consoletextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoletextbox.Location = new System.Drawing.Point(26, 124);
            this.consoletextbox.Margin = new System.Windows.Forms.Padding(4);
            this.consoletextbox.Multiline = true;
            this.consoletextbox.Name = "consoletextbox";
            this.consoletextbox.ReadOnly = true;
            this.consoletextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoletextbox.Size = new System.Drawing.Size(297, 163);
            this.consoletextbox.TabIndex = 6;
            this.consoletextbox.TabStop = false;
            // 
            // dataGrid_listaUsuarios
            // 
            this.dataGrid_listaUsuarios.AllowUserToAddRows = false;
            this.dataGrid_listaUsuarios.AllowUserToDeleteRows = false;
            this.dataGrid_listaUsuarios.AllowUserToResizeColumns = false;
            this.dataGrid_listaUsuarios.AllowUserToResizeRows = false;
            this.dataGrid_listaUsuarios.ColumnHeadersHeight = 25;
            this.dataGrid_listaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid_listaUsuarios.Location = new System.Drawing.Point(400, 50);
            this.dataGrid_listaUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_listaUsuarios.Name = "dataGrid_listaUsuarios";
            this.dataGrid_listaUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGrid_listaUsuarios.RowHeadersVisible = false;
            this.dataGrid_listaUsuarios.RowHeadersWidth = 50;
            this.dataGrid_listaUsuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid_listaUsuarios.Size = new System.Drawing.Size(400, 336);
            this.dataGrid_listaUsuarios.TabIndex = 19;
            this.dataGrid_listaUsuarios.Visible = false;
            // 
            // button_LogOut
            // 
            this.button_LogOut.AutoSize = true;
            this.button_LogOut.Location = new System.Drawing.Point(212, 322);
            this.button_LogOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(75, 28);
            this.button_LogOut.TabIndex = 20;
            this.button_LogOut.Text = "Log Out";
            this.button_LogOut.UseVisualStyleBackColor = true;
            this.button_LogOut.Click += new System.EventHandler(this.button_LogOut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Control Panel";
            // 
            // label_listaUsuarios
            // 
            this.label_listaUsuarios.AutoSize = true;
            this.label_listaUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_listaUsuarios.Location = new System.Drawing.Point(404, 25);
            this.label_listaUsuarios.Name = "label_listaUsuarios";
            this.label_listaUsuarios.Size = new System.Drawing.Size(118, 20);
            this.label_listaUsuarios.TabIndex = 22;
            this.label_listaUsuarios.Text = "Lista Usuarios";
            this.label_listaUsuarios.Visible = false;
            // 
            // menuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 413);
            this.Controls.Add(this.label_listaUsuarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_LogOut);
            this.Controls.Add(this.dataGrid_listaUsuarios);
            this.Controls.Add(this.consoletextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_listausuarios);
            this.Controls.Add(this.button_signUp);
            this.Controls.Add(this.button_logIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_username);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "menuUsuario";
            this.Text = "menuUsuario";
            this.Load += new System.EventHandler(this.menuUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listaUsuarios)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGrid_listaUsuarios;
        private System.Windows.Forms.Button button_LogOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_listaUsuarios;
    }
}