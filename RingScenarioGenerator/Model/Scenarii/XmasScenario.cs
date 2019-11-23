using RingScenarioGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Media;

namespace RingScenarioGenerator.Model.Scenarii
{
    public class XmasScenario : AbstractScenario
    {
        private Random rd = new Random();

        public override void Animate(IViewPublisher publisher, CancellationToken token)
        {
            for (int loopi = 0; loopi < 1000; loopi++)
            {
                DispatcherInvocker(() =>
                {
                    var colors = new List<Brush>();
                    for (int i = 0; i < TOTAL_LED; i++)
                    {
                        var green = BrushHelper.BuildBrush(0, 255, 0);
                        colors.Add(green);
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        var ind = rd.Next(0, TOTAL_LED);
                        colors[ind] = BrushHelper.BuildBrush(255, 255, 255);
                    }

                    publisher.UpdateAllLeds(colors);
                });

                token.ThrowIfCancellationRequested();
                WaitAction();
            }
        }
    }
}
