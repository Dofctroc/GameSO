using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClienteC__Juego
{
    public partial class InGameNotes : Form
    {
        int partidaNum;

        string txtGrid;   // File name where normal grid status is saved
        string txtGrid2;   // File name where names grid status is saved
        string txtBox;   // File name where written text is saved

        int rows, cols, rows2, cols2, marginCols, marginRows, marginCols2, marginRows2;     // Variables involving the
        int tileWidth, tileHeight, tileWidth2, tileHeight2;                                 // creation of the grids
        string[] notepadSaveInfoGrid, notepadSaveInfoGrid2;     // Variables where info is saved or loaded
        string[,] notepadReadInfo, notepadReadInfo2;            // from the datafiles where grid status is saved
        bool emptyDataFile, emptyDataFile2;     // Booleans that determine if the read datafile is empty or not

        PictureBox[,] grid, gridNames;         // Picture Box grids 

        public InGameNotes(int partidaNum)
        {
            InitializeComponent();
            this.partidaNum = partidaNum;
        }

        private void InGameNotes_Load(object sender, EventArgs e)
        {
            txtGrid = AppDomain.CurrentDomain.BaseDirectory + @"\notepad_tiles_" + partidaNum + ".txt";     // File name where normal grid status is saved
            txtGrid2 = AppDomain.CurrentDomain.BaseDirectory + @"\notepad_names_" + partidaNum + ".txt";   // File name where names grid status is saved
            txtBox = AppDomain.CurrentDomain.BaseDirectory + @"\NotePad_notes_" + partidaNum + ".txt";       // File name where written text is saved

            panel_NotePad.Size = new Size(600, 580);

            rows = 21; cols = 8;
            tileWidth = 20; tileHeight = 20;
            marginCols = 6 * tileWidth;
            marginRows = 3 * tileHeight;

            rows2 = 21; cols2 = 1;
            tileWidth2 = 5 * 20; tileHeight2 = 20;
            marginCols2 = 1 * tileWidth;
            marginRows2 = 3 * tileHeight;

            LoadNotepadState();

            gridNames = new PictureBox[rows2, cols2];
            Point initialPos2 = new Point(marginCols2, marginRows2);

            for (int row = 0; row < rows2; row++)
            {
                if (row == 6)
                    initialPos2 = new Point(marginCols2, marginRows2 + 2 * tileHeight);
                if (row == 12)
                    initialPos2 = new Point(marginCols2, marginRows2 + 4 * tileHeight);

                gridNames[row, 0] = new PictureBox();
                gridNames[row, 0].Location = new Point(initialPos2.X, initialPos2.Y + row * tileHeight);
                gridNames[row, 0].Size = new Size(tileWidth2, tileHeight2);
                gridNames[row, 0].BorderStyle = BorderStyle.None;
                gridNames[row, 0].BackColor = Color.Transparent;
                if (emptyDataFile2)
                    gridNames[row, 0].Tag = "UnCrossed";
                else
                {
                    gridNames[row, 0].Tag = notepadReadInfo2[row, 0];
                    UpdateTileImage(gridNames[row, 0]);
                }
                gridNames[row, 0].BackgroundImageLayout = ImageLayout.Stretch;
                gridNames[row, 0].MouseEnter += Tile_mouseEnter;
                gridNames[row, 0].MouseLeave += Tile_mouseLeave;
                gridNames[row, 0].MouseClick += Tile_mouseClick;
                panel_NotePad.Controls.Add(gridNames[row, 0]);
            }

            grid = new PictureBox[rows, cols];
            Point initialPos = new Point(marginCols, marginRows);

            for (int row = 0; row < rows; row++)
            {
                if (row == 6)
                    initialPos = new Point(marginCols, marginRows + 2 * tileHeight);
                if (row == 12)
                    initialPos = new Point(marginCols, marginRows + 4 * tileHeight);

                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = new PictureBox();
                    grid[row, col].Location = new Point(initialPos.X + col * tileWidth, initialPos.Y + row * tileHeight);
                    grid[row, col].Size = new Size(tileWidth, tileHeight);
                    grid[row, col].BorderStyle = BorderStyle.None;
                    grid[row, col].BackColor = Color.Transparent;
                    if (emptyDataFile)
                        grid[row, col].Tag = "Empty";
                    else
                    {
                        grid[row, col].Tag = notepadReadInfo[row, col];
                        UpdateTileImage(grid[row, col]);
                    }
                    grid[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    grid[row, col].MouseEnter += Tile_mouseEnter;
                    grid[row, col].MouseLeave += Tile_mouseLeave;
                    grid[row, col].MouseClick += Tile_mouseClick;
                    panel_NotePad.Controls.Add(grid[row, col]);
                }
            }

            // Codigo para ubicar todos los elementos dentro del formulario
            lbl_write.Height = tBox_write.Height;
            lbl_write.Width = 42;
            tBox_write.Width = 11 * tileWidth;
            richtBox_notes.Size = new Size(14 * tileWidth - 10, 21 * tileHeight + 5);
            richtBox_notes.Location = new Point(15 * tileWidth + 5, 5 * tileHeight + 5);
            lbl_write.Location = new Point(15 * tileWidth + 5, 27 * tileHeight - 5);
            tBox_write.Location = new Point(lbl_write.Location.X + lbl_write.Width + 5, lbl_write.Location.Y);
        }

        private void InGameNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNotepadState();
        }

        // ----------------------- BEHAVIOUR OF GRID TILES ------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------------

        private void Tile_mouseEnter(object sender, EventArgs e)
        {
            PictureBox hoveredPBox = (PictureBox)sender;
            hoveredPBox.BackColor = Color.FromArgb(100, Color.Green);
        }

        private void Tile_mouseLeave(object sender, EventArgs e)
        {
            PictureBox hoveredPBox = (PictureBox)sender;
            hoveredPBox.BackColor = Color.Transparent;
        }

        private void Tile_mouseClick(object sender, EventArgs e)
        {
            PictureBox hoveredPBox = (PictureBox)sender;

            if (hoveredPBox.Tag.ToString() == "Empty")
                hoveredPBox.Tag = "Cross";
            else if (hoveredPBox.Tag.ToString() == "Cross")
                hoveredPBox.Tag = "Tick";
            else if (hoveredPBox.Tag.ToString() == "Tick")
                hoveredPBox.Tag = "Interr";
            else if (hoveredPBox.Tag.ToString() == "Interr")
                hoveredPBox.Tag = "Exclam";
            else if (hoveredPBox.Tag.ToString() == "Exclam")
                hoveredPBox.Tag = "Empty";

            else if (hoveredPBox.Tag.ToString() == "UnCrossed")
                hoveredPBox.Tag = "Crossed";
            else if (hoveredPBox.Tag.ToString() == "Crossed")
                hoveredPBox.Tag = "UnCrossed";

            UpdateTileImage(hoveredPBox);
        }

        private void UpdateTileImage(PictureBox PBox)
        {
            if (PBox.Tag.ToString() == "Empty")
                PBox.BackgroundImage = null;
            else if (PBox.Tag.ToString() == "Cross")
                PBox.BackgroundImage = Properties.Resources.Cross;
            else if (PBox.Tag.ToString() == "Tick")
                PBox.BackgroundImage = Properties.Resources.Tick;
            else if (PBox.Tag.ToString() == "Interr")
                PBox.BackgroundImage = Properties.Resources.Interr;
            else if (PBox.Tag.ToString() == "Exclam")
                PBox.BackgroundImage = Properties.Resources.Exclam;

            else if (PBox.Tag.ToString() == "UnCrossed")
                PBox.BackgroundImage = null;
            else if (PBox.Tag.ToString() == "Crossed")
                PBox.BackgroundImage = Properties.Resources.Crossed;
        }

        // --------------------- Load and save modifications ------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------------------

        private void SaveNotepadState()
        {
            notepadSaveInfoGrid = new string[rows];
            notepadSaveInfoGrid2 = new string[rows];

            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    notepadSaveInfoGrid[row] = notepadSaveInfoGrid[row] + grid[row, col].Tag.ToString() + "/";

            for (int row = 0; row < rows; row++)
                    notepadSaveInfoGrid2[row] = notepadSaveInfoGrid2[row] + gridNames[row, 0].Tag.ToString();

            try
            {
                // Append the lines to the file
                File.WriteAllLines(txtGrid, notepadSaveInfoGrid);
                File.WriteAllLines(txtGrid2, notepadSaveInfoGrid2);
                File.WriteAllText(txtBox, richtBox_notes.Text);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during file writing
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNotepadState()
        {
            notepadReadInfo = new string[rows, cols];
            notepadReadInfo2 = new string[rows, 1];
            richtBox_notes.SelectionFont = new Font("Calibri", 10, FontStyle.Regular);
            richtBox_notes.SelectionColor = Color.Black;

            // Load all data from the grid
            try
            {
                string[] lines1 = File.ReadAllLines(txtGrid);
                if (lines1.Length > 0) 
                {
                    int n = 0;
                    foreach (string line in lines1) {
                        string[] vectorLine = line.Split('/');
                        for (int col = 0; col < cols; col++)
                            notepadReadInfo[n, col] = vectorLine[col];
                        n++;
                    }
                    emptyDataFile = false;
                }
                else
                    emptyDataFile = true;

                string[] lines2 = File.ReadAllLines(txtGrid2);
                if (lines2.Length > 0)
                {
                    int n = 0;
                    foreach (string line in lines2) {
                        notepadReadInfo2[n, 0] = line;
                        n++;
                    }
                    emptyDataFile2 = false;
                }
                else
                    emptyDataFile2 = true;


                string[] lines3 = File.ReadAllLines(txtBox);

                foreach (string line in lines3)
                {
                    richtBox_notes.AppendText(line);
                    richtBox_notes.AppendText(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during file reading
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------ OTHER FUNCTIONALITIES ------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------


        private void tBox_write_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string text = tBox_write.Text;
                if (text != "")
                {
                    e.SuppressKeyPress = true;
                    richtBox_notes.SelectionFont = new Font("Calibri", 10, FontStyle.Regular);
                    richtBox_notes.SelectionColor = Color.Black;
                    richtBox_notes.AppendText(text);
                    richtBox_notes.AppendText(Environment.NewLine);
                    tBox_write.Clear();
                }
                else
                {
                    e.SuppressKeyPress = true;
                    tBox_write.Clear();
                }
            }
        }
    }
}
