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
                new AvatarConfiguration(
                    email,
                    width,
                    AvatarImageExtension.Jpeg,
                    AvatarRating.R);

            IAvatar avatar = new Avatar(configuration);

            if (avatar.Exists(folder, filename) == false)
            {
                avatar.SaveAs(folder, filename);
                Console.WriteLine("Foto gravada com sucesso !!!");
            }
            else
            {

                Console.WriteLine("Foto existente !!!");
            }

            Console.ReadKey();
        }
    }
}
