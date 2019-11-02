using System.Web.Mvc;

namespace TrWebBlogEx.Models
{
    /// <summary>
    /// This is the Model Class used for showing the example of using 
    /// free and Open source WYSWYG editer SummerNote in ASP.Net MVC 
    /// Application
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// For Title of the Note
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// To Save content of the Note which can be anything.
        /// </summary>
        [AllowHtml]
        public string Content { get; set; }
    }
}