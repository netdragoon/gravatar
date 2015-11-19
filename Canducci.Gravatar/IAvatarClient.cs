namespace Canducci.Gravatar
{
    public interface IAvatarClient: System.IDisposable
    {
        byte[] Download(string address);
    }
}