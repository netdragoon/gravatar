namespace Canducci.Gravatar.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string f = "image/";            

            IAvatarFolder folder = new AvatarFolder(f);

            int width = 250;

            IEmail email = new Email("fulviocanducci@hotmail.com");

            IAvatarConfiguration configuration = 
                new AvatarConfiguration(
                    email, 
                    folder,
                    width,                     
                    AvatarImageExtension.Jpeg, 
                    AvatarRating.R);
            
            IAvatar avatar = new Avatar(configuration);

            if (avatar.Exists() == false)
            {
                avatar.Save();
                System.Console.WriteLine("Foto gravada com sucesso !!!");
            }
            else
            {

                System.Console.WriteLine("Foto existente !!!");
            }
            
            System.Console.ReadKey();
        }
    }
}
