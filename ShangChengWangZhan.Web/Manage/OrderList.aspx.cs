
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using Shopping;
using Shopping.Model;
using Shopping.BLL;
using Shopping.Common;
namespace Shopping.Web.Manage
{
    public partial class OrderList : ManagePage
    {

        #region 基本变量
        /// <summary>
        /// 过滤条件变量
        /// </summary>
        StringBuilder condition = new StringBuilder();
        #endregion
        
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
            GetCondition();
            datagrid.VirtualItemCount = OrderBLL.GetOrderCount(condition.ToString());
            datagrid.DataSource = OrderBLL.GetOrderList(datagrid.PageSize, datagrid.CurrentPageIndex + 1, condition.ToString(),"OrderID","DESC");
            datagrid.DataBind();
        }
        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetCondition()
        {
            string keyword = txtKeyword.Value.Trim();
            if (keyword != "")
            {
                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat(" OrderNo like '%{0}%'", keyword);
            }

            return condition.ToString();
        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void datagrid_OnItemDataBound(Object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //    Repeater repeater = (Repeater)e.Item.FindControl("repeater");
                //    Model.Order orderInfo = (Model.Order)e.Item.DataItem;

                //    if (orderInfo != null)
                //    {
                //        repeater.DataSource = SnapshotBLL.GetSnapshotList("OrderID=" + orderInfo.OrderID);
                //        repeater.DataBind();

                //    }
            }
        }
        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void search_btn_Click(object sender, EventArgs e)
        {
            datagrid.CurrentPageIndex = 0;
            BindData();
        }
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void datagrid_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
            datagrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void datagrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int id = Utils.StrToInt(e.CommandArgument);
            switch (e.CommandName)
            {
                case "del":
                    
                    Delete(id);
                    break;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id">ID</param>
        private void Delete(int Id)
        {
            bool flag = OrderBLL.DeleteOrder(Id);
            if (flag)
            {
                ShowOK("删除成功!");
            }
            else
            {
                ShowError("删除失败!");
            }
        }
    }
}