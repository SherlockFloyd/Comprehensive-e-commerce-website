<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryEdit.aspx.cs" Inherits="Shopping.Web.Member.DeliveryEdit" %>

<%@ Register Src="/Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="/Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<%@ Register Src="Lefter.ascx" TagName="Lefter" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员中心</title>
    <link href="/CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/member.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/jquery.validity.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/JS/jquery.validity.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("form").validity(
                    function () {
                        $("#txtName").require("请输入收货人!");
                        $("#txtAddress").require("请输入地址!");
                        $("#txtTel").require("请输入联系电话!");


                    }
                );
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <!-- header end -->
    <div class="body-skin w990">
        <ul class="navigation clearfix mb10">
        </ul>
        <div class="body-main clearfix">
            <Shopping:Lefter ID="Lefter1" runat="server" />
            <div class="main">
                <div class="tabview tab-module tab-modify mb10">
                    <ul class="tab-nav clearfix">
                        <li class="active"><a href="javascript:;">收货地址</a></li>
                    </ul>
                    <div class="tab-content">
                        <table class="tb-4">
                            <colgroup>
                                <col width="15%" />
                                <col />
                            </colgroup>
                            <tr>
                                <td align="right">
                                    收货人：
                                </td>
                                <td>
                                    <input class="text" type="text" name="txtName" id="txtName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    联系电话：
                                </td>
                                <td>
                                    <input class="text" type="text" name="txtTel" id="txtTel" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    地址：
                                </td>
                                <td>
                                    <input class="text" type="text" name="txtAddress" id="txtAddress" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="updateBtn" CssClass="btn2" Text="提交更新" runat="server" OnClick="updateBtn_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
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
