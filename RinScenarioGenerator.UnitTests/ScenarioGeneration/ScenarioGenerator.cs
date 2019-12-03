using Microsoft.VisualStudio.TestTools.UnitTesting;
using RingScenarioGenerator.Model.Scenarii;
using System;
using System.Collections.Generic;
using System.IO;

namespace RinScenarioGenerator.UnitTests
{
    [TestClass]
    public class ScenarioGenerator
    {
        [TestMethod]
        public void ShouldGenerateTailScenario()
        {
            List<string> rows = new List<string>();

            char zero = '0';
            string light = "050000000150000000250000000"; // 3 leds


            //for (int i = 0; i <= (  AbstractScenario.TOTAL_LED   - light.Length/9)                ; i++)
            for (int i = 0; i <= AbstractScenario.TOTAL_LED; i++)
            {
                string left = light.PadLeft(light.Length + i * 9, zero);
                string right = left.PadRight(AbstractScenario.TOTAL_LED * 9, zero);
                rows.Add(right);
            }

            string path = @"e:\tail.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllLines(path, rows);
        }
    }
}
