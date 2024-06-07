using ChessGame.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ChessGame
{
    internal class Board
    {
        private List<ChessFigure> ChessFigures = new List<ChessFigure>();

        private FigureGroup Turn = FigureGroup.White;
        private int lastSelected = -1; 

        public GameType _gameType=GameType.Default;
        public List<object> movesGridCollection=new List<object>();


        public const float CellWidth = 80;
        public const float CellHeight = 80;
        public const float BoardWidth = 640;
        public const float BoardHeight = 640;


        public Board(System.Windows.Controls.Grid Grid)
        {
            if(_gameType == GameType.Default)
            {
                for (uint i = 1; i != 9; ++i)
                    ChessFigures.Add(FigureBuilder.CreateFigure
                        (
                            i, 2u,
                            FigureType.Pawn,
                            FigureGroup.White,
                            "FigureImages/wP.png"
                        ));
                for (uint i=1;i!=9;++i)
                    ChessFigures.Add(FigureBuilder.CreateFigure
                        (
                            i,7u,
                            FigureType.Pawn,
                            FigureGroup.Black,
                            "FigureImages/bP.png"
                        ));



                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        1u,1u,
                        FigureType.Rock,
                        FigureGroup.White,
                        "FigureImages/wR.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        8u,1u,
                        FigureType.Rock,
                        FigureGroup.White,
                        "FigureImages/wR.png"
                    ));
                

                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        1u,8u,
                        FigureType.Rock,
                        FigureGroup.Black,
                        "FigureImages/bR.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        8u,8u,
                        FigureType.Rock,
                        FigureGroup.Black,
                        "FigureImages/bR.png"
                    ));





                ChessFigures.Add(FigureBuilder.CreateFigure
                   (
                       2u, 1u,
                       FigureType.Knight,
                       FigureGroup.White,
                       "FigureImages/wN.png"
                   ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        7u, 1u,
                        FigureType.Knight,
                        FigureGroup.White,
                        "FigureImages/wN.png"
                    ));


                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        2u, 8u,
                        FigureType.Knight,
                        FigureGroup.Black,
                        "FigureImages/bN.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        7u, 8u,
                        FigureType.Knight,
                        FigureGroup.Black,
                        "FigureImages/bN.png"
                    ));




                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        3u, 1u,
                        FigureType.Bishop,
                        FigureGroup.White,
                        "FigureImages/wB.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        6u, 1u,
                        FigureType.Bishop,
                        FigureGroup.White,
                        "FigureImages/wB.png"
                    ));


                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        3u, 8u,
                        FigureType.Bishop,
                        FigureGroup.Black,
                        "FigureImages/bB.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        6u, 8u,
                        FigureType.Bishop,
                        FigureGroup.Black,
                        "FigureImages/bB.png"
                    ));





                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        5u, 1u,
                        FigureType.King,
                        FigureGroup.White,
                        "FigureImages/wK.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        4u, 1u,
                        FigureType.Queen,
                        FigureGroup.White,
                        "FigureImages/wQ.png"
                    ));

                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        5u, 8u,
                        FigureType.King,
                        FigureGroup.Black,
                        "FigureImages/bK.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        4u, 8u,
                        FigureType.Queen,
                        FigureGroup.Black,
                        "FigureImages/bQ.png"
                    ));
            }

            Grid.Children.Clear();
            foreach(var el in ChessFigures)
                Grid.Children.Add(el.Image);

            for(int i=0;i<ChessFigures.Count;i++)
            {
                Type t=ChessFigures.ElementAt(i).GetType();

                if(t.Name=="Bishop")
                    ((Bishop)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if(t.Name=="King")
                    ((King)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if(t.Name=="Knight")
                    ((Knight)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if(t.Name=="Pawn")
                    ((Pawn)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if(t.Name=="Queen")
                    ((Queen)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if(t.Name=="Rock")
                    ((Rock)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
            }
        }


        public void UpdateChessImages(System.Windows.Controls.Grid Grid)
        {
            Grid.Children.Clear();
            foreach (var el in ChessFigures)
                Grid.Children.Add(el.Image);

            if(lastSelected!=-1)
            {
                Rectangle rectangle=new Rectangle();
                //Selection rect
                rectangle.Stroke = new SolidColorBrush(Colors.MediumOrchid);
                rectangle.StrokeThickness = 8;
                rectangle.Margin =
                    MarginFromCoords(ChessFigures.ElementAt(lastSelected).X, ChessFigures.ElementAt(lastSelected).Y);
                Grid.Children.Add(rectangle);
            }

            if (movesGridCollection.Count != 0)
                for(int i=0;i< movesGridCollection.Count;++i)
                    Grid.Children.Add((UIElement)movesGridCollection[i]);
        }


        public static Thickness MarginFromCoords(Vector vector)
        {
            return MarginFromCoords((uint)vector.X, (uint)vector.Y);
        }
        public static Thickness MarginFromCoords(Point vector)
        {
            return MarginFromCoords((uint)vector.X, (uint)vector.Y);
        }
        public static Thickness MarginFromCoords(uint X, uint Y)
        {
            return new Thickness
            (
                ChessGame.Board.CellWidth * (X - 1),
                ChessGame.Board.CellHeight * (8 - Y),
                ChessGame.Board.CellWidth * (8 - X),
                ChessGame.Board.CellHeight * (Y-1)
            );
        }


        public static Point CoordsFromMargin(double left,double top)
        {
            return new Point(left / CellWidth+1, 8-top / CellHeight);
        }
        public static Point CoordsFromMargin(Thickness thickness)
        {
            return CoordsFromMargin(thickness.Left, thickness.Top);
        }


        public void ResetSelection()
        {
            if (this.lastSelected == -1)
                return;
            this.ChessFigures.Find(x => x.Selected == true).Selected=false;
            this.lastSelected = -1;
            movesGridCollection.Clear();
        }

        public static bool ValidCell(Point point)
        {
            return ValidCell((uint)point.X, (uint)point.Y);
        }
        public static bool ValidCell(uint X, uint Y)
        {
            return !(X <= 0 || X > 8 || Y <= 0 || Y > 8);
        }
        #region Events
        public event MouseButtonEventHandler FigureSelected;

        public void FigureSelectedHandler(object sender,MouseButtonEventArgs mouseButtonEventArgs)
        {
            ChessFigure chessFigure=sender as ChessFigure;
            if (chessFigure is null)
                throw new ArgumentException("Wrong reference");


            if (chessFigure.FigureGroup != Turn)
            {
                chessFigure.Selected = false;
                ResetSelection();
                return;
            }
                
            if (!(chessFigure).Selected)
            {
                lastSelected = -1;
                movesGridCollection.Clear();
                return;
            }
            else
            {

                lastSelected = this.ChessFigures.IndexOf(chessFigure);
                for (int i = 0;i<this.ChessFigures.Count;++i)
                {
                    if (i == lastSelected)
                        continue;
                    ChessFigures.ElementAt(i).Selected = false;
                }
            }


            //Steps
            movesGridCollection.Clear();
            List<Point> vectors=chessFigure.GetMoveCells();
            for(int i=0; i<vectors.Count;++i)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Margin = MarginFromCoords(vectors.ElementAt(i));
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(50,50,255,50));
                rectangle.MouseDown += new MouseButtonEventHandler(MoveChosen);

                movesGridCollection.Add(rectangle);
            }
        }

        public void MoveChosen(object sender, MouseButtonEventArgs mouseEventArgs)
        {
            Point point = CoordsFromMargin(((Rectangle)(sender)).Margin);

            ChessFigure chessFigure = this.ChessFigures.Find(x => x.Selected);
            chessFigure.Move(point);

            if (Turn == FigureGroup.White)
                Turn = FigureGroup.Black;
            else
                Turn = FigureGroup.White;

            ResetSelection();

            movesGridCollection.Clear();
        }
        #endregion
    }
}
