using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Queen : ChessFigure
    {
        public Queen() : base() { }
        public Queen(uint X, uint Y) : base(X, Y) { }
        public override bool CheckMove(uint X, uint Y, List<ChessFigure> chessFigures)
        {
            throw new NotImplementedException();
        }

        public override void Move(uint X, uint Y)
        {
            throw new NotImplementedException();
        }
    }
}
