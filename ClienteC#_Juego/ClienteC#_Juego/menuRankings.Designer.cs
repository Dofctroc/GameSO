namespace ClienteC__Juego
{
    partial class menuRankings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btt_IndInfo = new System.Windows.Forms.Button();
            this.btt_Rankings = new System.Windows.Forms.Button();
            this.dGrid_totScore = new System.Windows.Forms.DataGridView();
            this.dGrid_user = new System.Windows.Forms.DataGridView();
            this.btt_Refresh = new System.Windows.Forms.Button();
            this.tBox_username = new System.Windows.Forms.TextBox();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.gBox_Rank = new System.Windows.Forms.GroupBox();
            this.lbl_gamesR = new System.Windows.Forms.Label();
            this.lbl_scoreR = new System.Windows.Forms.Label();
            this.dGrid_totGames = new System.Windows.Forms.DataGridView();
            this.gBox_Ind = new System.Windows.Forms.GroupBox();
            this.tBox_gameID = new System.Windows.Forms.TextBox();
            this.lbl_gameID = new System.Windows.Forms.Label();
            this.dGrid_game = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_totScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_user)).BeginInit();
            this.gBox_Rank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_totGames)).BeginInit();
            this.gBox_Ind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_game)).BeginInit();
            this.SuspendLayout();
            // 
            // btt_IndInfo
            // 
            this.btt_IndInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btt_IndInfo.Location = new System.Drawing.Point(15, 50);
            this.btt_IndInfo.Name = "btt_IndInfo";
            this.btt_IndInfo.Size = new System.Drawing.Size(90, 50);
            this.btt_IndInfo.TabIndex = 0;
            this.btt_IndInfo.Text = "Individual Info";
            this.btt_IndInfo.UseVisualStyleBackColor = true;
            this.btt_IndInfo.Click += new System.EventHandler(this.btt_IndInfo_Click);
            // 
            // btt_Rankings
            // 
            this.btt_Rankings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btt_Rankings.Location = new System.Drawing.Point(15, 111);
            this.btt_Rankings.Name = "btt_Rankings";
            this.btt_Rankings.Size = new System.Drawing.Size(90, 50);
            this.btt_Rankings.TabIndex = 1;
            this.btt_Rankings.Text = "Global rankings";
            this.btt_Rankings.UseVisualStyleBackColor = true;
            this.btt_Rankings.Click += new System.EventHandler(this.btt_Rankings_Click);
            // 
            // dGrid_totScore
            // 
            this.dGrid_totScore.AllowUserToAddRows = false;
            this.dGrid_totScore.AllowUserToDeleteRows = false;
            this.dGrid_totScore.AllowUserToResizeColumns = false;
            this.dGrid_totScore.AllowUserToResizeRows = false;
            this.dGrid_totScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGrid_totScore.DefaultCellStyle = dataGridViewCellStyle5;
            this.dGrid_totScore.Location = new System.Drawing.Point(10, 40);
            this.dGrid_totScore.Name = "dGrid_totScore";
            this.dGrid_totScore.ReadOnly = true;
            this.dGrid_totScore.RowHeadersWidth = 51;
            this.dGrid_totScore.RowTemplate.Height = 24;
            this.dGrid_totScore.Size = new System.Drawing.Size(250, 280);
            this.dGrid_totScore.TabIndex = 2;
            // 
            // dGrid_user
            // 
            this.dGrid_user.AllowUserToAddRows = false;
            this.dGrid_user.AllowUserToDeleteRows = false;
            this.dGrid_user.AllowUserToResizeColumns = false;
            this.dGrid_user.AllowUserToResizeRows = false;
            this.dGrid_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGrid_user.DefaultCellStyle = dataGridViewCellStyle6;
            this.dGrid_user.Location = new System.Drawing.Point(10, 65);
            this.dGrid_user.Name = "dGrid_user";
            this.dGrid_user.ReadOnly = true;
            this.dGrid_user.RowHeadersWidth = 51;
            this.dGrid_user.RowTemplate.Height = 24;
            this.dGrid_user.Size = new System.Drawing.Size(250, 250);
            this.dGrid_user.TabIndex = 3;
            // 
            // btt_Refresh
            // 
            this.btt_Refresh.BackColor = System.Drawing.Color.Wheat;
            this.btt_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btt_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_Refresh.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_Refresh.Location = new System.Drawing.Point(25, 280);
            this.btt_Refresh.Name = "btt_Refresh";
            this.btt_Refresh.Size = new System.Drawing.Size(80, 34);
            this.btt_Refresh.TabIndex = 4;
            this.btt_Refresh.Text = "Refresh";
            this.btt_Refresh.UseVisualStyleBackColor = false;
            this.btt_Refresh.Click += new System.EventHandler(this.btt_Refresh_Click);
            // 
            // tBox_username
            // 
            this.tBox_username.Location = new System.Drawing.Point(59, 37);
            this.tBox_username.Name = "tBox_username";
            this.tBox_username.Size = new System.Drawing.Size(150, 22);
            this.tBox_username.TabIndex = 5;
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Location = new System.Drawing.Point(56, 18);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(157, 16);
            this.lbl_userName.TabIndex = 6;
            this.lbl_userName.Text = "Check user game history:";
            // 
            // gBox_Rank
            // 
            this.gBox_Rank.BackColor = System.Drawing.Color.Tan;
            this.gBox_Rank.Controls.Add(this.lbl_gamesR);
            this.gBox_Rank.Controls.Add(this.lbl_scoreR);
            this.gBox_Rank.Controls.Add(this.dGrid_totGames);
            this.gBox_Rank.Controls.Add(this.dGrid_totScore);
            this.gBox_Rank.Location = new System.Drawing.Point(128, 10);
            this.gBox_Rank.Name = "gBox_Rank";
            this.gBox_Rank.Size = new System.Drawing.Size(530, 330);
            this.gBox_Rank.TabIndex = 7;
            this.gBox_Rank.TabStop = false;
            this.gBox_Rank.Text = "Global Rankings";
            // 
            // lbl_gamesR
            // 
            this.lbl_gamesR.Location = new System.Drawing.Point(270, 20);
            this.lbl_gamesR.Name = "lbl_gamesR";
            this.lbl_gamesR.Size = new System.Drawing.Size(250, 20);
            this.lbl_gamesR.TabIndex = 5;
            this.lbl_gamesR.Text = "TOTAL GAMES PLAYED";
            this.lbl_gamesR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_scoreR
            // 
            this.lbl_scoreR.Location = new System.Drawing.Point(10, 20);
            this.lbl_scoreR.Name = "lbl_scoreR";
            this.lbl_scoreR.Size = new System.Drawing.Size(250, 20);
            this.lbl_scoreR.TabIndex = 4;
            this.lbl_scoreR.Text = "TOTAL SCORE";
            this.lbl_scoreR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dGrid_totGames
            // 
            this.dGrid_totGames.AllowUserToAddRows = false;
            this.dGrid_totGames.AllowUserToDeleteRows = false;
            this.dGrid_totGames.AllowUserToResizeColumns = false;
            this.dGrid_totGames.AllowUserToResizeRows = false;
            this.dGrid_totGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGrid_totGames.DefaultCellStyle = dataGridViewCellStyle7;
            this.dGrid_totGames.Location = new System.Drawing.Point(270, 40);
            this.dGrid_totGames.Name = "dGrid_totGames";
            this.dGrid_totGames.ReadOnly = true;
            this.dGrid_totGames.RowHeadersWidth = 51;
            this.dGrid_totGames.RowTemplate.Height = 24;
            this.dGrid_totGames.Size = new System.Drawing.Size(250, 280);
            this.dGrid_totGames.TabIndex = 3;
            // 
            // gBox_Ind
            // 
            this.gBox_Ind.BackColor = System.Drawing.Color.Tan;
            this.gBox_Ind.Controls.Add(this.tBox_gameID);
            this.gBox_Ind.Controls.Add(this.lbl_gameID);
            this.gBox_Ind.Controls.Add(this.dGrid_game);
            this.gBox_Ind.Controls.Add(this.dGrid_user);
            this.gBox_Ind.Controls.Add(this.tBox_username);
            this.gBox_Ind.Controls.Add(this.lbl_userName);
            this.gBox_Ind.Location = new System.Drawing.Point(200, 10);
            this.gBox_Ind.Name = "gBox_Ind";
            this.gBox_Ind.Size = new System.Drawing.Size(530, 330);
            this.gBox_Ind.TabIndex = 8;
            this.gBox_Ind.TabStop = false;
            this.gBox_Ind.Text = "Individual Info";
            // 
            // tBox_gameID
            // 
            this.tBox_gameID.Location = new System.Drawing.Point(320, 37);
            this.tBox_gameID.Name = "tBox_gameID";
            this.tBox_gameID.Size = new System.Drawing.Size(150, 22);
            this.tBox_gameID.TabIndex = 8;
            // 
            // lbl_gameID
            // 
            this.lbl_gameID.AutoSize = true;
            this.lbl_gameID.Location = new System.Drawing.Point(317, 18);
            this.lbl_gameID.Name = "lbl_gameID";
            this.lbl_gameID.Size = new System.Drawing.Size(140, 16);
            this.lbl_gameID.TabIndex = 9;
            this.lbl_gameID.Text = "Check game statistics:";
            // 
            // dGrid_game
            // 
            this.dGrid_game.AllowUserToAddRows = false;
            this.dGrid_game.AllowUserToDeleteRows = false;
            this.dGrid_game.AllowUserToResizeColumns = false;
            this.dGrid_game.AllowUserToResizeRows = false;
            this.dGrid_game.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGrid_game.DefaultCellStyle = dataGridViewCellStyle8;
            this.dGrid_game.Location = new System.Drawing.Point(270, 65);
            this.dGrid_game.Name = "dGrid_game";
            this.dGrid_game.ReadOnly = true;
            this.dGrid_game.RowHeadersWidth = 51;
            this.dGrid_game.RowTemplate.Height = 24;
            this.dGrid_game.Size = new System.Drawing.Size(250, 250);
            this.dGrid_game.TabIndex = 7;
            // 
            // menuRankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(696, 352);
            this.Controls.Add(this.gBox_Ind);
            this.Controls.Add(this.gBox_Rank);
            this.Controls.Add(this.btt_Refresh);
            this.Controls.Add(this.btt_Rankings);
            this.Controls.Add(this.btt_IndInfo);
            this.MaximizeBox = false;
            this.Name = "menuRankings";
            this.Text = "menuRankings";
            this.Load += new System.EventHandler(this.menuRankings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_totScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_user)).EndInit();
            this.gBox_Rank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_totGames)).EndInit();
            this.gBox_Ind.ResumeLayout(false);
            this.gBox_Ind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_game)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btt_IndInfo;
        private System.Windows.Forms.Button btt_Rankings;
        private System.Windows.Forms.DataGridView dGrid_totScore;
        private System.Windows.Forms.DataGridView dGrid_user;
        private System.Windows.Forms.Button btt_Refresh;
        private System.Windows.Forms.TextBox tBox_username;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.GroupBox gBox_Rank;
        private System.Windows.Forms.GroupBox gBox_Ind;
        private System.Windows.Forms.DataGridView dGrid_totGames;
        private System.Windows.Forms.TextBox tBox_gameID;
        private System.Windows.Forms.Label lbl_gameID;
        private System.Windows.Forms.DataGridView dGrid_game;
        private System.Windows.Forms.Label lbl_gamesR;
        private System.Windows.Forms.Label lbl_scoreR;
    }
}