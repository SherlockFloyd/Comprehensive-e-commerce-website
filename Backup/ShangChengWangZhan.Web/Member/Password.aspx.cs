using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping;
using  Shopping.Model;

namespace Shopping.Web.Member
{
    public partial class Password : MemberPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void updateBtn_Click(object sender, EventArgs e)
        {
           User userInfo = UserBLL.GetUserInfo(onlineUserInfo.UserID);
            string oldpwd = txtOldPwd.Value;
            string newpwd = txtNewPwd.Value.Trim();
            string confirmpwd = txtConfirmPwd.Value.Trim();

            if (oldpwd != userInfo.Password)
            {
                WebUtility.Alert("旧密码错误!");
            }
            else
            {
                if (newpwd != confirmpwd)
                {
                    WebUtility.Alert("两次密码不一致!");
                }
                else
                {
                    userInfo.Password = newpwd;
                    UserBLL.UpdateUser(userInfo);
                    MemberUtils.SaveUserCookie(userInfo);
                    WebUtility.Alert("修改成功!");
                }
            }
        }
    }
}