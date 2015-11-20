using System;

namespace Canducci.Gravatar
{
    public interface IAvatarClient: System.IDisposable
    {
        byte[] Download(string address);
        byte[] Download(Uri address);
    }
}