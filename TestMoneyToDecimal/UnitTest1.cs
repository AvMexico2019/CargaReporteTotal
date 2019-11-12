using Microsoft.VisualStudio.TestTools.UnitTesting;
using CargaReporteTotal;

namespace Utilerias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DineroADecimal()
        {
            Assert.AreEqual((decimal)666666333033.05, Program.DineroADecimal("$666,666,333,033.05"));
            Assert.AreEqual((decimal)333033.05, Program.DineroADecimal("$333,033.05"));
            Assert.AreEqual((decimal)0.0, Program.DineroADecimal("$0.0"));
            Assert.AreEqual((decimal)34.5, Program.DineroADecimal("34.5"));
            Assert.AreEqual((decimal)333333333.03, Program.DineroADecimal("$333,333,333.03"));
            Assert.AreEqual((decimal)0.0, Program.DineroADecimal(""));
            Assert.AreEqual((decimal)0.0, Program.DineroADecimal(null));
            Assert.AreEqual((decimal)0.0, Program.DineroADecimal(string.Empty));
        }
        
        [TestMethod]
        public void IsExcelNull1()
        {
            Assert.AreEqual(true, Program.IsExcelNull(""));
        }

        [TestMethod]
        public void IsExcelNull2()
        {
            Assert.AreEqual(false, Program.IsExcelNull("1"));
        }

        [TestMethod]
        public void IsExcelNull3()
        {
            Assert.AreEqual(true, Program.IsExcelNull(null));
        }

        [TestMethod]
        public void IsExcelNull4()
        {
            Assert.AreEqual(true, Program.IsExcelNull("NULL"));
        }

        [TestMethod]
        public void IsExcelNull5()
        {
            Assert.AreEqual(true, Program.IsExcelNull("     "));
        }

        [TestMethod]
        public void IsExcelNull6()
        {
            Assert.AreEqual(true, Program.IsExcelNull(string.Empty));
        }
    }
}
