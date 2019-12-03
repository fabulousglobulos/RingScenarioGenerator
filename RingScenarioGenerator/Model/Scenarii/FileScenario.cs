using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using RingScenarioGenerator.Helper;

namespace RingScenarioGenerator.Model.Scenarii
{
    public class FileScenario : AbstractScenario
    {
        public override void Animate(IViewPublisher publisher, CancellationToken token)
        {
            string path = string.Empty;

            MainWindow.MainDispatcher.Invoke(() =>
                    {
                        FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            path = openFileDialog.SelectedPath;
                        }
                    });


            if (!string.IsNullOrEmpty(path))
            {
                var files = Directory.GetFiles(path);

                do
                {
                    foreach (var file in files)
                    {

                        var rows = File.ReadAllLines(file);
                        foreach (string row in rows)
                        {

                            if (row.Length >= (TOTAL_LED * 3 * 3)) // because 3 colors RGB , each color encoded on 3 char
                            {

                                DispatcherInvocker(() =>
                                {
                                    var colors = new List<Brush>();
                                    for (int id = 0; id < TOTAL_LED; id++)
                                    {
                                        var red = Convert.ToInt32(row.Substring(id * 9, 3));
                                        var green = Convert.ToInt32(row.Substring(id * 9 + 3, 3));
                                        var blue = Convert.ToInt32(row.Substring(id * 9 + 6, 3));

                                        var b = BrushHelper.BuildBrush(red, green, blue);
                                        colors.Add(b);
                                    }

                                    publisher.UpdateAllLeds(colors);
                                });


                                token.ThrowIfCancellationRequested();
                                WaitAction();
                            }
                        }
                    }
                } while (!token.IsCancellationRequested);

            }
        }
    }
}
