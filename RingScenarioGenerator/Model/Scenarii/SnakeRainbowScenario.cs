using RingScenarioGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Media;


namespace RingScenarioGenerator.Model.Scenarii
{

    public class SnakeRainbowScenario : AbstractScenario
    {
        public override void Animate(IViewPublisher publisher, CancellationToken token)
        {
            int step = 100;

            var colorsKey = Enumerable.Range(0, step).Select(x => x * (1530 / step)).OrderByDescending(x => x).ToList();

            int i = 0;

            while (true)
            {
                DispatcherInvocker(() =>
                             {
                                 var colors = new List<Brush>();
                                 for (int led_i = 0; led_i < TOTAL_LED; led_i++)
                                 {
                                     int indice = i + led_i;
                                     if (indice >= step)
                                     {
                                         indice = indice - step;
                                     }
                                     colors.Add(BrushHelper.RGBRadiant(colorsKey[indice]));
                                 }

                                 publisher.UpdateAllLeds(colors);
                             });

                token.ThrowIfCancellationRequested();

                WaitActionCustom(50);

                i++;
                if (i > step)
                { i = 0; }
            }
        }

    }
}
