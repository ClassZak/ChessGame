using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChessGame
{
    internal class Rock : ChessFigure
    {
        public Rock() : base() { }
        public Rock(uint X, uint Y) : base(X, Y) { }
        public override bool CheckMove(uint X, uint Y, List<ChessFigure> chessFigures)
        {
            throw new NotImplementedException();
        }

        public new event MouseButtonEventHandler FigureSelected;

        public override List<Point> GetMoveCells()
        {
            List<Point> points = new List<Point>();


            for (int i = 1; i != 9; ++i)
            {
                if (i == X)
                    continue;
                points.Add(new Point(i, Y));
            }
            for (int i = 1; i != 9; ++i)
            {
                if (i == Y)
                    continue;
                points.Add(new Point(X, i));
            }

            




            while (points.Count(x => !Board.ValidCell(x)) != 0)
                points.RemoveAt(points.FindIndex(x => !Board.ValidCell(x)));

            for (int i = 0; i < points.Count; ++i)
            {
                if
                (
                    points.ElementAt(i).X < 0 ||
                    points.ElementAt(i).X > 8 ||
                    points.ElementAt(i).Y < 0 ||
                    points.ElementAt(i).Y > 8
                )
                {
                    points.RemoveAt(i);
                }
            }






            return points;
        }

        public override void Move(uint X, uint Y)
        {
            this.X = X;
            this.Y = Y;
            this.CorrectMargin();
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
