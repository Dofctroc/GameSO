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
            this.dataGrid_listaUsuarios = new System.Windows.Forms.DataGridView();
            this.button_partidanueva = new System.Windows.Forms.Button();
            this.button_LogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_listaUsuarios
            // 
            this.dataGrid_listaUsuarios.AllowUserToAddRows = false;
            this.dataGrid_listaUsuarios.AllowUserToDeleteRows = false;
            this.dataGrid_listaUsuarios.AllowUserToResizeColumns = false;
            this.dataGrid_listaUsuarios.AllowUserToResizeRows = false;
            this.dataGrid_listaUsuarios.ColumnHeadersHeight = 25;
            this.dataGrid_listaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid_listaUsuarios.Location = new System.Drawing.Point(312, 14);
            this.dataGrid_listaUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid_listaUsuarios.Name = "dataGrid_listaUsuarios";
            this.dataGrid_listaUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGrid_listaUsuarios.RowHeadersVisible = false;
            this.dataGrid_listaUsuarios.RowHeadersWidth = 50;
            this.dataGrid_listaUsuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid_listaUsuarios.Size = new System.Drawing.Size(450, 420);
            this.dataGrid_listaUsuarios.TabIndex = 20;
            this.dataGrid_listaUsuarios.Visible = false;
            // 
            // button_partidanueva
            // 
            this.button_partidanueva.AutoSize = true;
            this.button_partidanueva.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_partidanueva.Location = new System.Drawing.Point(40, 149);
            this.button_partidanueva.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_partidanueva.Name = "button_partidanueva";
            this.button_partidanueva.Size = new System.Drawing.Size(215, 44);
            this.button_partidanueva.TabIndex = 21;
            this.button_partidanueva.Text = "Partida Nueva";
            this.button_partidanueva.UseVisualStyleBackColor = true;
            // 
            // button_LogOut
            // 
            this.button_LogOut.AutoSize = true;
            this.button_LogOut.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LogOut.Location = new System.Drawing.Point(40, 381);
            this.button_LogOut.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(131, 44);
            this.button_LogOut.TabIndex = 22;
            this.button_LogOut.Text = "Log Out";
            this.button_LogOut.UseVisualStyleBackColor = true;
            this.button_LogOut.Click += new System.EventHandler(this.button_LogOut_Click);
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_LogOut);
            this.Controls.Add(this.button_partidanueva);
            this.Controls.Add(this.dataGrid_listaUsuarios);
            this.Name = "principal";
            this.Text = "principal";
            this.Load += new System.EventHandler(this.principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_listaUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_listaUsuarios;
        private System.Windows.Forms.Button button_partidanueva;
        private System.Windows.Forms.Button button_LogOut;
    }
}