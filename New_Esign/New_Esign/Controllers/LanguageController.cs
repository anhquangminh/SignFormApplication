using System.Web.Mvc;

namespace New_Esign.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }

        public bool ChangeLanguage(string languageId)
        {
            LanguageHelper.languageId = languageId;
            Ultils.WriteCookie("lang", languageId);
            return true;
        }
    }
}