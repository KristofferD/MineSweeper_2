using MineSweeper_2;
using System;
using System.Drawing;
using System.Windows.Forms;

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

            gameBoard.ReadOnly = true;
            gameBoard.RowHeadersVisible = false;
            gameBoard.ColumnHeadersVisible = false;
            gameBoard.AllowUserToAddRows = false;
            gameBoard.AllowUserToDeleteRows = false;
            gameBoard.AllowUserToResizeColumns = false;
            gameBoard.AllowUserToResizeRows = false;
            gameBoard.DefaultCellStyle.SelectionBackColor = gameBoard.DefaultCellStyle.BackColor;
            gameBoard.DefaultCellStyle.SelectionForeColor = gameBoard.DefaultCellStyle.ForeColor;

            foreach (DataGridViewColumn col in gameBoard.Columns)
            {
                col.Width = 30;
            }

            gameBoard.RowTemplate.Height = 30;
        }

        private void GameBoard_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            _game.RevealCell(e.RowIndex, e.ColumnIndex);
            UpdateCellDisplay(e.RowIndex, e.ColumnIndex);

            if (_game.GameStatus == GameStatus.Won)
            {
                MessageBox.Show("You won!");
            }
            else if (_game.GameStatus == GameStatus.Lost)
            {
                MessageBox.Show("You lost!");
            }
        }

        private void UpdateCellDisplay(int row, int col)
        {
            DataGridViewCell cellDisplay = gameBoard.Rows[row].Cells[col];

            if (_game.Cells[row, col].IsRevealed)
            {
                cellDisplay.Style.BackColor = Color.LightGray;
                if (_game.Cells[row, col].IsMine)
                {
                    cellDisplay.Value = "*";
                }
                else if (_game.Cells[row, col].AdjacentMines > 0)
                {
                    cellDisplay.Value = _game.Cells[row, col].AdjacentMines.ToString();
                }
                else
                {
                    cellDisplay.Value = ""; // added this line to clear the cell value
                    _game.RevealAdjacentCells(row, col);
                }
            }
            else
            {
                cellDisplay.Style.BackColor = Color.White;
                cellDisplay.Value = "";
            }
        }

    }
}
