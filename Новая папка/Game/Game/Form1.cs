using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private List<PictureBox> pictureBoxList = new List<PictureBox>();
        private Random random = new Random(); // Random number generator
        int x = 30; // Начальная позиция X
        int y = 30;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 16; i++)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(50, 50),
                    Location = new Point(x, y),
                    BackColor = Color.Green,
                    Tag = Rnd() // Assign a random tag
                };

                pictureBox.Click += PictureBox_Click; // Add a click event handler
                x += 60;
                if (i % 4 == 0)
                {
                    x = 30;
                    y += 60;
                }

                pictureBoxList.Add(pictureBox);
                this.Controls.Add(pictureBox);
            }
        }

        private string Rnd()
        {
            // Randomly decide if this PictureBox represents a win or a loss
            int value = random.Next(1, 4); // Random number between 1 and 3
            if (value == 1)
                return "win"; // Represents a winning box
            else
                return "loss"; // Represents a losing box
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null)
            {
                string tag = clickedPictureBox.Tag.ToString();
                if (tag == "win")
                {
                    clickedPictureBox.BackColor = Color.Gold; // Highlight winning boxes
                    
                }
                else
                {
                    clickedPictureBox.BackColor = Color.Red; // Highlight losing boxes
                    MessageBox.Show("LOOOOOSSSSEEER");
                }
            }
        }
    }
}
