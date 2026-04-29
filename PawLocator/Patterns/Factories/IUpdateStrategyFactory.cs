using PawLocator.Patterns.Strategies;

namespace PawLocator.Patterns.Factories
{
    public interface IUpdateStrategyFactory
    {
        IUpdateStrategy Create(string type);
    }
}
