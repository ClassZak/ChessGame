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
        public override bool CheckMove(uint X, uint Y, List<ChessFigure> chessFigures)
        {
            throw new NotImplementedException();
        }


        public new event MouseButtonEventHandler FigureSelected;


        public override Vector[] GetMoveCells()
        {
            Vector[] vectors;

            if(FigureGroup== FigureGroup.White)
            {
                if (Y!=2)
                {
                    vectors= new Vector[2];
                    vectors[0].X = X;
                    vectors[0].Y = Y;
                    vectors[1].X = X;
                    vectors[1].Y = Y+1;
                }
                else
                {
                    vectors = new Vector[3];
                    vectors[0].X = X;
                    vectors[0].Y = Y;
                    vectors[1].X = X;
                    vectors[1].Y = Y+1;
                    vectors[2].X = X;
                    vectors[2].Y = Y+2;
                }
            }
            else
            {
                if (Y != 7)
                {
                    vectors = new Vector[2];
                    vectors[0].X = X;
                    vectors[0].Y = Y;
                    vectors[1].X = X;
                    vectors[1].Y = Y - 1;
                }
                else
                {
                    vectors = new Vector[3];
                    vectors[0].X = X;
                    vectors[0].Y = Y;
                    vectors[1].X = X;
                    vectors[1].Y = Y - 1;
                    vectors[2].X = X;
                    vectors[2].Y = Y - 2;
                }
            }
            


            return vectors;
        }

        public override void Move(uint X, uint Y)
        {
            throw new NotImplementedException();
        }

        public override void SelectionHandling(object sender, MouseButtonEventArgs mouseEventArgs)
        {
            Selected=!Selected;


            Vector[] positions=GetMoveCells();

            StringBuilder sb=new StringBuilder();
            for (int i=0; i<positions.Length; i++)
                sb.Append($"({positions[i].X},{positions[i].Y})\n");
            

            MessageBox.Show(sb.ToString(), "позиции");


            if (FigureSelected is null)
                return;
            FigureSelected(sender,mouseEventArgs);
        }
    }
}
