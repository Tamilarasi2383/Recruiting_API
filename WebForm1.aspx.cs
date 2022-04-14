using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruiting_API
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string DownloadFile(string fileName)
        {
            //Set the File Folder Path.
            string path = HttpContext.Current.Server.MapPath("~/Candidate/Resume_India/");

            //Read the File as Byte Array.
            byte[] bytes = File.ReadAllBytes(path + fileName);

            //Convert File to Base64 string and send to Client.
            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }
    }
}