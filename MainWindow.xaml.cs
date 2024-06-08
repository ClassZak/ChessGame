﻿using System;
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

namespace ChessGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board _board;
        public static MediaPlayer MediaPlayer;
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
            _board.BoardRotated += new EventHandler(RotateBoard);
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

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            _board.ResetGame(Board);
        }

        private void RotateBoard(object sender, EventArgs e)
        {
            ScaleTransform scaleTransform = new ScaleTransform(1, (((Board)(sender)).Turn == FigureGroup.Black) ? -1 : 1);
            CellsGrid.LayoutTransform= scaleTransform;
        }
    }
}
