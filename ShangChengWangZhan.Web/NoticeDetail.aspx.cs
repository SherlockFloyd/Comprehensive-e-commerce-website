using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping.Model;
using Shopping.BLL;

namespace Shopping.Web
{
    public partial class NoticeDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Notice model = NoticeBLL.GetNoticeInfo(Utils.StrToInt(Requests.Query("noticeid")));
                if (model != null)
                {
                    //txttitle.Text = model.Title;
                    //txttime.Text = model.CreateTime.ToString();
                    //txtcontent.Text = model.Content;
                    txttitle.Text = model.Title;
                    txttime.Text = model.CreateTime.ToString();
                    txtcontent.Text = model.Content;
                
                }
            }
        }
    }
}