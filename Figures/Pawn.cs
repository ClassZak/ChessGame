﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessGame
{
    internal class Pawn : ChessFigure
    {
        public Pawn():base() { }
        public Pawn(uint X,uint Y):base(X,Y) { }
        public override bool CheckMove(uint X, uint Y, List<ChessFigure> chessFigures)
        {
            throw new NotImplementedException();
        }


        public new event MouseButtonEventHandler FigureSelected;


        public override List<Point> GetMoveCells()
        {
            List<Point> points;

            if(FigureGroup== FigureGroup.White)
            {

                points = new List<Point>()
                { new Point(X,Y+1) };
                if (Y==2)
                    points.Add(new Point(X, Y + 2));
            }
            else
            {
                points = new List<Point>()
                { new Point(X,Y-1) };
                if (Y == 7)
                    points.Add(new Point(X, Y - 2));
            }

            while (points.Count(x => !Board.ValidCell(x)) != 0)
                points.RemoveAt(points.FindIndex(x => !Board.ValidCell(x)));


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
            Selected=!Selected;

            if (!(FigureSelected is null))
                FigureSelected(this,mouseEventArgs);
        }
    }
}
