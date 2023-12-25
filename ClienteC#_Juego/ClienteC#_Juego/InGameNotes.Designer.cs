namespace ClienteC__Juego
{
    partial class InGameNotes
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
            this.panel_NotePad = new System.Windows.Forms.Panel();
            this.richtBox_notes = new System.Windows.Forms.RichTextBox();
            this.lbl_write = new System.Windows.Forms.Label();
            this.tBox_write = new System.Windows.Forms.TextBox();
            this.panel_NotePad.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_NotePad
            // 
            this.panel_NotePad.AutoSize = true;
            this.panel_NotePad.BackgroundImage = global::ClienteC__Juego.Properties.Resources.NotePad;
            this.panel_NotePad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_NotePad.Controls.Add(this.richtBox_notes);
            this.panel_NotePad.Controls.Add(this.lbl_write);
            this.panel_NotePad.Controls.Add(this.tBox_write);
            this.panel_NotePad.Location = new System.Drawing.Point(0, 0);
            this.panel_NotePad.Name = "panel_NotePad";
            this.panel_NotePad.Size = new System.Drawing.Size(600, 580);
            this.panel_NotePad.TabIndex = 0;
            // 
            // richtBox_notes
            // 
            this.richtBox_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richtBox_notes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richtBox_notes.Location = new System.Drawing.Point(306, 105);
            this.richtBox_notes.Name = "richtBox_notes";
            this.richtBox_notes.ReadOnly = true;
            this.richtBox_notes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richtBox_notes.Size = new System.Drawing.Size(271, 423);
            this.richtBox_notes.TabIndex = 40;
            this.richtBox_notes.Text = "";
            // 
            // lbl_write
            // 
            this.lbl_write.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_write.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_write.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbl_write.Location = new System.Drawing.Point(303, 531);
            this.lbl_write.Name = "lbl_write";
            this.lbl_write.Size = new System.Drawing.Size(50, 25);
            this.lbl_write.TabIndex = 39;
            this.lbl_write.Text = "Text:";
            this.lbl_write.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBox_write
            // 
            this.tBox_write.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBox_write.Location = new System.Drawing.Point(359, 534);
            this.tBox_write.Name = "tBox_write";
            this.tBox_write.Size = new System.Drawing.Size(218, 22);
            this.tBox_write.TabIndex = 1;
            this.tBox_write.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_write_KeyDown);
            // 
            // InGameNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(640, 602);
            this.Controls.Add(this.panel_NotePad);
            this.MaximizeBox = false;
            this.Name = "InGameNotes";
            this.Text = "InGameNotes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InGameNotes_FormClosing);
            this.Load += new System.EventHandler(this.InGameNotes_Load);
            this.panel_NotePad.ResumeLayout(false);
            this.panel_NotePad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_NotePad;
        private System.Windows.Forms.TextBox tBox_write;
        private System.Windows.Forms.Label lbl_write;
        private System.Windows.Forms.RichTextBox richtBox_notes;
    }
}