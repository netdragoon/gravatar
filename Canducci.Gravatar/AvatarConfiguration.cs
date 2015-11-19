using System;
using Canducci.Gravatar.Validation;

namespace Canducci.Gravatar
{
    public class AvatarConfiguration : IAvatarConfiguration
    {
        protected const string _url = "http://www.gravatar.com/avatar/{0}.{1}?s={2}&r={3}&d={4}";
        protected const string _urlsecure = "https://secure.gravatar.com/avatar/{0}.{1}?s={2}&r={3}&d={4}";
        public int Width { get; private set; }
        public IEmail Email { get; private set; }
        public AvatarImageExtension Extension { get; private set; }
        public AvatarRating Rating { get; private set; }
        public AvatarDefaultImage DefaultImage { get; private set; }
        public AvatarConfiguration(string email,
            int width = 100,
            AvatarImageExtension extension = AvatarImageExtension.Jpg,
            AvatarRating rating = AvatarRating.G,
            AvatarDefaultImage defaultimage = AvatarDefaultImage.NoImage)
        {
            Email = new Email(email);
            ValidateRange(width);
            Width = width;
            Extension = extension;
            Rating = rating;
            DefaultImage = defaultimage;
        }
        public AvatarConfiguration(IEmail email,
            int width = 100,
            AvatarImageExtension extension = AvatarImageExtension.Jpg,
            AvatarRating rating = AvatarRating.G,
            AvatarDefaultImage defaultimage = AvatarDefaultImage.NoImage)
        {
            Email = email;
            ValidateRange(width);
            Width = width;
            Extension = extension;
            Rating = rating;
            DefaultImage = defaultimage;
        }

        public string Url(bool secure = false)
        {            
            string address = secure ? _urlsecure : _url;
            return string.Format(address,
                    Email.Hash,
                    Extension.ToLower(),
                    Width.ToString(),
                    Rating.ToLower(),
                    DefaultImage == AvatarDefaultImage.NoImage ? 
                    "404": 
                    DefaultImage.ToLower());
        }

        public IAvatarConfiguration SetWidth(int width)
        {
            ValidateRange(width);
            Width = width;
            return this;
        }
        public IAvatarConfiguration SetAvatarImageExtension(AvatarImageExtension extension)
        {
            Extension = extension;
            return this;
        }
        public IAvatarConfiguration SetAvatarRating(AvatarRating rating)
        {
            Rating = rating;
            return this;
        }
        public IAvatarConfiguration SetAvatarDefaultImage(AvatarDefaultImage defaultimage)
        {
            DefaultImage = defaultimage;
            return this;
        }

        public IAvatarConfiguration SetEmail(IEmail email)
        {
            Email = email;
            return this;
        }
        private void ValidateRange(int width)
        {
            Assertion.Range(width, 1, 2048, "Width invalid, only 1 to 2048 pixel is valid");
        }
    }
}
