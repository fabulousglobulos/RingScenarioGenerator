using Microsoft.VisualStudio.TestTools.UnitTesting;
using RingScenarioGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using System.Windows.Media;

namespace RinScenarioGenerator.UnitTests
{

    [TestClass]
    public class ScenarioGeneratorTests
    {
        IViewPublisher _publisherMocker = A.Fake<IViewPublisher>();

        //[TestMethod]
        //public void Should_generate_random()
        //{
        //    ScenarioGenerator model = new ScenarioGenerator();

        //    int numbercall = 0;
        //    ScenarioGenerator.WaitAction = () => numbercall++;
        //    ScenarioGenerator.DispatcherInvocker = (action) => action();

        //    model.Aleatoire(_publisherMocker, new System.Threading.CancellationToken());

        //    Assert.AreEqual(numbercall, 1000);
        //    A.CallTo(() => _publisherMocker.UpdateAllLeds(A<List<Brush>>.Ignored)).MustHaveHappened(1000, Times.Exactly);

        //}



        //[TestMethod]
        //public void Should_generate_tail()
        //{
        //    ScenarioGenerator model = new ScenarioGenerator();

        //    int numbercall = 0;
        //    ScenarioGenerator.WaitAction = () => numbercall++;
        //    ScenarioGenerator.DispatcherInvocker = (action) => action();

        //    model.Tail(_publisherMocker, new System.Threading.CancellationToken());

        //    Assert.AreEqual(numbercall, 1000);
        //    A.CallTo(() => _publisherMocker.UpdateAllLeds(A<List<Brush>>.Ignored)).MustHaveHappened(1000, Times.Exactly);

        //}
    }
}
