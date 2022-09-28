
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
    public partial class CommodityList : ManagePage
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
            string condition = GetCondition();
            datagrid.VirtualItemCount = CommodityBLL.GetCommodityCount(condition);
            datagrid.DataSource = CommodityBLL.GetCommodityList(datagrid.PageSize, datagrid.CurrentPageIndex + 1, condition,"UpdateTime","DESC");
            datagrid.DataBind();
        }
        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetCondition()
        {
            StringBuilder condition = new StringBuilder();

            int onSale = Utils.StrToInt(Requests.All("txtOnsale"));

            string keyword = txtKeyword.Value.Trim();
            if (keyword != "")
            {
                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat(" Name like '%{0}%'", keyword);
            }
            if (onSale > 0)
            {
                if (condition.ToString() != "")
                    condition.Append(" AND ");
                condition.AppendFormat(" OnSale={0}", onSale);
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
            bool flag = CommodityBLL.DeleteCommodity(Id);
            if (flag)
            {
                ShowOK("删除成功!");
            }
            else
            {
                ShowError("删除失败!");
            }
        }

        /// <summary>
        /// 批量上架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void batchOnsaleBtn_Click(object sender, EventArgs e)
        {
            string CommodityIds = Requests.Form("CommodityIDs");
            if (CommodityIds == "")
            {
                ShowError("请选择要上架的商品!");
            }
            if (CommodityBLL.BatchUpdateCommodityStatus(2, CommodityIds))
            {
                ShowOK("批量上架成功!");
            }
            else
            {
                ShowError("批量上架失败!");
            }
        }

        /// <summary>
        /// 批量下架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void batchOffSaleBtn_Click(object sender, EventArgs e)
        {
            string CommodityIds = Requests.Form("CommodityIDs");
            if (CommodityIds == "")
            {
                ShowError("请选择要下架的商品!");
            }
            if (CommodityBLL.BatchUpdateCommodityStatus(1, CommodityIds))
            {
                ShowOK("批量下成功!");
            }
            else
            {
                ShowError("批量下架失败!");
            }
        }
    }
}