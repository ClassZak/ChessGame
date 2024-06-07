using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChessGame
{
    internal class Knight : ChessFigure
    {
        public Knight() : base() { }
        public Knight(uint X, uint Y) : base(X, Y) { }

        public new event MouseButtonEventHandler FigureSelected;

        public override List<Point> GetMoveCells(List<ChessFigure> chessFigures)
        {
            List<Point> points = new List<Point>
            {
                new Point(X - 1, Y + 2),
                new Point(X + 1, Y + 2),
                new Point(X + 2, Y + 1),
                new Point(X + 2, Y - 1),
                new Point(X + 1, Y - 2),
                new Point(X - 1, Y - 2),
                new Point(X - 2, Y - 1),
                new Point(X - 2, Y + 1)
            };


            points.RemoveAll(x => !Board.ValidCell(x));
            points.RemoveAll(x =>
            !(chessFigures.Find(y => y.X == x.X && y.Y == x.Y && y.FigureGroup==this.FigureGroup) is null));

            return points;
        }
        public override void Move(uint X, uint Y)
        {
            this.X = X;
            this.Y = Y;
            this.CorrectMargin();
            Turned = true;
        }

        public override void Move(Point point)
        {
            Move((uint)point.X, (uint)point.Y);
        }


        public override void SelectionHandling(object sender, MouseButtonEventArgs mouseEventArgs)
        {
            Selected = !Selected;

            if (!(FigureSelected is null))
                FigureSelected(this, mouseEventArgs);
        }

    }
}
