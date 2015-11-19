namespace Canducci.Gravatar
{
    public interface IAvatarConfiguration
    {
        IEmail Email { get; }
        AvatarDefaultImage DefaultImage { get; }
        AvatarImageExtension Extension { get; }
        AvatarRating Rating { get; }
        int Width { get; }
        IAvatarConfiguration SetAvatarDefaultImage(AvatarDefaultImage defaultimage);
        IAvatarConfiguration SetAvatarImageExtension(AvatarImageExtension extension);
        IAvatarConfiguration SetAvatarRating(AvatarRating rating);
        IAvatarConfiguration SetWidth(int width);
        IAvatarConfiguration SetEmail(IEmail email);
        string Url(bool secure = false);
    }
}