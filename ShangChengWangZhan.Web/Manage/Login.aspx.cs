using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping;
using Shopping.BLL;

namespace Shopping.Web.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Requests.Query("action") == "logout")
            {
                ManageUtils.RemoveCookie();
                Response.Redirect("Login.aspx");
            }

            if (IsPostBack)
            {
                string name = Requests.Form("userName");
                string pwd = Requests.Form("password");
                string code = Requests.Form("verifyCode");
                if (name.Trim() == "")
                {
                    WebUtility.Alert("请您输入用户名!");
                    return;
                }
                if (pwd.Trim() == "")
                {
                    WebUtility.Alert("请您输入密码!");
                    return;

                }
                if (code.Trim() == "")
                {
                    WebUtility.Alert("请您输入验证码!");
                    return;

                }

                try
                {
                    string checkcode = Utils.GetSession("CheckCode").ToString();
                }
                catch { }
                if (Utils.GetSession("CheckCode").ToString() != code)
                {
                    WebUtility.Alert("验证码错误啦!");
                    return;

                }
                else
                {
                   Shopping.Model.Admin adminInfo = AdminBLL.GetAdminInfoByCondition("AdminName='" + name + "'");
                    if (adminInfo != null)
                    {
                        if (adminInfo.Password != pwd)
                        {
                            WebUtility.Alert("密码错误!");
                            return;
                        }
                        else
                        {
                            adminInfo.LastLoginIP = adminInfo.LoginIP;
                            adminInfo.LastLoginTime = adminInfo.LoginTime;
                            adminInfo.LoginTime = DateTime.Now;
                            adminInfo.LoginIP = Requests.GetIP();
                            adminInfo.LoginTimes += 1;

                            AdminBLL.UpdateAdmin(adminInfo);
                            ManageUtils.SaveAdminCookie(adminInfo.AdminName, adminInfo.Password);
                            Response.Redirect("Index.aspx");
                        }
                    }
                    else
                    {
                        WebUtility.Alert("用户名不存在！");
                        return;

                    }
                }
            }
        }


    }
}