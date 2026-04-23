namespace PawLocator.Patterns.Strategies
{
    public class LostUpdateStrategy:IUpdateStrategy
    {
        public string FormatMessage(string message)
        {
            return "🔴 LOST: " + message;
        }
    }
}
