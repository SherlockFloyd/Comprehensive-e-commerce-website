using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Shopping.Common;



using Shopping.BLL;

namespace Shopping
{
    public class ManagePage : Page
    {


        public Model.Admin adminInfo = null;

        protected override void OnInit(EventArgs e)
        {
            adminInfo = GetAdminInfoByCookie();
            if (adminInfo == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

      
        /// <returns></returns>
        public Model.Admin GetAdminInfoByCookie()
        {

            HttpCookie cookie = Cookie.Get("admin");
            Model.Admin model = null;
            if (cookie == null || cookie.Values["name"] == "" || cookie.Values["key"] == "")
            {
                return null;
            }
            else
            {
                string name = cookie.Values["name"];
                string pwd = cookie.Values["key"];
                model = AdminBLL.GetAdminInfoByCondition("AdminName='" + name + "'");
                if (model == null)
                {
                    return null;
                }
                else
                {
                    if (model.Password != pwd)
                    {
                        return null;

                    }
                    else
                    {
                        return model;
                    }
                }
            }
        }
         
        public static void ShowOK(string message)
        {
            string returnUrl = Requests.Form("prevpageurl");
            int page = Utils.StrToInt(Requests.Query("page"));

            if (string.IsNullOrEmpty(returnUrl))//若要返回的前页地址为空，则直接获取上一页地址
            {
                returnUrl = Requests.GetPrevUrl();
                int gotopagetext = Utils.StrToInt(Requests.Form("gotopagetext"));

                gotopagetext = gotopagetext > 0 ? gotopagetext - 1 : 0;
                if (returnUrl.IndexOf("page") != -1)//上一页地址含有page，则替换页码为datagrid里的page表单
                {
                    returnUrl = returnUrl.Replace("page=" + page.ToString(), "page=" + gotopagetext.ToString());
                }
                else//不含page，则直接在地址后加上datagrid里的page表单
                {
                    returnUrl = returnUrl + (returnUrl.IndexOf('?') != -1 ? "&" : "?") + "page=" + gotopagetext.ToString();
                }
            }
            else
            {
                if (returnUrl.IndexOf("page") != -1)//上一页地址含有page，则替换页码为datagrid里的page表单
                {
                    //returnUrl = Regex.Replace(returnUrl, @"page=[\d+]", "page=" + page.ToString());
                }
                else//不含page，则直接在地址后加上datagrid里的page表单
                {
                    returnUrl = returnUrl + (returnUrl.IndexOf('?') != -1 ? "&" : "?") + "page=" + page.ToString();
                }
            }

            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<meta http-equiv='refresh' content='1;URL=" + returnUrl + "'> ");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:130px;width:300px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<table width='100%' style=\"margin-top:10px;border:1px solid #CAE2A4; background:#F7FAF1;\">");
            Response.Write("<tr>");
            Response.Write("<td valign=\"top\" style=\"background:url(/icons/success.gif) 15px 15px no-repeat;padding:20px 10px 15px 60px;\">");
            Response.Write("<span style=\"font-size:14px;\">");
            Response.Write(message);
            Response.Write("</span>");
            Response.Write("</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</div>");

            Response.Write("</body></html>");
            Response.End();


        }
        public static void ShowOK(string message, int second)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<meta http-equiv='refresh' content='" + second.ToString() + ";URL=" + Requests.GetPrevUrl() + "'> ");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:120px;width:284px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<div id='Layer2' style='position:absolute;z-index:300;width:270px;height:90px;background-color: #FFFFFF;border:solid #000000 1px;font-size:14px;'>");
            Response.Write("<div id='Layer4' style='height:26px;background:#D3DBDE;line-height:26px;padding:0px 3px 0px 3px;font-weight:bolder;'>操作成功</div>");
            Response.Write("<div id='Layer5' style='height:64px;line-height:150%;padding:0px 3px 0px 3px;' align='center'><BR />");
            Response.Write("<table><tr><td valign=middle style='font-size: 14px;' >" + message + "<BR /></td></tr></table>");
            Response.Write("<BR /></div></div><div id='Layer3' style='position:absolute;width:270px;height:90px;z-index:299;left:4px;top:5px;background-color: #E8E8E8;'></div></div>");
            Response.Write("</body></html>");
            Response.End();
        }
        public static void ShowOK(string message, string returnUrl)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<meta http-equiv='refresh' content='1;URL=" + returnUrl + "'> ");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:130px;width:300px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<table width='100%' style=\"margin-top:10px;border:1px solid #CAE2A4; background:#F7FAF1;\">");
            Response.Write("<tr>");
            Response.Write("<td valign=\"top\" style=\"background:url(/icons/success.gif) 15px 15px no-repeat;padding:20px 10px 15px 60px;\">");
            Response.Write("<span style=\"font-size:14px;\">");
            Response.Write(message);
            Response.Write("</span>");
            Response.Write("</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</div>");
            Response.Write("</body></html>");
            Response.End();
        }
        public static void ShowOK(string message, string returnUrl, int second)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<meta http-equiv='refresh' content='" + second.ToString() + ";URL=" + returnUrl + "'> ");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:120px;width:284px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<div id='Layer2' style='position:absolute;z-index:300;width:270px;height:90px;background-color: #FFFFFF;border:solid #000000 1px;font-size:14px;'>");
            Response.Write("<div id='Layer4' style='height:26px;background:#D3DBDE;line-height:26px;padding:0px 3px 0px 3px;font-weight:bolder;'>操作成功</div>");
            Response.Write("<div id='Layer5' style='height:64px;line-height:150%;padding:0px 3px 0px 3px;' align='center'><BR />");
            Response.Write("<table><tr><td valign=middle style='font-size: 14px;' >" + message + "<BR /></td></tr></table>");
            Response.Write("<BR /></div></div><div id='Layer3' style='position:absolute;width:270px;height:90px;z-index:299;left:4px;top:5px;background-color: #E8E8E8;'></div></div>");
            Response.Write("</body></html>");
            Response.End();
        }
        public static void ShowError(string message)
        {

            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<meta> ");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:130px;width:300px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<table width='100%' style=\"margin-top:10px;border:1px solid #FAC5C7; background:#FEF0F0;\">");
            Response.Write("<tr>");
            Response.Write("<td valign=\"top\" style=\"background:url(/icons/errora.gif) 15px 15px no-repeat;padding:20px 10px 15px 60px;\">");
            Response.Write("<span style=\"font-size:14px;\">");
            Response.Write(message);
            Response.Write("</span>");
            Response.Write("</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</div>");
            Response.Write("<script>setTimeout('history.back()',2000)</script>");
            Response.End();
        }
        public static void ShowError(string message, int second)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<meta http-equiv='refresh' content='" + second.ToString() + ";URL=" + Requests.GetPrevUrl() + "'> ");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:120px;width:284px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<div id='Layer2' style='position:absolute;z-index:300;width:270px;height:90px;background-color: #FFFFFF;border:solid #000000 1px;font-size:14px;'>");
            Response.Write("<div id='Layer4' style='height:26px;background:#D3DBDE;line-height:26px;padding:0px 3px 0px 3px;font-weight:bolder;'>发生错误</div>");
            Response.Write("<div id='Layer5' style='height:64px;line-height:150%;padding:0px 3px 0px 3px;' align='center'><BR />");
            Response.Write("<table><tr><td valign=middle style='font-size: 14px;' >" + message + "<BR /></td></tr></table>");
            Response.Write("<BR /></div></div><div id='Layer3' style='position:absolute;width:270px;height:90px;z-index:299;left:4px;top:5px;background-color: #E8E8E8;'></div></div>");
            Response.Write("</body></html>");
            Response.End();
        }
        public static void ShowError(string message, string returnUrl)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<meta http-equiv='refresh' content='1;URL=" + returnUrl + "'> ");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:130px;width:300px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<table width='100%' style=\"margin-top:10px;border:1px solid #FAC5C7; background:#FEF0F0;\">");
            Response.Write("<tr>");
            Response.Write("<td valign=\"top\" style=\"background:url(/icons/errora.gif) 15px 15px no-repeat;padding:20px 10px 15px 60px;\">");
            Response.Write("<span style=\"font-size:14px;\">");
            Response.Write(message);
            Response.Write("</span>");
            Response.Write("</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</div>");
            Response.End();
        }
        public static void ShowError(string message, string returnUrl, int second)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<meta http-equiv='refresh' content='" + second.ToString() + ";URL=" + returnUrl + "'> ");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:120px;width:284px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<div id='Layer2' style='position:absolute;z-index:300;width:270px;height:90px;background-color: #FFFFFF;border:solid #000000 1px;font-size:14px;'>");
            Response.Write("<div id='Layer4' style='height:26px;background:#D3DBDE;line-height:26px;padding:0px 3px 0px 3px;font-weight:bolder;'>发生错误</div>");
            Response.Write("<div id='Layer5' style='height:64px;line-height:150%;padding:0px 3px 0px 3px;' align='center'><BR />");
            Response.Write("<table><tr><td valign=middle style='font-size: 14px;' >" + message + "<BR /></td></tr></table>");
            Response.Write("<BR /></div></div><div id='Layer3' style='position:absolute;width:270px;height:90px;z-index:299;left:4px;top:5px;background-color: #E8E8E8;'></div></div>");
            Response.Write("</body></html>");
            Response.End();
        }

        public static void ShowHavePermissionError()
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Write("<html>");
            Response.Write("<body margin='10'>");
            Response.Write("<div id='success' style='position:absolute;z-index:300;height:130px;width:300px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;'>");
            Response.Write("<table width='100%' style=\"margin-top:10px;border:1px solid #FAC5C7; background:#FEF0F0;\">");
            Response.Write("<tr>");
            Response.Write("<td valign=\"top\" style=\"background:url(/icons/errora.gif) 15px 15px no-repeat;padding:20px 10px 15px 60px;\">");
            Response.Write("<span style=\"font-size:14px;\">");
            Response.Write("您没有该管理权限");
            Response.Write("</span>");
            Response.Write("</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</div>");
            Response.End();
        }
    }
}
