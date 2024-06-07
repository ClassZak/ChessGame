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

namespace ChessGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board _board;
        public MainWindow()
        {
            InitializeComponent();
            RunGame();
            Thread thread = new Thread(UIUpdate);
            thread.Start();
        }
        public void RunGame()
        {
            _board= new Board(this.Board);
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
                Thread.Sleep(50);
            }
        }
    }
}
