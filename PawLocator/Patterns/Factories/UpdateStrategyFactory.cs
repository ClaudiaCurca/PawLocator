using PawLocator.Patterns.Strategies;

namespace PawLocator.Patterns.Factories
{
    public class UpdateStrategyFactory : IUpdateStrategyFactory
    {
        public IUpdateStrategy Create(string type)
        {
            return type switch
            {
                "lost" => new LostUpdateStrategy(),
                "found" => new FoundUpdateStrategy(),
                "seen" => new SeenUpdateStrategy(),
                _ => new SeenUpdateStrategy()
            };
        }
    }
}
