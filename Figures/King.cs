﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChessGame
{
    internal class King : ChessFigure
    {
        public King() : base() { }
        public King(uint X, uint Y) : base(X, Y) { }
        public override bool CheckMove(uint X, uint Y, List<ChessFigure> chessFigures)
        {
            throw new NotImplementedException();
        }

        public override Vector[] GetMoveCells()
        {
            throw new NotImplementedException();
        }
        public override void Move(uint X, uint Y)
        {
            throw new NotImplementedException();
        }
        public override void SelectionHandling(object sender, MouseButtonEventArgs mouseEventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
