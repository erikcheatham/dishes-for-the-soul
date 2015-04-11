using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticumDishes;

namespace PracticumDishesTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void TestMain()
        {
            //Build Object For Program Wide Inputs
            ValueObjects.Inputs i = new ValueObjects.Inputs();

            //NORMALS List
            i.input = "morning, 1, 2, 3";
            string aResult1 = OutputOperations.FormatOutput(i).output;
            string eResult1 = "eggs, toast, coffee";
            Assert.AreEqual(eResult1, aResult1);

            i.input = "morning, 2, 1, 3";
            string aResult2 = OutputOperations.FormatOutput(i).output;
            string eResult2 = "eggs, toast, coffee";
            Assert.AreEqual(eResult2, aResult2);

            i.input = "morning, 1, 2, 3, 4";
            string aResult3 = OutputOperations.FormatOutput(i).output;
            string eResult3 = "eggs, toast, coffee, error";
            Assert.AreEqual(eResult3, aResult3);

            i.input = "night, 1, 2, 3, 4";
            string aResult4 = OutputOperations.FormatOutput(i).output;
            string eResult4 = "steak, potato, wine, cake";
            Assert.AreEqual(eResult4, aResult4);

            //MULTIPLES list

            i.input = "morning, 1, 2, 3, 3, 3";
            string aResult5 = OutputOperations.FormatOutput(i).output;
            string eResult5 = "eggs, toast, coffee(x3)";
            Assert.AreEqual(eResult5, aResult5);

            i.input = "night, 1, 2, 2, 4";
            string aResult6 = OutputOperations.FormatOutput(i).output;
            string eResult6 = "steak, potato(x2), cake";
            Assert.AreEqual(eResult6, aResult6);

            //ERROR list

            i.input = "night, 1, 2, 3, 5";
            string aResult7 = OutputOperations.FormatOutput(i).output;
            string eResult7 = "steak, potato, wine, error";
            Assert.AreEqual(eResult7, aResult7);

            i.input = "night, 1, 1, 2, 3, 5";
            string aResult8 = OutputOperations.FormatOutput(i).output;
            string eResult8 = "steak, error";
            Assert.AreEqual(eResult8, aResult8);

            PracticumDishes.OutputOperations.FormatOutput(i);
        }
    }
}
