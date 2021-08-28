using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Converter;
using System.Collections.Generic;

namespace ConverterTest
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void GetUnitTypes_ReturnsCorrectList()
        {
            ConverterClass converterClass = new ConverterClass();
            List<String> receivedList = converterClass.getUnitTypes();
            List<String> expectedList = new List<String> { "Length", "Weight" };
            CollectionAssert.AreEqual(expectedList, receivedList);
        }
        [TestMethod]
        public void GetUnits_ReturnsCorrectList()
        {
            ConverterClass converterClass = new ConverterClass();
            Unit unitObject = new Unit();
            List<Unit> receivedList = converterClass.getUnits("Weight");
            List<Unit> expectedList = new List<Unit>();
            unitObject = new Unit("mg", 0.000001);
            expectedList.Add(unitObject);
            unitObject = new Unit("g", 0.001);
            expectedList.Add(unitObject);
            unitObject = new Unit("kg", 1);
            expectedList.Add(unitObject);
            unitObject = new Unit("t", 1000);
            expectedList.Add(unitObject);
            unitObject = new Unit("lbs", 0.453592);
            expectedList.Add(unitObject);
            unitObject = new Unit("oz", 0.0283495);
            expectedList.Add(unitObject);
            CollectionAssert.AreEqual(expectedList, receivedList);
        }
        [TestMethod]
        public void AddUnits_Works()
        {
            ConverterClass converterClass = new ConverterClass();
            List<Unit> units = new List<Unit>();
            units.Add(new Unit("MKD", 67.5));
            converterClass.addUnits("Currencies", units);

            List<String> receivedTypes = converterClass.getUnitTypes();
            CollectionAssert.Contains(receivedTypes, "Currencies");

            List<Unit> receivedUnits = converterClass.getUnits("Currencies");
            CollectionAssert.AreEqual(units, receivedUnits);
        }
        [TestMethod]
        public void Convert_Works()
        {
            ConverterClass converterClass = new ConverterClass();
            Unit fromUnit = new Unit("m", 1);
            Unit toUnit = new Unit("km", 1000);
            double value = 21;
            double result = 0.021;
            Assert.AreEqual(result, converterClass.convert(fromUnit.name, toUnit.name, value, "Length"));
        }
    }
}
