using Bank.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bank.Domain.Tests
{
    [TestClass] // 👈 Necesario para que MSTest reconozca la clase como contenedora de tests
    public class BankAccountTests
    {
        [TestMethod] // 👈 Necesario para que MSTest detecte este método como test
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod] // 👈 NUEVO: prueba de crédito
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            var account = new BankAccount("User", 10.00);
            // Act
            account.Credit(5.25);
            // Assert
            Assert.AreEqual(15.25, account.Balance, 0.001, "Account not credited correctly");
        }

        // (Opcional) Casos frontera aumentan cobertura:
        [TestMethod]
        public void Credit_WithNegativeAmount_Throws()
        {
            var account = new BankAccount("User", 10.00);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Credit(-1));
        }
    }
}
