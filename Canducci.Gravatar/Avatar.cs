using System;
using System.IO;
namespace Canducci.Gravatar
{
    public class Avatar : IAvatar
    {
        #region Property        
        protected IAvatarClient _client;                
        public IAvatarConfiguration Configuration { get; private set; }        
        public IEmail Email
        {
            get
            {
                return Configuration.Email;
            }
        }
        public byte[] Image { get; private set; }
        #endregion Property

        #region Constructs
        public Avatar(string email)
        {
            _client = new AvatarClient();
            Configuration = new AvatarConfiguration(email);
            Load();
        }
        public Avatar(IAvatarConfiguration configuration)
        {
            _client = new AvatarClient();
            Configuration = configuration;
            Load();
        }
        public Avatar(IAvatarClient client, IAvatarConfiguration configuration)
        {
            _client = client;
            Configuration = configuration;
            Load();
        }
        #endregion Constructs

        #region SaveAs        
        public bool SaveAs(string folder, string filename)
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                File.WriteAllBytes(Path(folder, filename), Image);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }                       
        }

        public bool SaveAs(string folder)
        {
            return SaveAs(folder, Configuration.Email.Hash);
        }
        #endregion SaveAs

        #region Exists
        public bool Exists(string folder, string filename)
        {
            string path = Path(folder, filename);
            return File.Exists(path);
        }
        public bool Exists(string folder)
        {
            string path = Path(folder);
            return File.Exists(path);                        
        }
        #endregion Exists

        #region LoadImage
        protected void Load()
        {
            Image = _client.Download(Configuration.Url());
        }
        #endregion LoadImage

        #region PathImage
        public string Path(string folder, string filename)
        {
            return string.Format("{0}{1}.{2}.{3}", folder, filename, Configuration.Width, Configuration.Extension.ToLower());
        }
        public string Path(string folder)
        {
            return string.Format("{0}{1}.{2}.{3}", folder, Configuration.Email.Hash, Configuration.Width, Configuration.Extension.ToLower());
        }
        #endregion PathImage
        
        #region Dispose       
        public void Dispose()
        {
            Configuration = null;
            _client.Dispose();
        }
        #endregion Dispose
    }
}
