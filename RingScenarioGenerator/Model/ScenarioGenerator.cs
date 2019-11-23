using RingScenarioGenerator.Helper;
using RingScenarioGenerator.Model.Scenarii;
using RingScenarioGenerator.ViewModel;
using System;
using System.Collections.Generic;

using System.Threading;


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

            AbstractScenario s = null;
            switch (eScenario)
            {
                case EScenario.Xmas:
                    {
                        s = new XmasScenario();
                        break;
                    }
                case EScenario.Tail:
                    {
                        s = new TailScenario();
                        break;
                    }
                case EScenario.Random:
                default:
                    {
                        s = new RandomScenario();
                        break;
                    }
            }
            _scenarii.Add(eScenario, s);
            return s;

        }

        public void Animate(string scenario, IViewPublisher publisher, CancellationToken token)
        {
            var s = Get(scenario);
            s.Animate(publisher, token);
        }
    }
}
