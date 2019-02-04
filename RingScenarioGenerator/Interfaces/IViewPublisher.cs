using System.Collections.Generic;
using System.Threading;
using System.Windows.Media;
using RingScenarioGenerator.ViewModel;

namespace RingScenarioGenerator
{
    public interface IViewPublisher
    {
        void UpdateAllLeds(List<Brush> colors);
    }
}