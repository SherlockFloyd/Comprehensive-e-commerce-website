using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shopping.Model;
using Shopping.BLL;
namespace Shopping
{
   
    public class VisitLogOperate
    {
        public VisitLogOperate(Model.OnLineUserInfo onlineUserInfo)
        {
            this.OnLineUserInfo = onlineUserInfo;
            this.LoadVisitLogList();
        }

        private Model.OnLineUserInfo _OnLineUserInfo;
        /// <summary>
        /// 会员在线信息
        /// </summary>
        public Model.OnLineUserInfo OnLineUserInfo
        {
            get { return _OnLineUserInfo; }
            set { _OnLineUserInfo = value; }
        }

        private List<VisitLog> _VisitLogList;

        public List<VisitLog> VisitLogList
        {
            get { return _VisitLogList; }
            set { _VisitLogList = value; }
        }

        public void AddVisitLog(int CommodityId,int Visits)
        {
            VisitLog model;

            if (OnLineUserInfo.UserID != -1)
            {
                model = VisitLogBLL.GetVisitLogInfoByCondition("UserID=" + OnLineUserInfo.UserID + " AND CommodityID=" + CommodityId);

                if (model != null)
                {
                    model.Visits += Visits;
                    model.UpdateTime = DateTime.Now;

                    VisitLogBLL.UpdateVisitLog(model);
                }
                else
                {
                    model = new VisitLog();
                    model.UserID = OnLineUserInfo.UserID;
                    model.CommodityID = CommodityId;

                    model.Visits = 1;
                    model.UpdateTime = DateTime.Now;
                    VisitLogBLL.AddVisitLog(model);
                }
            }
            else
            {
                model = VisitLogBLL.GetVisitLogInfoByCondition("GuestID='" + OnLineUserInfo.GuestID + "' AND CommodityID=" + CommodityId);

                if (model != null)
                {
                    model.Visits += Visits;
                    model.UpdateTime = DateTime.Now;

                    VisitLogBLL.UpdateVisitLog(model);
                }
                else
                {
                    model = new VisitLog();
                    model.GuestID = OnLineUserInfo.GuestID;
                    model.CommodityID = CommodityId;

                    model.Visits = 1;
                    model.UpdateTime = DateTime.Now;
                    VisitLogBLL.AddVisitLog(model);
                }

            }


        }

        private void LoadVisitLogList()
        {
            if (OnLineUserInfo.UserID != -1)
            {
                if (OnLineUserInfo.GuestID != "")
                {
                    List<VisitLog> list = VisitLogBLL.GetVisitLogListByGuestID(0, OnLineUserInfo.GuestID);

                    foreach (VisitLog model in list)
                    {
                        AddVisitLog(model.CommodityID,model.Visits);
                    }

                    VisitLogBLL.DeleteVisitLogByGuestID(OnLineUserInfo.GuestID);
                }

                _VisitLogList = VisitLogBLL.GetVisitLogListByUserID(6, OnLineUserInfo.UserID);
            }
            else
            {
                _VisitLogList = VisitLogBLL.GetVisitLogListByGuestID(6, OnLineUserInfo.GuestID);
            }
        }
    }
}
