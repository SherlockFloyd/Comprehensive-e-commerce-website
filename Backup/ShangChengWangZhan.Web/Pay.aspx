<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="Shopping.Web.Pay" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>确认支付</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990">
        <div class="clearfix mt10">
            <div class="nav_new">
                <h2>
                    订单付款
                </h2>
            </div>
            <div class="complete">
                订单号：<em><a href="javascript:;"><asp:Literal ID="txtOrderNo" runat="server"></asp:Literal></a>
                    </em><asp:PlaceHolder Visible="false" ID="PlaceHolder1" runat="server">
                验证码：<input type="text" runat="server" id="txtCode" style="width: 50px;" /><a
                    href='#' title='看不清楚，换个图片' tabindex="5">
                    <img id="imgCheckCode" src="VerifyImage.aspx" /></a><asp:Button ID="subitBtn" Text="确认付款"
                        CssClass="btn2" runat="server" OnClick="subitBtn_Click" /></asp:PlaceHolder>
                <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false"><font color="blue">
                    已成功付款!</font> </asp:PlaceHolder>
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
