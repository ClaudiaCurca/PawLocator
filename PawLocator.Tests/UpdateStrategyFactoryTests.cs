using PawLocator.Patterns.Factories;
using PawLocator.Patterns.Strategies;

namespace PawLocator.Tests
{
    public class UpdateStrategyFactoryTests
    {
        [Fact]
        public void Create_ShouldReturn_LostStrategy_WhenTypeIsLost()
        {
            // Arrange
            var factory = new UpdateStrategyFactory();

            // Act
            var result = factory.Create("lost");

            // Assert
            Assert.IsType<LostUpdateStrategy>(result);
        }
    }
}
