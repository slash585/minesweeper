using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper_v2
{
    public interface ITileButtonDelegate
    {
        void OpenTile(int row, int column);
        void AddFlag(int row, int column);
        void OpenMine();
    }
}
