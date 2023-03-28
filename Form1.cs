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
    }
}
