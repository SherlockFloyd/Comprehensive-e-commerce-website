using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping;
using Shopping.Model;
using Shopping.BLL;

namespace Shopping.Web.Member
{
    public partial class PostRate : MemberPage
    {

        Shopping.Model.Snapshot snapshotInfo = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int snapshotID = Utils.StrToInt(Requests.Query("snapshotid"));
            snapshotInfo = SnapshotBLL.GetSnapshotInfo(snapshotID, onlineUserInfo.UserID);
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

            if (snapshotInfo != null)
            {
                photo.Src = snapshotInfo.Photo;
                Commodityname.Text = snapshotInfo.Name;
                Commodityprice.Text = snapshotInfo.Price.ToString();
                quantity.Text = snapshotInfo.Quantity.ToString();
                totalprice.Text = snapshotInfo.TotalPrice.ToString();
                
                // pressname.Text = snapshotInfo.UserID;
            }
        }

        /// <summary>
        /// 评价按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void subitBtn_Click(object sender, EventArgs e)
        {

            if (snapshotInfo != null)
            {
                if (snapshotInfo.IsGrade == 0)
                {
                    int grade = Utils.StrToInt(Requests.Form("grade"));
                    string ratecontent = content.Value;
                    Rate rateInfo = new  Rate();
                    rateInfo.CommodityID = snapshotInfo.CommodityID;
                    rateInfo.Grade = grade;
                    rateInfo.RateContent = ratecontent;
                    rateInfo.RateTime = DateTime.Now;
                    rateInfo.ReplyContent = "";
                    rateInfo.ReplyTime = DateTime.Now;
                    rateInfo.SnapshotID = snapshotInfo.SnapshotID;
                    rateInfo.UserID = onlineUserInfo.UserID;

                    if (RateBLL.AddRate(rateInfo) > 0)
                    {
                        Shopping.Model.Commodity CommodityInfo = CommodityBLL.GetCommodityInfo(snapshotInfo.CommodityID);
                        if (CommodityInfo != null)
                        {
                            int rateTotal = 0;
                            int gradeTotal = 0;

                            snapshotInfo.IsGrade = 1;
                            SnapshotBLL.UpdateSnapshot(snapshotInfo);//更新快照ID已经被评价

                            List<Rate> list = RateBLL.GetRateList("CommodityID=" + CommodityInfo.CommodityID);

                            foreach (Rate model in list)
                            {
                                rateTotal += 1;
                                gradeTotal += model.Grade;
                            }

                            CommodityInfo.RateTotal = rateTotal;
                            CommodityInfo.GradeTotal = gradeTotal;

                            CommodityBLL.UpdateCommodity(CommodityInfo);//更新商品评价总人数和总分

                            WebUtility.Alert("评价成功!", "RateList.aspx");
                        }
                    }
                    else
                    {
                        WebUtility.Alert("评价失败!");
                    }
                }
                else
                {
                    WebUtility.Alert("您的商品已经评价过了。");
                }
            }
            else
            {
                WebUtility.Alert("您没有购买过该商品，无法参与评价!", "index.aspx");
            }
        }
    }
}