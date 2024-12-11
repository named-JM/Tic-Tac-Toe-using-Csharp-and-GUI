using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private char currentPlayer = 'X'; // Current player (X or O)
        private Button[] buttons; // Array to hold buttons for easy access
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize buttons array
            buttons = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };

            // Attach click event handler to each button
            foreach (var button in buttons)
            {
                button.Click += Button_Click;
            }

            ResetGame();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button != null && string.IsNullOrEmpty(button.Text))
            {
                // Set the current player's mark
                button.Text = currentPlayer.ToString();

                // Check if the current player won
                if (CheckWin())
                {
                    lblStatus.Text = $"Player {currentPlayer} wins!";
                    DisableButtons();
                }
                else if (IsDraw())
                {
                    lblStatus.Text = "It's a draw!";
                    DisableButtons();
                }
                else
                {
                    // Switch player
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    lblStatus.Text = $"Player {currentPlayer}'s turn";
                }
            }
        }

        private void ResetGame()
        {
            currentPlayer = 'X';
            lblStatus.Text = "Player X's turn";

            foreach (var button in buttons)
            {
                button.Text = string.Empty;
                button.Enabled = true;
            }
        }

        private void DisableButtons()
        {
            foreach (var button in buttons)
            {
                button.Enabled = false;
            }
        }

        private bool CheckWin()
        {
            // Winning combinations
            int[,] winPatterns = new int[,]
            {
                { 0, 1, 2 }, // Row 1
                { 3, 4, 5 }, // Row 2
                { 6, 7, 8 }, // Row 3
                { 0, 3, 6 }, // Column 1
                { 1, 4, 7 }, // Column 2
                { 2, 5, 8 }, // Column 3
                { 0, 4, 8 }, // Diagonal 1
                { 2, 4, 6 }  // Diagonal 2
            };

            for (int i = 0; i < winPatterns.GetLength(0); i++)
            {
                int a = winPatterns[i, 0];
                int b = winPatterns[i, 1];
                int c = winPatterns[i, 2];

                if (!string.IsNullOrEmpty(buttons[a].Text) &&
                    buttons[a].Text == buttons[b].Text &&
                    buttons[a].Text == buttons[c].Text)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsDraw()
        {
            foreach (var button in buttons)
            {
                if (string.IsNullOrEmpty(button.Text))
                {
                    return false;
                }
            }

            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            ResetGame();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
