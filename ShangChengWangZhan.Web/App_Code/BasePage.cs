using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Web
{
    public class BasePage : System.Web.UI.Page
    {
        public Shopping.Model.OnLineUserInfo onlineUserInfo;

        public Shopping.VisitLogOperate visitLogOperate;

        /// <summary>
        /// 构造方法
        /// </summary>
        public BasePage()
        {
            onlineUserInfo = Shopping.OnLineUser.GetOnLineUserInfo();
            visitLogOperate = new Shopping.VisitLogOperate(onlineUserInfo);
        }
    }
}