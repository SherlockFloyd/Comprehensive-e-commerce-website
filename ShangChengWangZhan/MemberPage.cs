using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

using Shopping.Data;
using Shopping.Common;
using Shopping;


namespace Shopping
{
    public class MemberPage : Page
    {

        public Model.OnLineUserInfo onlineUserInfo = null;

        protected override void OnInit(EventArgs e)
        {
            onlineUserInfo = OnLineUser.GetOnLineUserInfo(true);

            if (onlineUserInfo == null)
                //if (onlineUserInfo == null)
            {
                Response.Redirect("/login.aspx");
            }
        }
    }
}
