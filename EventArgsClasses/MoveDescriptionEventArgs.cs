using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class MoveDescriptionEventArgs : EventArgs
    {
        public string MoveDescript {  get; set; }
        public MoveDescriptionEventArgs(string MoveDescript)
        {
            this.MoveDescript = MoveDescript;
        }
    }
}
