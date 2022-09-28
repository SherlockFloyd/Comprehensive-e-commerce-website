using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping.Common;
using Shopping;

namespace Shopping.Web.Member
{
    public partial class AttentionList : Shopping.MemberPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }


        
        private void BindData()
        {

            string condition = "UserID=" + onlineUserInfo.UserID;

            pager.Total = AttentionBLL.GetAttentionCount(condition);
            pager.Calculate();

            repeater.DataSource =AttentionBLL.GetAttentionList(pager.PageSize, pager.CurrentPage, condition);
            repeater.DataBind();
        }


        /// <summary>
        /// 事件操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int AttentionID = Utils.StrToInt(e.CommandArgument);

            if (e.CommandName == "cancel")
            {
                if (AttentionBLL.DeleteAttention(AttentionID))
                {
                    WebUtility.Alert("成功取消!");
                }
                else
                {
                    WebUtility.Alert("取消失败!");
                }

            }

            
        }
    }
}