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
    public HomeController()
    {
      context = new DbPersonalWebEntities();
    }

    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(Message message)
    {
      if (ModelState.IsValid)
      {
        message.CreatedDate = DateTime.Now;
        context.Messages.Add(message);
        context.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.Error = ModelState.Values.FirstOrDefault(p => p.Errors.Count >= 0).Errors[0].ErrorMessage;
      return View();
    }

    [ChildActionOnly]
    public PartialViewResult ExperiencePartial()
    {
      return PartialView(context.Experiences.ToList());
    }

    [ChildActionOnly]
    public PartialViewResult EducationPartial()
    {
      return PartialView(context.Educations.ToList());
    }

    [ChildActionOnly]
    public PartialViewResult BlogPartial()
    {
      return PartialView(context.Blogs.ToList());
    }

    [ChildActionOnly]
    public PartialViewResult PortfolioPartial()
    {
      return PartialView(context.Portfolios.ToList());
    }

    [HttpGet]
    public JsonResult JsonData()
    {
      SettingWeb settingWeb = JsonFileManager.JsonConvertToObject<SettingWeb>("App_Data\\SettingWeb.json");

      return Json(settingWeb, JsonRequestBehavior.AllowGet);
    }

  }
}
