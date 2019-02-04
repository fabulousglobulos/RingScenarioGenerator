using RingScenarioGenerator.Helper;
using RingScenarioGenerator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RingScenarioGenerator
{

    public class ScenarioGenerator : IScenarioGenerator
    {
        public const int TOTAL_LED = 61;

        Random rd = new Random();


        public static Action WaitAction = () => System.Threading.Thread.Sleep(100);

        public static Action<Action> DispatcherInvocker = (action) => Application.Current.Dispatcher.Invoke(action);


        public void Aleatoire(IViewPublisher publisher, CancellationToken token)
        {
            for (int loopi = 0; loopi < 1000; loopi++)
            {
                // Application.Current.Dispatcher.Invoke(() =>
                DispatcherInvocker(()=>
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

        private Brush getRandomBrush()
        {
            int r = rd.Next(0, 255);
            int g = rd.Next(0, 255);
            int b = rd.Next(0, 255);
            return BrushHelper.BuildBrush(r, g, b);
        }

        public void Tail(IViewPublisher publisher, CancellationToken token)
        {
            int head = 0;
            bool running = true;

            int loop = 0;

            while (loop <1000)
            {
                //kApplication.Current.Dispatcher.Invoke(() =>
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
