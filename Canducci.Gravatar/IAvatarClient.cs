namespace Canducci.Gravatar
{
    public interface IAvatarClient: System.IDisposable
    {
        byte[] Download(string address);
#if NET40
        System.Threading.Tasks.Task<byte[]> DownloadAsync(string address);
#endif
    }
}