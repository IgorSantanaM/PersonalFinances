using PersonalFinances.Domain.Accounts;

namespace PersonalFinances.Tests.Domain
{
    public class AccountTests
    {
        [Fact]
        public void CompareTwoAccounts_NotEquals_ReturnTrue()
        {
            // Arrange
            // nothing to see here

            // Act
            var acc1 = new Account( "Igor", AccountType.Wallet, 1000, false);
            var acc2 = new Account( "Igor", AccountType.Wallet, 1000, false);


            // Assert
            Assert.True(acc1 != acc2 && !acc1.Equals(acc2));
        }
        [Fact]
        public void CompareTwoCategories_NotEquals_ReturnTrue()
        {
            // Arrange
            // nothing to see here

            // Act
            var category1 = new Category( "Salary", 0, 0);
            var category2 = new Category( "Salary", 0, 0);

            // Assert
            Assert.True(category1 != category2 && !category1.Equals(category2));
        }
    }
}