namespace Shopping.Controls
{

    using System;
    using System.Collections.Specialized;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Shopping.Common;
  
    public class Pager : WebControl
    {
        private bool _alternate;
        private int _currentPage = Utils.StrToInt(Requests.All("page"));
        private string _currentUrl = "";
        private string _displayMode = "";
        private bool _enableQueryString;
        private string _firstPage = "";
        private string _lastPage = "";
        private int _maxPage;
        private string _nextPage = "";
        private int _pageSize;
        private string _prevPage = "";
        private string _rawUrl = "";
        private string _rewriteQueryString = "";
        private string _rewriteUrlPattern = "";
        private bool _showCounts;
        private bool _showPageSize;
        private int _total;
        private NameValueCollection m_itemColl;
        /// <summary>
        /// 
        /// </summary>
        public Pager()
        {
            if (this._currentPage < 1)
            {
                this._currentPage = 1;
            }
            this._maxPage = 1;
            this._pageSize = 0x19;
            this._total = 0;
            this._showCounts = true;
            this._alternate = false;
            this._showPageSize = false;
            this._enableQueryString = true;
            this._rawUrl = HttpContext.Current.Request.RawUrl;
            if (this._rawUrl.IndexOf('?') != -1)
            {
                this._rewriteQueryString = "?" + this._rawUrl.Substring(this._rawUrl.IndexOf('?') + 1);
            }
            else
            {
                this._rewriteQueryString = string.Empty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Calculate()
        {
            this._maxPage = this._total / this._pageSize;
            if ((this._total % this._pageSize) != 0)
            {
                this._maxPage++;
            }
            this._maxPage = Math.Max(this._maxPage, 1);
            this._currentPage = Math.Max(Math.Min(this.CurrentPage, this._maxPage), 1);
        }
        /// <summary>
        /// 
        /// </summary>
        public string GetPage(int page)
        {
            if (page <= 1)
            {
                return this.FirstPage;
            }
            if (page >= this.MaxPage)
            {
                return this.LastPage;
            }
            if (this._alternate)
            {
                return (this._rewriteUrlPattern.Replace("{page}", page.ToString()) + this.RewriteQueryString);
            }
            string currentUrl = this.CurrentUrl;
            if (currentUrl.IndexOf("?") == -1)
            {
                currentUrl = currentUrl + "?";
            }
            return (currentUrl + "page=" + page);
        }
        /// <summary>
        /// 
        /// </summary>
        public string NumberMode3()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<div class=\"pagerjump\">");
            if (this.CurrentPage > 1)
            {
                builder.Append("<a class=\"previous\" href='" + this.PrevPage + "'><em>上一页</em></a> ");
            }
            if (this.CurrentPage > 5)
            {
                builder.Append("<a href='" + this.GetPage(1) + "' class=\"num\">1</a> <span class=\"nextmore\">...</span> ");
            }
            int num = ((this.CurrentPage - 3) < 1) ? 1 : (this.CurrentPage - 3);
            int num2 = ((this.CurrentPage + 3) > this.MaxPage) ? this.MaxPage : (this.CurrentPage + 3);
            for (int i = num; i < (num2 + 1); i++)
            {
                builder.Append("<a   href='" + this.GetPage(i) + "' class=\"num");
                if (this.CurrentPage == i)
                {
                    builder.Append(" current");
                }
                builder.Append("\">" + i);
                builder.Append("</a> ");
            }
            if (this.CurrentPage != this.MaxPage)
            {
                builder.Append(" <span class=\"nextmore\">...</span> <a class=\"next\" href='" + this.NextPage + "'><em>下一页</em></a> ");
            }
            builder.Append("</div>");
            if (this.MaxPage > 1)
            {
                builder.Append("<div class=\"gotopage\"><span>跳转至</span><div class=\"input\"><input type='text' class='text' id='gotopage" + this.ID + "' /> <input type=\"button\" class='btn_submit' value=\"确定\" onclick=\"gotoPage()\"></div></div>");
                builder.Append("<script language='javascript'>\n");
                builder.Append("function gotoPage(){\n");
                if (this._alternate)
                {
                    builder.Append("var formatString = \"" + this._rewriteUrlPattern.Replace("{page}", "{0}") + this.RewriteQueryString + "\";\n");
                }
                else
                {
                    builder.Append("var formatString = \"" + this.CurrentUrl + "?page={0}\";\n");
                }
                builder.Append("var gotopage=document.getElementById('gotopage" + this.ID + "');var reg=/^\\d+$/;var re = new RegExp(reg);\n");
                builder.Append("if(!(gotopage.value).match(re)){alert('请输入正确的页码!');return;}\n");
                builder.Append("var page = eval(gotopage.value);\n");
                builder.Append("document.location = formatString.replace(\"{0}\",page);\n");
                builder.Append("}");
                builder.Append("</script>");
            }
            return builder.ToString();
        }
        /// <summary>
        /// 重写 System.Web.UI.Control.Render 方法
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {
            output.Write(this.NumberMode3());
        }
        /// <summary>
        /// 
        /// </summary>
        public void SetItem(string name, object value)
        {
            this.Items.Add(name, this.Context.Server.UrlEncode(value.ToString()));
        }
        /// <summary>
        /// 
        /// </summary>
        public void SetItem(string name, string value)
        {
            this.Items.Add(name, this.Context.Server.UrlEncode(value));
        }
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return this.NumberMode3();
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Alternate
        {
            get
            {
                return this._alternate;
            }
            set
            {
                this._alternate = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CurrentPage
        {
            get
            {
                if (this._currentPage == 0)
                {
                    string str = Requests.All("page");
                    this._currentPage = Utils.StrToInt(str);
                    if (this._currentPage < 1)
                    {
                        this._currentPage = 1;
                    }
                    if ((this._currentPage > this._maxPage) && (this._maxPage > 0))
                    {
                        this._currentPage = this._maxPage;
                    }
                }
                return this._currentPage;
            }
        }
        /// <summary>
        /// 当前页地址
        /// </summary>
        public string CurrentUrl
        {
            get
            {
                if ((this._currentUrl == null) || (this._currentUrl == string.Empty))
                {
                    if (this._alternate)
                    {
                        this._currentUrl = this._rawUrl;
                    }
                    else
                    {
                        this._currentUrl = this.Context.Request.FilePath + this.QueryString;
                    }
                }
                return this._currentUrl;
            }
        }
        /// <summary>
        /// 显示模式
        /// </summary>
        public string DisplayMode
        {
            get
            {
                return this._displayMode;
            }
            set
            {
                this._displayMode = value;
            }
        }
        /// <summary>
        /// 是否启用伪静态
        /// </summary>
        public bool EnableQueryString
        {
            get
            {
                return this._enableQueryString;
            }
            set
            {
                this._enableQueryString = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FirstPage
        {
            get
            {
                if (this._alternate)
                {
                    this._firstPage = this._rewriteUrlPattern.Replace("{page}", "1") + this.RewriteQueryString;
                }
                else
                {
                    this._firstPage = this.CurrentUrl;
                    if (this._firstPage.IndexOf("?") == -1)
                    {
                        this._firstPage = this._firstPage + "?";
                    }
                    this._firstPage = this._firstPage + "page=1";
                }
                return this._firstPage;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private NameValueCollection Items
        {
            get
            {
                if (this.m_itemColl == null)
                {
                    this.m_itemColl = new NameValueCollection();
                }
                return this.m_itemColl;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastPage
        {
            get
            {
                if (this._alternate)
                {
                    if (this._maxPage > 1)
                    {
                        this._lastPage = this._rewriteUrlPattern.Replace("{page}", this._maxPage.ToString()) + this.RewriteQueryString;
                    }
                    else
                    {
                        this._lastPage = this._rewriteUrlPattern.Replace("{page}", "") + this.RewriteQueryString;
                    }
                }
                else
                {
                    this._lastPage = this.CurrentUrl;
                    if (this._lastPage.IndexOf("?") == -1)
                    {
                        this._lastPage = this._lastPage + "?";
                    }
                    this._lastPage = this._lastPage + "page=" + this._maxPage;
                }
                return this._lastPage;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MaxPage
        {
            get
            {
                return this._maxPage;
            }
            set
            {
                this._maxPage = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NextPage
        {
            get
            {
                if (this._alternate)
                {
                    int num = this.CurrentPage + 1;
                    this._nextPage = this._rewriteUrlPattern.Replace("{page}", num.ToString()) + this.RewriteQueryString;
                }
                else
                {
                    this._nextPage = this.CurrentUrl;
                    if (this._nextPage.IndexOf("?") == -1)
                    {
                        this._nextPage = this._nextPage + "?";
                    }
                    this._nextPage = this._nextPage + "page=" + (this.CurrentPage + 1);
                }
                return this._nextPage;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PageSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PreviousRecords
        {
            get
            {
                return (this._pageSize * (this.CurrentPage - 1));
            }
        }
        /// <summary>
        /// 上一页地址
        /// </summary>
        public string PrevPage
        {
            get
            {
                if (this._alternate)
                {
                    if (this.CurrentPage > 2)
                    {
                        int num = this.CurrentPage - 1;
                        this._prevPage = this._rewriteUrlPattern.Replace("{page}", num.ToString()) + this.RewriteQueryString;
                    }
                    else
                    {
                        this._prevPage = this._rewriteUrlPattern.Replace("{page}", "1") + this.RewriteQueryString;
                    }
                }
                else
                {
                    this._prevPage = this.CurrentUrl;
                    if (this._prevPage.IndexOf("?") == -1)
                    {
                        this._prevPage = this._prevPage + "?";
                    }
                    this._prevPage = this._prevPage + "page=" + (this.CurrentPage - 1);
                }
                return this._prevPage;
            }
        }
        /// <summary>
        ///  URL模板中QueryString部分
        /// </summary>
        public string QueryString
        {
            get
            {
                string str = string.Empty;
                if ((this.m_itemColl != null) && (this.Items.AllKeys.Length > 0))
                {
                    str = "?";
                    foreach (string str2 in this.Items.AllKeys)
                    {
                        string str3 = str;
                        str = str3 + str2 + "=" + this.Items[str2] + "&";
                    }
                }
                return str;
            }
        }
        /// <summary>
        /// 伪静态参数
        /// </summary>
        public string RewriteQueryString
        {
            get
            {
                if (this._enableQueryString)
                {
                    return this._rewriteQueryString;
                }
                if (this.m_itemColl == null)
                {
                    return "";
                }
                string str = "?";
                //foreach (string str2 in this.Items.AllKeys)
                //{
                //    string str3 = str;
                //    str = str3 + str2 + "=" + this.Items[str2] + "&";
                //}
                return str.Substring(0, str.Length - 1);
            }
        }
        /// <summary>
        ///  伪静态地址模板，传入{page}用以替换真实页码
        /// </summary>
        public string RewriteUrlPattern
        {
            get
            {
                return this._rewriteUrlPattern;
            }
            set
            {
                this._rewriteUrlPattern = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ShowCounts
        {
            get
            {
                return this._showCounts;
            }
            set
            {
                this._showCounts = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ShowPageSize
        {
            get
            {
                return this._showPageSize;
            }
            set
            {
                this._showPageSize = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
    }
}

