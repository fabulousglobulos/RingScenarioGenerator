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
    public class SideScenario : AbstractScenario
    {
        List<int> secondRing = new List<int> {      15, 0, 1, 1, 2, 3,
                                                    3, 4, 5, 5, 6, 7,
                                                    7, 8, 9, 9, 10, 11,
                                                    11, 12, 13, 13, 14, 15 };

        List<int> thirdRing = new List<int> {      11, 0, 0, 1, 1, 2,
                                                    2, 3, 3, 4, 4, 5,
                                                    5, 6, 6, 7, 7, 8,
                                                    8, 9, 9, 10, 10, 11 };

        List<int> fourthRing = new List<int> {      7, 7, 7, 0, 0, 0,
                                                    1, 1, 1, 2, 2, 2,
                                                    3, 3, 3, 4, 4, 4,
                                                    5, 5, 5, 6, 6, 6 };

        public override void Animate(IViewPublisher publisher, CancellationToken token)
        {
            do
            {
                for (int i = 0; i < 24; i++)
                {
                    DispatcherInvocker(() =>
                    {
                        //ring 1;
                        int a1 = i;

                        int b1 = i - 1;
                        if (b1 < 0)
                            b1 = b1 + 24;

                        int c1 = i - 2;
                        if (c1 < 0)
                            c1 = c1 + 24;


                        int d1 = i - 3;
                        if (d1 < 0)
                            d1 = d1 + 24;



                        //ring2
                        int a2 = secondRing[a1] + 24;

                        int b2 = a2 - 1;
                        if (b2 <24)
                            b2 = b2 + 16;

                        int c2 = a2 - 2;
                        if (c2 < 24)
                            c2 = c2 + 16;



                        //ring3
                        int a3 = thirdRing[a1] + 24+16;

                        int b3 = a3 - 1;
                        if (b3 < (24+16))
                            b3 = b3 + 12;

                        //ring4

                        int a4 = fourthRing[a1] + 24 + 16 + 12;

                        


                        var brushes = Enumerable.Repeat(0, 60).Select(x => BrushHelper.BuildBrush(0, 0, 0)).ToList();

                        brushes[d1] = BrushHelper.BuildBrush(0, 0, 40);
                        brushes[c1] = BrushHelper.BuildBrush(0, 0, 105);
                        brushes[b1] = BrushHelper.BuildBrush(0, 0, 175);
                        brushes[a1] = BrushHelper.BuildBrush(0, 0, 255);

                        //if(a1 != 0 && a1 != 6 && a1 != 12 && a1 != 18)
                        if (a1 != 4 && a1 != 10 && a1 != 16 && a1 != 22)
                            brushes[c2] = BrushHelper.BuildBrush(0, 0, 55);
                        brushes[b2] = BrushHelper.BuildBrush(0, 0, 150);
                        brushes[a2] = BrushHelper.BuildBrush(0, 0, 255);


                        brushes[b3] = BrushHelper.BuildBrush(0, 0, 120);
                        brushes[a3] = BrushHelper.BuildBrush(0, 0, 255);

                        brushes[a4] = BrushHelper.BuildBrush(0, 0, 255);

                        publisher.UpdateAllLeds(brushes);
                    });

                    token.ThrowIfCancellationRequested();
                    WaitActionCustom(30);


                }
            } while (!token.IsCancellationRequested);
        }



    }
}