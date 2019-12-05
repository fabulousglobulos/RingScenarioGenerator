using RingScenarioGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RingScenarioGenerator.Model.Scenarii
{
    public abstract class AbstractScenario
    {
        /// <summary>
        /// 61 = all rings + unitary
        /// 60 = all rings NO unitary
        /// </summary>
        public const int TOTAL_LED = 60; //24+16+12+8

        abstract public void Animate(IViewPublisher publisher, CancellationToken token);

        protected static Action WaitAction = () => Thread.Sleep(100);
        protected static Action<int> WaitActionCustom = (a) => Thread.Sleep(a);

        public  static Action<Action> DispatcherInvocker = (action) => Application.Current.Dispatcher.Invoke(action);

    }
}
