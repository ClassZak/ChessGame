using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessGame
{
    internal class Statistic
    {
        public const string StatSource = "Statistic.bin";
        public void ReadNumbersFromFile(string filePath= StatSource)
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), filePath)))
            {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write)))
                {
                    writer.Write((uint)10);
                    writer.Write((uint)10);
                    writer.Write((uint)10);

                    writer.Close();
                }

                //Установка атрибута "Скрытый" для файла
                //File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.Hidden);
            }
            else
            {
                using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                {
                    WhiteWons = reader.ReadUInt32();
                    BlackWons = reader.ReadUInt32();
                    Draws = reader.ReadUInt32();

                    reader.Close();
                }
            }
        }
        public void Save(string filePath = StatSource)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write)))
            {
                writer.Write(WhiteWons);
                writer.Write(BlackWons);
                writer.Write(Draws);

                writer.Close();
            }

            //Установка атрибута "Скрытый" для файла
            //File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.Hidden);
        }

        public uint WhiteWons = 0;
        public uint BlackWons = 0;
        public uint Draws = 0;


        public Statistic()
        {

        }
        public Statistic(string filePath= StatSource)
        {
            ReadNumbersFromFile(filePath);
        }
    }
}
