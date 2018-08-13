using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TicTacToe_Minimax
{
    public partial class Form1 : Form
    {
        Board board;
        int depth; //will be input
        int playerScore = 0;
        int computerScore = 0;
        int computerPlayIndex = 0;
        bool turn = true;
        public List<Button> buttons;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Board();
            buttons = new List<Button>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            for (int i = 2; i < 9; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = 2;
            depth = (int)comboBox1.SelectedItem;
        }
        private void gameLoop(int x, int y)
        {
            if (!board.isGameOver())
            {
                board.move(x * 3 + y);

                Minimax_AlphaBeta alphaBeta = new Minimax_AlphaBeta(depth);

                alphaBeta.alphaBetaPruning(board, Board.State.O, 0, int.MinValue, int.MaxValue);
                moveOnBoard(board);
                //checkTheWinner();
                board.debug();
                if (board.isGameOver())
                    checkTheWinner();
            }
            else
            {
                checkTheWinner();
            }
        }
        private void mouseClick(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            label1.Text = "";
            //ex. button1, index which s 1 needed
            string buttonNumber = button.Name.Substring(button.Name.Length - 1);
            int x = (Int32.Parse(buttonNumber) - 1) / 3;
            int y = (Int32.Parse(buttonNumber) - 1) % 3;
            button.Text = "X";
            button.Enabled = false;
            button.BackColor = Color.BlueViolet;
            gameLoop(x, y);
        }
        private void moveOnBoard(Board board)
        {
            List<int> oStates = board.oStates();
            for (int i = 0; i < oStates.Count; i++)
            {
                int index = oStates[i];
                buttons[index].Text = "O";
                buttons[index].BackColor = Color.Crimson;
                buttons[index].Enabled = false;
            }
        }
        //If the game is over and the next turn is computer's, put O directly.
        private void checkTheWinner()
        {
            if (board.getWinner() == Board.State.X)
            {
                label1.Text = "You Won!";
                playerScore++;
                turn = !turn;
                refreshBoard();
                if (!turn)
                {
                    computerPlayIndex = board.playComputerTurn();
                    buttons[computerPlayIndex].Text = "O";
                    buttons[computerPlayIndex].BackColor = Color.Crimson;
                    buttons[computerPlayIndex].Enabled = false;
                }

            }
            else if (board.getWinner() == Board.State.O)
            {
                label1.Text = "You Lost!";
                computerScore++;
                turn = !turn;
                refreshBoard();
                if (!turn)
                {
                    computerPlayIndex = board.playComputerTurn();
                    buttons[computerPlayIndex].Text = "O";
                    buttons[computerPlayIndex].BackColor = Color.Crimson;
                    buttons[computerPlayIndex].Enabled = false;
                }

            }
            else if (board.getMoveCount() == 9 && board.getWinner() == Board.State.BLANK)
            {
                label1.Text = "Draw!";
                turn = !turn;
                refreshBoard();
                if (!turn)
                {
                    computerPlayIndex = board.playComputerTurn();
                    buttons[computerPlayIndex].Text = "O";
                    buttons[computerPlayIndex].BackColor = Color.Crimson;
                    buttons[computerPlayIndex].Enabled = false;
                }

            }
        }
        //resets board[][] and refreshes button settings.
        private void refreshBoard()
        {
            board.reset();
            label3.Text = playerScore.ToString();
            label4.Text = computerScore.ToString();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Enabled = true;
                buttons[i].BackColor = Color.Gainsboro;
                buttons[i].Text = "";
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            depth = (int)comboBox1.SelectedItem;
        }
        //reset scores and refresh
        private void button10_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            computerScore = 0;
            refreshBoard();
        }
    }
}
