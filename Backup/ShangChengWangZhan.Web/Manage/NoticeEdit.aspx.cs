
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Shopping;
using Shopping.Model;
using Shopping.BLL;
using Shopping.Common;

namespace Shopping.Web.Manage
{
    public partial class NoticeEdit : ManagePage
    {

        #region 基本变量
        private Notice info;
        private string action;
        private int id;
        #endregion


        /// <summary>
        /// 页面载入事件
        /// </summary>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="e">事件的参数</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Requests.Query("action");
            id = Utils.StrToInt(Requests.Query("id"));
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
            if (action == "edit")
            {
                info = NoticeBLL.GetNoticeInfo(id);
                if (info != null)
                {
                    txtTitle.Value = info.Title;
                    txtContent.Value = info.Content;
                }
            }
        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="e">事件的参数</param>
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

        #region 添加事件
        /// <summary>
        /// 添加
        /// </summary>
        private void Add()
        {
             
            string title = txtTitle.Value.Trim();
            string content = txtContent.Value.Trim();
            info = new Notice();
            info.Title = title;
            info.Content = content;
            info.CreateTime = DateTime.Now;
           // info.AdminID = adminInfo.AdminID;
            int flag = NoticeBLL.AddNotice(info);
            if (flag > 0)
            {
                ShowOK("添加成功!", "NoticeList.aspx");
            }
            else
            {
                ShowError("添加失败!");
            }
        }
        #endregion

        #region 更新事件
        /// <summary>
        /// 更新
        /// </summary>
        private void Update()
        {
             

            string title = txtTitle.Value.Trim();
            string content = txtContent.Value.Trim();
            info = NoticeBLL.GetNoticeInfo(id);
            if (info != null)
            {
                info.Title = title;
                info.Content = content;
                bool flag = NoticeBLL.UpdateNotice(info);
                if (flag)
                {
                    ShowOK("更新成功!", "NoticeList.aspx");
                }
                else
                {
                    ShowError("更新失败!");
                }
            }
        }
        #endregion
    }
}