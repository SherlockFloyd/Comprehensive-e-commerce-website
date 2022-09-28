using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using Shopping.Common;
using Shopping;


namespace Shopping.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string name = username.Value.Trim();
            string password = txtPassword.Value.Trim();
            string confirmpassword = txtConfirmPassword.Value.Trim();
            string code = txtCode.Value.Trim();

            if (name == "" || password == "" || confirmpassword == "")
            {
                WebUtility.Alert("请输入完整的用户信息。");
                return;
            }

            if (password != confirmpassword)
            {
                WebUtility.Alert("您输入的两次密码不一致。");
                return;
            }

            if (Utils.GetSession("CheckCode").ToString() != code)
            {
                WebUtility.Alert("验证码错误啦!");
                return;
            }
            else
            {
             Shopping.Model.User userInfo = UserBLL.GetUserByUserName(name);

                if (userInfo != null)
                {
                    WebUtility.Alert("您输入的用户名已经存在。");
                    return;
                }
                else
                {
                    userInfo = new Shopping.Model.User()
                    {
                        UserName = name,
                        Password = password,
                        RegTime = DateTime.Now,
                        LastLoginTime = DateTime.Now,
                        LoginTime = DateTime.Now,
                        Sex = (int)SexEnum.WoMen,
                        BirthDay = DateTime.Now,
                        LoginTimes = 0,
                        Point = 0,
                        Status = 1,
                        Address = "",
                        Email = name,
                        EmailIsChecked = 0,
                        LastLoginIP = "",
                        LoginIP = "",
                        Phone = "",
                        Post = 000000,
                        RealName = ""
                    };


                    if (UserBLL.AddUser(userInfo) > 0)
                    {
                     

                        Shopping.MemberUtils.SaveUserCookie(userInfo);
                    }

                    Response.Redirect("Index.aspx");
                }
            }
        }
    }
}