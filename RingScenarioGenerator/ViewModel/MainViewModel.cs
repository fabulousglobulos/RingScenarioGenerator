using RingScenarioGenerator.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace RingScenarioGenerator.ViewModel
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        public const int TOTAL_LED = 61;

        Random rd = new Random();

        public ICommand OnMyButtonClick { get; set; }

        public MainViewModel()
        {
            var defaultbrush = BrushHelper.BuildBrush(255, 0, 0);
            var defaultColors = new List<Brush>();
            for (int i = 0; i < TOTAL_LED; i++)
            {
                defaultColors.Add(defaultbrush);
            }
            UpdateAllLeds(defaultColors);


            OnMyButtonClick = new RelayCommand(cmd => OnMyButtonClickImpl());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
            {
                var args = new PropertyChangedEventArgs(property);
                handlers(this, args);
            }
        }

        Task runingTask = null;
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token;


        public async void OnMyButtonClickImpl()
        {
            if (runingTask != null)
            {
                if (source != null)
                {
                    source.Cancel();
                }
                runingTask = null;
            }
            else
            {
                source = new CancellationTokenSource();
                token = source.Token;

                Action action = new Action(() =>
                {
                    try
                    {
                        //tail();
                        Aleatoire();
                    }
                    catch (OperationCanceledException)
                    {

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.ToString());
                    }
                });

                runingTask = Task.Run(action, token);
            }
        }

        public void tail()
        {
            int head = 0;
            bool running = true;

            while (running)
            {
                Application.Current.Dispatcher.Invoke(() =>
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

                   UpdateAllLeds(colors);
               });

                token.ThrowIfCancellationRequested();
                head++;
                if (head > TOTAL_LED)
                {
                    head = 0;
                }
                System.Threading.Thread.Sleep(100);
            }
        }


        public  void Aleatoire()
        {
            for (int loopi = 0; loopi < 1000; loopi++)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var colors = new List<Brush>();
                    for (int i = 0; i < TOTAL_LED; i++)
                    {
                        var random = getRandomBrush();
                        colors.Add(random);
                    }

                    UpdateAllLeds(colors);
                });

                token.ThrowIfCancellationRequested();
                System.Threading.Thread.Sleep(100);
            }
        }

        public void UpdateAllLeds(List<Brush> colors)
        {
            Brush1_1 = colors[00];
            Brush1_2 = colors[01];
            Brush1_3 = colors[02];
            Brush1_4 = colors[03];
            Brush1_5 = colors[04];
            Brush1_6 = colors[05];
            Brush1_7 = colors[06];
            Brush1_8 = colors[07];
            Brush1_9 = colors[08];
            Brush1_10 = colors[9];
            Brush1_11 = colors[10];
            Brush1_12 = colors[11];
            Brush1_13 = colors[12];
            Brush1_14 = colors[13];
            Brush1_15 = colors[14];
            Brush1_16 = colors[15];
            Brush1_17 = colors[16];
            Brush1_18 = colors[17];
            Brush1_19 = colors[18];
            Brush1_20 = colors[19];
            Brush1_21 = colors[20];
            Brush1_22 = colors[21];
            Brush1_23 = colors[22];
            Brush1_24 = colors[23];

            Brush2_1 = colors[24];
            Brush2_2 = colors[25];
            Brush2_3 = colors[26];
            Brush2_4 = colors[27];
            Brush2_5 = colors[28];
            Brush2_6 = colors[29];
            Brush2_7 = colors[30];
            Brush2_8 = colors[31];
            Brush2_9 = colors[32];
            Brush2_10 = colors[33];
            Brush2_11 = colors[34];
            Brush2_12 = colors[35];
            Brush2_13 = colors[36];
            Brush2_14 = colors[37];
            Brush2_15 = colors[38];
            Brush2_16 = colors[39];

            Brush3_1 = colors[40];
            Brush3_2 = colors[41];
            Brush3_3 = colors[42];
            Brush3_4 = colors[43];
            Brush3_5 = colors[44];
            Brush3_6 = colors[45];
            Brush3_7 = colors[46];
            Brush3_8 = colors[47];
            Brush3_9 = colors[48];
            Brush3_10 = colors[49];
            Brush3_11 = colors[50];
            Brush3_12 = colors[51];

            Brush4_1 = colors[52];
            Brush4_2 = colors[53];
            Brush4_3 = colors[54];
            Brush4_4 = colors[55];
            Brush4_5 = colors[56];
            Brush4_6 = colors[57];
            Brush4_7 = colors[58];
            Brush4_8 = colors[59];

            Brush5_1 = colors[60];

        }

        private Brush getRandomBrush()
        {
            int r = rd.Next(0, 255);
            int g = rd.Next(0, 255);
            int b = rd.Next(0, 255);
            return BrushHelper.BuildBrush(r, g, b);
        }


    




        //        private void generateDefinition()
        //        {
        //            string final = string.Empty;
        //            for (int i = 1; i <= 24; i++)
        //            {
        //                final += Generate("1_" + i);

        //            }

        //            for (int i = 1; i <= 16; i++)
        //            {
        //                final += Generate("2_" + i);

        //            }

        //            for (int i = 1; i <= 12; i++)
        //            {
        //                final += Generate("3_" + i);

        //            }

        //            for (int i = 1; i <= 8; i++)
        //            {
        //                final += Generate("4_" + i);

        //            }

        //            final += Generate("5_1");
        //        }



        //        private string Generate(string template)
        //        {
        //            return @"private Brush _b" + template + @";

        //        public Brush Brush" + template + @"
        //        {
        //            get { return _b" + template + @"; }
        //            set
        //            {
        //                if (value != _b" + template + @")
        //                {
        //                    _b" + template + @" = value;
        //                    OnPropertyChanged(""Brush" + template + @""");
        //                }
        //            }
        //        } 


        //";
        //        }

    }
}
