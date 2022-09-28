<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Shopping.Web.Register" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户注册</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/JS/jquery.validity.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("form").validity(
                    function () {
                        $("#username").require("请输入密码!").match("email", "用户名只能是E-mail格式!");
                    }
                );
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990 border">
        <div class="lib-title">
            <h2>
                用户注册</h2>
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
                    <input type="text" class="text w140" runat="server" id="username" /><font class="red">
                        * </font>必填
                </td>
            </tr>
            <tr>
                <td align="right">
                    密码：
                </td>
                <td>
                    <input type="password" class="text w140" runat="server" id="txtPassword" /><font
                        class="red"> * </font>必填
                </td>
            </tr>
            <tr>
                <td align="right">
                    确认密码：
                </td>
                <td>
                    <input type="password" class="text w140" runat="server" id="txtConfirmPassword" /><font
                        class="red"> * </font>必填
                </td>
            </tr>
            <tr>
                <td align="right">
                    验证码：
                </td>
                <td>
                    <input type="text" class="text" runat="server" id="txtCode" style="width: 50px;" /><a
                        href='#' title='看不清楚，换个图片' tabindex="5">
                        <img id="imgCheckCode" src="VerifyImage.aspx" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="registerBtn" OnClientClick="return checkInfo();" runat="server" Text="提交注册"
                        CssClass="btn2" OnClick="registerBtn_Click" />
                </td>
            </tr>
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
            var confirmpassword = $("#txtConfirmPassword");
            var code = $("#txtCode");

            if ($.trim(username.val()) == "") {
                alert("请输入用户名!");
                username.focus();
                return false;
            }
            if ($.trim(password.val()) == "") {
                alert("请输入用密码!");
                password.focus();
                return false;
            }
            if ($.trim(confirmpassword.val()) == "") {
                alert("请输入确认!");
                confirmpassword.focus();
                return false;
            }
            if ($.trim(code.val()) == "") {
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
