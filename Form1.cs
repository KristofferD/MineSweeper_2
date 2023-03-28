using System;
using System.Windows.Forms;

namespace MineSweeperAgain
{
    public partial class Form1 : Form
    {
        private Game _game;

        public Form1()
        {
            InitializeComponent();
            _game = new Game(10, 10, 10);
            dataGridView1.RowCount = _game.Board.NumRows;
            dataGridView1.ColumnCount = _game.Board.NumCols;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (e.Button == MouseButtons.Left)
            {
                _game.RevealCell(row, col);
            }
            else if (e.Button == MouseButtons.Right)
            {
                _game.ToggleFlaggedCell(row, col);
            }

            UpdateGridView();
        }

        private void UpdateGridView()
        {
            for (int row = 0; row < _game.Board.NumRows; row++)
            {
                for (int col = 0; col < _game.Board.NumCols; col++)
                {
                    var cell = _game.Board.GetCell(row, col);
                    var dataGridViewCell = dataGridView1.Rows[row].Cells[col];
                    if (cell.IsRevealed)
                    {
                        dataGridViewCell.Value = cell.IsMine ? "X" : cell.AdjacentMinesCount.ToString();
                    }
                    else
                    {
                        dataGridViewCell.Value = cell.IsFlagged ? "F" : "";
                    }
                }
            }
        }
    }
}
