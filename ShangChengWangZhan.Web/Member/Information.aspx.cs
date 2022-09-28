using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping;
using Shopping.Model;

namespace Shopping.Web.Member
{
    public partial class Information : MemberPage
    {
        //private int userID = 0;
        private User userInfo = null;
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //userID = Utils.StrTonInt(Renquests.Query("userid"));
                userInfo = UserBLL.GetUserInfo(onlineUserInfo.UserID);

                if (userInfo != null)
                {
                    txtUserName.Text = userInfo.UserName;
                    txtAddress.Value = userInfo.Address;
                    txtPost.Value = userInfo.Post.ToString();
                    txtEmail.Value = userInfo.Email;
                    txtRealName.Value = userInfo.RealName;
                    txtPhone.Value = userInfo.Phone;
                    txtBirthDay.Value = userInfo.BirthDay.ToString("yyyy-MM-dd");

                    txtSex.DataSource = Shopping.Common.SexUtils.GetSexInfoList();
                    txtSex.DataTextField = "SexName";
                    txtSex.DataValueField = "SexID";
                    txtSex.DataBind();


                    try
                    {
                        txtSex.Items.FindByValue(userInfo.Sex.ToString()).Selected = true;
                    }
                    catch
                    { }
                }
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string realname = txtRealName.Value.Trim();
            int post = Utils.StrToInt(txtPost.Value.Trim());
            int sex = Utils.StrToInt(Requests.Form("txtSex"));
            DateTime birthday = Utils.StrToDateTime(txtBirthDay.Value.Trim());
            string email = txtEmail.Value.Trim();
            string phone = txtPhone.Value.Trim();
            string address = txtAddress.Value.Trim();

            //userID = Utils.StrTonInt(Renquests.Query("userid"));
            userInfo = UserBLL.GetUserInfo(onlineUserInfo.UserID);

            if (userInfo != null)
            {

                userInfo.RealName = realname;
                userInfo.Post = post;
                userInfo.Sex = sex;
                userInfo.BirthDay = birthday;
                userInfo.Email = email;
                userInfo.Phone = phone;
                userInfo.Address = address;


                if (UserBLL.UpdateUser(userInfo))
                {
                    WebUtility.Alert("更新成功!", "Information.aspx");
                }
                else
                {
                    WebUtility.Alert("更新失败!");
                }
            }
        }
    }
}