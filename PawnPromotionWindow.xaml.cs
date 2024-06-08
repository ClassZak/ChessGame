using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace ChessGame
{
    /// <summary>
    /// Логика взаимодействия для PawnPromotionWindow.xaml
    /// </summary>
    public partial class PawnPromotionWindow : Window
    {
        bool Selected = false;
        public FigureType SelectedFigureType;


        public PawnPromotionWindow()
        {
            InitializeComponent();
        }
        public PawnPromotionWindow(FigureGroup group) : this()
        {
            if(group==FigureGroup.Black)
            {
                image0.Source =
                new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(),"FigureImages", "bQ.png")));
                image1.Source =
                new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "FigureImages", "bR.png")));
                image2.Source =
                new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "FigureImages", "bB.png")));
                image3.Source =
                new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "FigureImages", "bN.png")));
            }
        }

        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Selected=true;
            switch(this.FigureList.SelectedIndex)
            {
                case 0:
                    SelectedFigureType = FigureType.Queen;
                    break;
                case 1:
                    SelectedFigureType = FigureType.Rock;
                    break;
                case 2:
                    SelectedFigureType = FigureType.Bishop;
                    break;
                case 3:
                    SelectedFigureType = FigureType.Knight;
                    break;
            }
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !Selected;
        }
    }
}
