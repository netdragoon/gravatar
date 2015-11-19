using System;
using System.Net;
namespace Canducci.Gravatar
{
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
#if NET40
        public async System.Threading.Tasks.Task<byte[]> DownloadAsync(string address)
        {
            return await _web.DownloadDataTaskAsync(address);
        }
#endif
        public void Dispose()
        {
            _web.Dispose();
            _web = null;
        }
    }
}
