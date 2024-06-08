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

        public new event MouseButtonEventHandler FigureSelected;

        public override List<Point> GetAttackedMoveCells(List<ChessFigure> chessFigures)
        {
            return GetMoveCells(chessFigures);
            List<Point> points = new List<Point>();

            //Hor
            bool stop = false;
            for (uint i = X - 1; i != 0; --i)
            {
                if (stop)
                    break;

                if (!(chessFigures.Find(el => el.X == i && el.Y == Y) is null))
                    stop = true;

                points.Add(new Point(i, Y));
            }

            stop = false;
            for (uint i = X + 1; i != 9; ++i)
            {
                if (stop)
                    break;

                if (!(chessFigures.Find(el => el.X == i && el.Y == Y) is null))
                    stop = true;

                points.Add(new Point(i, Y));
            }
            //Vert
            stop = false;
            for (uint i = Y - 1; i != 0; --i)
            {
                if (stop)
                    break;

                if (!(chessFigures.Find(el => el.X == X && el.Y == i) is null))
                    stop = true;

                points.Add(new Point(X, i));
            }

            stop = false;
            for (uint i = Y + 1; i != 9; ++i)
            {
                if (stop)
                    break;

                if (!(chessFigures.Find(el => el.X == X && el.Y == i) is null))
                    stop = true;

                points.Add(new Point(X, i));
            }
            points.RemoveAll(x => !Board.ValidCell(x));

            return points;
        }

        public override List<Point> GetMoveCells(List<ChessFigure> chessFigures)
        {
            List<Point> points = new List<Point>();

            //Hor
            bool stop = false;
            for (uint i = X-1; i != 0; --i)
            {
                if (stop)
                    break;

                if (!(chessFigures.Find(el => el.X == i && el.Y == Y) is null))
                {
                    if (chessFigures.Find(el => el.X == i && el.Y == Y).FigureGroup == this.FigureGroup)
                        break;
                    else
                        stop = true;
                }

                points.Add(new Point(i, Y));
            }

            stop = false;
            for (uint i = X + 1; i != 9; ++i)
            {
                if (stop)
                    break;

                if (!(chessFigures.Find(el => el.X == i && el.Y == Y) is null))
                {
                    if (chessFigures.Find(el => el.X == i && el.Y == Y).FigureGroup == this.FigureGroup)
                        break;
                    else
                        stop = true;
                }

                points.Add(new Point(i, Y));
            }
            //Vert
            stop = false;
            for (uint i = Y-1; i != 0; --i)
            {
                if (stop)
                    break;

                if (!(chessFigures.Find(el => el.X == X && el.Y == i) is null))
                {
                    if (chessFigures.Find(el => el.X == X && el.Y == i).FigureGroup == this.FigureGroup)
                        break;
                    else
                        stop = true;
                }

                points.Add(new Point(X, i));
            }

            stop = false;
            for (uint i = Y + 1; i != 9; ++i)
            {
                if (stop)
                    break;

                if (!(chessFigures.Find(el => el.X == X && el.Y == i) is null))
                {
                    if (chessFigures.Find(el => el.X == X && el.Y == i).FigureGroup == this.FigureGroup)
                        break;
                    else
                        stop = true;
                }

                points.Add(new Point(X, i));
            }
            points.RemoveAll(x => !Board.ValidCell(x));

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
