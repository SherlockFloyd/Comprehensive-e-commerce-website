using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Shopping.Common;
using Shopping;
using Shopping.BLL;



namespace Shopping.Web.Member
{
    public partial class OrderList : MemberPage
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
            string condition = GetCondition();
            pager.Total = OrderBLL.GetOrderCount(condition);
            pager.Calculate();

            repeater.DataSource = OrderBLL.GetOrderList(pager.PageSize, pager.CurrentPage, condition, "OrderTime", "DESC");
            repeater.DataBind();
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        private string GetCondition()
        {
            StringBuilder condition = new StringBuilder();
            condition.AppendFormat("UserID={0}", onlineUserInfo.UserID);

            string keyword = Requests.All("key");

            if (keyword != "")
            {
                pager.SetItem("key", Utils.UrlEncode(keyword));

                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat("OrderNo='{0}'", Utils.UrlDecode(keyword));
            }

            if (Requests.All("action") == "operate")
            {
                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat(" Status in({0},{1})", (int)Shopping.OrderEnum.WaitPay, (int)Shopping.OrderEnum.Send);
            }


            return condition.ToString();
        }

        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void serachBtn_Click(object sender, EventArgs e)
        {
            BindData();
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
                    photoRep.DataSource = SnapshotBLL.GetSnapshotList("OrderID=" + orderInfo.OrderID);
                    photoRep.DataBind();

                    if (orderInfo.Status == (int)OrderEnum.WaitPay)
                    {
                        link.Text = string.Format("<a class=\"pay b-1\" href=\"/Pay.aspx?action=pay&orderid={0}\">付款</a><br/>", orderInfo.OrderID);
                    }
                }
            }
        }
    }
}