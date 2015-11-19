using System;
namespace Canducci.Gravatar
{
    public interface IAvatar: IDisposable
    {
        IEmail Email { get; }
        IAvatarConfiguration Configuration { get; }
        byte[] Image { get; }        
        bool SaveAs(string path, string filename);
        bool SaveAs(string path);
    }
}