using System;
using System.IO;
namespace Canducci.Gravatar
{
    public class Avatar : IAvatar
    {
        #region Property
        /// <summary>
        /// AvatarClient Download
        /// </summary>
        protected IAvatarClient _client;        
        /// <summary>
        /// Configuration Gravatar
        /// </summary>
        public IAvatarConfiguration Configuration { get; private set; }
        /// <summary>
        /// Email Gravatar
        /// </summary>
        public IEmail Email
        {
            get
            {
                return Configuration.Email;
            }
        }
        /// <summary>
        /// Array de Bytes Image Gravatar
        /// </summary>
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
        /// <summary>
        /// SaveAs
        /// </summary>
        /// <param name="folder">Path of file</param>
        /// <param name="filename">Name of file</param>
        /// <returns>True / False</returns>
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
        /// <summary>
        /// SaveAs
        /// </summary>
        /// <param name="folder">Path of file</param>
        /// <returns>True or False</returns>
        public bool SaveAs(string folder)
        {
            return SaveAs(folder, Configuration.Email.Hash);
        }
        #endregion SaveAs

        #region Dispose
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {            
            Configuration = null;
            _client.Dispose();
        }
        #endregion Dispose

        #region Exists_Static
        /// <summary>
        /// Gravatar
        /// </summary>
        /// <param name="configuration">Configuration Gravatar</param>
        /// <param name="folder">Path of file</param>
        /// <param name="filename">Name of file</param>
        /// <param name="path">Out Path of file (Complete)</param>
        /// <returns></returns>
        public static bool Exists(IAvatarConfiguration configuration, string folder, string filename, out string path)
        {
            path = Path(folder, filename, configuration);
            bool exists = File.Exists(path);
            if (exists == false) path = null;
            return exists;
        }
        #endregion Exists_Static

        #region RoutineAux
        private void Load()
        {
            Image = _client.Download(Configuration.Url());
        }
        private static string Path(string folder, string filename, IAvatarConfiguration configuration)
        {
            return string.Format("{0}{1}.{2}.{3}", folder, filename, configuration.Width, configuration.Extension.ToLower());
        }
        #endregion RoutineAux
    }
}
