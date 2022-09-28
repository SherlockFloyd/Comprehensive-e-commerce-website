
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Model;
using Shopping.BLL;
using Shopping.Common;

namespace Shopping.Web.Manage
{
    public partial class CommodityEdit : ManagePage
    {

        #region 基本变量
        private Commodity info;
        private string action;
        private int id;
        #endregion

        private int commoditiyid = 0;
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Requests.Query("action");
            commoditiyid = Utils.StrToInt(Requests.Query("id"));
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定事件
        /// </summary>
        private void BindData()
        {
            txtCateID.DataSource = CateBLL.GetCateList();
            txtCateID.DataTextField = "Name";
            txtCateID.DataValueField = "CateID";
            txtCateID.DataBind();

            txtCommodityNo.Value = DateTime.Now.ToString("yyyyMMddHHmmss") + Utils.GetRandomString(1, 4, "0123456789");
            txtCommodityNo.Disabled = true;

            //txtPoint.Disabled = true;

            if (action == "edit")
            {
                Commodity info = CommodityBLL.GetCommodityInfo(commoditiyid);
                if (info != null)
                {


                    txtPrice.Value = info.Price.ToString();
                    txtRemark.Value = info.Remark;
                    txtName.Value = info.Name;
                    txtCommodityNo.Value = (info.CommodityNo == "" ? CommodityUtils.GetCommodityNo() : info.CommodityNo);
                    txtMarketPrice.Value = info.MarketPrice.ToString();

                    txtStock.Value = info.Stock.ToString();
                    Img1.Src = info.Photo;
             
                    try
                    {
                        txtCateID.Items.FindByValue(info.CommodityID.ToString()).Selected = true;
                    }
                    catch
                    {

                    }
                }

            }
        }

        #region 更新事件
        /// <summary>
        /// 更新
        /// </summary>
        private void Update()
        {


            decimal marketprice = Utils.StrToDecimal(txtMarketPrice.Value.Trim());

            decimal price = Utils.StrToDecimal(txtPrice.Value.Trim());
            string remark = txtRemark.Value.Trim();
            string name = txtName.Value.Trim();
            string Commodityno = txtCommodityNo.Value.Trim();

            int cateid = Utils.StrToInt(txtCateID.Value.Trim());
            int pressid = Utils.StrToInt(Requests.Form("txtPressID"));

            //int point = 0;// Utils.StrToInt(txtPoint.Value.Trim());
            int stock = Utils.StrToInt(txtStock.Value.Trim());

            string filenamePath = "";
            Upload upload = new Upload();
            if (Request.Files["txtPhoto"].ContentLength > 0)
            {
                upload.InceptFile = "jpg,gif";
                string path = "/Images/Commodity/";
                upload.Save(Request.Files["txtPhoto"], path, out filenamePath);
            }

            if (filenamePath == "" && Request.Files["txtPhoto"].ContentLength > 0)
            {
                WebUtility.Alert(upload.ErrString());
                return;
            }

            Commodity info = CommodityBLL.GetCommodityInfo(commoditiyid);

            if (info != null)
            {

                info.MarketPrice = marketprice;

                info.Price = price;
                if (filenamePath != "")
                    info.Photo = filenamePath;
                info.Remark = remark;
                info.Name = name;
                info.CommodityNo = Commodityno;

                info.CateID = cateid;

                info.Stock = stock;
                info.IsNew = 0;
                info.IsRecommend = 0;
                info.IsHot = 0;
                //info.Point = point;// (Utils.StrToInt(price / 10) > 30 ? 30 : Utils.StrToInt(price / 10));
                info.UpdateTime = DateTime.Now;

                bool flag = CommodityBLL.UpdateCommodity(info);
                if (flag)
                {
                    CommodityUtils.UpdateForSerach(info);//更新搜索字段
                    WebUtility.Alert("更新成功!", "CommodityList.aspx");
                }
                else
                {
                    WebUtility.Alert("更新失败!");
                }
            }
        }
        #endregion

        #region 添加事件
        /// <summary>
        /// 添加
        /// </summary>
        private void Add()
        {
            decimal marketprice = Utils.StrToDecimal(txtMarketPrice.Value.Trim());
            decimal price = Utils.StrToDecimal(txtPrice.Value.Trim());
            string remark = txtRemark.Value.Trim();
            string name = txtName.Value.Trim();
            string Commodityno = txtCommodityNo.Value.Trim();

            int cateid = Utils.StrToInt(txtCateID.Value.Trim());

            //int point = 0;// Utils.StrToInt(txtPoint.Value.Trim());
            int stock = Utils.StrToInt(txtStock.Value.Trim());
            string filenamePath = "";
            Upload upload = new Upload();
            if (Request.Files["txtPhoto"].ContentLength > 0)
            {
                upload.InceptFile = "jpg,gif";
                string path = "/Images/Commodity/";
                upload.Save(Request.Files["txtPhoto"], path, out filenamePath);
            }

            if (filenamePath == "" && Request.Files["txtPhoto"].ContentLength > 0)
            {
                WebUtility.Alert(upload.ErrString());
                return;
            }
            Commodity info = new Commodity();
            if (filenamePath != "")
                info.Photo = filenamePath;


            info.MarketPrice = marketprice;

            info.Price = price;
            info.OnSale = 1;
            info.OnSaleTime = DateTime.Now;
            info.Remark = remark;
            info.Name = name;
            info.RateTotal = 0;
            info.GradeTotal = 0;
            info.CreateTime = DateTime.Now;
            info.CommodityNo = Commodityno;

            info.CateID = cateid;
            //info.UserID = onlineUserInfo.UserID;
            info.Stock = stock;
            info.IsNew = 0;
            info.IsRecommend = 0;
            info.IsHot = 0;
            //info.Point = point;// (Utils.StrToInt(price / 10) > 30 ? 30 : Utils.StrToInt(price / 10));

            info.UpdateTime = DateTime.Now;
            info.OnSale = 2;


            int flag = CommodityBLL.AddCommodity(info);
            if (flag > 0)
            {
                CommodityUtils.UpdateForSerach(info);//更新搜索字段
                WebUtility.Alert("添加成功!", "CommodityList.aspx");
            }
            else
            {
                WebUtility.Alert("添加失败!");
            }
        }
        #endregion

        protected void subitBtn_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case "add":
                    Add();
                    break;
                case "edit":
                    Update();
                    break;
            }
        }
    }
}