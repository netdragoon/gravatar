using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canducci.Gravatar.Console4._5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = "image/";
            string filename = "foto300a";
            int width = 300;

            IEmail email = new Email("fulviocanducci@hotmail.com");

            IAvatarConfiguration configuration =
                new AvatarConfiguration(email, width, AvatarImageExtension.Jpeg, AvatarRating.R);

            string path;

            if (Avatar.Exists(configuration, folder, filename, out path))
            {
                Console.WriteLine("Foto existente: {0}", path);
            }
            else
            {
                IAvatar avatar = new Avatar(configuration);
                avatar.SaveAs(folder, filename);
                Console.WriteLine("Foto gravada com sucesso !!!");
            }

            Console.ReadKey();
        }
    }
}
