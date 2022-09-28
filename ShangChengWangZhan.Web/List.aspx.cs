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

namespace Shopping.Web
{
    public partial class List : System.Web.UI.Page
    {

        
        private ListPageUrlInfo listPageUrlInfo = null;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindData();
            }
        }

        
        private void BindData()
        {
            int cateId = Utils.StrToInt(Requests.All("cateid"));
            string keyword = Utils.UrlEncode(Requests.All("k"));
            int ishot = Utils.StrToInt(Requests.All("h"));
            int isnew = Utils.StrToInt(Requests.All("n"));
            int ordertype = Utils.StrToInt(Requests.All("o"));

            if (cateId > 0)
            {
                pager.SetItem("cateid", cateId);
            }


            if (keyword != "")
            {
                pager.SetItem("k", keyword);
            }
            if (ishot == 1)
            {
                pager.SetItem("h", "1");
            }
            if (isnew == 1)
            {
                pager.SetItem("n", "1");
            }
            if (ordertype > 0)
            {
                pager.SetItem("o", ordertype);
            }

            listPageUrlInfo = new ListPageUrlInfo();

            listPageUrlInfo.CateID = cateId;
            listPageUrlInfo.KeyWord = keyword;
            listPageUrlInfo.IsNew = isnew;
            listPageUrlInfo.IsHot = ishot;
            listPageUrlInfo.OrderType = (OrderTypeEnum)ordertype;

            //设置排序
            SetSortType();

            //类别信息绑定
            BindCate();


            //获取商品列表
            GetCommodityList();

            //设置搜索条件
            SetSerachCondition();
        }

        #region 获取商品列表
        
        private void GetCommodityList()
        {
            int total = 0;
            List<Commodity> list = Shopping.LuceneUtils.GetCommodityList(pager.PageSize, pager.CurrentPage, listPageUrlInfo, out total);
            pager.Total = total;



            pager.Calculate();
            repeater.DataSource = list;
            repeater.DataBind();
        }
        #endregion

        
        public void SetSerachCondition()
        {
            StringBuilder serachCondition = new StringBuilder();

            if (listPageUrlInfo.CateID > 0)
            {
                Cate cateInfo = CateBLL.GetCateInfo(listPageUrlInfo.CateID);

                if (cateInfo != null)
                {
                    ListPageUrlInfo tempPageUrlInfo = new ListPageUrlInfo(listPageUrlInfo);
                    tempPageUrlInfo.CateID = 0;
                    serachCondition.AppendFormat("<li><a class=\"cancel\" href=\'{0}'>{1}</a>", UrlFactory.GetCommodityDetailAspxRewrite(tempPageUrlInfo, 1), cateInfo.Name);
                }
            }
            else
            {
                PlaceHolder2.Visible = true;
            }



            if (listPageUrlInfo.KeyWord != "" && listPageUrlInfo.KeyWord != "0")
            {
                ListPageUrlInfo tempPageUrlInfo = new ListPageUrlInfo(listPageUrlInfo);
                tempPageUrlInfo.KeyWord = "";
                serachCondition.AppendFormat("<li><a class=\"cancel\" href=\'{0}'>{1}</a>", UrlFactory.GetCommodityDetailAspxRewrite(tempPageUrlInfo, 1), Utils.UrlDecode(listPageUrlInfo.KeyWord));
            }

            if (listPageUrlInfo.IsHot == 1)
            {
                ListPageUrlInfo tempPageUrlInfo = new ListPageUrlInfo(listPageUrlInfo);
                tempPageUrlInfo.IsHot = 0;
                serachCondition.AppendFormat("<li><a class=\"cancel\" href=\'{0}'>{1}</a>", UrlFactory.GetCommodityDetailAspxRewrite(tempPageUrlInfo, 1), "热卖");

            }

            if (listPageUrlInfo.IsNew == 1)
            {
                ListPageUrlInfo tempPageUrlInfo = new ListPageUrlInfo(listPageUrlInfo);
                tempPageUrlInfo.IsNew = 0;
                serachCondition.AppendFormat("<li><a class=\"cancel\" href=\'{0}'>{1}</a>", UrlFactory.GetCommodityDetailAspxRewrite(tempPageUrlInfo, 1), "新品");
            }



            if (serachCondition.ToString() != "")
            {
                chooseCondition.Text = serachCondition.ToString();
                PlaceHolder1.Visible = true;

                //重置筛选条件
                ListPageUrlInfo resetSerachCodition = new ListPageUrlInfo(listPageUrlInfo);
                resetSerachCodition.IsNew = 0;
                resetSerachCodition.IsHot = 0;
                resetSerachCodition.KeyWord = "";
                resetSerachCodition.CateID = 0;
                resetSerachCodition.OrderType = OrderTypeEnum.销量;
                Literal1.Text = string.Format("<a href='{0}'>重置所有筛选条件</a>", UrlFactory.GetCommodityDetailAspxRewrite(resetSerachCodition, 1));
            }

        }



        #region 设置排序
        
        private void SetSortType()
        {
            //默认
            ListPageUrlInfo tempSerachCondition = new ListPageUrlInfo(listPageUrlInfo);
            tempSerachCondition.OrderType = OrderTypeEnum.销量;
            //s1.Text = string.Format("<a href='{0}'>销量</a>", UrlFactory.GetCommodityDetailAspxRewrite(tempSerachCondition, 1));

            //热卖
            ListPageUrlInfo hotsaleSerachCondition = new ListPageUrlInfo(listPageUrlInfo);
            hotsaleSerachCondition.IsHot = 1;
            hotsaleSerachCondition.IsNew = 0;
            //s2.Text = string.Format("<a href='{0}'>热卖</a>", UrlFactory.GetCommodityDetailAspxRewrite(hotsaleSerachCondition, 1));

            //新品
            ListPageUrlInfo newSerachCondition = new ListPageUrlInfo(listPageUrlInfo);
            newSerachCondition.IsHot = 0;
            newSerachCondition.IsNew = 1;
            //s3.Text = string.Format("<a href='{0}'>新品</a>", UrlFactory.GetCommodityDetailAspxRewrite(newSerachCondition, 1));



            if (listPageUrlInfo.OrderType != OrderTypeEnum.价格从低到高 && listPageUrlInfo.OrderType != OrderTypeEnum.价格从高到低)
            {
                ListPageUrlInfo priceListPageUrlInfo = new ListPageUrlInfo(listPageUrlInfo);
                priceListPageUrlInfo.OrderType = OrderTypeEnum.价格从低到高;
                //s4.Text = string.Format("<a href='{0}'>价格↑</a>", UrlFactory.GetCommodityDetailAspxRewrite(priceListPageUrlInfo, 1));
            }
            else if (listPageUrlInfo.OrderType == OrderTypeEnum.价格从低到高)
            {
                ListPageUrlInfo priceListPageUrlInfo = new ListPageUrlInfo(listPageUrlInfo);
                priceListPageUrlInfo.OrderType = OrderTypeEnum.价格从高到低;
                //s4.Text = string.Format("<a href='{0}'>价格↑</a>", UrlFactory.GetCommodityDetailAspxRewrite(priceListPageUrlInfo, 1));
            }
            else if (listPageUrlInfo.OrderType == OrderTypeEnum.价格从高到低)
            {
                ListPageUrlInfo priceListPageUrlInfo = new ListPageUrlInfo(listPageUrlInfo);
                priceListPageUrlInfo.OrderType = OrderTypeEnum.价格从低到高;
                //s4.Text = string.Format("<a href='{0}'>价格↓</a>", UrlFactory.GetCommodityDetailAspxRewrite(priceListPageUrlInfo, 1));
            }

            if (listPageUrlInfo.OrderType == OrderTypeEnum.销量)
            {
                Shopping.Controls.Span s11 = (Shopping.Controls.Span)FindControl("s1");
                //s11.Attributes.Add("class", "selected");
            }
            if (listPageUrlInfo.IsHot == 1)
            {
                Shopping.Controls.Span s11 = (Shopping.Controls.Span)FindControl("s2");
                //s11.Attributes.Add("class", "selected");
            }
            if (listPageUrlInfo.IsNew == 1)
            {
                Shopping.Controls.Span s11 = (Shopping.Controls.Span)FindControl("s3");
                //s11.Attributes.Add("class", "selected");
            }
            if (listPageUrlInfo.OrderType == OrderTypeEnum.价格从低到高 || listPageUrlInfo.OrderType == OrderTypeEnum.价格从高到低)
            {
                Shopping.Controls.Span s11 = (Shopping.Controls.Span)FindControl("s4");
                //s11.Attributes.Add("class", "selected");
            }
            else
            {
                Shopping.Controls.Span s11 = (Shopping.Controls.Span)FindControl("s1");
                //s11.Attributes.Add("class", "selected");
            }
        }
        #endregion

        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        private void BindCate()
        {
            cateRepeater.DataSource = CateBLL.GetCateList();
            cateRepeater.DataBind();
        }
        /// <summary>
        /// 绑定事件[类别]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cateRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal cateLink = (Literal)e.Item.FindControl("txtCateLink");

                Cate cateInfo = (Cate)e.Item.DataItem;

                if (cateInfo != null)
                {
                    ListPageUrlInfo cateSerachCondition = new ListPageUrlInfo(listPageUrlInfo);
                    cateSerachCondition.CateID = cateInfo.CateID;
                    cateLink.Text = string.Format("<a href='{0}'>{1}<a>", UrlFactory.GetCommodityDetailAspxRewrite(cateSerachCondition, 1), cateInfo.Name);
                }
            }
        }

        #endregion








    }
}