using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperAgain
{
    public class Board
    {
        private Cell[,] _cells;

        public Board(int numRows, int numCols, int numMines)
        {
            // Create the 2D array of cells
            _cells = new Cell[numRows, numCols];

            // Initialize each cell
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    _cells[row, col] = new Cell();
                }
            }

            // Place the mines randomly on the board
            Random random = new Random();
            int minesAdded = 0;

            while (minesAdded < numMines)
            {
                int row = random.Next(numRows);
                int col = random.Next(numCols);

                if (!_cells[row, col].IsMine)
                {
                    _cells[row, col].IsMine = true;
                    minesAdded++;
                }
            }
        }
    }

}
