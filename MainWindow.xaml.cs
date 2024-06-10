using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ChessGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board _board;
        public static MediaPlayer MediaPlayer;
        private string[] TurnDescription = { "Ход белых", "Ход чёрных" };
        StringBuilder movesDesc = new StringBuilder();
        uint moveNumber = 0;
        public MainWindow()
        {
            InitializeComponent();
            RunGame();
            Thread thread = new Thread(UIUpdate);
            thread.Start();
            InitCells();
        }
        public void RunGame()
        {
            _board= new Board(this.Board);
            _board.FigureCaptured += new EventHandler(FigureCaptured);
            _board.FigureMoved += new EventHandler(ChangeMoveDescriptionHandler);
            _board.GameEndedEvent += new EventHandler(GameEndedEventHandler);
            _board.SendDescription += new EventHandler(DescriptionHandler);
        }


        private void UIUpdate()
        {
            while(true)
            {
                try
                {
                    Dispatcher.Invoke(new Action(() => { _board.UpdateChessImages(this.Board); }));
                }
                catch
                {
                    return;
                }
                Thread.Sleep(11);
            }
        }


        public void CellPressed(object sender, MouseButtonEventArgs e)
        {
            
            _board.ResetSelection();
            //MessageBox.Show("Клетка нажата");
        }

        private void InitCells()
        {
            CellsGrid.Children.Clear();

            uint delta = 0;
            
            for (uint i=0;i!=64;++i)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.MouseDown += new MouseButtonEventHandler(CellPressed);

                if ((i) % 8 == 0)
                    ++delta;

                uint compIndex = delta + i;
                

                if (compIndex %2 == 0)
                    rectangle.Fill = new SolidColorBrush(Colors.Black);
                else
                    rectangle.Fill = new SolidColorBrush(Colors.White);

                CellsGrid.Children.Add(rectangle);
            }
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            _board.ResetGame(Board);
            InitCells();
            CapturedWhiteGrid.Children.Clear();
            CapturedBlackGrid.Children.Clear();
            ChangeMoveDescription(FigureGroup.White);
            EndGameMenuButton.IsEnabled = true;

            movesDesc.Clear();
            moveNumber = 0;
            this.MoveDescrTB.Text = "";
        }

        private void ExitGame(object sender, RoutedEventArgs e)
        {
            if(!(MediaPlayer is null))
                MediaPlayer.Stop();
            this.Close();
        }

        private void EndGame(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Игра завершена!");

            MessageBoxResult result = MessageBox.Show("Начать сначала?", "Новая игра", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                NewGame(sender, e);
        }

        private void FigureCaptured(object sender, EventArgs e)
        {
            ChessGame.Board board=(ChessGame.Board)sender;
            ChessFigure figure=((FigureCapturedEventArg)(e)).ChessFigure;


            if(!(figure is null || board is null))
            {
                System.Windows.Controls.Image image=
                    ImageBuilder.CreateImage(ImageBuilder.GetImageName(figure.FigureGroup,figure.FigureType));

                if(figure.FigureGroup==FigureGroup.White)
                    CapturedWhiteGrid.Children.Add(image);
                else
                    CapturedBlackGrid.Children.Add(image);
            }
        }
        private void ChangeMoveDescriptionHandler(object sender, EventArgs eventArgs)
        {
            ChangeMoveDescription(((ChessGame.Board)(sender)).Turn);
        }
        private void ChangeMoveDescription(FigureGroup turn)
        {
            if(turn == FigureGroup.White)
            {
                DescriptionTable.Text = TurnDescription[0];
                DescriptionTable.Foreground = new SolidColorBrush(Colors.White);
                DescriptionTable.FontSize = 20;
                DescriptionTable.FontWeight = FontWeights.Bold;
            }
            else
            {
                DescriptionTable.Text = TurnDescription[1];
                DescriptionTable.Foreground = new SolidColorBrush(Colors.Black);
                DescriptionTable.FontSize = 20;
                DescriptionTable.FontWeight = FontWeights.Bold;
            }
        }

        private void GameEndedEventHandler(object sender,EventArgs eventArgs)
        {
            GameEndedEventArgs gameEndedEventArgs= eventArgs as GameEndedEventArgs;

            if (gameEndedEventArgs is null)
                return;

            DescriptionTable.Text= gameEndedEventArgs.Message;
            DescriptionTable.Foreground = new SolidColorBrush
            (
                gameEndedEventArgs.IsDraw ? Colors.LightGray :
                (gameEndedEventArgs.WinGroup == FigureGroup.White ? Colors.Black: Colors.White)
            );

            DescriptionTable.FontSize = 20;
            DescriptionTable.FontWeight = FontWeights.Bold;
            EndGameMenuButton.IsEnabled = false;
        }

        void DescriptionHandler(object sender,EventArgs eventArgs)
        {
            MoveDescriptionEventArgs moveDescriptionEventArgs= eventArgs as MoveDescriptionEventArgs;

            if (moveDescriptionEventArgs is null) return;

            movesDesc.AppendLine((++moveNumber).ToString() + $" {moveDescriptionEventArgs.MoveDescript}");
            this.MoveDescrTB.Text=movesDesc.ToString();
        }
    }
}
