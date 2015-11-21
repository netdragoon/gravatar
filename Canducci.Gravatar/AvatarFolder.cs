namespace Canducci.Gravatar
{
    public class AvatarFolder : IAvatarFolder
    {
        public AvatarFolder(string folder)
        {
            Folder = folder;
        }
        public AvatarFolder(string folder, string prefix)
            :this(folder)
        {
            Prefix = prefix;
        }
        public string Prefix { get; private set; }
        public string Folder { get; private set; }        
        public string Path()
        {
            if (!string.IsNullOrEmpty(Prefix))
            {
                return string.Format("{0}{1}", Prefix, Folder);
            }
            return Folder;
        }
    }
}
