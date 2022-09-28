using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using Shopping;
using Shopping.Model;


namespace Shopping.Web.Member
{
    public partial class Index1 : Shopping.MemberPage
    {
        public User userInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userInfo = UserBLL.GetUserInfo(onlineUserInfo.UserID);
                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            int needOrder = Shopping.BLL.OrderBLL.GetOrderCount("UserID=" + onlineUserInfo.UserID + " AND Status in(" + (int)Shopping.OrderEnum.WaitPay + "," + (int)Shopping.OrderEnum.Send + ")");

            Literal1.Text = needOrder.ToString();


            txtAttentionCount.Text = Shopping.AttentionBLL.GetAttentionCount("UserID=" + onlineUserInfo.UserID).ToString();

            txtNeedRate.Text = Shopping.BLL.SnapshotBLL.GetSnapshotCount("UserID=" + onlineUserInfo.UserID + " AND ISGrade=0 AND Status=" + (int)Shopping.OrderEnum.Success).ToString();


            List<Model.Order> orderlist = Shopping.BLL.OrderBLL.GetOrderList("UserID=" + onlineUserInfo.UserID + string.Format(" AND Status in({0},{1})", (int)Shopping.OrderEnum.WaitPay, (int)Shopping.OrderEnum.Send));

            if (orderlist.Count <= 0)
            {
                PlaceHolder1.Visible = true;
            }
            repeater.DataSource = orderlist;
            repeater.DataBind();



            repeater1.DataSource = Shopping.BLL.SnapshotBLL.GetSnapshotList("UserID=" + onlineUserInfo.UserID + " AND IsGrade=0 AND STATUS=5");
            repeater1.DataBind();

            //consultCount.Text = ConsultBLL.GetConsultCount("UserID=" + onlineUserInfo.UserID + " AND ReplyIsRead=0 AND IsReply=1").ToString();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater photoRep = (Repeater)e.Item.FindControl("photoRepeater");
                Literal link = (Literal)e.Item.FindControl("payLink");

                Shopping.Model.Order orderInfo = (Shopping.Model.Order)e.Item.DataItem;

                if (orderInfo != null)
                {
                    photoRep.DataSource = Shopping.BLL.SnapshotBLL.GetSnapshotList("OrderID=" + orderInfo.OrderID);
                    photoRep.DataBind();

                    if (orderInfo.Status == (int)Shopping.OrderEnum.WaitPay)
                    {
                        if (OrderUtils.CheckStock(orderInfo))
                        {
                            link.Text = string.Format("<a class=\"pay b-3\" href=\"/Pay.aspx?action=pay&orderid={0}\">付款</a><br/>", orderInfo.OrderID);
                        }
                    }
                }
            }
        }
    }
}
