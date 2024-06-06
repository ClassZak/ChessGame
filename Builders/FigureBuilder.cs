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
                    figure.FigureGroup= figureGroup;
                    figure.FigureType= figureType;
                    figure.Image = ImageBuilder.CreateImage(imagePath);
                    break;
                case FigureType.Rock:
                    figure = new Rock(X, Y);
                    figure.FigureGroup = figureGroup;
                    figure.FigureType = figureType;
                    figure.Image = ImageBuilder.CreateImage(imagePath);
                    break;
                case FigureType.Knight:
                    figure = new Knight(X, Y);
                    figure.FigureGroup = figureGroup;
                    figure.FigureType = figureType;
                    figure.Image = ImageBuilder.CreateImage(imagePath);
                    break;
                case FigureType.Bishop:
                    figure = new Bishop(X, Y);
                    figure.FigureGroup = figureGroup;
                    figure.FigureType = figureType;
                    figure.Image = ImageBuilder.CreateImage(imagePath);
                    break;
                case FigureType.King:
                    figure = new King(X, Y);
                    figure.FigureGroup = figureGroup;
                    figure.FigureType = figureType;
                    figure.Image = ImageBuilder.CreateImage(imagePath);
                    break;
                case FigureType.Queen:
                    figure = new Queen(X, Y);
                    figure.FigureGroup = figureGroup;
                    figure.FigureType = figureType;
                    figure.Image = ImageBuilder.CreateImage(imagePath);
                    break;
                default:
                    figure = new Pawn();
                    break;
            }
            return figure;
        }
    }
}
