using RingScenarioGenerator.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Media;

namespace RingScenarioGenerator.Model.Scenarii
{
    public class RandomScenario : AbstractScenario
    {
        private Random rd = new Random();

        private Brush getRandomBrush()
        {
            int r = rd.Next(0, 255);
            int g = rd.Next(0, 255);
            int b = rd.Next(0, 255);
            return BrushHelper.BuildBrush(r, g, b);
        }

        public override void Animate(IViewPublisher publisher, CancellationToken token)
        {
            for (int loopi = 0; loopi < 1000; loopi++)
            {
                DispatcherInvocker(() =>
                {
                    var colors = new List<Brush>();
                    for (int i = 0; i < TOTAL_LED; i++)
                    {
                        var random = getRandomBrush();
                        colors.Add(random);
                    }

                    publisher.UpdateAllLeds(colors);
                });

                token.ThrowIfCancellationRequested();
                WaitAction();
            }
        }
    }
}