using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        String[] Animal = {
                              "ANT",
                              "BIRD",
                              "LION",
                              "ELEPHANT",
                              "GIRAFFE",
                              "KOALA",
                              "SNAKE",
                              "ALLIGATOR",
                              "STINGRAY",
                              "COYOTE"
                              };
        String[] City = {
                            "MALATYA",
                            "ISPARTA",
                            "ISTANBUL",
                            "NEWYORK",
                            "PARIS",
                            "LONDON",
                            "STOCKHOLM",
                            "HELSINKI",
                            "MANCHESTER",
                            "TOKIO"
                            };
        String[] Furnishing = {
                                  "TABLE",
                                  "DESK",
                                  "TELEVISION",
                                  "MATRESS",
                                  "ARMCHAIR",
                                  "CUPBOARD",
                                  "WARDROBE",
                                  "COFFEETABLE",
                                  "CHAIR",
                                  "BED",
                                  "COUCH"
                                  };
        String[] Geek = {
                            "ORC",
                            "JEDI",
                            "SITH",
                            "KLINGON",
                            "KRYPTONITE",
                            "GOTHAM",
                            "TIMETRAVEL",
                            "TARDIS",
                            "GANDALF",
                            "WIZARD"
                            };
        Int32 Life = 10;
        Int32 Hint = 3;
        String word;
        Random r = new Random();
        Char[] charactersOfWord;
        Int32 progress;
        List<Button> buttons = new List<Button>();
        List<Label> labels = new List<Label>();

        public Form1()
        {

            InitializeComponent();
            foreach (Button b in buttons)
            {
                if (b.Text.Length == 1)
                {
                    b.Enabled = false;
                }
                else
                {
                    b.Enabled = true;
                }
                if (b.Text.Equals("END GAME"))
                {
                    b.Enabled = false;
                }
                if (b.Text.Equals("Hint"))
                {
                    b.Enabled = false;
                }
                //Console.WriteLine(b.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            word = Animal[r.Next(0, Animal.Length)];
            charactersOfWord = word.ToCharArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            word = City[r.Next(0, City.Length)];
            charactersOfWord = word.ToCharArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            word = Furnishing[r.Next(0, Furnishing.Length)];
            charactersOfWord = word.ToCharArray();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            word = Geek[r.Next(0, Geek.Length)];
            charactersOfWord = word.ToCharArray();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            /*Label namelabel = new Label();
            namelabel.Location = new Point(13, 13);
            namelabel.Font = new Font(this.Font.Name, 35, FontStyle.Underline);
            namelabel.Text = " ";
            namelabel.AutoSize = true;
            this.Controls.Add(namelabel);
            */
            if (word == null)
            {
                MessageBox.Show("Please select a category!");
            }
            else
            {
                /*
                foreach (Label lbl in labels)
                {
                    lbl.Text = "  ";
                    //lbl.Font = new Font(this.Font.Name, 24, FontStyle.Regular);
                    this.Controls.Remove(lbl);
                } 
                */
                Console.WriteLine(this.Controls.GetType());
                //int x = 14;
                Console.WriteLine(word);
                progress = word.Length;
                addLabel();
                //for (int i = 0; i < progress; i++)
                //{
                    /*
                    Label lbl = new Label();
                    lbl.Location = new Point(x, 250);
                    lbl.Text = "  ";
                    lbl.Font = new Font(this.Font.Name, 24, FontStyle.Underline);
                    lbl.AutoSize = true;
                    labels.Add(lbl);
                    //Console.WriteLine(x);
                    x = x+35;
                     Labels will be dealt here
                     */
                //}
                /*
                foreach (Label lbl in labels)
                {
                    this.Controls.Add(lbl);
                }
                 */

                Life = 10;
                hintLabel();
                //foreach (Button b in this.Controls)
                foreach (Button b in buttons)
                {
                    if (b.Text.Length == 1)
                    {
                        b.Enabled = true;
                    }
                    else
                    {
                        b.Enabled = false;
                    }
                    if (b.Text.Equals("END GAME"))
                    {
                        b.Enabled = true;
                    }
                    if (b.Text.Equals("Hint"))
                    {
                        b.Enabled = true;
                    }
                }
                this.Invalidate();

            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            hintLabel();
            word = null;
            //Console.WriteLine(word);
            foreach (Button b in buttons)
            {
                if (b.Text.Length == 1)
                {
                    b.Enabled = false;
                }
                else
                {
                    b.Enabled = true;
                }
                if (b.Text.Equals("GAME START"))
                {
                    b.Enabled = true;
                }
                if (b.Text.Equals("END GAME"))
                {
                    b.Enabled = false;
                }
                if (b.Text.Equals("Hint"))
                {
                    b.Enabled = false;
                }
            }
            /*
            foreach (Label lbl in labels)
            {
                Console.WriteLine(lbl.Text);
                //lbl.Text = "  ";
                //lbl.Font = new Font(this.Font.Name, 24, FontStyle.Regular);
                //this.Controls.Remove(lbl);
            } 
             * */
            this.Invalidate();
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            if (word.Contains(b.Text))
            {
                int i = 0;
                foreach (var letter in charactersOfWord)
                {
                    if (letter.ToString().Equals(b.Text))
                    {
                        progress = progress - 1;
                        labels[i].Text = letter.ToString();
                        Console.WriteLine(i + " i");
                    }
                    i = i + 1;
                }
            }
            else
            {

                Life = Life - 1;
                Console.WriteLine(Life);
                DrawIt();
            }
                if (Life == 0)
                {
                    word = null;
                    Life = 10;
                    hintLabel();
                    Console.WriteLine("You Lose");
                    /*foreach (Label lbl in labels)
                    {
                        lbl.Text = "  ";
                        this.Controls.Remove(lbl);
                    } */
                    foreach (Button button in buttons)
                    {
                        if (button.Text.Length.Equals(1))
                        {
                            button.Enabled = false;
                        }
                        if (!button.Text.Length.Equals(1))
                        {
                            button.Enabled = true;
                        }
                        if (button.Text.Equals("END GAME"))
                        {
                            button.Enabled = false;
                        }
                        if (button.Text.Equals("Hint"))
                        {
                            button.Enabled = false;
                        }
                    }


                }
                if (progress == 0)
                {
                    Life = 10;
                    word = null;
                    Console.WriteLine("You Win");
                    Hint = Hint + 1;
                    hintLabel();
                    /*foreach (Label lbl in labels)
                    {
                        lbl.Text = "  ";
                        this.Controls.Remove(lbl);
                    } */
                    foreach (Button button in buttons)
                    {
                        if (button.Text.Length.Equals(1))
                        {
                            button.Enabled = false;
                        }
                        if (!button.Text.Length.Equals(1))
                        {
                            button.Enabled = true;
                        }
                        if (button.Text.Equals("END GAME"))
                        {
                            button.Enabled = false;
                        }
                        if (button.Text.Equals("Hint"))
                        {
                            button.Enabled = false;
                        }
                    }
                    Console.WriteLine("Buttons were not active at this point.");

                }
                //Console.WriteLine(b.Text);
            }
        

        private void DrawIt()
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            if (Life == 9)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 85, 190, 210, 190);
            }
            else if (Life == 8)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 148, 190, 148, 50);
            }
            else if (Life == 7)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 148, 50, 198, 50);
            }
            else if (Life == 6)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 198, 50, 198, 70);
            }
            else if (Life == 5)
            {
                graphics.DrawEllipse(System.Drawing.Pens.Black, 188, 70, 20, 20);
            }
            else if (Life == 4)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 198, 90, 198, 130);
            }
            else if (Life == 3)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 198, 95, 183, 115);
            }
            else if (Life == 2)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 198, 95, 213, 115);
            }
            else if (Life == 1)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 198, 130, 183, 170);
            }
            else if (Life == 0)
            {
                graphics.DrawLine(System.Drawing.Pens.Black, 198, 130, 213, 170);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.DoubleBuffered = true;

            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    buttons.Add((Button)item);
                }
            }
            foreach (Button b in buttons)
            {
                if (b.Text.Length == 1)
                {
                    b.Enabled = false;
                }
                else
                {
                    b.Enabled = true;
                }
                if (b.Text.Equals("GAME START"))
                {
                    b.Enabled = true;
                }
                if (b.Text.Equals("END GAME"))
                {
                    b.Enabled = false;
                }
                if (b.Text.Equals("Hint"))
                {
                    b.Enabled = false;
                }
            }
            word = null;
            this.Invalidate();
        }
        private void addLabel() {
            groupBox1.Controls.Clear();
            labels.Clear();
            //int a = charactersOfWord.Length;
            int spaceBetweenLabels = groupBox1.Width / charactersOfWord.Length;
            for (int i = 0; i < charactersOfWord.Length; i++)
            {
                Label label = new Label();
                label.Text = "__";
                label.Location = new Point(10 + i * spaceBetweenLabels, groupBox1.Height - 30);
                label.Parent = groupBox1;
                label.BringToFront();
                labels.Add(label);
            }
        }
        private void hintLabel() { 
            Label hintLabel = new Label();
            this.label1.Text = "Hints Left: " + Hint.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (Hint == 0)
            {
                MessageBox.Show("You have no hints left!");
            }
            else
            {
                Hint = Hint - 1;
                List<Int32> indexArray = new List<Int32>();
                int hintValue;
                int i = 0;
                char letterToBeUnlocked;
                foreach (Label label in labels)
                {
                    if (label.Text.Equals("__"))
                    {
                        indexArray.Add(i);
                    }
                    i = i + 1;
                }
                Random hintIndex = new Random();
                hintValue = indexArray[hintIndex.Next(0, progress)];
                letterToBeUnlocked = charactersOfWord[hintValue];
                foreach (Button button in buttons)
                {
                    if (button.Text.Equals(letterToBeUnlocked.ToString()))
                    {
                        button.PerformClick();
                    }
                } 
            }
            hintLabel();
        }
    }
}


