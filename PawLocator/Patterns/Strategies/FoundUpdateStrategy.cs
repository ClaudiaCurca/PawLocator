namespace PawLocator.Patterns.Strategies
{
    public class FoundUpdateStrategy:IUpdateStrategy
    {
        public string FormatMessage(string message)
        {
            return "🟢 FOUND: " + message;
        }
    }
}
