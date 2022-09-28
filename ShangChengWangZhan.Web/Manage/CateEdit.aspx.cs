
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Model;
using Shopping.BLL;
using Shopping.Common;

namespace Shopping.Web.Manage
{
    public partial class CateEdit : ManagePage
    {

        #region 基本变量
        private Cate info;
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
                info = CateBLL.GetCateInfo(id);
                if (info != null)
                {
                   
                    txtName.Value = info.Name;
                  
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
             
            string name = txtName.Value.Trim();
 

            info = new Cate();

        
            info.Name = name;
            info.CreateTime = DateTime.Now;


            int flag = CateBLL.AddCate(info);
            if (flag > 0)
            {
                ShowOK("添加成功!", "CateList.aspx");
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
          
            string name = txtName.Value.Trim();
 
            info = CateBLL.GetCateInfo(id);
            if (info != null)
            {
 
                info.Name = name;
      

                bool flag = CateBLL.UpdateCate(info);
                if (flag)
                {
                    ShowOK("更新成功!", "CateList.aspx");
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