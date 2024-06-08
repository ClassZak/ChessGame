using ChessGame.Builders;
using System;
using System.Collections.Generic;
using System.IO;
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
            ResetGame(Grid);
        }
        public void ResetGame(System.Windows.Controls.Grid Grid)
        {
            FigureSelected=null;
            ChessFigures = new List<ChessFigure>();

            Turn = FigureGroup.White;
            lastSelected = -1;

            _gameType = GameType.Default;
            movesGridCollection = new List<object>();



            if (_gameType == GameType.Default)
            {
                for (uint i = 1; i != 9; ++i)
                    ChessFigures.Add(FigureBuilder.CreateFigure
                        (
                            i, 2u,
                            FigureType.Pawn,
                            FigureGroup.White,
                            "FigureImages/wP.png"
                        ));
                for (uint i = 1; i != 9; ++i)
                    ChessFigures.Add(FigureBuilder.CreateFigure
                        (
                            i, 7u,
                            FigureType.Pawn,
                            FigureGroup.Black,
                            "FigureImages/bP.png"
                        ));



                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        1u, 1u,
                        FigureType.Rock,
                        FigureGroup.White,
                        "FigureImages/wR.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        8u, 1u,
                        FigureType.Rock,
                        FigureGroup.White,
                        "FigureImages/wR.png"
                    ));


                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        1u, 8u,
                        FigureType.Rock,
                        FigureGroup.Black,
                        "FigureImages/bR.png"
                    ));
                ChessFigures.Add(FigureBuilder.CreateFigure
                    (
                        8u, 8u,
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
            foreach (var el in ChessFigures)
                Grid.Children.Add(el.Image);

            for (int i = 0; i < ChessFigures.Count; i++)
            {
                Type t = ChessFigures.ElementAt(i).GetType();

                if (t.Name == "Bishop")
                    ((Bishop)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if (t.Name == "King")
                    ((King)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if (t.Name == "Knight")
                    ((Knight)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if (t.Name == "Pawn")
                    ((Pawn)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if (t.Name == "Queen")
                    ((Queen)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
                if (t.Name == "Rock")
                    ((Rock)(ChessFigures.ElementAt(i))).FigureSelected += new MouseButtonEventHandler(this.FigureSelectedHandler);
            }
        }

        public void UpdateChessImages(System.Windows.Controls.Grid Grid)
        {
            if(Turn==FigureGroup.White)
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
            else
            {
                Thickness oldMargin;
                for(int i=0;i< ChessFigures.Count;++i)
                {
                    oldMargin = ChessFigures.ElementAt(i).Image.Margin;
                    ChessFigures.ElementAt(i).Image.Margin=new Thickness(oldMargin.Left,oldMargin.Bottom,oldMargin.Right,oldMargin.Top);
                }

                if (lastSelected != -1)
                {
                    Rectangle rectangle = new Rectangle();
                    //Selection rect
                    rectangle.Stroke = new SolidColorBrush(Colors.MediumOrchid);
                    rectangle.StrokeThickness = 8;
                    rectangle.Margin =
                        MarginFromCoords(ChessFigures.ElementAt(lastSelected).X, ChessFigures.ElementAt(lastSelected).Y);

                    oldMargin = rectangle.Margin;
                    rectangle.Margin=new Thickness(oldMargin.Left,oldMargin.Bottom,oldMargin.Right,oldMargin.Top);

                    Grid.Children.Add(rectangle);
                }

                if (movesGridCollection.Count != 0)
                    for (int i = 0; i < movesGridCollection.Count; ++i)
                    {
                        UIElement uIElement = (UIElement)movesGridCollection[i];
                        Rectangle rectangle = uIElement as Rectangle;


                        if(rectangle is null)
                            Grid.Children.Add(uIElement);
                        else
                        {
                            oldMargin = rectangle.Margin;
                            rectangle.Margin = new Thickness(oldMargin.Left, oldMargin.Bottom, oldMargin.Right, oldMargin.Top);
                            Grid.Children.Add(uIElement);
                        }
                    }
            }
        }


        #region Coordinates converters 
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
        #endregion
        public void ResetSelection()
        {
            if (this.lastSelected == -1)
                return;
            this.ChessFigures.Find(x => x.Selected == true).Selected=false;
            this.lastSelected = -1;
            movesGridCollection.Clear();
        }
        #region Cells validation
        public static bool ValidCell(Point point)
        {
            return ValidCell((uint)point.X, (uint)point.Y);
        }
        public static bool ValidCell(uint X, uint Y)
        {
            return !(X <= 0 || X > 8 || Y <= 0 || Y > 8);
        }
        #endregion
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
            List<Point> vectors=chessFigure.GetMoveCells(this.ChessFigures);
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
            SoundKind soundKind=SoundKind.None;

            ChessFigure chessFigure = this.ChessFigures.Find(x => x.Selected);


            if(chessFigure.GetType().Name=="King")
            {
                if(!chessFigure.Turned)
                {
                    if (point.X == 3 || point.X == 7)
                    {
                        Rooking(point.X==7,chessFigure.FigureGroup);
                        if(soundKind==SoundKind.None)
                            soundKind = SoundKind.Rooking;
                    }
                }
            }


            try
            {
                int del=
                this.ChessFigures.RemoveAll(x => x.X == point.X && x.Y == point.Y);

                if (del != 0)
                {
                    if (soundKind == SoundKind.None)
                        soundKind = SoundKind.Caption;
                }
                else
                {
                    if (soundKind == SoundKind.None)
                        soundKind = SoundKind.Move;
                }
                    
            }
            catch
            {
                if (soundKind == SoundKind.None)
                    soundKind = SoundKind.Move;
            }
            chessFigure.Move(point);

            
                

            if (Turn == FigureGroup.White)
                Turn = FigureGroup.Black;
            else
                Turn = FigureGroup.White;

            ResetSelection();

            movesGridCollection.Clear();
            PlayGameSound(soundKind);
        }

        private void Rooking(bool isShortDirection, FigureGroup figureGroup)
        {
            if(isShortDirection)
            {
                ChessFigures.Find
                (
                    x =>
                    x.X == 8 &&
                    x.Y == ((figureGroup == FigureGroup.White) ? 1 : 8)
                ).Move(6, ((figureGroup == FigureGroup.White) ? 1u : 8u));
            }
            else
            {
                ChessFigures.Find
                (
                    x =>
                    x.X == 1 &&
                    x.Y == ((figureGroup == FigureGroup.White) ? 1 : 8)
                ).Move(4, ((figureGroup == FigureGroup.White) ? 1u : 8u));
            }
        }
        #endregion

        #region Sounds
        public void PlayGameSound(SoundKind soundKind)
        {
            MainWindow.MediaPlayer = new MediaPlayer();
            switch (soundKind)
            {
                case SoundKind.Move:
                    MainWindow.MediaPlayer.Open(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(),"Sounds/Move.mp3")));
                    break;
                case SoundKind.Check:
                    MainWindow.MediaPlayer.Open(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Sounds/Move.mp3")));
                    break;
                case SoundKind.Caption:
                    MainWindow.MediaPlayer.Open(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Sounds/Caption.mp3")));
                    break;
                case SoundKind.Rooking:
                    MainWindow.MediaPlayer.Open(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Sounds/Rooking.mp3")));
                    break;
            }
            MainWindow.MediaPlayer.Play();
        }
        #endregion
    }
}
