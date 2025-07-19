using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Number_Project
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int randomNumber;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            randomNumber = random.Next(1, 101);
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            int userGuess;

            if (int.TryParse(txtGuess.Text, out userGuess))
            {
                if (userGuess >=1 && userGuess <= 100)
                {
                    if (userGuess < randomNumber)
                    {
                        lblFeedback.Text = "Too low!";
                    }
                    else if (userGuess > randomNumber)
                    {
                        lblFeedback.Text = "Too high!";
                    }
                    else
                    {
                        lblFeedback.Text = "Correct! Well done!";

                        DialogResult result = MessageBox.Show("Do you want to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            randomNumber = random.Next(1, 101);
                            lblFeedback.Text = "";
                            txtGuess.Clear();
                        }
                    }
                }
                else
                {
                    lblFeedback.Text = "Invalid input. Please enter a valid number.";

                }
                txtGuess.Clear();
                txtGuess.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            if (randomNumber % 2 ==0)
            {
                lblFeedback.Text = "Hint: The number is even.";
            }
            else
            {
                lblFeedback.Text = "Hint: The number is odd.";
            }
            if (randomNumber > 50)
            {
                lblFeedback.Text = "Hint: The number is greater than 50.";
            }
            else
            {
                lblFeedback.Text = "Hint: The number is less than or equal to 50.";
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = "Enter a number between 1 and 100. Use the Guess button to submit your guess.";
        }
    }
}
