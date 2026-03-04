using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTests_Abazov
{
    [TestClass]
    public class BankAccountTests_Abazov
    {
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 10.00;
            double creditAmount = 5.55;
            double expected = 15.55;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            account.Credit(creditAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 10.00;
            double creditAmount = -5.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            try
            {
                account.Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
