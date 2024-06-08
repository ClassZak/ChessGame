using System;
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


        public new event MouseButtonEventHandler FigureSelected;


        public override List<Point> GetMoveCells(List<ChessFigure> chessFigures)
        {
            List<Point> points= new List<Point>();

            if(FigureGroup== FigureGroup.White)
            {
                points.Add(new Point(X,Y+1));
                if (Y==2 && chessFigures.Find(y => y.X == X && y.Y == Y+1) is null)
                    points.Add(new Point(X, Y + 2));
            }
            else
            {
                points.Add(new Point(X,Y-1));
                if (Y == 7 && chessFigures.Find(y => y.X == X && y.Y == Y - 1) is null)
                    points.Add(new Point(X, Y - 2));
            }
            points.RemoveAll(x => !Board.ValidCell(x));
            points.RemoveAll(x=>!(chessFigures.Find(y=>y.X==x.X&&y.Y==x.Y) is null));


            if
            (
                !(
                    chessFigures.Find
                    (
                        x=>x.X==X-1 &&
                        x.Y==(this.FigureGroup == FigureGroup.White ? Y+1 : Y-1) &&
                        x.FigureGroup!=this.FigureGroup
                    ) is null
                )
            )
                points.Add(new Point(X - 1, (this.FigureGroup == FigureGroup.White ? Y + 1 : Y - 1)));
            if
            (
                !(
                    chessFigures.Find
                    (
                        x=>x.X==X+1 &&
                        x.Y==(this.FigureGroup == FigureGroup.White ? Y+1 : Y-1) &&
                        x.FigureGroup!=this.FigureGroup
                    ) is null
                )
            )
                points.Add(new Point(X + 1, (this.FigureGroup == FigureGroup.White ? Y + 1 : Y - 1)));




            return points;
        }

        public override List<Point> GetAttackedMoveCells(List<ChessFigure> chessFigures)
        {
            List<Point> points = new List<Point>
            {
                new Point(X - 1, (this.FigureGroup == FigureGroup.White) ? Y + 1 : Y - 1),
                new Point(X + 1, (this.FigureGroup == FigureGroup.White) ? Y + 1 : Y - 1)
            };

            points.RemoveAll(x => Board.ValidCell(new Point(x.X, x.Y)));

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
            Selected=!Selected;

            if (!(FigureSelected is null))
                FigureSelected(this,mouseEventArgs);
        }
    }
}
