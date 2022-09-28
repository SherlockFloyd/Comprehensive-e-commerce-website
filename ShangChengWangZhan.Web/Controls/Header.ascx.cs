using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using Shopping;
using Shopping.Common;
using Shopping.Controls;
using Shopping.BLL;
namespace Shopping.Web.Controls
{
    public partial class Header : System.Web.UI.UserControl
    {
        private string selectedMenu = "";
        public string SelectedMenu
        {
            get { return selectedMenu; }
            set { selectedMenu = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            string menuName = string.Empty;
            if (SelectedMenu == string.Empty)
            {
                menuName = Requests.GetPageName().ToLower().Split('.')[0];
            }
            else
            {
                menuName = SelectedMenu;
            }

            Span span = (Span)this.FindControl(menuName);
            if (span != null)
            {

                span.Attributes.Add("class", "nav-select");
            }

 
            if (!IsPostBack)
            {
                Shopping.Model.OnLineUserInfo onlineUserInfo = Shopping.OnLineUser.GetOnLineUserInfo(true);
                StringBuilder loginInfo = new StringBuilder();
                if (onlineUserInfo != null)
                {
                    loginInfo.AppendFormat("您好!<a href=\"/member/index.aspx\">{0}</a>,欢迎来到商城网站&nbsp;|&nbsp;<a href=\"/login.aspx?action=logout\">退出</a>", onlineUserInfo.UserName);
                }
                else
                {
                    loginInfo.Append("<a href=\"login.aspx\">登录</a>&nbsp;|&nbsp;<a href=\"register.aspx\">免费注册<a>");
                }
                displayInfo.Text = loginInfo.ToString();

      
            }
        }
        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void serachBtn_Click(object sender, EventArgs e)
        {
            string strkeyword = "";
            string url = "list.aspx";
            if (strkeyword != "")
            {
                Shopping.Model.ListPageUrlInfo listPageUrlInfo = new Model.ListPageUrlInfo()
                {
                    KeyWord = Utils.UrlEncode(Utils.ReplaceSqlWord(strkeyword))
                };
                url = UrlFactory.GetCommodityDetailAspxRewrite(listPageUrlInfo, 1);
            }
            Response.Redirect(url);
        }

 
    }
}