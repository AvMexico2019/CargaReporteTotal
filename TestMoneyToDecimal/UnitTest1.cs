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
            Assert.AreEqual((decimal)666666333033.05, Program.DineroADecimal(0, "$666,666,333,033.05"));
            Assert.AreEqual((decimal)333033.05, Program.DineroADecimal(0, "$333,033.05"));
            Assert.AreEqual((decimal)0.0, Program.DineroADecimal(0, "$0.00"));
            Assert.AreEqual((decimal)34.5, Program.DineroADecimal(0, "34.5"));
            Assert.AreEqual((decimal)333333333.03, Program.DineroADecimal(0, "$333,333,333.03"));
            Assert.AreEqual((decimal)0.0, Program.DineroADecimal(0, ""));
            Assert.AreEqual((decimal)0.0, Program.DineroADecimal(0, null));
            Assert.AreEqual((decimal)0.0, Program.DineroADecimal(0, string.Empty));
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

        [TestMethod]
        public void ExcelNumeroADecimal1()
        {
            Assert.AreEqual((decimal) 0.0, Program.ExcelNumeroADecimal(0, string.Empty));
        }

        [TestMethod]
        public void ExcelNumeroADecimal2()
        {
            Assert.AreEqual((decimal)0.0, Program.ExcelNumeroADecimal(0, ""));
        }

        [TestMethod]
        public void ExcelNumeroADecimal3()
        {
            Assert.AreEqual((decimal)0.0, Program.ExcelNumeroADecimal(0, null));
        }

        [TestMethod]
        public void ExcelNumeroADecimal4()
        {
            Assert.AreEqual((decimal)333333333.0, Program.ExcelNumeroADecimal(0, "  $333,333,333.00 "));
        }

        [TestMethod]
        public void ExcelNumeroADecimal5()
        {
            Assert.AreEqual((decimal)333333333.0, Program.ExcelNumeroADecimal(0, @" \ $333,333,333.00 "));
        }

        [TestMethod]
        public void ExcelNumeroADecimal6()
        {
            Assert.AreEqual((decimal)333333333.0, Program.ExcelNumeroADecimal(0, @" \ $333,333,333.00"" "));
        }

        [TestMethod]
        public void ExcelNumeroADouble1()
        {
            Assert.AreEqual((double)0.0, Program.ExcelNumeroADouble(0, string.Empty));
        }

        [TestMethod]
        public void ExcelNumeroADouble2()
        {
            Assert.AreEqual((double)0.0, Program.ExcelNumeroADouble(0, ""));
        }

        [TestMethod]
        public void ExcelNumeroADouble3()
        {
            Assert.AreEqual((double)0.0, Program.ExcelNumeroADouble(0, null));
        }

        [TestMethod]
        public void ExcelNumeroADouble4()
        {
            Assert.AreEqual((double)333333333.0, Program.ExcelNumeroADouble(0, "  $333,333,333.00 "));
        }

        [TestMethod]
        public void ExcelNumeroADouble5()
        {
            Assert.AreEqual((double)333333333.0, Program.ExcelNumeroADouble(0, @" \ $333,333,333.00 "));
        }

        [TestMethod]
        public void ExcelNumeroADouble6()
        {
            Assert.AreEqual((double)333333333.0, Program.ExcelNumeroADouble(0, @" \ $333,333,333.00"" "));
        }
    }
}
