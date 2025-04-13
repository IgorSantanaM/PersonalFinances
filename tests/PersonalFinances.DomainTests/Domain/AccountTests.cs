using PersonalFinances.Domain.Accounts;

namespace PersonalFinances.UnitTests.Domain
{
    public class AccountTests
    {
        [Fact]
        public void CompareTwoAccounts_NotEquals_ReturnTrue()
        {
            // Arrange
            // nothing to see here

            // Act
            var acc1 = new Account("Igor", AccountType.Wallet, 1000, false);
            var acc2 = new Account("Igor", AccountType.Wallet, 1000, false);


            // Assert
            Assert.True(acc1 != acc2 && !acc1.Equals(acc2));
        }
        
        [Fact]
        public void Account_Validate_ValidAccount_ReturnTrue()
        {
            // Arrange
            var account = new Account("Igor", AccountType.Wallet, 1000, false);
            // Act
            var result = account.IsValidate();
            // Assert
            Assert.True(result);
        }
        [Fact]
        public void Account_Validate_InvalidAccount_ReturnFalse()
        {
            // Arrange
            var account = new Account("", AccountType.Wallet, 1000, false);
            // Act
            var result = account.IsValidate();
            // Assert
            Assert.False(result);
        }
        
    }
}