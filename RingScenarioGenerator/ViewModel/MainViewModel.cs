using RingScenarioGenerator.Helper;
using RingScenarioGenerator.Model.Scenarii;
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
using System.Collections.ObjectModel;

namespace RingScenarioGenerator.ViewModel
{
    public partial class MainViewModel : INotifyPropertyChanged, IViewPublisher
    {

        private string _selectedScenario;
        public string SelectedScenario
        {
            get { return _selectedScenario; }
            set
            {
                if (value != this._selectedScenario)
                    _selectedScenario = value;
                this.OnPropertyChanged("SelectedScenario");
            }
        }

        private ObservableCollection<string> _scenarioCollection;
        public ObservableCollection<string> ScenarioCollection
        {
            get { return _scenarioCollection; }
            set
            {
                if (value != this._scenarioCollection)
                    _scenarioCollection = value;
                this.OnPropertyChanged("FileObjectCollection");
            }
        }


        private IScenarioGenerator _scenario = null;

        public ICommand OnMyButtonClick { get; set; }

        public ICommand OnRecordScenearioClick { get; set; }

        public MainViewModel()
        {
            var defaultbrush = BrushHelper.BuildBrush(255, 0, 0);
            var defaultColors = new List<Brush>();
            for (int i = 0; i < AbstractScenario.TOTAL_LED; i++)
            {
                defaultColors.Add(defaultbrush);
            }
            UpdateAllLeds(defaultColors);


            OnMyButtonClick = new RelayCommand(cmd => OnMyButtonClickImpl());
            OnRecordScenearioClick = new RelayCommand(cmd => OnRecordScenearioClickImpl());

            _scenario = new ScenarioGenerator();

            var scenariiList = new ObservableCollection<string>();
            Enum.GetValues(typeof(EScenario)).Cast<EScenario>().ToList().ForEach(x => scenariiList.Add(x.ToString()));
            this.ScenarioCollection = scenariiList;

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

        bool recording = false;
        List<List<Brush>> _scenarioRecordded = new List<List<Brush>>();
        public async void OnRecordScenearioClickImpl()
        {

            if (recording == false)
            {//now we startsaving;
                _scenarioRecordded.Clear();
                recording = true;
            }
            else
            {// stop recording
                recording = false;

                //save it
                Action action = new Action(() =>
                {
                    try
                    {
                        _scenario.SaveToFile(_scenarioRecordded);
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.ToString());
                    }
                });

                Task.Run(action);
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
                        _scenario.Animate(_selectedScenario, this, token);
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


        public void UpdateAllLeds(List<Brush> colors)
        {
            if (recording == true)
            {
                _scenarioRecordded.Add(colors);
            }

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
            if (AbstractScenario.TOTAL_LED > 60)
            {
                Brush5_1 = colors[60];
            }
        }

    }
}
