using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class FigureCapturedEventArg : EventArgs
    {
        public ChessFigure ChessFigure { get; set; }


        public FigureCapturedEventArg()
        {

        }
        public FigureCapturedEventArg(ChessFigure ChessFigure)
        {
            this.ChessFigure = ChessFigure;
        }
    }
}
