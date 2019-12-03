using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingScenarioGenerator.Model.Scenarii
{

    //beware the enum value must the same as the scenario definition (the class that implement AbstractScenario)
    // for exemple Xmas  value , will generate XmasScenario...
    //because of reflexion in the ScenarioGenerator
    public enum  EScenario
    {
        File,
        Xmas,
        Tail,
        Random
    }
}
