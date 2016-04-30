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
        String word;
        Random r = new Random();
        Char[] charactersOfWord;
        Int32 progress;
        public Form1()
        {
            InitializeComponent();
            foreach (Button b in this.Controls)
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
                //Console.WriteLine(b.Text);
            }     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            word = Animal[r.Next(0, Animal.Length)];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            word = City[r.Next(0, City.Length)];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            word = Furnishing[r.Next(0, Furnishing.Length)];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            word = Geek[r.Next(0, Geek.Length)];
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (word == null)
            {
                MessageBox.Show("Please select a category!");
            }
            else
            {
                Console.WriteLine(word);
                progress = word.Length;
                foreach (Button b in this.Controls)
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
                }
                charactersOfWord = word.ToCharArray(); 
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(word);
            foreach (Button b in this.Controls)
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
            }
            word = null;
        }

        void btn_Click(object sender, EventArgs e) 
        {
            Button b = (Button)sender;
            b.Enabled = false;
            if (word.Contains(b.Text))
            {
                foreach (var letter in charactersOfWord)
                {
                    if (letter.ToString().Equals(b.Text))
                    {
                        progress = progress - 1;
                        Console.WriteLine(progress);                         
                    }
                }
            }
            else
            {
                Life = Life - 1;
                Console.WriteLine(Life);
            }
            if (Life == 0)
            {
                Console.WriteLine("You Lose");
                foreach (Button button in this.Controls)
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
                }
                word = null;
            }
            if (progress == 0)
            {
                Console.WriteLine("You Win");
                foreach (Button button in this.Controls)
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
                }
                word = null;
            }
            //Console.WriteLine(b.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
