using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinScenarioGenerator.UnitTests
{
    [TestClass]
    public class GenerateBindingTest
    {


        [TestMethod]
        private void generateDefinition()
        {
            string final = string.Empty;
            for (int i = 1; i <= 24; i++)
            {
                final += Generate("1_" + i);

            }

            for (int i = 1; i <= 16; i++)
            {
                final += Generate("2_" + i);

            }

            for (int i = 1; i <= 12; i++)
            {
                final += Generate("3_" + i);

            }

            for (int i = 1; i <= 8; i++)
            {
                final += Generate("4_" + i);

            }

            final += Generate("5_1");
        }



        private string Generate(string template)
        {
            return @"private Brush _b" + template + @";

                public Brush Brush" + template + @"
                {
                    get { return _b" + template + @"; }
                    set
                    {
                        if (value != _b" + template + @")
                        {
                            _b" + template + @" = value;
                            OnPropertyChanged(""Brush" + template + @""");
                        }
                    }
                } 


        ";
        }

    }
}
