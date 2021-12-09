using PersonalWeb.HelperMethods;
using PersonalWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace PersonalWeb.Controllers
{
  public class HomeController : Controller
  {
    DbPersonalWebEntities context;
    SettingWeb settingWeb = JsonFileManager.JsonConvertToObject<SettingWeb>("App_Data\\SettingWeb.json");
    public HomeController()
    {
      context = new DbPersonalWebEntities();
    }

    [HttpGet]
    public ActionResult Index()
    {
      return View(settingWeb);
    }


    [HttpPost]
    public ActionResult Index(Message message)
    {

      if (ModelState.IsValid)
      {
        context.Messages.Add(message);
        context.SaveChanges();
        return RedirectToAction("Index");
      }

      foreach (var item in ModelState.Values)
      {
        if (item.Errors.Count == 1)
          ViewBag.Error = item.Errors[0].ErrorMessage;
      }
      return View(settingWeb);
    }

    public PartialViewResult ExperiencePartial()
    {
      return PartialView(context.Experiences.ToList());
    }

    public PartialViewResult EducationPartial()
    {
      return PartialView(context.Educations.ToList());
    }

    public PartialViewResult BlogPartial()
    {
      return PartialView(context.Blogs.ToList());
    }

    public PartialViewResult PortfolioPartial()
    {
      return PartialView(context.Portfolios.ToList());
    }


  }
}
