using System;
using lemonway.services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lemonway.test
{
    [TestClass]
    public class FibonacciServiceTest
    {

        private static IFibonacciService _fibonacciService;


        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            _fibonacciService = new FibonacciService();
        }

        [DataTestMethod]
        [DataRow(-101, -1)]
        [DataRow(0, -1)]
        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [DataRow(3, 2)]
        [DataRow(4, 3)]
        [DataRow(5, 5)]
        [DataRow(6, 8)]
        [DataRow(7, 13)]
        [DataRow(8, 21)]
        [DataRow(9, 34)]
        [DataRow(10, 55)]
        [DataRow(11, 89)]
        [DataRow(20, 6765)]
        [DataRow(101, -1)]
        public void TestResult(int inputValue, int expectedResult)
        {
            var result = _fibonacciService.GetValue(inputValue);
            Assert.IsTrue(expectedResult == result, $"Expected value is {expectedResult} but result is {result}");
        }
    }
}
