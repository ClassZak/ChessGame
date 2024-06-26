﻿using ChessGame.Builders;
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

        public new event MouseButtonEventHandler FigureSelected;


        public List<Point> GetDefaultMoveCells()
        {
            List<Point> points = new List<Point>
            {
                new Point(X - 1, Y - 1),
                new Point(X - 1, Y),
                new Point(X - 1, Y + 1),
                new Point(X, Y + 1),
                new Point(X, Y - 1),
                new Point(X + 1, Y - 1),
                new Point(X + 1, Y),
                new Point(X + 1, Y + 1)
            };
            points.RemoveAll(x => !Board.ValidCell(x));

            return points;
        }


        public bool PositionChecked(List<ChessFigure> chessFigures, Point point)
        {
            bool res = false;
            foreach(ChessFigure chessFigure in chessFigures)
            {
                if (chessFigure.FigureGroup == this.FigureGroup)
                    continue;

                if(chessFigure.FigureType==FigureType.King && chessFigure.FigureGroup!=FigureGroup)
                {
                    if(((King)(chessFigure)).GetDefaultMoveCells().Contains(point))
                    {
                        res= true;
                        break;
                    }
                    continue;
                }

                List<ChessFigure> currectCheckList = new List<ChessFigure>(chessFigures);
                // Remove elements
                currectCheckList.Remove(this);
                if(point.X!=X && point.Y!=Y)
                {
                    currectCheckList.RemoveAll
                    (
                        x=>(x.FigureGroup != this.FigureGroup)
                        && this.GetDefaultMoveCells().Contains(new Point(x.X,x.Y))
                    );
                }

                if (chessFigure.GetAttackedMoveCells(currectCheckList).Contains(point))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
        public override List<Point> GetMoveCells(List<ChessFigure> chessFigures)
        {
            List<Point> points= new List<Point>
            {
                new Point(X - 1, Y - 1),
                new Point(X - 1, Y),
                new Point(X - 1, Y + 1),
                new Point(X, Y + 1),
                new Point(X, Y - 1),
                new Point(X + 1, Y - 1),
                new Point(X + 1, Y),
                new Point(X + 1, Y + 1)
            };


            

            if(!Turned)
            {
                if(!PositionChecked(chessFigures,new Point(X,Y)))
                    if(FigureGroup==FigureGroup.White)
                    {
                        if (!(chessFigures.Find(x => x.X == 1 && x.Y == 1) is null))
                            if(!(chessFigures.Find(x => x.X == 1 && x.Y == 1 && x.GetType().Name=="Rock" && x.FigureGroup==this.FigureGroup && !x.Turned) is null))
                            {
                                bool canRooking = true;
                                for(uint i = X-1; i!=1;--i)
                                {
                                    if(!(chessFigures.Find(x=>x.X==i && x.Y==Y) is null) || PositionChecked(chessFigures,new Point(i,Y)))
                                    {
                                        canRooking = false;
                                        break;
                                    }
                                }

                                if(canRooking)
                                    points.Add(new Point(X-2,Y));
                            }
                        if (!(chessFigures.Find(x => x.X == 8 && x.Y == 1) is null))
                            if (!(chessFigures.Find(x => x.X == 8 && x.Y == 1 && x.GetType().Name == "Rock" && x.FigureGroup == this.FigureGroup && !x.Turned) is null))
                            {
                                bool canRooking = true;
                                for (uint i = X + 1; i != 8; ++i)
                                {
                                    if (!(chessFigures.Find(x => x.X == i && x.Y == Y) is null) || PositionChecked(chessFigures, new Point(i, Y)))
                                    {
                                        canRooking = false;
                                        break;
                                    }
                                }

                                if (canRooking)
                                    points.Add(new Point(X + 2, Y));
                            }
                    }
                    else
                    {
                        if (!(chessFigures.Find(x => x.X == 1 && x.Y == 8) is null))
                            if (!(chessFigures.Find(x => x.X == 1 && x.Y == 8 && x.GetType().Name == "Rock" && x.FigureGroup == this.FigureGroup && !x.Turned) is null))
                            {
                                bool canRooking = true;
                                for (uint i = X - 1; i != 1; --i)
                                {
                                    if (!(chessFigures.Find(x => x.X == i && x.Y == Y) is null) || PositionChecked(chessFigures, new Point(i, Y)))
                                    {
                                        canRooking = false;
                                        break;
                                    }
                                }

                                if (canRooking)
                                    points.Add(new Point(X - 2, Y));
                            }
                        if (!(chessFigures.Find(x => x.X == 8 && x.Y == 8) is null))
                            if (!(chessFigures.Find(x => x.X == 8 && x.Y == 8 && x.GetType().Name == "Rock" && x.FigureGroup == this.FigureGroup && !x.Turned) is null))
                            {
                                bool canRooking = true;
                                for (uint i = X + 1; i != 8; ++i)
                                {
                                    if (!(chessFigures.Find(x => x.X == i && x.Y == Y) is null) || PositionChecked(chessFigures, new Point(i, Y)))
                                    {
                                        canRooking = false;
                                        break;
                                    }
                                }

                                if (canRooking)
                                    points.Add(new Point(X + 2, Y));
                            }
                    }
            }

            points.RemoveAll(x => !Board.ValidCell(x) || PositionChecked(chessFigures,new Point(x.X,x.Y)));
            points.RemoveAll(x =>
            !(chessFigures.Find(y => y.X == x.X && y.Y == x.Y && y.FigureGroup == this.FigureGroup) is null));
            points.RemoveAll(x=>PositionChecked(chessFigures, new Point(x.X,x.Y)));



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

        public override List<Point> GetAttackedMoveCells(List<ChessFigure> chessFigures)
        {
            List<Point> points = GetDefaultMoveCells();
            points.RemoveAll(x => !Board.ValidCell(x));

            return points;
        }
    }
}
