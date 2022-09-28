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
    public partial class DeliveryList : Shopping.MemberPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            repeater.DataSource = DeliveryBLL.GetDeliveryList("UserID=" + onlineUserInfo.UserID);
            repeater.DataBind();
        }


        /// <summary>
        /// 事件操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int deliveryID = Utils.StrToInt(e.CommandArgument);

            if (e.CommandName == "del")
            {
                if (DeliveryBLL.DeleteDelivery(deliveryID))
                {
                    WebUtility.Alert("删除成功!");
                }
                else
                {
                    WebUtility.Alert("删除失败!");
                }
            }

            if (e.CommandName == "setDefault")
            {
                if (DeliveryBLL.SetDefaultDelivery(deliveryID, onlineUserInfo.UserID))
                {

                    WebUtility.Alert("设置成功!");
                }
                else
                {
                    WebUtility.Alert("设置失败!");
                }
            }
        }
    }
}