using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TaxCalculatorClient.Models.Interfaces;

namespace TaxCalculatorClient.Models
{
    public class ProgressiveTaxCalculatorHandler : ICalculatorHandler
    {
        public void Calculate(double AnnualIncome, ref double TaxPayable)
        {
            double incomeRemaining = AnnualIncome;

            from0To8350TaxOn10(ref incomeRemaining, ref TaxPayable);
            from8351to33950TaxOn15(ref incomeRemaining, ref TaxPayable);
            from33951To82250TaxOn25(ref incomeRemaining, ref TaxPayable);
            from82251To171550TaxOn28(ref incomeRemaining, ref TaxPayable);
            from171551To372950TaxOn33(ref incomeRemaining, ref TaxPayable);
            from372951ToInfinateTaxOn35(ref incomeRemaining, ref TaxPayable);

            /*var methods = this.GetType().GetMethods();
            foreach(MethodInfo item in methods)
            {
                if (item.Name.StartsWith("from"))
                {
                    double remainingIncome = double.Parse(item.Invoke(null, null).ToString());

                    if (remainingIncome > 0)
                    {
                        incomeRemaining -= remainingIncome;
                    }
                    else
                    {
                        break;
                    }
                   
                }
            }*/
        }

        private void from0To8350TaxOn10(ref double incomeRemaining, ref double TaxPayable)
        {
            if (incomeRemaining < 0)
                return;

            double maxDifference = 8350 - 0;
            double difference = incomeRemaining - maxDifference;

            if (difference > 0)
            {
                TaxPayable += (maxDifference * 10 / 100);
            }
            else
            {
                TaxPayable += (incomeRemaining * 10 / 100);
            }

            incomeRemaining = incomeRemaining - maxDifference;
        }

        private void from8351to33950TaxOn15(ref double incomeRemaining, ref double TaxPayable)
        {
            if (incomeRemaining < 0)
                return;

            double maxDifference = 33950 - 8351;
            double difference = incomeRemaining - maxDifference;

            if (difference > 0)
            {
                TaxPayable += (maxDifference * 15 / 100);
            }
            else
            {
                TaxPayable += (incomeRemaining * 15 / 100);
            }

            incomeRemaining = incomeRemaining - maxDifference;
        }

        private void from33951To82250TaxOn25(ref double incomeRemaining, ref double TaxPayable)
        {
            if (incomeRemaining < 0)
                return;

            double maxDifference = 82250 - 33951;
            double difference = incomeRemaining - maxDifference;

            if (difference > 0)
            {
                TaxPayable += (maxDifference * 25 / 100);
            }
            else
            {
                TaxPayable += (incomeRemaining * 25 / 100);
            }

            incomeRemaining = incomeRemaining - maxDifference;
        }

        private void from82251To171550TaxOn28(ref double incomeRemaining, ref double TaxPayable)
        {
            if (incomeRemaining < 0)
                return;

            double maxDifference = 171550 - 82251;
            double difference = incomeRemaining - maxDifference;

            if (difference > 0)
            {
                TaxPayable += (maxDifference * 28 / 100);
            }
            else
            {
                TaxPayable += (incomeRemaining * 28 / 100);
            }

            incomeRemaining = incomeRemaining - maxDifference;
        }

        private void from171551To372950TaxOn33(ref double incomeRemaining, ref double TaxPayable)
        {
            if (incomeRemaining < 0)
                return;

            double maxDifference = 372950 - 171551;
            double difference = incomeRemaining - maxDifference;

            if (difference > 0)
            {
                TaxPayable += (maxDifference * 33 / 100);
            }
            else
            {
                TaxPayable += (incomeRemaining * 33 / 100);
            }

            incomeRemaining = incomeRemaining - maxDifference;
        }

        private void from372951ToInfinateTaxOn35(ref double incomeRemaining, ref double TaxPayable)
        {
            if (incomeRemaining < 0)
                return;

            TaxPayable += (incomeRemaining * 35 / 100);

            incomeRemaining = incomeRemaining - incomeRemaining;
        }
    }
}
