using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canducci.Gravatar.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("avatar")]
        public ActionResult AvatarResult()
        {
            string folder = "/Images/";
            //string filename = "foto";
            int width = 400;

            IEmail email = new Email("fulviocanducci@hotmail.com");
            IAvatarConfiguration configuration =
                new AvatarConfiguration(email, 
                    width, 
                    AvatarImageExtension.Jpeg, 
                    AvatarRating.R);

            string path = Server.MapPath(folder);

            IAvatar avatar = new Avatar(configuration);

            if (avatar.Exists(path) == false)
            {             
                  avatar.SaveAs(path);
            }

            ViewBag.Path = avatar.Path(folder);

            return View();
        }
    }
}