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
        }

        private void GameBoard_CellClick(object? sender, DataGridViewCellEventArgs e)

        {
            private void GameBoard_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                var mouseEventArgs = e as MouseEventArgs;
                if (mouseEventArgs?.Button == MouseButtons.Left)
                {
                    // Left click on cell
                }
                else if (mouseEventArgs?.Button == MouseButtons.Right)
                {
                    // Right click on cell
                }
            }


        }
    }
}
