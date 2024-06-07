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
            List<Point> points = new List<Point>();

            points.Add(new Point(X - 1, Y + 2));
            points.Add(new Point(X + 1, Y + 2));
            points.Add(new Point(X + 2, Y + 1));
            points.Add(new Point(X + 2, Y - 1));

            points.Add(new Point(X + 1, Y - 2));
            points.Add(new Point(X - 1, Y - 2));
            points.Add(new Point(X - 2, Y - 1));
            points.Add(new Point(X - 2, Y + 1));




            while (points.Count(x => !Board.ValidCell(x)) != 0)
                points.RemoveAt(points.FindIndex(x => !Board.ValidCell(x)));

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
