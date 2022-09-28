<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompleteOrder.aspx.cs"
    Inherits="Shopping.Web.CompleteOrder" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>完成订单</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990">
        <div class="flow clearfix">
            <div class="flow_steps">
                <ul>
                    <li class="done">1.我的购物车</li>
                    <li class="done">2.确认订单详情</li>
                    <li class="current last">3.成功提交订单</li>
                </ul>
            </div>
        </div>
        <div class="clearfix">
            <div class="nav_new">
                <h2>
                    订单下单成功！
                </h2>
            </div>
            <div class="complete">
                <img src="icons/accept.gif" />您的订单：<em><a href="javascript:;"><asp:Literal ID="txtOrderNo"
                    runat="server"></asp:Literal></a></em>已成功提交，请<asp:Literal ID="payLiteral" runat="server"></asp:Literal>!
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
