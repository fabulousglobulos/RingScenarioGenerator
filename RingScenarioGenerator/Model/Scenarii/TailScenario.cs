using RingScenarioGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Media;

namespace RingScenarioGenerator.Model.Scenarii
{
    public class TailScenario : AbstractScenario
    {
        public override void Animate(IViewPublisher publisher, CancellationToken token)
        {
            int head = 0;
            bool running = true;

            int loop = 0;

            while (loop < 1000)
            {
                DispatcherInvocker(() =>
                {
                    var colors = new List<Brush>();
                    for (int i = 0; i < TOTAL_LED; i++)
                    {
                        int blue = 0;
                        if (i == head) { blue = 50; }
                        if ((i - 1) == head) { blue = 150; }
                        if ((i - 2) == head) { blue = 255; }

                        colors.Add(BrushHelper.BuildBrush(0, 0, blue));
                    }

                    publisher.UpdateAllLeds(colors);
                });

                token.ThrowIfCancellationRequested();
                head++;
                if (head > TOTAL_LED)
                {
                    head = 0;
                }
                WaitAction();
                loop++;
            }
        }
    }
}
