using MineSweeperAgain;
using System;

namespace MineSweeper_2
{
    public class Game
    {
        public int Rows { get; }
        public int Columns { get; }
        public int Mines { get; }
        public Cell[,] Cells { get; private set; }

        public Game(int rows, int columns, int mines)
        {
            Rows = rows;
            Columns = columns;
            Mines = mines;

            Cells = new Cell[rows, columns]; // Add this line

            InitializeCells();
            PlaceMines();
            CalculateAdjacentMines();
        }

        private void InitializeCells()
        {
            Cells = new Cell[Rows, Columns];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Cells[row, col] = new Cell();
                }
            }
        }

        private void PlaceMines()
        {
            var random = new Random();
            int minesPlaced = 0;

            while (minesPlaced < Mines)
            {
                int row = random.Next(Rows);
                int col = random.Next(Columns);

                if (!Cells[row, col].IsMine)
                {
                    Cells[row, col].IsMine = true;
                    minesPlaced++;
                }
            }
        }

        private void CalculateAdjacentMines()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (Cells[row, col].IsMine)
                    {
                        continue;
                    }

                    int adjacentMines = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int newRow = row + i;
                            int newCol = col + j;

                            if (newRow >= 0 && newRow < Rows && newCol >= 0 && newCol < Columns && Cells[newRow, newCol].IsMine)
                            {
                                adjacentMines++;
                            }
                        }
                    }

                    Cells[row, col].AdjacentMines = adjacentMines;
                }
            }
        }

        // Add the following methods to your Game class:

        public bool RevealCell(int row, int column)
        {
            if (row < 0 || row >= RowCount || column < 0 || column >= ColumnCount)
            {
                return false;
            }

            Cell cell = Cells[row, column];
            if (cell.IsRevealed || cell.IsFlagged)
            {
                return false;
            }

            cell.IsRevealed = true;

            if (cell.IsMine)
            {
                return true;
            }

            if (cell.AdjacentMines == 0)
            {
                for (int r = -1; r <= 1; r++)
                {
                    for (int c = -1; c <= 1; c++)
                    {
                        if (r == 0 && c == 0)
                        {
                            continue;
                        }

                        RevealCell(row + r, column + c);
                    }
                }
            }

            return false;
        }

        public bool CheckGameStatus()
        {
            int revealedCells = 0;
            foreach (Cell cell in Cells)
            {
                if (cell.IsRevealed)
                {
                    revealedCells++;
                }
            }

            return (RowCount * ColumnCount) - revealedCells == MineCount;
        }

    }
}
