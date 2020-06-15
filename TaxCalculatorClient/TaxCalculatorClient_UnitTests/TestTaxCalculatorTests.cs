using NUnit.Framework;
using System;
using TaxCalculatorClient.Models;
using TaxCalculatorClient.Models.Interfaces;

namespace TaxCalculatorClient_UnitTests
{
    public class Tests
    {
        private TaxCalculator _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new TaxCalculator();
        }

        /// <summary>
        /// a Test for TaxCalculator constructor
        ///</summary>
        [Test]
        public void TaxCalculator_GivenWith_NewInstance_ShouldBe_ZeroTaxPayable()
        {
            Assert.AreEqual(_sut.TaxPayable, 0);
        }

        /// <summary>
        /// a Test for TaxCalculator constructor and default Calculate method
        ///</summary>
        [Test]
        public void TaxCalculator_GivenWith_NewInstanceAndCalculate_ShouldBe_ZeroTaxPayable()
        {
            _sut.Calculate();
            Assert.AreEqual(_sut.TaxPayable, 0);
        }

        /// <summary>
        /// a Test for FlatValue TaxCalutation given with 300000 annual income, tax payable should be 10000
        ///</summary>
        [Test]
        public void TaxCalculator_GivenWith_FlatValueTaxCalculatorAnd300000Income_ShouldBe_10000()
        {
            const int INCOME = 300000;
            const string CODE = "A100";

            _sut.AnnualIncome = INCOME.ToString();
            _sut.PostalCode = CODE;

            _sut.Calculate();

            Assert.AreEqual(_sut.TaxPayable, 10000);
        }

        /// <summary>
        /// a Test for FlatValue TaxCalutation given with 199000 annual income, tax should be 5%
        ///</summary>
        [Test]
        public void TaxCalculator_GivenWith_FlatValueTaxCalculatorAnd199000Income_ShouldBe_5Percent()
        {
            const int INCOME = 199000;
            const string CODE = "A100";

            _sut.AnnualIncome = INCOME.ToString();
            _sut.PostalCode = CODE;

            _sut.Calculate();

            Assert.AreEqual(_sut.TaxPayable, (INCOME * 5 / 100));
        }

        /// <summary>
        /// a Test for FlatRate TaxCalutation given with 199000 annual income, tax should be 17.5%
        ///</summary>
        [Test]
        public void TaxCalculator_GivenWith_FlatRateTaxCalculatorAnd199000Income_ShouldBe_17_50Percent()
        {
            const int INCOME = 199000;
            const string CODE = "7000";

            _sut.AnnualIncome = INCOME.ToString();
            _sut.PostalCode = CODE;

            _sut.Calculate();

            Assert.AreEqual(_sut.TaxPayable, (INCOME * 17.5 / 100));
        }

        /// <summary>
        /// a Test for Progressive TaxCalutation given with 8349 annual income, tax should be 5%
        ///</summary>
        [Test]
        public void TaxCalculator_GivenWith_ProgressiveTaxCalculatorAnd8349Income_ShouldBe_10Percent()
        {
            const double INCOME = 8349.00;
            const string CODE = "7441";

            _sut.AnnualIncome = INCOME.ToString();
            _sut.PostalCode = CODE;
            _sut.Calculate();

            double manualCalculation = (INCOME * 10 / 100);
            manualCalculation = Math.Round(manualCalculation, 2);

            Assert.AreEqual(_sut.TaxPayable, manualCalculation);
        }

        /// <summary>
        /// a Test for Progressive TaxCalutation given with 10000 annual income, tax should be (5% on 8350) + (15% on the rest)
        ///</summary>
        [Test]
        public void TaxCalculator_GivenWith_ProgressiveTaxCalculatorAnd8349Income_ShouldBe_TaxCalculatedAsProgressive()
        {
            // INCOME HAS TO BE MORE THAN 8350
            const double INCOME = 10000.00;
            const string CODE = "1000";

            _sut.AnnualIncome = INCOME.ToString();
            _sut.PostalCode = CODE;
            _sut.Calculate();

            double manualFirstCalculation = 0.00;
            double remainingIncome = 0.00;

            if (INCOME > 8350)
            {
                manualFirstCalculation = (8350 * 10 / 100);
                remainingIncome = INCOME - 8350;
            }
              
            double manualSecondCalculation = remainingIncome * 15 / 100;
             
            double result = (manualFirstCalculation + manualSecondCalculation);
            result = Math.Round(result, 2);

            Assert.AreEqual(_sut.TaxPayable, result);
        }
    }
}