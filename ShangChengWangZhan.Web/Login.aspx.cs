using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping;
using Shopping.Model;
using Shopping.Common;

namespace Shopping.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Requests.Query("action");

            if (action == "logout")
            {
                MemberUtils.RemoveUserCookie();
                Response.Redirect("Index.aspx");
            }
        }

        
        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string name = username.Value.Trim();

            string password = txtPassword.Value.Trim();

            string code = txtCode.Value.Trim();

            string verifyCode = "";
            try
            {
                verifyCode = Utils.GetSession("CheckCode").ToString();
            }
            catch
            {
            }

            if (name == "" || password == "")
            {
                WebUtility.Alert("请输入完整的用户信息。");
                return;
            }
            if (verifyCode != code)
            {
                WebUtility.Alert("验证码错误啦!");
                return;
            }
            else
            {
                Shopping.Model.User userInfo = UserBLL.GetUserByUserName(name);
                if (userInfo != null)
                {
                    if (userInfo.Password == password)
                    {
                        userInfo.LastLoginIP = userInfo.LoginIP;
                        userInfo.LastLoginTime = userInfo.LoginTime;
                        userInfo.LoginTimes += 1;
                        userInfo.LoginTime = DateTime.Now;
                        userInfo.LoginIP = Requests.GetIP();
                        UserBLL.UpdateUser(userInfo);

                        MemberUtils.SaveUserCookie(userInfo);

                        string returnUrl = "Index.aspx";
                        if (Requests.Query("returnurl") != "")
                            returnUrl = Requests.Query("returnurl");
                        Response.Redirect(returnUrl);
                    }
                    else
                    {
                        WebUtility.Alert("密码错误。");
                        return;
                    }
                }
                else
                {
                    WebUtility.Alert("用户不存在。");
                    return;
                }
            }
        }
    }
}