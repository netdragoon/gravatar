using System;
using System.IO;
namespace Canducci.Gravatar
{
    public class Avatar : IAvatar
    {
        #region Property                                      
        public IAvatarConfiguration Configuration { get; private set; }        
        public IEmail Email
        {
            get
            {
                return Configuration.Email;
            }
        }        
        private byte[] _image;
        public byte[] Image
        {
            get
            {
                Load();
                return _image;
            }
            private set
            {
                _image = value;
            }
        }
        #endregion Property

        #region Constructs
        public Avatar(string email, IAvatarFolder folder)
        {            
            Configuration = new AvatarConfiguration(email,folder);            
        }
        public Avatar(IAvatarConfiguration configuration)
        {         
            Configuration = configuration;            
        }        
        #endregion Constructs

        #region Save                
        public bool Save()
        {
            try
            {
                if (!Directory.Exists(Configuration.Folder.Path()))
                {
                    Directory.CreateDirectory(Configuration.Folder.Path());
                }
                File.WriteAllBytes(Path(), Image);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveAs(string folder, string name)
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                File.WriteAllBytes(string.Format("{0}{1}.{2}.{3}", folder, name, Configuration.Width, Configuration.Extension.ToLower()), Image);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion SaveAs

        #region Exists        
        public bool Exists()
        {            
            return File.Exists(Path());
        }
        #endregion Exists

        #region LoadImage
        protected void Load()
        {
            if (_image == null)
            {
                if (Exists())
                {
                    _image = File.ReadAllBytes(Path());
                }
                else
                {
                    using (IAvatarClient _client = new AvatarClient())
                    {
                        _image = _client.Download(Configuration.Url());
                    }
                }
            }
        }
        #endregion LoadImage

        #region PathImage        
        public string Path()
        {
            return string.Format("{0}{1}.{2}.{3}", Configuration.Folder.Path(), Configuration.FileName, Configuration.Width, Configuration.Extension.ToLower());            
        }
        public string WebPath()
        {
            return string.Format("{0}{1}.{2}.{3}", Configuration.Folder.Folder, Configuration.FileName, Configuration.Width, Configuration.Extension.ToLower());
        }
        #endregion PathImage

        #region Dispose       
        public void Dispose()
        {
            Configuration = null;            
        }
        #endregion Dispose
    }
}
