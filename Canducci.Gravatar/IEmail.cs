namespace Canducci.Gravatar
{
    public interface IEmail
    {
        string Hash { get; }
        string Value { get; }
    }
}