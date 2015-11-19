using System.Net;
namespace Canducci.Gravatar
{
    /// <summary>
    /// Class Avatar Client
    /// </summary>
    public sealed class AvatarClient : IAvatarClient
    {
        public WebClient _web;
        public AvatarClient()
        {
            _web = new WebClient();
        }
        public AvatarClient(WebClient web)
        {
            _web = web;
        }
        public byte[] Download(string address)
        {
            return _web.DownloadData(address);
        }
        public void Dispose()
        {
            _web.Dispose();
            _web = null;
        }
    }
}
