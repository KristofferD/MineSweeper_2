using MineSweeper_2;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace MineSweeperAgain
{
    public partial class Form1 : Form
    {
        private Game _game;

        public Form1()
        {
            InitializeComponent();

            gameBoard.RowCount = 10;
            gameBoard.ColumnCount = 10;

            _game = new Game(gameBoard.RowCount, gameBoard.ColumnCount, 10);

            gameBoard.CellClick += GameBoard_CellClick;
            gameBoard.CellMouseUp += GameBoard_CellMouseUp;
        }

        private void GameBoard_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Your logic for handling cell clicks goes here
        }

        private void GameBoard_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Left click on cell
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Right click on cell
            }
        }

        private void GameBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;

            bool clickedOnMine = _game.RevealCell(row, column);
            if (clickedOnMine)
            {
                MessageBox.Show("Game Over! You clicked on a mine.");
                return;
            }

            UpdateGameBoard();

            bool gameWon = _game.CheckGameStatus();
            if (gameWon)
            {
                MessageBox.Show("Congratulations! You've won the game.");
            }
        }

        private void UpdateGameBoard()
        {
            for (int row = 0; row < _game.RowCount; row++)
            {
                for (int column = 0; column < _game.ColumnCount; column++)
                {
                    Cell cell = _game.Cells[row, column];
                    if (cell.IsRevealed)
                    {
                        if (cell.IsMine)
                        {
                            gameBoard.Rows[row].Cells[column].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            gameBoard.Rows[row].Cells[column].Value = cell.AdjacentMines > 0 ? cell.AdjacentMines.ToString() : string.Empty;
                        }
                    }
                }
            }
        }
    }
}
