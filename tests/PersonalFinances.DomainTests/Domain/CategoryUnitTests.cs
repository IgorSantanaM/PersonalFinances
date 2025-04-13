
using PersonalFinances.Domain.Accounts;

namespace PersonalFinances.UnitTests.Domain
{
    public sealed class CategoryUnitTests
    {
        [Fact]
        public void CompareTwoCategories_NotEquals_ReturnTrue()
        {
            // Arrange
            // nothing to see here

            // Act
            var category1 = new Category("Salary", 0, 0);
            var category2 = new Category("Salary", 0, 0);

            // Assert
            Assert.True(category1 != category2 && !category1.Equals(category2));
        }
        [Fact]
        public void Category_Validate_ValidCategory_ReturnTrue()
        {
            // Arrange
            var category = new Category("Salary", 0, 0);
            // Act
            var result = category.IsValidate();
            // Assert
            Assert.True(result);
        }
        [Fact]
        public void Category_Validate_InvalidCategory_ReturnFalse()
        {
            // Arrange
            var category = new Category("", 0, 0);
            // Act
            var result = category.IsValidate();
            // Assert
            Assert.False(result);
        }
    }
}
