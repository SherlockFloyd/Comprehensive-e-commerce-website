<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="Shopping.Web.NewsDetail" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新闻详情</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990">
        <div class="n clearfix">
            <div class="nav_new" style="border: none !important">
                <h2>
                    新闻信息</h2>
            </div>
            <div class="n-title">
                <asp:Literal ID="txttitle" runat="server"></asp:Literal>
            </div>
            <div class="n-time">
                <asp:Literal ID="txttime" runat="server"></asp:Literal>
            </div>
            <div class="n-content">
                <asp:Literal ID="txtcontent" runat="server"></asp:Literal>
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
