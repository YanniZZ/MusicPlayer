//- A.L2.Player1/1. Player Skin
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class ColorSkin : Skin
    {
        public ColorSkin(string color)
        {
            ConsoleColor getcolor;
            string color1;
            if (Enum.TryParse(color, out getcolor)) Console.ForegroundColor = getcolor;
            else Console.WriteLine("Unknown Color");
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Render(string text)
        {
            Console.Write(Console.ForegroundColor);
        }

    }
}