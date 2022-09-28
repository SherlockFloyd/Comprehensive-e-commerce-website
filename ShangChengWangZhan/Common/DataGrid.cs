namespace Shopping.Controls
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Shopping.Common;

    public class DataGrid : System.Web.UI.WebControls.DataGrid
    {
        private const string FirstPageCommandArgument = "First";
        private const string GoToPageCommandArgument = "GoToPage";
        private const string LastPageCommandArgument = "Last";

        public DataGrid()
        {

            base.CssClass = "list-table";
            base.CssClass = "list-table";
            base.AllowPaging = true;
            base.AllowCustomPaging = true;
            base.ShowHeader = true;
            base.PageSize = 0x19;
            base.AutoGenerateColumns = false;
            int num = Utils.StrToInt(Requests.Query("page"));
            if (num > 0)
            {
                base.CurrentPageIndex = num;
            }
            base.SortCommand += new DataGridSortCommandEventHandler(this.SortGrid);
        }

        protected override bool OnBubbleEvent(object source, EventArgs e)
        {
            bool flag = false;
            if (e is DataGridCommandEventArgs)
            {
                DataGridCommandEventArgs args = (DataGridCommandEventArgs)e;
                this.OnItemCommand(args);
                flag = true;
                string commandName = args.CommandName;
                if (commandName == "Select")
                {
                    this.SelectedIndex = args.Item.ItemIndex;
                    this.OnSelectedIndexChanged(EventArgs.Empty);
                    return flag;
                }
                if (!(commandName == "Page"))
                {
                    switch (commandName)
                    {
                        case "Sort":
                            {
                                DataGridSortCommandEventArgs args3 = new DataGridSortCommandEventArgs(source, args);
                                this.OnSortCommand(args3);
                                return flag;
                            }
                        case "Edit":
                            this.OnEditCommand(args);
                            return flag;

                        case "Update":
                            this.OnUpdateCommand(args);
                            return flag;

                        case "Cancel":
                            this.OnCancelCommand(args);
                            return flag;

                        case "Delete":
                            this.OnDeleteCommand(args);
                            return flag;
                    }
                    return flag;
                }
                string commandArgument = (string)args.CommandArgument;
                int currentPageIndex = base.CurrentPageIndex;
                switch (commandArgument)
                {
                    case "Next":
                        currentPageIndex++;
                        break;

                    case "Prev":
                        currentPageIndex--;
                        break;

                    case "First":
                        currentPageIndex = 0;
                        break;

                    case "Last":
                        currentPageIndex = base.PageCount - 1;
                        break;

                    case "GoToPage":
                        {
                            int num2 = Utils.StrToInt(Requests.Form("pagetext"));
                            if (num2 <= 0)
                            {
                                currentPageIndex = 0;
                            }
                            if (num2 > base.PageCount)
                            {
                                currentPageIndex = base.PageCount - 1;
                            }
                            else if (num2 > 0)
                            {
                                currentPageIndex = num2 - 1;
                            }
                            break;
                        }
                    default:
                        currentPageIndex = int.Parse(commandArgument, CultureInfo.InvariantCulture) - 1;
                        break;
                }
                DataGridPageChangedEventArgs args2 = new DataGridPageChangedEventArgs(source, currentPageIndex);
                this.OnPageIndexChanged(args2);
            }
            return flag;
        }

        protected override void OnItemCreated(DataGridItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Pager) && this.AllowPaging)
            {
                int num;
                LinkButton child = new LinkButton();
                LinkButton button2 = new LinkButton();
                LinkButton button3 = new LinkButton();
                LinkButton button4 = new LinkButton();
                TableCell cell = (TableCell)e.Item.Controls[0];
                cell.Controls.Clear();
                LiteralControl control = new LiteralControl("splittable")
                {
                    Text = "</td></tr></tbody><tfoot><tr><td colspan='" + this.Columns.Count.ToString() + "'>"
                };
                cell.Controls.AddAt(0, control);
                child.CommandName = "Page";
                child.CommandArgument = "First";
                child.ToolTip = "上一页";
                if (base.CurrentPageIndex <= 0)
                {
                    child.Enabled = false;
                 
                    child.Text = "<span><img src=\"/icons/page-first-disabled.gif\" /></span>";
                }
                else
                {
                    // child.CssClass = "page-first";
                    child.Text = "<img src=\"/icons/page-first.gif\" />";
                }
                button2.CommandName = "Page";
                button2.CommandArgument = "Prev";
                button2.ToolTip = "上一页";
                if (base.CurrentPageIndex > 0)
                {
                    //  button2.CssClass = "page-prev";
                    button2.Text = "<img src=\"/icons/page-prev.gif\" />";
                }
                else
                {
                    button2.Enabled = false;
                    //  button2.CssClass = "page-prev-disabled";
                    button2.Text = "<span><img src=\"/icons/page-prev-disabled.gif\" /></span>";
                }
                button3.CommandName = "Page";
                button3.CommandArgument = "Next";
                button3.ToolTip = "下一页";
                if (base.CurrentPageIndex < (base.PageCount - 1))
                {
                    button3.Text = "<img src=\"/icons/page-next.gif\" />";
                }
                else
                {
                    button3.Enabled = false;
                    button3.Text = "<span><img src=\"/icons/page-next-disabled.gif\" /></span>";
                }
                button4.CommandName = "Page";
                button4.CommandArgument = "Last";
                button4.ToolTip = "尾页";
                if (base.CurrentPageIndex < (base.PageCount - 1))
                {
                    button4.Text = "<img src=\"/icons/page-last.gif\" />";
                }
                else
                {
                    button4.Enabled = false;
                    button4.Text = "<span><img src=\"/icons/page-last-disabled.gif\" /></span>";
                }
                cell.Controls.Add(child);
                cell.Controls.Add(button2);
                cell.Controls.Add(new LiteralControl("<span class=\"gotopage\">Page"));
                LinkButton button5 = new LinkButton();
                button5.Attributes.Add("id", "gotopage");
                button5.CommandName = "Page";
                button5.CommandArgument = "GoToPage";
                button5.Text = " <img src=\"/icons/server_go.gif\" title='跳转' /> ";
                cell.Controls.Add(new LiteralControl("<input type='text' class='text' id='gotopagetext" + this.ID + "' name='pagetext'"));
                cell.Controls.Add(new LiteralControl(" onkeydown=\"if(event.keyCode==13) {return(document.getElementById('gotopage')).click();}\""));
                cell.Controls.Add(new LiteralControl(" style=\"width:30px;\""));
                cell.Controls.Add(new LiteralControl(" value=\"" + ((base.CurrentPageIndex == 0) ? "1" : (num = base.CurrentPageIndex + 1).ToString()) + "\""));
                cell.Controls.Add(new LiteralControl(" />"));



                cell.Controls.Add(button5);
                cell.Controls.Add(new LiteralControl("</span>"));
                cell.Controls.Add(button3);
                cell.Controls.Add(button4);
                cell.Controls.Add(new LiteralControl("<a href='javascript:location.reload();'><img src='/icons/refresh.gif' /></a>"));
                num = (base.CurrentPageIndex * this.PageSize) + 1;
                cell.Controls.Add(new LiteralControl("<span class='total'>当前显示 " + num.ToString()));
                cell.Controls.Add(new LiteralControl(" - "));
                if (base.CurrentPageIndex < (base.PageCount - 1))
                {
                    num = (base.CurrentPageIndex + 1) * this.PageSize;
                    cell.Controls.Add(new LiteralControl(num.ToString()));
                }
                else
                {
                    num = this.VirtualItemCount + this.ShamCount;
                    cell.Controls.Add(new LiteralControl(num.ToString()));
                }
                num = this.VirtualItemCount + this.ShamCount;
                cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;共" + num.ToString() + "条记录</span>"));
                e.Item.Controls.Add(cell);
            }
            base.OnItemCreated(e);
        }

        protected override void Render(HtmlTextWriter output)
        {
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            base.Render(writer2);
            string str = writer.ToString();
            if (str.Length > 0)
            {
                int num;
                if (base.ShowHeader)
                {
                    num = str.IndexOf(">") + 1;
                    str = str.Insert(num, "<thead>");
                }
                num = str.IndexOf("</tr>") + "</tr>".Length;
                if (base.ShowHeader)
                {
                    str = str.Insert(num, "</thead><tbody>");
                }
                else
                {
                    str = str.Insert(num, "<tbody>");
                }
                num = str.LastIndexOf("</table>");
                if (this.AllowPaging)
                {
                    str = str.Insert(num, "</tfoot>");
                }
                else
                {
                    str = str.Insert(num, "</tbody>");
                }
                output.Write(str);

            }
        }

        protected void SortGrid(object sender, DataGridSortCommandEventArgs e)
        {
            foreach (DataGridColumn column in this.Columns)
            {
                if (column.SortExpression == e.SortExpression)
                {
                    string dataGridSortType = this.DataGridSortType;
                    if (dataGridSortType == "ASC")
                    {
                        this.DataGridSortType = "DESC";
                    }
                    else
                    {
                        this.DataGridSortType = "ASC";
                    }
                    if (column.HeaderText.IndexOf("<img src=") >= 0)
                    {
                        if (dataGridSortType == "ASC")
                        {
                            column.HeaderText = column.HeaderText.Replace("<img src=/base/images/default/grid/sort_asc.gif />", "<img src=/base/images/default/grid/sort_desc.gif />");
                        }
                        else
                        {
                            column.HeaderText = column.HeaderText.Replace("<img src=/base/images/default/grid/sort_desc.gif />", "<img src=/base/images/default/grid/sort_asc.gif />");
                        }
                    }
                    else if (dataGridSortType == "ASC")
                    {
                        column.HeaderText = column.HeaderText + "<img src=/base/images/default/grid/sort_desc.gif />";
                    }
                    else
                    {
                        column.HeaderText = column.HeaderText + "<img src=/base/images/default/grid/sort_asc.gif />";
                    }
                }
                else
                {
                    column.HeaderText = column.HeaderText.Replace("<img", "~").Split(new char[] { '~' })[0];
                }
            }
        }

        public bool AllowAutoDataGridPanel
        {
            get
            {
                object obj2 = this.ViewState["AllowAutoDataGridPanel"];
                return ((obj2 == null) || ((bool)obj2));
            }
            set
            {
                this.ViewState["AllowAutoDataGridPanel"] = value;
            }
        }

        public string Condition
        {
            get
            {
                object obj2 = this.ViewState["Condition"];
                return ((obj2 == null) ? "" : ((string)obj2));
            }
            set
            {
                this.ViewState["Condition"] = value;
            }
        }

        [Category("Appearance"), Description("排序方式"), DefaultValue("ASC")]
        public string DataGridSortType
        {
            get
            {
                object obj2 = this.ViewState["DataGridSortType"];
                return ((obj2 == null) ? "DESC" : ((string)obj2));
            }
            set
            {
                this.ViewState["DataGridSortType"] = value;
            }
        }

        public string DataSortExpression
        {
            get
            {
                object obj2 = this.ViewState["DataSortExpression"];
                return ((obj2 == null) ? this.DataKeyField : ((string)obj2));
            }
            set
            {
                this.ViewState["DataSortExpression"] = value;
            }
        }

        public int PageButtonCount
        {
            get
            {
                object obj2 = this.ViewState["PageButtonCount"];
                return ((obj2 == null) ? 5 : ((int)obj2));
            }
            set
            {
                this.ViewState["PageButtonCount"] = value;
            }
        }

        public int ShamCount
        {
            get
            {
                object obj2 = this.ViewState["ShamCount"];
                return ((obj2 == null) ? 0 : ((int)obj2));
            }
            set
            {
                this.ViewState["ShamCount"] = value;
            }
        }
    }
}

