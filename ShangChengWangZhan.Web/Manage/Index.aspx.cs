using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using Shopping.Common;

using Shopping;
using Shopping.BLL;

namespace Shopping.Web.Manage
{
    public partial class Index : ManagePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InitMenu();
        }
        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        private void InitMenu()
        {
            DataSet ds = Utils.GetDataFromXml("/Manage/Config/managemenu.config");
            DataTable mainMenu = ds.Tables[0].Copy();
            DataView subMenu = ds.Tables[1].Copy().DefaultView;
            ds.Dispose();
           
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < mainMenu.Rows.Count; i++)
            {
                string menuTitle = mainMenu.Rows[i]["menutitle"].ToString();
                StringBuilder submenuResult = new StringBuilder();
                subMenu.RowFilter = "MainMenu_Id=" + i.ToString();
                if (subMenu.Count > 0)
                {
                    for (int j = 0; j < subMenu.Count; j++)
                    {
                        
                            string link = subMenu[j]["link"].ToString();
                            string menutitle = subMenu[j]["menutitle"].ToString();
                            submenuResult.AppendFormat("<li url=\"{0}\"><span>{1}</span></li>", link, menutitle);
                         
                    }
                    if (submenuResult.Length > 0)
                    {
                        result.AppendFormat("<div title=\"{0}\" class=\"l-scroll\">", menuTitle);
                        result.Append("<ul>");
                        result.Append(submenuResult);
                        result.Append("</ul>");
                        result.Append("</div>");
                    }

                    submenuResult.Length = 0;
                }
            }

            menu.Text = result.ToString();
        }
    }
}
