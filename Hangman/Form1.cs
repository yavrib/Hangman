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
        //Words in category arrays
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

        //Initialize global scope variables
        Int32 Life = 10;
        Int32 Hint = 3;
        String word;
        Random r = new Random();
        Char[] charactersOfWord;
        Int32 progress;     //A variable to track progress
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

            }
        }

        //Category selection buttons
        private void button1_Click(object sender, EventArgs e)
        {
            word = Animal[r.Next(0, Animal.Length)];    //Getting random word from specific category array 
            charactersOfWord = word.ToCharArray();  // Disintegrate every char in selected word to compare pushed button later
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


        //Buttons visibility settings after Game Start Button triggered
        private void button5_Click(object sender, EventArgs e)
        {

            if (word == null)
            {
                MessageBox.Show("Please select a category!");
            }
            else
            {
                progress = word.Length; //Progress setted word length to keep track of game
                addLabel();
                Life = 10;  //Initialize life tracker variable
                hintLabel();    //Initialize hint label

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


        //Game button visibilty settings after end-game
        private void button6_Click(object sender, EventArgs e)
        {
            hintLabel();
            word = null;
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
            this.Invalidate();
        }

        //Game core mechanics starts here 
        void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender; //Button listener
            b.Enabled = false;  //Disable button after pressed 
            if (word.Contains(b.Text))  //Condition if selected word contains pressed char
            {
                int i = 0;
                foreach (var letter in charactersOfWord)    //This loop check every char in array to get and add this char to labels list.
                {
                    if (letter.ToString().Equals(b.Text))
                    {
                        progress = progress - 1;    
                        labels[i].Text = letter.ToString(); //Pressed letter goes to label list to print screen with exact index number
                    }
                    i = i + 1;
                }
            }
            else
            {
                Life = Life - 1;
                DrawIt();   //Drawing one more stick to visualize hangman
            }

            //Player lose situation
            if (Life == 0)
            {
                //Core variables which held game mechanichs are reset
                word = null;
                Life = 10;
                hintLabel();
                MessageBox.Show("You Lose!");

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

            //Player win situation
            if (progress == 0)
            {
                Life = 10;
                word = null;
                Hint = Hint + 1;
                hintLabel();
                MessageBox.Show("You Win!");
               
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
        }

        //Hangman visuals goes here
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

            this.DoubleBuffered = true; //To handle flickering problems we use this property.

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
        //Add labels to screen
        private void addLabel()
        {
            groupBox1.Controls.Clear();
            labels.Clear();
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
        //Shows how many hint left
        private void hintLabel()
        {
            Label hintLabel = new Label();
            this.label1.Text = "Hints Left: " + Hint.ToString();
        }

        //Hint button mechanics
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


