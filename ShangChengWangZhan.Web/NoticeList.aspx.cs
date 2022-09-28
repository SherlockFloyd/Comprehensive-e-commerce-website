using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Shopping;
using Shopping.Model;
using Shopping.BLL;
using Shopping.Common;

namespace Shopping.Web
{
    public partial class NoticeList : System.Web.UI.Page
    {

      
        private ListPageUrlInfo listPageUrlInfo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

       
        private void BindData()
        {
           
            GetNoticeList();

        }

        #region 获取公告列表
       
        private void GetNoticeList()
        {
            int total = 0;
            List<Notice> list = Shopping.LuceneUtils.GetNoticeList(pager.PageSize, pager.CurrentPage, out total);
            pager.Total = total;



            pager.Calculate();
            repeater.DataSource = list;
            repeater.DataBind();
        }
        #endregion
    }
}