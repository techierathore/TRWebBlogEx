using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TrWebBlogEx.Models;

namespace TrWebBlogEx.Controllers
{
    public class SummerNoteExController : Controller
    {
        // GET: SummerNoteEx
        public ActionResult BlogEntry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BlogEntry(BlogPost aBlogPost)
        {
            return View("ShowBlog", aBlogPost);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile(HttpPostedFileBase aUploadedFile)
        {
            var vReturnImagePath = string.Empty;
            if (aUploadedFile.ContentLength > 0)
            {
                var vFileName = Path.GetFileNameWithoutExtension(aUploadedFile.FileName);
                var vExtension = Path.GetExtension(aUploadedFile.FileName);

                string sImageName = vFileName + DateTime.Now.ToString("YYYYMMDDHHMMSS");

                var vImageSavePath = Server.MapPath("/UpImages/") + sImageName + vExtension;
                 //sImageName = sImageName + vExtension;
                 vReturnImagePath =  "/UpImages/" + sImageName + vExtension;
                ViewBag.Msg = vImageSavePath;
                var path = vImageSavePath;

                // Saving Image in Original Mode
                aUploadedFile.SaveAs(path);
                var vImageLength = new FileInfo(path).Length;
                //here to add Image Path to You Database ,
                TempData["message"] = string.Format("Image was Added Successfully");
            }
            return Json(Convert.ToString(vReturnImagePath), JsonRequestBehavior.AllowGet);
        }
    }
}