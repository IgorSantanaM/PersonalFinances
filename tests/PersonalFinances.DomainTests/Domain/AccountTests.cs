using PersonalFinances.Domain.Accounts;

namespace PersonalFincances.Tests.Domain
{
    public class AccountTests
    {
        [Fact]
        public void CompareTwoAccounts_NotEquals_ReturnTrue()
        {
            // Arrange
            // nothing to see here

            // Act
            var acc1 = new Account("Igor", 2000, true);
            var acc2 = new Account("Igor", 2000, true);
            // Assert
            Assert.True(acc1 != acc2 && !acc1.Equals(acc2));
        }
        //[Fact]
        //public void CreateTwoAccountObjects_ObjectsAreCompared_IsEqualMustBeFalse()
        //{
        //    // Arrange
        //    // nothing to see here

        //    // Act
        //    var acc1 = new Account("Igor", 2000, true);

        //    var acc2 = new Account("Anaile", 5000, false);
        //    // Assert
        //    Assert.True(acc1 != acc2);
        //}
    }
}