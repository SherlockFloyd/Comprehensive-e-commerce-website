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
    public partial class DeliveryEdit : MemberPage
    {

        private int deliveryID = 0;
        private Delivery deliveryInfo = null;

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                deliveryID = Utils.StrToInt(Requests.Query("deliveryid"));
                deliveryInfo = DeliveryBLL.GetDeliveryInfo(deliveryID, onlineUserInfo.UserID);
                if (deliveryInfo != null)
                {
                    txtAddress.Value = deliveryInfo.Address;
                    txtName.Value = deliveryInfo.Name;
                    txtTel.Value = deliveryInfo.Tel;
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

            string name = txtName.Value.Trim();
            string tel = txtTel.Value.Trim();
            string address = txtAddress.Value.Trim();
            deliveryID = Utils.StrToInt(Requests.Query("deliveryid"));
            deliveryInfo = DeliveryBLL.GetDeliveryInfo(deliveryID);
            if (deliveryInfo != null)
            {
                deliveryInfo.Name = name;
                deliveryInfo.Tel = tel;
                deliveryInfo.Address = address;


                if (DeliveryBLL.UpdateDelivery(deliveryInfo))
                {
                    WebUtility.Alert("更新成功!", "DeliveryList.aspx");
                }
                else
                {
                    WebUtility.Alert("更新失败!");
                }
            }
        }
    }
}