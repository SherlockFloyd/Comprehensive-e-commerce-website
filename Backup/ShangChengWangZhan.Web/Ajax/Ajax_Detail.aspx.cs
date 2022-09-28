using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using Shopping;
using Shopping.Model;

using Shopping.Common;


namespace Shopping.Web.Ajax
{
    public partial class Ajax_Detail : System.Web.UI.Page
    {
        /// <summary>
        /// 载入输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Response.Expires = 0;//清除缓存
            string action = Requests.All("action");
            int CommodityId = Utils.StrToInt(Requests.All("Commodityid"));
            string result = "";
            switch (action)
            {
                //case "getconsult":
                //    result = GetConsultList(CommodityId);
                //    break;
                case "addfav":
                    result = AddFav(CommodityId);
                    break;
                case "getrate":
                    result = GetRate(CommodityId);
                    break;
            }

            Response.Write(result);
            Response.End();
        }

        /// <summary>
        /// 加入收藏
        /// </summary>
        /// <param name="CommodityId"></param>
        /// <returns></returns>
        private string AddFav(int CommodityId)
        {
            string result = "-1";
            Model.Commodity CommodityInfo = Shopping.BLL.CommodityBLL.GetCommodityInfo(CommodityId);
            Shopping.Model.OnLineUserInfo onlineUserInfo = Shopping.OnLineUser.GetOnLineUserInfo(true);
            if (CommodityInfo != null && onlineUserInfo != null)
            {

                if (AttentionBLL.GetAttentionInfoByCondition("UserID=" + onlineUserInfo.UserID + " AND CommodityID=" + CommodityId) == null)
                {

                    Attention model = new Attention()
                    {
                        CommodityID = CommodityId,
                        CommodityName = CommodityInfo.Name,
                        CreateTime = DateTime.Now,
                        UserID = onlineUserInfo.UserID
                    };

                    int rid = AttentionBLL.AddAttention(model);

                    if (rid > 0)
                    {
                        result = "5";
                    }
                }
                else
                {
                    result = "exist";
                }
            }
            return result;
        }
        /// <summary>
        /// 获取商品评价列表信息
        /// </summary>
        /// <param name="CommodityId"></param>
        /// <returns></returns>
        private string GetRate(int CommodityId)
        {
            int pagesize = Utils.StrToInt(Requests.All("S"));
            int pageIndex = Utils.StrToInt(Requests.All("P"));

            string condition = "CommodityID=" + CommodityId;


            StringBuilder result = new StringBuilder();
            List<Rate> list = RateBLL.GetRateList(pagesize, pageIndex, condition);
            int recordCount = RateBLL.GetRateCount(condition);
            result.Append("<ul class=\"pj-list\">");

            foreach (Rate rateInfo in list)
            {
                result.Append("<li class=\"clearfix\">");
                result.Append("<div class=\"pj-avatar\">");
                result.Append("<div class=\"pj-user-avatar\"><img src=\"/images/UserGroup/VIP会员.png\"></div>");
                result.Append("<div class=\"pj-user-name\">" + rateInfo.UserName + "</div>");
                result.Append("</div>");
                result.Append("<div class=\"pj-box\">");
                result.Append("<i></i>");
                result.Append("<div class=\"pj-top clearfix\"><span class=\"pj-star\"><em>商品评分：</em><a class=\"comment-star\"><span class=\"tstar w" + 14 * rateInfo.Grade + "\"></span></a>&nbsp;<span class=\"pj-date\">发布时间：" + rateInfo.RateTime + "</span></div>");
                result.Append("<div class=\"pj-content\"><strong>点评内容：</strong>" + rateInfo.RateContent + "</div>");

                if (rateInfo.ReplyContent != "")
                {
                    result.Append("<div class=\"pj-useable\">回复内容 ：<font color=\"black\">" + rateInfo.ReplyContent + "</font></div>");
                }
                result.Append("</div>");
                result.Append("</li>");
            }


            result.Append("</ul>");
            int PageCont = (recordCount % pagesize == 0 ? recordCount / pagesize : (recordCount / pagesize) + 1);
            return PageCont + "*" + recordCount + "●" + Utils.UriEncode(result.ToString());
        }
        /// <summary>
        /// 获取商品评价列表信息
        /// </summary>
        /// <param name="CommodityId"></param>
        /// <returns></returns>
        //private string GetConsultList(int CommodityId)
        //{
        //    int pagesize = Utils.StrToInt(Requests.All("S"));
        //    int pageIndex = Utils.StrToInt(Requests.All("P"));

        //    string condition = "CommodityID=" + CommodityId;


        //    //StringBuilder result = new StringBuilder();
        //    //List<Consult> list = ConsultBLL.GetConsultList(pagesize, pageIndex, condition, "ConsultID", "DESC");
        //    //int recordCount = ConsultBLL.GetConsultCount(condition);
        //    //result.Append("<ul class=\"pj-list\">");

        //    //foreach (Consult info in list)
        //    //{
        //    //    result.Append("<li class=\"clearfix\">");
        //    //    result.Append("<div class=\"pj-avatar\">");
        //    //    result.Append("<div class=\"pj-user-avatar\"><img src=\"/images/UserGroup/VIP会员.png\"></div>");
        //    //    result.Append("<div class=\"pj-user-name\">" + Utils.HideUserName(info.UserName) + "</div>");
        //    //    result.Append("</div>");
        //    //    result.Append("<div class=\"pj-box\">");
        //    //    result.Append("<i></i>");
        //    //    result.Append("<div class=\"pj-top clearfix\"><span class=\"pj-date\">咨询时间：" + info.CreateTime + "</span></div>");
        //    //    result.Append("<div class=\"pj-content\"><strong>咨询内容：</strong>" + info.Content + "</div>");

        //    //    //if (info.ReplyContent != "")
        //    //    //{
        //    //    //    result.Append("<div class=\"pj-useable\">回复内容 ：<font color=\"black\">" + info.ReplyContent + "</font></div>");
        //    //    //}
        //    //    result.Append("</div>");
        //    //    result.Append("</li>");
        //    //}


        //    result.Append("</ul>");
        //    int PageCont = (recordCount % pagesize == 0 ? recordCount / pagesize : (recordCount / pagesize) + 1);
        //    return PageCont + "*" + recordCount + "●" + Utils.UriEncode(result.ToString());
        //}
    }
}