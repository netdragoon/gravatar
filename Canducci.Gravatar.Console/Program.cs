namespace Canducci.Gravatar.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = "image/";
            string filename = "foto250a";
            int width = 250;

            IEmail email = new Email("fulviocanducci@hotmail.com");

            IAvatarConfiguration configuration = 
                new AvatarConfiguration(
                    email, 
                    width, 
                    AvatarImageExtension.Jpeg, 
                    AvatarRating.R);
            
            IAvatar avatar = new Avatar(configuration);

            if (avatar.Exists(folder, filename) == false)
            {
                avatar.SaveAs(folder, filename);
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
