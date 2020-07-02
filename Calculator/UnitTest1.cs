using Calculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalcultorCanSumTwoNumbers()
        {
            //arrange
            var calculator = new MyCalculator();
            var num1 = 5;
            var num2 = 9;


            //act
            var result = calculator.Sum(num1, num2);

            //assert
            Assert.AreEqual(14, result);
        }

        [TestMethod]
        public void CalcultorReturnsInsurancePrice_Success()
        {
            //arrange
            var calculator = new MyCalculator();
            double netPremium = 100;
            double comission = 10;
            double discount = -5;


            //act
            var result = calculator.CalculateInsurancePrice(netPremium, comission, discount);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(117.04, result);
            
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CalcultorReturnsInsurancePrice_FailWhenNetPremiumIs0()
        {            
            //arrange
            var calculator = new MyCalculator();
            double comission = 10;
            double discount = -5;

            //act
            var result = calculator.CalculateInsurancePrice(0, comission, discount);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CalcultorReturnsInsurancePrice_FailWhenComissionIsNegative()
        {
            //arrange
            var calculator = new MyCalculator();
            double comission = -10;
            double discount = -5;

            //act
            var result = calculator.CalculateInsurancePrice(100, comission, discount);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CalcultorReturnsInsurancePrice_FailWhenDiscountIsPositive()
        {
            //arrange
            var calculator = new MyCalculator();
            double comission = 10;
            double discount = 5;

            //act
            var result = calculator.CalculateInsurancePrice(100, comission, discount);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CalcultorReturnsInsurancePrice_FailWhenDiscountIs100Percent()
        {
            //arrange
            var calculator = new MyCalculator();
            double comission = 10;
            double discount = -100;

            //act
            var result = calculator.CalculateInsurancePrice(100, comission, discount);
        }

        [TestMethod]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.AreEqual(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }
    }
}
