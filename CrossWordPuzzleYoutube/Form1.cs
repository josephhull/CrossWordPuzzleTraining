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
            UserControl1[] Boxes = new UserControl1[1000];

            InitializeBoard();
            clue_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
            //this gets the location of the board window and puts the clues right next to it
            clue_window.StartPosition = FormStartPosition.Manual;

            clue_window.Show();
            clue_window.clue_table.AutoResizeColumns();

            int MaxX=0, MaxY = 0;


            foreach(id_cells row in idc)
            {
                 if (row.direction.ToLower() == "across")
                 {
                     if (row.x + row.word.Length > MaxX)
                     {
                         MaxX = row.x + row.word.Length;
                     }
                 }
                if (row.direction.ToLower() == "down")
                 {
                     if (row.y + row.word.Length > MaxY)
                     {
                         MaxY = row.y + row.word.Length;
                     }
                 }
            }

            UserControl1 mycontrol = new UserControl1();
            flowLayoutPanel1.Size = new Size(MaxX * mycontrol.Size.Width, MaxY * mycontrol.Size.Height);
             //FLow has now been sized to whatever we needed it to be
            for (int x = 0; x < MaxX * MaxY; x++)
            {
                Boxes[x] = new UserControl1();
                Boxes[x].Parent = flowLayoutPanel1;
                Boxes[x].tbEntry.TextChanged += tbEntry_TextChanged;
            }

             foreach(id_cells row in idc)
             {
                 //set number of label and answer
                 Boxes[row.x + (MaxX* row.y)].lbNumber.Text = row.number;
                 for(int p=0; p < row.word.Length; p++)
                     //p for position
                 {
                     if (row.direction.ToLower() == "across")
                     {
                         Boxes[row.x + p + (MaxX * row.y)].Answer = row.word.Substring(p, 1);
                     }
                     else
                     {
                         Boxes[row.x + (MaxX * (row.y + p))].Answer = row.word.Substring(p, 1);

                     }
                 }
             }

             for (int x = 0; x < MaxX * MaxY; x++)
             {
                 if (Boxes[x].Answer == null)
                 {
                     Boxes[x].panel1.Visible = false;
                     Boxes[x].tbEntry.TabStop = false;
                     Boxes[x].tbEntry.ReadOnly = true;
                 }
                 Boxes[x].tbEntry.Tag = Boxes[x].Answer;
             }
             Form1_LocationChanged(this, null);
        }

         void tbEntry_TextChanged(object sender, EventArgs e)
         {
             TextBox tbwork = (TextBox) sender;
             if (tbwork.Text == (string) tbwork.Tag)
                 tbwork.ForeColor = Color.Green;
             else
                 tbwork.ForeColor = Color.Red;
         }

         private void InitializeBoard()
         {

         }

        
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            clue_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
            //this gets the location of the board window and puts the clues right next to it
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

                    clue_window.clue_table.Rows.Clear();
                    idc.Clear();

                    buildWordList();
                    InitializeBoard();                    
                }
        }

        private void board_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
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
}


//TODO:
 //HAVE FUN WITH THIS