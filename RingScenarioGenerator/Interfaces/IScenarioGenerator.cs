using System.Threading;
using RingScenarioGenerator.ViewModel;

namespace RingScenarioGenerator
{
    public interface IScenarioGenerator
    {
        void Aleatoire(IViewPublisher publisher, CancellationToken token);
        void Tail(IViewPublisher publisher, CancellationToken token);
        void Christmas(IViewPublisher publisher, CancellationToken token);
    }
}