using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace ChessGame
{
    internal abstract class ChessFigure
    {
        public ChessFigure() { }
        public ChessFigure(uint X,uint Y)
        {
            this.X = X;
            this.Y = Y;
        }


        public Image Image { get; set; }
        public FigureType FigureType { get; set; }
        public FigureGroup FigureGroup { get; set; }
        uint X { get; set; }
        uint Y { get; set; }


        public abstract void Move(uint X, uint Y);
        public abstract bool CheckMove(uint X, uint Y, List<ChessFigure> chessFigures);
        public void CurrectMargin()
        {
            this.Image.Margin=Board.MarginFromCoords(this.X,this.Y);
        }
    }
}
