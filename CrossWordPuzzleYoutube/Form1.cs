using System;
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
            // this is a constructor
            //only fires when instanced
        {
            buildWordList();
            InitializeComponent();
        }

        
        private void buildWordList()
            //this is just a method
        {
            string line = "";
            using(StreamReader s = new StreamReader(puzzle_file))
            {
                line = s.ReadLine(); //ignores first line
                while((line = s.ReadLine()) != null)
                {
                    string [] l = line.Split('|');
                    idc.Add(new id_cells(Int32.Parse(l[0]),Int32.Parse(l[1]),l[2],l[3],l[4],l[5]));
                    //new is instancing id_cells
                    //according to objects construcot
                    clue_window.clue_table.Rows.Add(new string[] { l[3], l[2], l[5] });
                }
                //line is equal to whatever it read

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


            List<UserControl1> APES = new List<UserControl1>();
            //this instances UserControl2 as mylist from here on out
            for (int x = 0; x < 4; x++)
            //x is unimportant as a variable
            //it never gets used again during the loop
            {
                UserControl1 tb1 = new UserControl1();
                //this instances tb as the new UserControl2 reference
                tb1.Parent = flowLayoutPanel1;
                //this says that the UserControl window(s)
                //  will appear on the flowLayoutPanel1
                //we put this in the loop because it will make
                //  each added usercontrol to this parent
                APES.Add(tb1); 
                //this is pretty much just adding a usercontrol
                //  to the flowLayoutPanel parent
            }   //once the loop has ended, we are left with the amount

            
            List<UserControl2> BLANK1 = new List<UserControl2>();
            //this instances UserControl1 as mylist from here on out
            for (int x = 0; x < 4; x++)
            //x is unimportant as a variable
            //it never gets used again during the loop
            {
                UserControl2 tb1 = new UserControl2();
                //this instances tb as the new UserControl1 reference
                tb1.Parent = flowLayoutPanel1;
                //this says that the UserControl window(s)
                //  will appear on the flowLayoutPanel1
                //we put this in the loop because it will make
                //  each added usercontrol to this parent
                BLANK1.Add(tb1);
                //this is pretty much just adding a usercontrol
                //  to the flowLayoutPanel parent
            }

            List<UserControl1> D = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
           {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                D.Add(tb1);
           }

            List<UserControl2> BLANK2 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
           {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK2.Add(tb1);
           }

            List<UserControl1> N = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                N.Add(tb1);
            }

            List<UserControl2> BLANK3 = new List<UserControl2>();
            for (int x = 0; x < 5; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK3.Add(tb1);
            }

            List<UserControl1> FOUR = new List<UserControl1>();
            for (int x = 0; x < 4; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                FOUR.Add(tb1);
            }

            List<UserControl1> DEMETER = new List<UserControl1>();
            for (int x = 0; x < 7; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                DEMETER.Add(tb1);
            }

            List<UserControl2> BLANK4 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK4.Add(tb1);
            }

            List<UserControl1> M = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                M.Add(tb1);
            }

            List<UserControl2> BLANK5 = new List<UserControl2>();
            for (int x = 0; x < 2; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK5.Add(tb1);
            }

            List<UserControl1> Q = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                Q.Add(tb1);
            }

            List<UserControl2> BLANK6 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK6.Add(tb1);
            }

            List<UserControl1> C = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                C.Add(tb1);
            }

            List<UserControl2> BLANK7 = new List<UserControl2>();
            for (int x = 0; x < 2; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK7.Add(tb1);
            }

            List<UserControl1> O = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                O.Add(tb1);
            }

            List<UserControl2> BLANK8 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK8.Add(tb1);
            }

            List<UserControl1> B = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                B.Add(tb1);
            }

            List<UserControl2> BLANK9 = new List<UserControl2>();
            for (int x = 0; x < 2; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK9.Add(tb1);
            }

            List<UserControl1> U = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                U.Add(tb1);
            }

            List<UserControl2> BLANK10 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK10.Add(tb1);
            }

            List<UserControl1> LOOM = new List<UserControl1>();
            for (int x = 0; x < 4; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                LOOM.Add(tb1);
            }

            List<UserControl2> BLANK11 = new List<UserControl2>();
            for (int x = 0; x < 4; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK11.Add(tb1);
            }

            List<UserControl1> A = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                A.Add(tb1);
            }

            List<UserControl2> BLANK12 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK12.Add(tb1);
            }

            List<UserControl1> L = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                L.Add(tb1);
            }

            List<UserControl2> BLANK13 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK13.Add(tb1);
            }

            List<UserControl1> O2 = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                O2.Add(tb1);
            }

            List<UserControl2> BLANK14 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK14.Add(tb1);
            }

            List<UserControl1> LEE = new List<UserControl1>();
            for (int x = 0; x < 3; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                LEE.Add(tb1);
            }

            List<UserControl2> BLANK15 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK15.Add(tb1);
            }

            List<UserControl1> TAP = new List<UserControl1>();
            for (int x = 0; x < 3; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                TAP.Add(tb1);
            }

            List<UserControl2> BLANK16 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK16.Add(tb1);
            }

            List<UserControl1> Z = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                Z.Add(tb1);
            }

            List<UserControl2> BLANK17 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK17.Add(tb1);
            }

            List<UserControl1> E = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                E.Add(tb1);
            }

            List<UserControl2> BLANK18 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK18.Add(tb1);
            }

            List<UserControl1> R = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                R.Add(tb1);
            }

            List<UserControl2> BLANK19 = new List<UserControl2>();
            for (int x = 0; x < 1; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK19.Add(tb1);
            }

            List<UserControl1> INSPECTOR = new List<UserControl1>();
            for (int x = 0; x < 9; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                INSPECTOR.Add(tb1);
            }

            List<UserControl1> NONE = new List<UserControl1>();
            for (int x = 0; x < 4; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                NONE.Add(tb1);
            }

            List<UserControl2> BLANK20 = new List<UserControl2>();
            for (int x = 0; x < 2; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK20.Add(tb1);
            }

            List<UserControl1> U2 = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                U2.Add(tb1);
            }

            List<UserControl2> BLANK21 = new List<UserControl2>();
            for (int x = 0; x < 2; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK21.Add(tb1);
            }

            List<UserControl1> O3 = new List<UserControl1>();
            for (int x = 0; x < 1; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                O3.Add(tb1);
            }

            List<UserControl1> ONE = new List<UserControl1>();
            for (int x = 0; x < 3; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                ONE.Add(tb1);
            }

            List<UserControl2> BLANK22 = new List<UserControl2>();
            for (int x = 0; x < 3; x++)
            {
                UserControl2 tb1 = new UserControl2();
                tb1.Parent = flowLayoutPanel1;
                BLANK22.Add(tb1);
            }

            List<UserControl1> TOUR = new List<UserControl1>();
            for (int x = 0; x < 4; x++)
            {
                UserControl1 tb1 = new UserControl1();
                tb1.Parent = flowLayoutPanel1;
                TOUR.Add(tb1);
            }

            //TODO: Make rows and columns
            //      Make rows and columns only have 10
            //      Make numbers on specific ones
            //      Get familiar with user controls
           
            //HOWTO:
            //      Copy paste list<usercontrol> stuff and add to suffix # on mylist
            //      Count how many rows need to be
            //      UserControl1  =  blank
            //      UserControl2  =  black
            //      UserControln  =  whatever number you want, just add to UserControl
            
            

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
                //intialization
                //test, comparision
                //increment
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
            //.Tag is...
            //hidden text that you can use on string object
            //use it for hidden stuff you can hidden
            //user never sees it
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
                    //this is lambda
            {

                Rectangle r = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                e.Graphics.FillRectangle(Brushes.White, r);
                Font f = new Font(e.CellStyle.Font.FontFamily, 7);
                e.Graphics.DrawString(number, f, Brushes.Black, r);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Joseph");
        }

        private void howToLoadYourOwnPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
            // e is just the EventArgs (Event Arguments) instanced
        {
            MessageBox.Show("To make your own puzzles include .pzl as your extension and follow this format:\n x | y | direction | number | word | clue");
        }

        /*private void rewardsSystem(object sender, EventArgs e)
        {
            if()
         * //if all color is darkgreen and not black, then success
        }*/

        public System.Drawing.Size x { get; set; }
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
