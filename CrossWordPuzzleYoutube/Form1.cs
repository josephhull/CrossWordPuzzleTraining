﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CrossWordPuzzleYoutube
{
    public partial class Form1 : Form
    {
        Clues clue_window = new Clues();
        List<id_cells> idc = new List<id_cells>();
        public string puzzle_file = Application.StartupPath + "\\Puzzles\\Puzzle.pzl";

        public Form1()
        {
            buildWordList();
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buildWordList()
        {
            string line = "";
            using(StreamReader s = new StreamReader(puzzle_file))
            {
                line = s.ReadLine(); //ignores first line
                while((line = s.ReadLine()) != null)
                {
                    string [] l = line.Split('|');
                    idc.Add(new id_cells(Int32.Parse(l[0]),Int32.Parse(l[1]),l[2],l[3],l[4],l[5]));
                    clue_window.clue_table.Rows.Add(new string[] { l[3], l[2], l[5] });
                }

            }//end using


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBoard();
            clue_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
            //this gets the location of the board window and puts the clues right next to it
            clue_window.StartPosition = FormStartPosition.Manual;

            clue_window.Show();
            clue_window.clue_table.AutoResizeColumns();
        }

        private void InitializeBoard()
        {
            board.BackgroundColor = Color.Black;
            board.DefaultCellStyle.BackColor = Color.Black;
            //makes everything black


            for (int i = 0; i < 10; i++)
                board.Rows.Add();
            //if i is less than 10, add 1
            //once it becomes greater than 10
            //the loop will stop

            foreach (DataGridViewColumn c in board.Columns)
                c.Width = board.Width / board.Columns.Count;
            //set width columns
            //by dividing width by number of columns
            //this allows specific and angular proportions

            foreach (DataGridViewRow r in board.Rows)
                r.Height = board.Height / board.Rows.Count;
            //set width rows
            //by dividing width by number of rows
            //this allows specific and angular proportions

            for(int row = 0 ; row < board.Rows.Count; row++)
            {
                for(int col = 0; col < board.Columns.Count; col++)
                    board[col, row].ReadOnly = true;
                //make all cells readonly
            }

            foreach(id_cells i in idc)
            {
                int start_col = i.x;
                //column is 'x' as specified on sheet
                int start_row = i.y;
                //row is 'y' as specified on sheet
                char[] word = i.word.ToCharArray();
                //this just puts the word
                //as specified in the sheet
                //into a char array

                for(int j=0; j < word.Length; j++)
                {
                    if(i.direction.ToUpper() == "ACROSS")
                    {
                        formatCell(start_row, start_col + j, word[j].ToString());
                    }
                    if(i.direction.ToUpper() == "DOWN")
                    {
                        formatCell(start_row + j, start_col, word[j].ToString());
                    }
                }

            }

        }

        private void formatCell(int row, int col, String letter)
        {
            DataGridViewCell c = board[col, row];
            c.Style.BackColor = Color.White;
            c.ReadOnly = false;
            c.Style.SelectionBackColor = Color.Cyan;
            c.Tag = letter;
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            clue_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
            //this gets the location of the board window and puts the clues right next to it
        }

        private void board_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //make uppercase always
            try
            {
                board[e.ColumnIndex, e.RowIndex].Value = board[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
            }
            catch { }

            //only 1 letter entered
            try
            {
               if(board[e.ColumnIndex, e.RowIndex].Value.ToString().Length > 1)
                   // if the cell has more than one character in it....
                   board[e.ColumnIndex, e.RowIndex].Value = board[e.ColumnIndex, e.RowIndex].Value.ToString().Substring(0, 1);
                    // then I will make it so only the first letter is entered
            }
            catch { }

            //change color is answer is correct
            try
            {
                if (board[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper().Equals(board[e.ColumnIndex, e.RowIndex].Tag.ToString().ToUpper()))
                    //Imperative to use .ToUpper() when specifying color
                    //It all must be specific and precise!!
                    board[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkGreen;
                else
                     board[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
            }
            catch { }
        }

        private void startPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Puzzle Files|*.pzl";
                //this add security to file
                //it forces only certain files
                if(ofd.ShowDialog().Equals(DialogResult.OK))
                {
                    puzzle_file = ofd.FileName;

                    board.Rows.Clear();
                    clue_window.clue_table.Rows.Clear();
                    idc.Clear();

                    buildWordList();
                    InitializeBoard();                    
                }
        }

        private void board_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            String number = "";

            //foreach(item c in list of items)
            if(idc.Any(c => (number = c.number) != "" && c.x == e.ColumnIndex && c.y == e.RowIndex))
            {
                Rectangle r = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                e.Graphics.FillRectangle(Brushes.White, r);
                Font f = new Font(e.CellStyle.Font.FontFamily, 7);
                e.Graphics.DrawString(number, f, Brushes.Black, r);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Joseph");
        }

        private void howToLoadYourOwnPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To make your own puzzles include .pzl as your extension and follow this format:    x | y | direction | number | word | clue");
        }

        /*private void rewardsSystem(object sender, EventArgs e)
        {
            if()
        }*/
    }

    public class id_cells
    {
        public int x;
        public int y;
        public string direction;
        public string number;
        public string word;
        public string clue;

        public id_cells(int x, int y, string d, string n, string w, string c)
        {
            this.x = x;
            this.y = y;
            this.direction = d;
            this.number = n;
            this.word = w;
            this.clue = c;
        }

    }
    //end of class
}