using System;
using System.IO;
namespace Canducci.Gravatar
{
    public class Avatar : IAvatar
    {
        protected IAvatarClient _client;        
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
        public IAvatarConfiguration Configuration { get; private set; }
        public IEmail Email
        {
            get
            {
                return Configuration.Email;
            }
        }
        public byte[] Image { get; private set; }
        public bool SaveAs(string folder, string filename)
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                File.WriteAllBytes(Path(folder, filename, Configuration), Image);
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

        public void Dispose()
        {            
            Configuration = null;
            _client.Dispose();
        }

        public static bool Exists(IAvatarConfiguration configuration, string folder, string filename, out string path)
        {
            path = Path(folder, filename, configuration);
            bool exists = File.Exists(path);
            if (exists == false) path = null;
            return exists;
        }
        private void Load()
        {
            Image = _client.Download(Configuration.Url());
        }
        private static string Path(string folder, string filename, IAvatarConfiguration configuration)
        {
            return string.Format("{0}{1}.{2}.{3}", folder, filename, configuration.Width, configuration.Extension.ToLower());
        }
        
    }
}
