using System;
namespace Canducci.Gravatar
{
    public interface IAvatar: IDisposable
    {        
        IEmail Email { get; }        
        IAvatarConfiguration Configuration { get; }        
        byte[] Image { get; }                   
        bool Save();
        bool SaveAs(string folder, string name);
        bool Exists();
        string Path();
        string WebPath();
    }
}