using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ChessGame
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, SolidColorBrush backgroundBrush)
        {
            TextRange rangeOfText1 = new TextRange(box.Document.ContentEnd, box.Document.ContentEnd);
            rangeOfText1.Text = text;
            rangeOfText1.ApplyPropertyValue(TextElement.ForegroundProperty, backgroundBrush);
        }
    }
}
