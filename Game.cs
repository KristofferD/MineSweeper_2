using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperAgain
{
    public class Game
    {
        private Board _board;

        public Game(int numRows, int numCols, int numMines)
        {
            _board = new Board(numRows, numCols, numMines);
        }

        public void HandleCellClick(int row, int col)
        {
            // TODO: Handle clicking on a cell
        }

        // TODO: Add other methods to handle user input
    }
}
