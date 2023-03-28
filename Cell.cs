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
        public bool IsFlagged { get; set; }

        public void Reset()
        {
            IsMine = false;
            IsRevealed = false;
            IsFlagged = false;
        }

    }


}
