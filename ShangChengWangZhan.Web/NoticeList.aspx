<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="Shopping.Web.NoticeList" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公告信息</title>
    <link href="CSS/news.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="CSS/list.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div id="mainbody">
        <div class="lmright" style="width: 990px; margin-left: auto;margin-right: auto;">
            <div class="nllb">
                <ul>
                    <asp:Repeater ID="repeater" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="nltime">
                                    <p class="nlday">
                                        <%# Eval("CreateTime", "{0:dd}")%></p>
                                    <p class="nlmonth">
                                        <%# Eval("CreateTime", "{0:MM}")%>月</p>
                                </div>
                                <div class="nllbinfo">
                                    <p class="nltitle">
                                        <a href="NoticeDetail.aspx?noticeid=<%# Eval("NoticeID") %>">
                                            <%# Eval("Title")%></a></p>
                                    <%# Eval("Content")%>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!--dress end-->
            <div class="page">
                <Shopping:Pager ID="pager" runat="server" DisplayMode="num3" PageSize="10" />
            </div>
        </div>
    </div>
    <Shopping:Footer ID="Footer1" runat="server" />
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
    </form>
</body>
</html>
