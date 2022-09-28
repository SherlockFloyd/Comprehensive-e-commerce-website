using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using Shopping;
using Shopping.BLL;
using Shopping.Common;

namespace Shopping.Web.Manage
{
    public partial class Password : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void subitBtn_Click(object sender, EventArgs e)
        {
            string old = Password1.Value.Trim();
            string p1 = Password2.Value.Trim();
            string p2 = Password3.Value.Trim();

            if (old == "" || p1 == "" || p2 == "")
            {
                ShowError("请输入完整密码！");
            }

            if (adminInfo.Password != old)
            {
                ShowError("旧密码错误！");
            }

            if (p1 != p2)
            {
                ShowError("两次密码不一致！");
            }
            else
            {
                adminInfo.Password = p1;

                if (AdminBLL.UpdateAdmin(adminInfo))
                {
                    ManageUtils.SaveAdminCookie(adminInfo.AdminName, adminInfo.Password);
                    ShowOK("更新成功！","AdminList.aspx");
                }
                else
                {
                    ShowError("更新失败！");
                }
            }
        }
    }
}