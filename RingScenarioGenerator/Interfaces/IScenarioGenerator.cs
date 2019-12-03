using System.Collections.Generic;
using System.Threading;
using System.Windows.Media;
using RingScenarioGenerator.Model.Scenarii;
using RingScenarioGenerator.ViewModel;

namespace RingScenarioGenerator
{
    public interface IScenarioGenerator
    {
        void Animate (string scenario, IViewPublisher publisher, CancellationToken token);

        void SaveToFile(List<List<Brush>> recordedScenario);
    }
}