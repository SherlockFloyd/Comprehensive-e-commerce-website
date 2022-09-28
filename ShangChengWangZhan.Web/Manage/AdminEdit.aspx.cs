using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Shopping;
using Shopping.Model;
using Shopping.BLL;
using Shopping.Common;

namespace Shopping.Web.Manage
{
    public partial class AdminEdit : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="e">事件的参数</param>
        protected void subitBtn_Click(object sender, EventArgs e)
        {

            Admin info = new Admin();
            string adminname = txtAdminName.Value.Trim();
            if (AdminBLL.GetAdminInfoByCondition("AdminName='" + adminname + "'") != null)
            {
                ShowError("此用户名已经存在!");
            }
            info.AdminName = adminname;
            info.Password = "123456";
            info.CreateTime = DateTime.Now;
            info.LastLoginTime = DateTime.Now;
            info.LastLoginIP = "";
            info.LoginTimes = 0;
            info.LoginTime = DateTime.Now;
            info.LoginIP = "";
            int flag = AdminBLL.AddAdmin(info);
            if (flag > 0)
            {
                ShowOK("添加成功!", "AdminList.aspx");
            }
            else
            {
                ShowError("添加失败!");
            }
        }
    }
}