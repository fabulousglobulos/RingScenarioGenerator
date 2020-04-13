using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace RingScenarioGenerator.Helper
{
    public static class BrushHelper
    {
        public static  Brush BuildBrush(int r, int g, int b)
        {
            return new SolidColorBrush(Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b)));
        }

        public static Brush RGBRadiant(int x)
        {
            //http://blog.vermot.net/2011/11/03/generer-un-degrade-en-arc-en-ciel-en-fonction-d-une-valeur-programmatio/
            Brush color;
            int r = 0;
            int g = 0;
            int b = 0;
            if (x >= 0 && x < 255)
            {
                r = 255;
                g = x;
                b = 0;
            }
            if (x >= 255 && x < 510)
            {
                r = 510 - x;
                g = 255;
                b = 0;
            }
            if (x >= 510 && x < 765)
            {
                r = 0;
                g = 255;
                b = x - 510;
            }
            if (x >= 765 && x < 1020)
            {
                r = 0;
                g = 1020 - x;
                b = 255;
            }
            if (x >= 1020 && x < 1275)
            {
                r = x - 1020;
                g = 0;
                b = 255;
            }
            if (x >= 1275 && x <= 1530)
            {
                r = 255;
                g = 0;
                b = 1530 - x;
            }
            color = BrushHelper.BuildBrush(r, g, b);
            return color;
        }
    }
}