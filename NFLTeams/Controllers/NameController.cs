using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamListViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams(),
                UserName = session.GetName()
            };

            return View(model);

        }
        [HttpPost]
        public RedirectToActionResult Change(TeamListViewModel model)                            //gets the users name from the TeamListViewModel objecct
        {
            var session = new NFLSession(HttpContext.Session); session.SetName(model.UserName); //set the name in session state
            return RedirectToAction("Index", "Home", new                                        // redirects to home page
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            });
        }
    }
}

