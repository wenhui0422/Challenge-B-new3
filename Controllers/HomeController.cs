using ChallengeB.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileManager _fileMgr;

        public HomeController(IFileManager fileMgr)
        {
            _fileMgr = fileMgr;
        }

        public ActionResult Index()
        {
            var files = _fileMgr.GetFiles();

            return View(files);
        }

        public JsonResult ViewFile(string filepath)
        {
            bool exist = _fileMgr.ViewCSVFile(filepath);

            return new JsonResult(new { Data = exist });
        }

    }
}
