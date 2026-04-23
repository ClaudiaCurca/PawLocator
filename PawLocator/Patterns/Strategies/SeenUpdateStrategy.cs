namespace PawLocator.Patterns.Strategies
{
    public class SeenUpdateStrategy:IUpdateStrategy
    {
        public string FormatMessage(string message)
        {
            return "👀 SEEN: " + message;
        }
    }
}
