﻿namespace ClienteC__Juego
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
            this.button_signUp = new System.Windows.Forms.Button();
            this.button_logIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.consoletextbox = new System.Windows.Forms.TextBox();
            this.button_LogOut = new System.Windows.Forms.Button();
            this.lbl_panelControl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDeControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "UserName";
            // 
            // textbox_password
            // 
            this.textbox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_password.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textbox_password.Location = new System.Drawing.Point(177, 77);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(125, 22);
            this.textbox_password.TabIndex = 2;
            // 
            // textbox_username
            // 
            this.textbox_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_username.Location = new System.Drawing.Point(27, 77);
            this.textbox_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(125, 22);
            this.textbox_username.TabIndex = 1;
            // 
            // button_signUp
            // 
            this.button_signUp.AutoSize = true;
            this.button_signUp.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_signUp.Location = new System.Drawing.Point(25, 228);
            this.button_signUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_signUp.Name = "button_signUp";
            this.button_signUp.Size = new System.Drawing.Size(116, 39);
            this.button_signUp.TabIndex = 3;
            this.button_signUp.Text = "Sign Up";
            this.button_signUp.UseVisualStyleBackColor = true;
            this.button_signUp.Click += new System.EventHandler(this.button_signUp_Click);
            // 
            // button_logIn
            // 
            this.button_logIn.AutoSize = true;
            this.button_logIn.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logIn.Location = new System.Drawing.Point(25, 275);
            this.button_logIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_logIn.Name = "button_logIn";
            this.button_logIn.Size = new System.Drawing.Size(101, 39);
            this.button_logIn.TabIndex = 4;
            this.button_logIn.Text = "Log In";
            this.button_logIn.UseVisualStyleBackColor = true;
            this.button_logIn.Click += new System.EventHandler(this.button_logIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Password";
            // 
            // consoletextbox
            // 
            this.consoletextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoletextbox.Location = new System.Drawing.Point(535, 50);
            this.consoletextbox.Margin = new System.Windows.Forms.Padding(4);
            this.consoletextbox.Multiline = true;
            this.consoletextbox.Name = "consoletextbox";
            this.consoletextbox.ReadOnly = true;
            this.consoletextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoletextbox.Size = new System.Drawing.Size(297, 411);
            this.consoletextbox.TabIndex = 6;
            this.consoletextbox.TabStop = false;
            this.consoletextbox.Visible = false;
            // 
            // button_LogOut
            // 
            this.button_LogOut.AutoSize = true;
            this.button_LogOut.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LogOut.Location = new System.Drawing.Point(25, 322);
            this.button_LogOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(116, 39);
            this.button_LogOut.TabIndex = 20;
            this.button_LogOut.Text = "Log Out";
            this.button_LogOut.UseVisualStyleBackColor = true;
            this.button_LogOut.Click += new System.EventHandler(this.button_LogOut_Click);
            // 
            // lbl_panelControl
            // 
            this.lbl_panelControl.AutoSize = true;
            this.lbl_panelControl.Location = new System.Drawing.Point(726, 30);
            this.lbl_panelControl.Name = "lbl_panelControl";
            this.lbl_panelControl.Size = new System.Drawing.Size(87, 16);
            this.lbl_panelControl.TabIndex = 21;
            this.lbl_panelControl.Text = "Control Panel";
            this.lbl_panelControl.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(845, 28);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.panelDeControlToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // panelDeControlToolStripMenuItem
            // 
            this.panelDeControlToolStripMenuItem.Name = "panelDeControlToolStripMenuItem";
            this.panelDeControlToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.panelDeControlToolStripMenuItem.Text = "Panel de Control";
            this.panelDeControlToolStripMenuItem.Click += new System.EventHandler(this.panelDeControlToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.consultasToolStripMenuItem.Text = "Consultas";
            this.consultasToolStripMenuItem.Click += new System.EventHandler(this.consultasToolStripMenuItem_Click);
            // 
            // menuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 474);
            this.Controls.Add(this.lbl_panelControl);
            this.Controls.Add(this.button_LogOut);
            this.Controls.Add(this.consoletextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_signUp);
            this.Controls.Add(this.button_logIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_username);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "menuUsuario";
            this.Text = "menuUsuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menuUsuario_FormClosing);
            this.Load += new System.EventHandler(this.menuUsuario_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.Button button_signUp;
        private System.Windows.Forms.Button button_logIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox consoletextbox;
        private System.Windows.Forms.Button button_LogOut;
        private System.Windows.Forms.Label lbl_panelControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panelDeControlToolStripMenuItem;
    }
}