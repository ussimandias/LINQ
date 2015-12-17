using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQFundamentals;

namespace LINQUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VegetableFarm vf = new VegetableFarm();

            var greeting = vf.sayHello("Banana");

            Assert.AreEqual(greeting, "Hello! Banana");
        }
    }
}
