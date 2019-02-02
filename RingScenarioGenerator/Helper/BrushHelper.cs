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

    }
}