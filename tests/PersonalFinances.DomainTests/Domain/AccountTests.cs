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
            var acc1 = new Account(Guid.NewGuid(), "Igor", 2000, true);
            var acc2 = new Account(Guid.NewGuid(), "Igor", 2000, true);

            // Assert
            Assert.True(acc1 != acc2 && !acc1.Equals(acc2));
        }
    }
}