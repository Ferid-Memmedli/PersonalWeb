using PersonalWeb.HelperMethods;
using PersonalWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalWeb.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      SettingWeb settingWeb = JsonFileManager.JsonConvertToObject<SettingWeb>("App_Data\\SettingWeb.json");
      return View(settingWeb);
    }
  }
}
