using System.Web.UI;
using System.Text.RegularExpressions;
using Shopping.Common;

namespace Shopping.Controls
{
    ///<Summary>
    ///纯文本对象，代替Label (HTML Span)
    ///</Summary>
    public class Span : System.Web.UI.WebControls.WebControl
    {
      
        public Span()
        {
            useId = false;
            tag = string.Empty;
            text = string.Empty;
            isHtmlEncode = false;
        }


        //字段
        //文本内容、标签属性集合
        private string text;
        private string tag;
        private bool useId;
        private bool isHtmlEncode;

        //属性
        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        public bool UseId
        {
            get
            {
                return useId;
            }
            set
            {
                useId = value;
            }
        }

        public bool IsHtmlEncode
        {
            get { return isHtmlEncode; }
            set { isHtmlEncode = value; }
        }

        //重写 System.Web.UI.Control.AddParsedSubObject 方法
        protected override void AddParsedSubObject(object obj)
        {
            if (obj is LiteralControl)
            {
                text = ((LiteralControl)obj).Text;
            }
            base.AddParsedSubObject(obj);
        }


        //重写 System.Web.UI.Control.Render 方法
        protected override void Render(HtmlTextWriter output)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            if (isHtmlEncode)
            {
                text = Utils.HtmlEncode(text);
            }

            if (!string.IsNullOrEmpty(tag))
            {
                output.Write("<" + tag + "");
                if (useId)
                {
                    output.Write(" id=\"" + this.ID + "\"");
                }
                foreach (string key in this.Attributes.Keys)
                {
                    output.Write(" " + key + "=\"" + Attributes[key].ToString() + "\"");
                }
                output.Write(">" + text + "</" + tag + ">");
            }
            else
            {
                output.Write(text);
            }
        }
    }
}