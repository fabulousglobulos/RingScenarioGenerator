using System;
using System.Collections.Generic;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RingScenarioGenerator.Helper;
using RingScenarioGenerator.ViewModel;


namespace RinScenarioGenerator.UnitTests
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MainViewModel vm = new MainViewModel();

            var brushes = new List<Brush>();
            for(int i =0; i< MainViewModel.TOTAL_LED; i++)
            {
                brushes.Add(BrushHelper.BuildBrush(i, i, i));
            }

            vm.UpdateAllLeds(brushes);

            SolidColorBrush Solid5_1 = vm.Brush5_1 as SolidColorBrush;
            Assert.AreEqual(MainViewModel.TOTAL_LED-1, Solid5_1.Color.R);
            Assert.AreEqual(MainViewModel.TOTAL_LED - 1, Solid5_1.Color.G);
            Assert.AreEqual(MainViewModel.TOTAL_LED - 1, Solid5_1.Color.B);



        }
    }
}
