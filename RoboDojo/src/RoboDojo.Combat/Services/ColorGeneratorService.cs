using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RoboDojo.Combat.Services
{
    public class ColorGeneratorService
    {
        private static Random _rand;

        static ColorGeneratorService()
        {
            _rand = new Random();
        }

        public static Color GetNextColor()
        {
            return Color.FromArgb(GetValidRGBValue(), GetValidRGBValue(), GetValidRGBValue());
        }

        private static int GetValidRGBValue()
        {
            return _rand.Next(0, 255);
        }
    }
}
