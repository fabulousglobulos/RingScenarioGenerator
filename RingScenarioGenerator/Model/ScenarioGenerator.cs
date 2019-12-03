using RingScenarioGenerator.Helper;
using RingScenarioGenerator.Model.Scenarii;
using RingScenarioGenerator.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

namespace RingScenarioGenerator
{

    public class ScenarioGenerator : IScenarioGenerator
    {
        private Dictionary<EScenario, AbstractScenario> _scenarii = new Dictionary<EScenario, AbstractScenario>();

        private AbstractScenario Get(string scenario)
        {
            var eScenario = (EScenario)Enum.Parse(typeof(EScenario), scenario);

            if (_scenarii.ContainsKey(eScenario))
            {
                return _scenarii[eScenario];
            }

            AbstractScenario s  = Activator.CreateInstance("RingScenarioGenerator", "RingScenarioGenerator.Model.Scenarii."+scenario+"Scenario") .Unwrap() as AbstractScenario; 

            _scenarii.Add(eScenario, s);
            return s;
        }

        public void Animate(string scenario, IViewPublisher publisher, CancellationToken token)
        {
            var s = Get(scenario);
            s.Animate(publisher, token);
        }


        public void SaveToFile(List<List<Brush>> recordedScenario)
        {
            string path = string.Empty;

            char zero = '0';

            AbstractScenario.DispatcherInvocker.Invoke(() =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save recorded scenario";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                }
            });

            if( !string.IsNullOrEmpty(path))
            {
                List<string> rows = new List<string>();

                foreach(var l in recordedScenario)
                {
                    string row = string.Empty;
                    foreach(var led in l)
                    {
                        AbstractScenario.DispatcherInvocker.Invoke(() =>
                        {
                            var solidbrush = led as SolidColorBrush;
                            if (solidbrush != null)
                            {
                                var red = Convert.ToInt32(solidbrush.Color.R).ToString().PadLeft(3, zero);
                                var green = Convert.ToInt32(solidbrush.Color.G).ToString().PadLeft(3, zero);
                                var blue = Convert.ToInt32(solidbrush.Color.B).ToString().PadLeft(3, zero);
                                row += red;
                                row += green;
                                row += blue;
                            }
                        });
                    }
                    rows.Add(row);
                }

                File.WriteAllLines(path, rows);
            }
        }
    }
}
