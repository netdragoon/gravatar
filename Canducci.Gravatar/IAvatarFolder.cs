namespace Canducci.Gravatar
{
    public interface IAvatarFolder
    {
        string Folder { get; }
        string Prefix { get; }
        string Path();
    }
}