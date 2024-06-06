using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Builders
{
    internal class FigureBuilder
    {
        public static ChessFigure CreateFigure
        (
            uint X,
            uint Y,
            FigureType figureType,
            FigureGroup figureGroup,
            string imagePath
        )
        {
            ChessFigure figure;
            switch(figureType)
            {
                case FigureType.Pawn:
                    figure = new Pawn(X, Y);
                    break;
                case FigureType.Rock:
                    figure = new Rock(X, Y);
                    break;
                case FigureType.Knight:
                    figure = new Knight(X, Y);
                    break;
                case FigureType.Bishop:
                    figure = new Bishop(X, Y);
                    break;
                case FigureType.King:
                    figure = new King(X, Y);
                    break;
                case FigureType.Queen:
                    figure = new Queen(X, Y);
                    break;
                default:
                    throw new ArgumentException("Wron figure type");
            }
            figure.FigureGroup = figureGroup;
            figure.FigureType = figureType;

            figure.Image = ImageBuilder.CreateImage(imagePath);
            figure.Image.Stretch = System.Windows.Media.Stretch.UniformToFill;
            figure.Image.Width = Board.CellWidth;
            figure.Image.Height = Board.CellHeight;
            figure.CurrectMargin();

            return figure;
        }
    }
}
