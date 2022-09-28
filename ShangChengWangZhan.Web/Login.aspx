<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shopping.Web.Login" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户登录</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/JS/jquery.validity.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990 login">
        <div class="lib-title">
            <h2>
                用户登录</h2>
        </div>
        <table class="tb-1">
            <colgroup>
                <col width="20%" />
                <col />
            </colgroup>
            <tr>
                <td align="right">
                    用户名：
                </td>
                <td>
                    <input type="text" class="text" runat="server" id="username" style="width: 142px;" /><font
                        class="red"> * </font>必填
                </td>
            </tr>
            <tr>
                <td align="right">
                    密码：
                </td>
                <td>
                    <input type="password" class="text" runat="server" style="width: 142px;" id="txtPassword" /><font
                        class="red"> * </font>必填
                </td>
            </tr>
            <tr>
                <td align="right">
                    验证码：
                </td>
                <td>
                    <input class="text" type="text" runat="server" id="txtCode" maxlength="4" style="width: 50px;" /><a
                        href='#' title='看不清楚，换个图片' tabindex="5">
                        <img id="imgCheckCode" src="VerifyImage.aspx" /></a>
                </td>
            </tr>
            <td colspan="2" align="center">
                <asp:Button ID="registerBtn" OnClientClick="return checkInfo();" runat="server" Text="登录"
                    CssClass="btn2" OnClick="registerBtn_Click" />&nbsp;<a href="Register.aspx">注册</a>
            </td>
        </table>
    </div>
    <Shopping:Footer ID="Footer1" runat="server" />
    </form>
    <script type="text/javascript">
        $("#imgCheckCode").click(function () {
            $(this).attr("src", "/VerifyImage.aspx?" + new Date());
        });

        function checkInfo() {
            var username = $("#username");
            var password = $("#txtPassword");

            var code = $("#txtCode");

            if (username.val() == "") {
                alert("请输入用户名!");
                username.focus();
                return false;
            }
            if (password.val() == "") {
                alert("请输入用密码!");
                password.focus();
                return false;
            }

            if (code.val() == "") {
                alert("请输入验证码!");
                code.focus();
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
</body>
</html>
