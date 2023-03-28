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
            Cell cell = _game.Cells[row, col];
            if (cell.IsRevealed)
            {
                if (cell.IsMine)
                {
                    gameBoard.Rows[row].Cells[col].Value = "M";
                    gameBoard.Rows[row].Cells[col].Style.BackColor = Color.Red;
                }
                else
                {
                    gameBoard.Rows[row].Cells[col].Value = cell.AdjacentMines > 0 ? cell.AdjacentMines.ToString() : "";
                    gameBoard.Rows[row].Cells[col].Style.BackColor = Color.LightGray;
                }
            }
        }
    }
}
