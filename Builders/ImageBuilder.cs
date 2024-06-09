using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessGame
{
    internal class ImageBuilder
    {
        public static Image CreateImage(string filename, bool local=true)
        {
            Image image = new Image();
            if (local)
            {
                var uri = new Uri(Path.Combine(Directory.GetCurrentDirectory(),filename));
                var bitmap = new BitmapImage(uri);
                image.Source = bitmap;
            }
            else
            {
                var uri = new Uri(filename);
                var bitmap = new BitmapImage(uri);
                image.Source = bitmap;
            }


            return image;
        }

        public static string GetImageName(FigureGroup figureGroup, FigureType figureType)
        {
            string filename;
            filename = (figureGroup == FigureGroup.White) ? "w" : "b";

            switch (figureType)
            {
                case FigureType.Pawn:
                    filename += "P";
                    break;
                case FigureType.Queen:
                    filename += "Q";
                    break;
                case FigureType.King:
                    filename += "K";
                    break;
                case FigureType.Knight:
                    filename += "N";
                    break;
                case FigureType.Rock:
                    filename += "R";
                    break;
                case FigureType.Bishop:
                    filename += "B";
                    break;
            }
            filename += ".png";

            return System.IO.Path.Combine("FigureImages", filename);
        }
    }
}
