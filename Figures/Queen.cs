using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChessGame
{
    internal class Queen : ChessFigure
    {
        public Queen() : base() { }
        public Queen(uint X, uint Y) : base(X, Y) { }

        public new event MouseButtonEventHandler FigureSelected;

        public override List<Point> GetMoveCells(List<ChessFigure> chessFigures)
        {
            List<Point> points = new List<Point>();
            bool stop=false;
            //Main diagonal
            {
                uint x, y;

                stop = false;
                x = (uint)X;
                y = (uint)Y;
                while (Board.ValidCell(++x, ++y))
                {
                    if (stop)
                        break;

                    if (!(chessFigures.Find(el => el.X == x && el.Y == y) is null))
                    {
                        if (chessFigures.Find(el => el.X == x && el.Y == y).FigureGroup == this.FigureGroup)
                            break;
                        else
                            stop = true;
                    }

                    points.Add(new Point(x, y));
                }

                stop = false;
                x = (uint)X;
                y = (uint)Y;
                while (Board.ValidCell(--x, --y))
                {
                    if (stop)
                        break;

                    if (!(chessFigures.Find(el => el.X == x && el.Y == y) is null))
                    {
                        if (chessFigures.Find(el => el.X == x && el.Y == y).FigureGroup == this.FigureGroup)
                            break;
                        else
                            stop = true;
                    }

                    points.Add(new Point(x, y));
                }

            }
            //Side diagonal
            {
                uint x, y;

                stop = false;
                x = (uint)X;
                y = (uint)Y;
                while (Board.ValidCell(--x, ++y))
                {
                    if (stop)
                        break;

                    if (!(chessFigures.Find(el => el.X == x && el.Y == y) is null))
                    {
                        if (chessFigures.Find(el => el.X == x && el.Y == y).FigureGroup == this.FigureGroup)
                            break;
                        else
                            stop = true;
                    }

                    points.Add(new Point(x, y));
                }

                stop = false;
                x = (uint)X;
                y = (uint)Y;
                while (Board.ValidCell(++x, --y))
                {
                    if (stop)
                        break;

                    if (!(chessFigures.Find(el => el.X == x && el.Y == y) is null))
                    {
                        if (chessFigures.Find(el => el.X == x && el.Y == y).FigureGroup == this.FigureGroup)
                            break;
                        else
                            stop = true;
                    }

                    points.Add(new Point(x, y));
                }
            }


            //Rook
            //Hor
            stop = false;
            for (uint i = X - 1; i != 0; --i)
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
            for (uint i = Y - 1; i != 0; --i)
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


        public override void SelectionHandling(object sender, MouseButtonEventArgs mouseEventArgs)
        {
            Selected = !Selected;

            if (!(FigureSelected is null))
                FigureSelected(this, mouseEventArgs);
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

        public override List<Point> GetAttackedMoveCells(List<ChessFigure> chessFigures)
        {
            List<Point> points = new List<Point>();

            bool stop = false;
            //Main diagonal
            {
                uint x, y;

                stop = false;
                x = (uint)X;
                y = (uint)Y;
                while (Board.ValidCell(++x, ++y))
                {
                    if (stop)
                        break;

                    if (!(chessFigures.Find(el => el.X == x && el.Y == y) is null))
                        stop = true;

                    points.Add(new Point(x, y));
                }

                stop = false;
                x = (uint)X;
                y = (uint)Y;
                while (Board.ValidCell(--x, --y))
                {
                    if (stop)
                        break;

                    if (!(chessFigures.Find(el => el.X == x && el.Y == y) is null))
                        stop = true;

                    points.Add(new Point(x, y));
                }

            }
            //Side diagonal
            {
                uint x, y;

                stop = false;
                x = (uint)X;
                y = (uint)Y;
                while (Board.ValidCell(--x, ++y))
                {
                    if (stop)
                        break;

                    if (!(chessFigures.Find(el => el.X == x && el.Y == y) is null))
                        stop = true;

                    points.Add(new Point(x, y));
                }

                stop = false;
                x = (uint)X;
                y = (uint)Y;
                while (Board.ValidCell(++x, --y))
                {
                    if (stop)
                        break;

                    if (!(chessFigures.Find(el => el.X == x && el.Y == y) is null))
                        stop = true;

                    points.Add(new Point(x, y));
                }
            }
            points.RemoveAll(x => !Board.ValidCell(x));

            //Rook
            //Hor
            stop = false;
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
    }
}
