using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessGame
{
    internal class EnPassantInfo
    {
        public EnPassantInfo()
        {
            IsPassant = false;
            ShowPassantMove=false;
            EnPassantActived=false;
            Pos=new Point(0,0);
            Pos=new Point(0,0);
        }
        public bool IsPassant { get; set; }
        public Point Pos { get; set; }
        public bool ShowPassantMove {  get; set; }
        public bool EnPassantActived {  get; set; }
    }
}
