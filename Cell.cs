using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperAgain
{
    public class Cell
    {
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public int AdjacentMines { get; set; }

        public void Reset()
        {
            IsMine = false;
            IsRevealed = false;
            AdjacentMines = 0;
        }

    }


}
