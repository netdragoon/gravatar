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
            IAvatarFolder folder = new AvatarFolder("image/");
            IEmail email = new Email("fulviocanducci@hotmail.com");
            IAvatarConfiguration configuration =
                new AvatarConfiguration(email, folder, 250, AvatarImageExtension.Jpeg, AvatarRating.R);
            IAvatar avatar = new Avatar(configuration);
            
            if (avatar.Exists() == false)
            {
                avatar.Save();
                Console.WriteLine("Foto gravada com sucesso !!!");
            }
            else
            {
                Console.WriteLine("Foto existente: {0}", avatar.Path());
            }
            Console.ReadKey();
        }
    }
}
