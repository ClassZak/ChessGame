using System;
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

        public new event MouseButtonEventHandler FigureSelected;


        public override List<Point> GetMoveCells()
        {
            List<Point> points= new List<Point>();
            points.Add(new Point(X - 1, Y - 1));
            points.Add(new Point(X - 1, Y));
            points.Add(new Point(X - 1, Y + 1));
            points.Add(new Point(X, Y + 1));
            points.Add(new Point(X, Y - 1));
            points.Add(new Point(X + 1, Y - 1));
            points.Add(new Point(X + 1, Y));
            points.Add(new Point(X + 1, Y + 1));




            while (points.Count(x => !Board.ValidCell(x))!=0)
                points.RemoveAt(points.FindIndex(x => !Board.ValidCell(x)));
            
            for(int i=0;i<points.Count;++i)
            {
                if
                (
                    points.ElementAt(i).X<0 ||
                    points.ElementAt(i).X>8 ||
                    points.ElementAt(i).Y<0 ||
                    points.ElementAt(i).Y>8
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
