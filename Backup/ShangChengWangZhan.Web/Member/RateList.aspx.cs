using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping;
using Shopping.BLL;

namespace Shopping.Web.Member
{
    public partial class RateList : MemberPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string condition = GetCondition();

            pager.Total = SnapshotBLL.GetSnapshotCount(condition);
            pager.Calculate();



            repeater.DataSource = SnapshotBLL.GetSnapshotList(pager.PageSize, pager.CurrentPage, condition, "SnapshotID", "DESC");
            repeater.DataBind();

        }
        
        private string GetCondition()
        {
            StringBuilder condition = new StringBuilder();
            condition.AppendFormat("UserID={0}", onlineUserInfo.UserID);
            condition.AppendFormat(" AND Status={0}", (int)OrderEnum.Success);

            if (Requests.All("rate") == "no")
            {
                condition.AppendFormat(" AND IsGrade=0");
            }

            return condition.ToString();
        }
    }
}