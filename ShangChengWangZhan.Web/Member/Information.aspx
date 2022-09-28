<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="Shopping.Web.Member.Information" %>

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
                        $("#txtRealName").require("请输入姓名!");
                        $("#txtAddress").require("请输入地址!");
                        $("#txtPhone").require("请输入电话号码!");
                        $("#txtEmail").require("请输入邮箱地址!").match("email", "Email格式错误!");
                        $("#txtPost").require("请输入邮编!").match("zip", "邮编地址错误!");

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
                        <li class="active"><a href="javascript:;">修改资料</a></li>
                    </ul>
                    <div class="tab-content">
                        <table class="tb-4">
                            <colgroup>
                                <col width="15%" />
                                <col />
                            </colgroup>
                            <tr>
                                <td align="right">
                                    用户名：
                                </td>
                                <td>
                                    <asp:Literal ID="txtUserName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    真实姓名：
                                </td>
                                <td>
                                    <input class="text" type="text" name="txtRealName" id="txtRealName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    性别：
                                </td>
                                <td>
                                    <select id="txtSex" name="txtSex" runat="server">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    出生日期：
                                </td>
                                <td>
                                    <input class="text" type="text" id="txtBirthDay" name="txtBirthDay" runat="server" />
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
                                <td align="right">
                                    电话号码：
                                </td>
                                <td>
                                    <input class="text" type="text" name="txtPhone" id="txtPhone" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    邮箱地址：
                                </td>
                                <td>
                                    <input class="text" type="text" name="txtEmail" id="txtEmail" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    邮编：
                                </td>
                                <td>
                                    <input class="text" type="text" name="txtPost" id="txtPost" runat="server" />
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
