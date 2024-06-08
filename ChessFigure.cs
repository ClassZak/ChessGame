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
        public ChessFigure()
        {
            Turned = false;
        }
        public ChessFigure(uint X, uint Y) : base()
        {
            this.X = X;
            this.Y = Y;
        }


        public bool Turned { get; protected set; }
        public bool Selected { get; set; }
        public Image Image { get; set; }
        public FigureType FigureType { get; set; }
        public FigureGroup FigureGroup { get; set; }
        public uint X { get; set; }
        public uint Y { get; set; }


        public abstract void Move(uint X, uint Y);
        public abstract void Move(Point point);
        public void CorrectMargin()
        {
            this.Image.Margin = Board.MarginFromCoords(this.X, this.Y);
        }
        public abstract List<Point> GetMoveCells(List<ChessFigure> chessFigures);
        public abstract List<Point> GetAttackedMoveCells(List<ChessFigure> chessFigures);



        #region Operators
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            ChessFigure chessFigure = obj as ChessFigure;
            if (chessFigure == null)
                return false;


            return
                chessFigure.X == this.X && chessFigure.Y == this.Y &&
                chessFigure.FigureGroup == this.FigureGroup &&
                chessFigure.FigureType == this.FigureType;
        }
        public static bool operator ==(ChessFigure chessFigure1, ChessFigure chessFigure2)
        {
            if (chessFigure1 is null || chessFigure2 is null)
                return false;

            return chessFigure1.Equals(chessFigure2);
        }
        public static bool operator !=(ChessFigure chessFigure1, ChessFigure chessFigure2)
        {
            if (chessFigure1 is null || chessFigure2 is null)
                return false;

            return !chessFigure1.Equals(chessFigure2);
        }


        #endregion
        #region Events
        public event MouseButtonEventHandler FigureSelected;
        public abstract void SelectionHandling(object sender, MouseButtonEventArgs mouseEventArgs);
        #endregion

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
