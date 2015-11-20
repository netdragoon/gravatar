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
        bool Exists(string folder, string filename);
        bool Exists(string folder);
        string Path(string folder, string filename);
        string Path(string folder);
    }
}