using MineSweeperAgain;
using System;

namespace MineSweeper_2
{
    public enum GameStatus
    {
        InProgress,
        Won,
        Lost
    }
    public class Game
    {
        public int Rows { get; }
        public int Columns { get; }
        public int Mines { get; }
        public Cell[,] Cells { get; private set; }
        
        public GameStatus GameStatus { get; private set; }

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

        public void RevealCell(int row, int col)
        {
            if (row < 0 || col < 0 || row >= this.Rows || col >= this.Columns)
            {
                return;
            }

            if (Cells[row, col].IsRevealed)
            {
                return;
            }

            Cells[row, col].IsRevealed = true;

            if (Cells[row, col].IsMine)
            {
                CheckGameStatus();
                return;
            }

            if (Cells[row, col].AdjacentMines == 0)
            {
                RevealAdjacentCells(row, col);
            }

            CheckGameStatus();
        }


        private void RevealAdjacentCells(int row, int col)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newRow = row + i;
                    int newCol = col + j;

                    if (newRow >= 0 && newRow < this.Rows && newCol >= 0 && newCol < this.Columns && !Cells[newRow, newCol].IsRevealed)
                    {
                        RevealCell(newRow, newCol);
                    }
                }
            }
        }
        private void CheckGameStatus()
        {
            int revealedCells = 0;
            bool mineRevealed = false;
            foreach (Cell cell in Cells)
            {
                if (cell.IsRevealed)
                {
                    revealedCells++;
                    if (cell.IsMine)
                    {
                        mineRevealed = true;
                    }
                }
            }

            if ((this.Rows * this.Columns) - revealedCells == this.Mines)
            {
                GameStatus = GameStatus.Won;
            }
            else if (mineRevealed)
            {
                GameStatus = GameStatus.Lost;
            }
            else
            {
                GameStatus = GameStatus.InProgress;
            }
        }
    }
}

