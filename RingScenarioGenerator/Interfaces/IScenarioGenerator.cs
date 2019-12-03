using System.Threading;
using RingScenarioGenerator.Model.Scenarii;
using RingScenarioGenerator.ViewModel;

namespace RingScenarioGenerator
{
    public interface IScenarioGenerator
    {
        void Animate (string scenario, IViewPublisher publisher, CancellationToken token);
    }
}