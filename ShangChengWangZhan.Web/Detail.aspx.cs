using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping.Model;
using Shopping.BLL;


namespace Shopping.Web
{
    public partial class Detail : BasePage
    {
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Commodityid = Utils.StrToInt(Requests.Query("Commodityid"));
                Commodity model = CommodityBLL.GetCommodityInfo(Commodityid);
                if (model != null)
                {
                    txtPhoto.Src = model.Photo;
                    txtRemark.Text = (model.Remark == "" ? "<div style='padding:20px'>暂无简介</div>" : model.Remark);
                    txtMarketPrice.Text = model.MarketPrice.ToString();
                    price.Text = model.Price.ToString();
                    Commodityname.Text = model.Name;
                    ListPageUrlInfo listPageUrlInfo = new ListPageUrlInfo()
                    {
                        CateID = model.CateID
                    };
                    txtCommodityid.Value = model.CommodityID.ToString();
                    int stock = model.Stock;
                    string stockTip = "";
                    if (stock <= 10)
                    {
                        stockTip = "(<font class='red'>库存紧张</font>)";
                    }
                    if (stock <= 0)
                    {
                        stockTip = "(<font class='red'>无库存</font>)";
                    }
                    stockIntro.Text = stockTip;

                    txtStock.Text = model.Stock.ToString();
                    txtRealName.Text = model.RealName;
           
                    decimal CommodityGradeAverage = 5.00M;
                    txtRateTotal.Text = model.RateTotal.ToString();
                    if (model.RateTotal > 0)
                    {
                        CommodityGradeAverage = Utils.GetPriceByRound(2, model.GradeTotal / Utils.StrToDecimal(model.RateTotal));
                    }
                    decimal grade = Utils.GetPriceByRound(0, CommodityGradeAverage * 14);
                    txtGrade.Text = "<span class=\"t_stat1 w" + grade + "\"></span>";
                    tGrade.Text = "&nbsp;<em>" + Utils.GetPriceByRound(1, CommodityGradeAverage) + "</em>&nbsp;(<a href=\"javascript:;\" class=\"t_0\"> 已有" + model.RateTotal + "人评价</a>)";
                    model.Visits += 1;

                    attentionCount.Text = Shopping.AttentionBLL.GetAttentionCount("CommodityID=" + Commodityid).ToString();

                    //Literal1.Text = Shopping.ConsultBLL.GetConsultCount("CommodityID=" + Commodityid).ToString();

                    GetVisitLog(Commodityid);

                    CommodityBLL.UpdateCommodity(model);


                    visitLogOperate.AddVisitLog(Commodityid, 1);


                    List<Commodity> tjList = LuceneUtils.GetCommodityList(model.ForSerach, Commodityid);

                    repeater2.DataSource = tjList;
                    repeater2.DataBind();
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }


        }

        #region 获取浏览记录

        /// <summary>
        /// 获取浏览记录
        /// </summary>
        /// <param name="CommodityID"></param>
        private void GetVisitLog(int CommodityID)
        {
            repeater1.DataSource = visitLogOperate.VisitLogList.Where(c => c.CommodityID != CommodityID).ToList();
            repeater1.DataBind();

            repeater3.DataSource = VisitLogBLL.GetVisitLogOther(6, CommodityID);
            repeater3.DataBind();
        }

        #endregion

        /// <summary>
        /// 提交咨询内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void subitConsultContentBtn_Click(object sender, EventArgs e)
        {

            Shopping.Model.OnLineUserInfo onlineUserInfo = Shopping.OnLineUser.GetOnLineUserInfo(true);
            if (onlineUserInfo == null)
            {
                Response.Redirect("Login.aspx");
            }

            int Commodityid = Utils.StrToInt(txtCommodityid.Value);

            Model.Commodity commodityInfo = CommodityBLL.GetCommodityInfo(Commodityid);

            if (commodityInfo == null)
            {
                Response.Redirect("List.aspx");
            }

            //if (commodityInfo.UserID == onlineUserInfo.UserID)
            //{
            //    WebUtility.Alert("抱歉,无法对自己的商品进行咨询!");
            //    return;
            //}

            //string content = txtConsultContent.Value.Trim();

            //if (content == "")
            //{
            //    WebUtility.Alert("请输入咨询内容!");
            //    return;
            //}


            //Shopping.Model.Consult model = new Shopping.Model.Consult()
            //{
            //    CommodityID = Commodityid,
            //    Name = Commodityname.Text,
            //    Content = content,
            //    CreateTime = DateTime.Now,
            //    IsReply = 0,
            //    ReplyContent = "",
            //    ReplyIsRead = 0,
            //    ReplyTime = DateTime.Now,
            //    UserID = onlineUserInfo.UserID,
            //    UserName = onlineUserInfo.UserName
            //};

            //if (Shopping.ConsultBLL.AddConsult(model) > 0)
            //{
            //    WebUtility.Alert("提交成功!", "Detail.aspx?commodityid=" + Commodityid);
            //}
            //else
            //{
            //    WebUtility.Alert("提交失败!");
            //    return;
            //}
        }
    }
}