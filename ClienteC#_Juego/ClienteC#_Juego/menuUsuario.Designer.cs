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
            this.button_signUp = new System.Windows.Forms.Button();
            this.button_logIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_controlPanel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notePadEXPERIMENTALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankingsEXPERIMENTALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richBox_Control = new System.Windows.Forms.RichTextBox();
            this.button_signOut = new System.Windows.Forms.Button();
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
            this.textbox_password.Location = new System.Drawing.Point(27, 139);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(125, 22);
            this.textbox_password.TabIndex = 2;
            // 
            // textbox_username
            // 
            this.textbox_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_username.Location = new System.Drawing.Point(27, 78);
            this.textbox_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(125, 22);
            this.textbox_username.TabIndex = 1;
            // 
            // button_signUp
            // 
            this.button_signUp.AutoSize = true;
            this.button_signUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_signUp.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_signUp.Location = new System.Drawing.Point(36, 385);
            this.button_signUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_signUp.Name = "button_signUp";
            this.button_signUp.Size = new System.Drawing.Size(123, 42);
            this.button_signUp.TabIndex = 3;
            this.button_signUp.Text = "Sign Up";
            this.button_signUp.UseVisualStyleBackColor = false;
            this.button_signUp.Click += new System.EventHandler(this.button_signUp_Click);
            // 
            // button_logIn
            // 
            this.button_logIn.AutoSize = true;
            this.button_logIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_logIn.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logIn.Location = new System.Drawing.Point(35, 432);
            this.button_logIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_logIn.Name = "button_logIn";
            this.button_logIn.Size = new System.Drawing.Size(108, 42);
            this.button_logIn.TabIndex = 4;
            this.button_logIn.Text = "Log In";
            this.button_logIn.UseVisualStyleBackColor = false;
            this.button_logIn.Click += new System.EventHandler(this.button_logIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Password";
            // 
            // lbl_controlPanel
            // 
            this.lbl_controlPanel.AutoSize = true;
            this.lbl_controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_controlPanel.Location = new System.Drawing.Point(669, 12);
            this.lbl_controlPanel.Name = "lbl_controlPanel";
            this.lbl_controlPanel.Size = new System.Drawing.Size(87, 16);
            this.lbl_controlPanel.TabIndex = 21;
            this.lbl_controlPanel.Text = "Control Panel";
            this.lbl_controlPanel.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(981, 30);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableroToolStripMenuItem,
            this.notePadEXPERIMENTALToolStripMenuItem,
            this.rankingsEXPERIMENTALToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.controlPanelToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // tableroToolStripMenuItem
            // 
            this.tableroToolStripMenuItem.Name = "tableroToolStripMenuItem";
            this.tableroToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.tableroToolStripMenuItem.Text = "Tablero (EXPERIMENTAL)";
            this.tableroToolStripMenuItem.Click += new System.EventHandler(this.tableroToolStripMenuItem_Click);
            // 
            // notePadEXPERIMENTALToolStripMenuItem
            // 
            this.notePadEXPERIMENTALToolStripMenuItem.Name = "notePadEXPERIMENTALToolStripMenuItem";
            this.notePadEXPERIMENTALToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.notePadEXPERIMENTALToolStripMenuItem.Text = "NotePad (EXPERIMENTAL)";
            this.notePadEXPERIMENTALToolStripMenuItem.Click += new System.EventHandler(this.notePadEXPERIMENTALToolStripMenuItem_Click);
            // 
            // rankingsEXPERIMENTALToolStripMenuItem
            // 
            this.rankingsEXPERIMENTALToolStripMenuItem.Name = "rankingsEXPERIMENTALToolStripMenuItem";
            this.rankingsEXPERIMENTALToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.rankingsEXPERIMENTALToolStripMenuItem.Text = "Rankings (EXPERIMENTAL)";
            this.rankingsEXPERIMENTALToolStripMenuItem.Click += new System.EventHandler(this.rankingsEXPERIMENTALToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.consultasToolStripMenuItem.Text = "Consultas";
            this.consultasToolStripMenuItem.Click += new System.EventHandler(this.consultasToolStripMenuItem_Click);
            // 
            // controlPanelToolStripMenuItem
            // 
            this.controlPanelToolStripMenuItem.Name = "controlPanelToolStripMenuItem";
            this.controlPanelToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.controlPanelToolStripMenuItem.Text = "Control Panel";
            this.controlPanelToolStripMenuItem.Click += new System.EventHandler(this.controlPanelToolStripMenuItem_Click);
            // 
            // richBox_Control
            // 
            this.richBox_Control.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richBox_Control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richBox_Control.ForeColor = System.Drawing.Color.White;
            this.richBox_Control.Location = new System.Drawing.Point(672, 31);
            this.richBox_Control.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richBox_Control.Name = "richBox_Control";
            this.richBox_Control.ReadOnly = true;
            this.richBox_Control.Size = new System.Drawing.Size(297, 532);
            this.richBox_Control.TabIndex = 25;
            this.richBox_Control.Text = "";
            // 
            // button_signOut
            // 
            this.button_signOut.AutoSize = true;
            this.button_signOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_signOut.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_signOut.Location = new System.Drawing.Point(36, 481);
            this.button_signOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_signOut.Name = "button_signOut";
            this.button_signOut.Size = new System.Drawing.Size(131, 42);
            this.button_signOut.TabIndex = 26;
            this.button_signOut.Text = "Sign Out";
            this.button_signOut.UseVisualStyleBackColor = false;
            this.button_signOut.Click += new System.EventHandler(this.button_signOut_Click);
            // 
            // menuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClienteC__Juego.Properties.Resources.fondoCluedoPixeled;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(981, 574);
            this.Controls.Add(this.button_signOut);
            this.Controls.Add(this.richBox_Control);
            this.Controls.Add(this.lbl_controlPanel);
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
        private System.Windows.Forms.Label lbl_controlPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notePadEXPERIMENTALToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richBox_Control;
        private System.Windows.Forms.Button button_signOut;
        private System.Windows.Forms.ToolStripMenuItem rankingsEXPERIMENTALToolStripMenuItem;
    }
}