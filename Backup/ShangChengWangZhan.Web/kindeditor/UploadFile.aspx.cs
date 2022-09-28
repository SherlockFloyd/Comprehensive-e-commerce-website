using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;


using Shopping.Common;




namespace Shopping.Web
{
  


    public partial class UploadFile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uploadpath = Requests.Query("uploadpath");
            if (uploadpath == string.Empty)
            {
                Response.Write("未设置上传路径");
                Response.End();
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);


            if (Requests.IsPost())
            {


                string filenamePath = "";
                HttpPostedFile postedFile = Request.Files[0];

                Upload upload = new Upload();

                upload.InceptFile = "jpg,gif,png";
                string path = "/Pic/Commodity/Detail/";
                upload.Save(postedFile, path, out filenamePath);

                Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
                if (filenamePath == "")
                {
                    Response.Write("{\"error\":1,\"message\":\"" + upload.ErrString() + "\"}");
                }
                else
                {
                    Response.Write("{\"error\":0,\"url\":\"" + filenamePath + "\"}");
                }
                Response.End();
            }
        }
    }
}
//
