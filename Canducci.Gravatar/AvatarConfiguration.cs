using Canducci.Gravatar.Validation;
namespace Canducci.Gravatar
{
    public class AvatarConfiguration : IAvatarConfiguration
    {
        #region Constants
        protected const string _url = "http://www.gravatar.com/avatar/{0}.{1}?s={2}&r={3}&d={4}";
        protected const string _urlsecure = "https://secure.gravatar.com/avatar/{0}.{1}?s={2}&r={3}&d={4}";
        #endregion Constants

        #region Property
        public IAvatarFolder Folder { get; private set; }
        public string FileName { get; private set; }
        public int Width { get; private set; }
        public IEmail Email { get; private set; }
        public AvatarImageExtension Extension { get; private set; }
        public AvatarRating Rating { get; private set; }
        public AvatarDefaultImage DefaultImage { get; private set; }
        #endregion Property

        #region Constructs
        public AvatarConfiguration(string email, IAvatarFolder folder, string filename, int width = 100,
            AvatarImageExtension extension = AvatarImageExtension.Jpg,
            AvatarRating rating = AvatarRating.G,
            AvatarDefaultImage defaultimage = AvatarDefaultImage.NoImage)
        {                        
            Email = new Email(email);
            Folder = folder;
            ValidateRange(width);
            Width = width;
            FileName = string.IsNullOrEmpty(filename) ? Email.Hash : filename;            
            Extension = extension;
            Rating = rating;
            DefaultImage = defaultimage;
        }
        public AvatarConfiguration(IEmail email, IAvatarFolder folder, string filename, int width = 100,
            AvatarImageExtension extension = AvatarImageExtension.Jpg,
            AvatarRating rating = AvatarRating.G,
            AvatarDefaultImage defaultimage = AvatarDefaultImage.NoImage)
        {            
            Email = email;
            Folder = folder;
            ValidateRange(width);
            Width = width;
            FileName = string.IsNullOrEmpty(filename) ? Email.Hash : filename;            
            Extension = extension;
            Rating = rating;
            DefaultImage = defaultimage;
        }
        public AvatarConfiguration(string email, IAvatarFolder folder, int width = 100,            
            AvatarImageExtension extension = AvatarImageExtension.Jpg,
            AvatarRating rating = AvatarRating.G,
            AvatarDefaultImage defaultimage = AvatarDefaultImage.NoImage)
        {
            Email = new Email(email);
            Folder = folder;
            ValidateRange(width);
            Width = width;
            FileName = Email.Hash;
            Extension = extension;
            Rating = rating;
            DefaultImage = defaultimage;
        }
        public AvatarConfiguration(IEmail email, IAvatarFolder folder, int width = 100,            
            AvatarImageExtension extension = AvatarImageExtension.Jpg,
            AvatarRating rating = AvatarRating.G,
            AvatarDefaultImage defaultimage = AvatarDefaultImage.NoImage)
        {
            Email = email;
            Folder = folder;
            ValidateRange(width);
            Width = width;
            FileName = Email.Hash;
            Extension = extension;
            Rating = rating;
            DefaultImage = defaultimage;
        }
        #endregion Constructs

        #region UrlGravatarGetPhoto
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
        #endregion UrlGravatarGetPhoto
        
        #region ValidationWidth
        private void ValidateRange(int width)
        {
            Assertion.Range(width, 1, 2048, "Width invalid, only 1 to 2048 pixel is valid");
        }        
        #endregion ValidationWidth
    }
}
