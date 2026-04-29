using PawLocator.Patterns.Strategies;

namespace PawLocator.Tests
{
    public class UpdateStrategyTests
    {
        [Fact]
        public void LostStrategy_Should_Contain_LOST_In_Message()
        {
            // Arrange
            var strategy = new LostUpdateStrategy();

            // Act
            var result = strategy.FormatMessage("dog near park");

            // Assert
            Assert.Contains("LOST", result);
        }
    }
}
