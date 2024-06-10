using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class GameEndedEventArgs : EventArgs
    {
        public string Message {  get; set; }
        public FigureGroup WinGroup { get; set; }
        public bool IsDraw {  get; set; }


        public GameEndedEventArgs(string message, FigureGroup winGroup, bool isDraw)
        {
            Message = message;
            WinGroup = winGroup;
            IsDraw = isDraw;
        }
    }
}
