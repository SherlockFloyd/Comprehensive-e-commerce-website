using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shopping.Model;
using Shopping.BLL;
using Shopping.Common;



namespace Shopping
{

    /// <summary>
    /// 排序类型
    /// </summary>
    public enum OrderTypeEnum
    {
        销量 = 1,
        价格从低到高 = 2,
        价格从高到低 = 3
    }

   
    public class LuceneUtils
    {
        #region 构建搜索条件
        /// <summary>
        /// 取得关键字分词结果
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<string> GetWordSegmentation(string keyword)
        {
            List<string> words = new List<string>();
            Rainsoft.WordSegment.SegmentV3 tv = new Rainsoft.WordSegment.SegmentV3();
            string[] wordsBySeg = tv.Segment(keyword.Replace("书", ""));

            foreach (string word in wordsBySeg)
            {
                if (!words.Contains(word))
                {
                    words.Add(word);
                }
            }

            if (keyword.Contains("书"))
            {
                words.Add("书");
            }

            if (words.Count <= 0)
            {
                words.Add(keyword);
            }

            return words;
        }
        /// <summary>
        /// 构建搜索条件
        /// </summary>
        /// <param name="listPageUrlInfo"></param>
        /// <returns></returns>
        public static string BuildSerachCondition(ListPageUrlInfo listPageUrlInfo)
        {
            StringBuilder condition = new StringBuilder();
            condition.Append(" OnSale=2");
            if (listPageUrlInfo.CateID > 0)
            {
                if (condition.ToString() != "")
                    condition.Append(" AND ");
                condition.AppendFormat(" CateID={0}", listPageUrlInfo.CateID);
            }

           

            if (listPageUrlInfo.KeyWord != "" && listPageUrlInfo.KeyWord != "0")
            {
                List<string> words = GetWordSegmentation(Utils.UrlDecode(listPageUrlInfo.KeyWord));

                StringBuilder segWordCondition = new StringBuilder();

                foreach (string word in words)
                {
                    if (segWordCondition.ToString() != "")
                    {
                        segWordCondition.Append(" OR ");
                    }

                    segWordCondition.AppendFormat(" ForSerach like '%{0}%'", word);
                }

                if (condition.ToString() != "")
                    condition.Append(" And ");

                condition.Append("( " + segWordCondition + " )");
            }
            if (listPageUrlInfo.IsHot == 1)
            {
                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat(" IsHot=1");
            }

            if (listPageUrlInfo.IsNew == 1)
            {
                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat(" IsNew=1");
            }
            return condition.ToString();
        }
        /// <summary>
        /// 构建搜索条件
        /// </summary>
        /// <param name="listPageUrlInfo"></param>
        /// <returns></returns>
        public static string BuildSerachCondition(ListPageUrlInfo listPageUrlInfo, int CommodityID)
        {
            StringBuilder condition = new StringBuilder();

            if (listPageUrlInfo.CateID > 0)
            {
                if (condition.ToString() != "")
                    condition.Append(" AND ");
                condition.AppendFormat(" CateID={0}", listPageUrlInfo.CateID);
            }

            

            if (listPageUrlInfo.KeyWord != "" && listPageUrlInfo.KeyWord != "0")
            {
                List<string> words = GetWordSegmentation(Utils.UrlDecode(listPageUrlInfo.KeyWord));

                StringBuilder segWordCondition = new StringBuilder();

                foreach (string word in words)
                {
                    if (segWordCondition.ToString() != "")
                    {
                        segWordCondition.Append(" OR ");
                    }

                    segWordCondition.AppendFormat(" ForSerach like '%{0}%'", word);
                }

                if (condition.ToString() != "")
                    condition.Append(" And ");

                condition.Append("( " + segWordCondition + " )");
            }
            if (listPageUrlInfo.IsHot == 1)
            {
                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat(" IsHot=1");
            }

            if (listPageUrlInfo.IsNew == 1)
            {
                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat(" IsNew=1");
            }

            if (CommodityID > 0)
            {
                if (condition.ToString() != "")
                    condition.Append(" And ");
                condition.AppendFormat(" CommodityID!=" + CommodityID);
            }

            return condition.ToString();
        }
        #endregion

        #region 获取数据列表

        /// <summary>
        /// 获取关键推荐商品
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<Commodity> GetCommodityList(string keyword, int CommodityID)
        {
            ListPageUrlInfo listPageUrlInfo = new ListPageUrlInfo() { KeyWord = keyword };
            string condition = BuildSerachCondition(listPageUrlInfo, CommodityID);
            return CommodityBLL.GetCommodityList(6, 1, condition);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="listPageUrlInfo"></param>
        /// <returns></returns>
        public static List<Commodity> GetCommodityList(int pageSize, int pageIndex, ListPageUrlInfo listPageUrlInfo, out int total)
        {
            string condition = BuildSerachCondition(listPageUrlInfo);
            total = 0;
            string orderfield = "";
            string sort = "";

            switch ((int)listPageUrlInfo.OrderType)
            {
                case (int)OrderTypeEnum.价格从高到低:
                    orderfield = "Price";
                    sort = "DESC";
                    break;
                case (int)OrderTypeEnum.价格从低到高:
                    orderfield = "Price";
                    sort = "ASC";
                    break;
                case (int)OrderTypeEnum.销量:
                    orderfield = "SaleTotal";
                    sort = "DESC";
                    break;
                default:
                    orderfield = "SaleTotal";
                    sort = "DESC";
                    break;
            }

            List<Model.Commodity> list = new List<Commodity>();
            total = CommodityBLL.GetCommodityCount(condition);
            list = CommodityBLL.GetCommodityList(pageSize, pageIndex, condition, orderfield, sort);

            return list;
        }

        public static List<Notice> GetNoticeList(int pageSize, int pageIndex, out int total)
        {
            total = 0;

            List<Model.Notice> list = new List<Notice>();
            total = NoticeBLL.GetNoticeCount("");
            list = NoticeBLL.GetNoticeList(pageSize, pageIndex, "", "NoticeID", "desc");

            return list;
        }

        public static List<News> GetNewsList(int pageSize, int pageIndex, out int total)
        {
            total = 0;

            List<Model.News> list = new List<News>();
            total = NewsBLL.GetNoticeCount("");
            list = NewsBLL.GetNoticeList(pageSize, pageIndex, "", "NoticeID", "desc");

            return list;
        }

        #endregion
    }

    public class CommodityUtils
    {
        /// <summary>
        /// 获取自动书籍编号
        /// </summary>
        /// <returns></returns>
        public static string GetCommodityNo()
        {
            return DateTime.Now.ToString("yyyyMMdd") + Utils.GetRandomString(1, 2, "0123456789");
        }


        /// <summary>
        /// 取得关键字分词结果
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<string> GetWordSegmentation(string keyword)
        {
            List<string> words = new List<string>();
            Rainsoft.WordSegment.SegmentV3 tv = new Rainsoft.WordSegment.SegmentV3();
            string[] wordsBySeg = tv.Segment(keyword);

            foreach (string word in wordsBySeg)
            {
                if (!words.Contains(word))
                {
                    words.Add(word);
                }
            }

            if (words.Count <= 0)
            {
                words.Add(keyword);
            }

            return words;
        }

     

        /// <summary>
        /// 更新商品搜索字段
        /// </summary>
        /// <param name="CommodityInfo"></param>
        public static void UpdateForSerach(Model.Commodity model)
        {
            if (model != null)
            {
                model.ForSerach = model.CateName     + " " + model.Name + " " + model.CommodityNo + " ";
                CommodityBLL.UpdateCommodity(model);
            }

             
        }
       
        #region 更新商品上下架状态/商品搜索字段
        /// <summary>
        /// 更新商品上下架状态[库存少于0更为下架状态]
        /// </summary>
        public static void UpdateCommodityState()
        {
            TimerServiceLog logInfo = new TimerServiceLog()
            {
                EndTime = DateTime.Now,
                StartTime = DateTime.Now,
                LogName = "更新商品上下架信息"
            };

            List<Model.Commodity> list = CommodityBLL.GetCommodityList("Onsale=2");

            int count = 0;//统计更新次数

            int logID = TimerServiceLogBLL.AddTimerServiceLog(logInfo);
            foreach (Model.Commodity CommodityInfo in list)
            {
                if (CommodityInfo.Stock <= 0)
                {
                    CommodityInfo.OnSale = 1;
                    CommodityBLL.UpdateCommodity(CommodityInfo);

                    count++;
                }
            }

            if (count > 0)
            {
                TimerServiceLogBLL.UpdateEndTime(logID);
            }
            else
            {
                TimerServiceLogBLL.DeleteTimerServiceLog(logID);
            }
        }
        /// <summary>
        /// 更新商品搜索字段
        /// </summary>
        public static void UpdateCommodityForSerach()
        {
            TimerServiceLog logInfo = new TimerServiceLog()
            {
                EndTime = DateTime.Now,
                StartTime = DateTime.Now,
                LogName = "更新商品搜索字段"
            };

            List<Model.Commodity> list = CommodityBLL.GetCommodityList("Onsale=2");
            int logID = TimerServiceLogBLL.AddTimerServiceLog(logInfo);
            int count = 0;//统计更新次数

            foreach (Model.Commodity info in list)
            {
                if (info.ForSerach != info.Name + " " + info.CateName   +  " " + info.CommodityNo + " ")
                {
                    info.ForSerach = info.Name + " " + info.CateName   +  " " + info.CommodityNo + " ";
                    CommodityBLL.UpdateCommodity(info);

                    count++;
                }
            }

            if (count > 0)
            {
                TimerServiceLogBLL.UpdateEndTime(logID);
            }
            else
            {
                TimerServiceLogBLL.DeleteTimerServiceLog(logID);
            }
        }

        #endregion


    }
}
