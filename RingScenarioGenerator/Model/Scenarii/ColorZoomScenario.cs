using RingScenarioGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Media;

namespace RingScenarioGenerator.Model.Scenarii
{
    public class ColorZoomScenario : AbstractScenario
    {
        public override void Animate(IViewPublisher publisher, CancellationToken token)
        {
            Brush colorRing1 = null;
            Brush colorRing2 = null;
            Brush colorRing3 = null;
            Brush colorRing4 = null;


            DispatcherInvocker(() =>
             {
                 colorRing1 = BrushHelper.BuildBrush(0, 0, 0);
                 colorRing2 = BrushHelper.BuildBrush(0, 0, 0);
                 colorRing3 = BrushHelper.BuildBrush(0, 0, 0);
                 colorRing4 = BrushHelper.BuildBrush(0, 0, 0);
             });

            while (true)
            {
                for (int loopi = 1; loopi <= 1530; loopi = loopi + 30)
                {

                    DispatcherInvocker(() =>
                    {
                        var colors = new List<Brush>();

                        colorRing4 = colorRing3;
                        colorRing3 = colorRing2;
                        colorRing2 = colorRing1;
                        colorRing1 = BrushHelper.RGBRadiant(loopi);

                        colors.AddRange(Enumerable.Repeat(colorRing4, 24).ToList());
                        colors.AddRange(Enumerable.Repeat(colorRing3, 16).ToList());
                        colors.AddRange(Enumerable.Repeat(colorRing2, 12).ToList());
                        colors.AddRange(Enumerable.Repeat(colorRing1, 8).ToList());

                        publisher.UpdateAllLeds(colors);
                    });

                    token.ThrowIfCancellationRequested();
                    WaitActionCustom(100);
                }
            }
        }

    }
}