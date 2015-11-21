namespace Canducci.Gravatar
{
    public interface IAvatarConfiguration
    {
        IAvatarFolder Folder { get; }
        string FileName { get; }
        IEmail Email { get; }
        AvatarDefaultImage DefaultImage { get; }
        AvatarImageExtension Extension { get; }
        AvatarRating Rating { get; }
        int Width { get; }        
        string Url(bool secure = false);
    }
}