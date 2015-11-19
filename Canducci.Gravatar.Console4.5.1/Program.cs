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
            string filename = "foto250a";
            int width = 250;

            IEmail email = new Email("fulviocanducci@hotmail.com");

            IAvatarConfiguration configuration =
                new AvatarConfiguration(email, width, AvatarImageExtension.Jpeg, AvatarRating.R);

            string path;

            if (Avatar.Exists(configuration, folder, filename, out path))
            {
                System.Console.WriteLine("Foto existente: {0}", path);
            }
            else
            {
                IAvatar avatar = new Avatar(configuration);
                avatar.SaveAs(folder, filename);
                System.Console.WriteLine("Foto gravada com sucesso !!!");
            }

            System.Console.ReadKey();
        }
    }
}
