using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        // Arrange
        double initialBalance = 1000.0;

        // Act
        var account = new BankAccount(initialBalance);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(initialBalance));
    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        double initialBalance = 1000.0;
        double depositAmount = 200.0;
        var account = new BankAccount(initialBalance);

        // Act
        account.Deposit(depositAmount);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(initialBalance + depositAmount));
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 1000.0;
        double depositAmount = -200.0;
        var account = new BankAccount(initialBalance);

        // Act
        var ex = Assert.Throws<ArgumentException>(() => account.Deposit(depositAmount));

        // Assert
        Assert.AreEqual("Deposit amount must be greater than zero.", ex.Message);
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        double initialBalance = 1000.0;
        double withdrawalAmount = 200.0;
        var account = new BankAccount(initialBalance);

        // Act
        account.Withdraw(withdrawalAmount);

        // Assert
        Assert.AreEqual(initialBalance - withdrawalAmount, account.Balance);
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 1000.0;
        double withdrawalAmount = -200.0;
        var account = new BankAccount(initialBalance);

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => account.Withdraw(withdrawalAmount));
        Assert.AreEqual("Invalid withdrawal amount.", ex.Message);
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 1000.0;
        double withdrawalAmount = 2000.0; // Amount greater than balance
        var account = new BankAccount(initialBalance);

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => account.Withdraw(withdrawalAmount));
        Assert.That(ex.Message, Is.EqualTo("Invalid withdrawal amount."));
    }
}

