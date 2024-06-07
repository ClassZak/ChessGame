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
    internal abstract class ChessFigure
    {
        public ChessFigure() { }
        public ChessFigure(uint X,uint Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public event MouseButtonEventHandler FigureSelected;


        public bool Selected {  get; set; }
        public Image Image { get; set; }
        public FigureType FigureType { get; set; }
        public FigureGroup FigureGroup { get; set; }
        public uint X { get; set; }
        public uint Y { get; set; }


        public abstract void Move(uint X, uint Y);
        public abstract bool CheckMove(uint X, uint Y, List<ChessFigure> chessFigures);
        public void CurrectMargin()
        {
            this.Image.Margin=Board.MarginFromCoords(this.X,this.Y);
        }
        public abstract Vector[] GetMoveCells();
        public abstract void SelectionHandling(object sender, MouseButtonEventArgs mouseEventArgs);
    }
}
