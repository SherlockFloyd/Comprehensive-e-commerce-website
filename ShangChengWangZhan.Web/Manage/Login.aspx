<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shopping.Web.Manage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理员登录</title>
    <script type="text/javascript" src="/base/input.js"></script>
    <script type="text/javascript">
        if (window.name != "bencalie") {
            location.reload();
            window.name = "bencalie";
        }
        else {
            window.name = "";
        }
    </script>
    <link href="/base/login_css.css" rel="stylesheet" type="text/css" />
    <%--    <link rel="stylesheet" type="text/css" href="/base/login.css">--%>
    <!--[if lte IE 6]> <link type="text/css" rel="stylesheet" href="style/ie6_login.css" mce_href="style/ie6_login.css" /><![endif]-->
    <!--[if IE 6]>
<script type="text/javascript" src="script/png.js"></script>
<![endif]-->
    <script src="/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(window).resize(function () {
                $('.className').css({
                    position: 'absolute',
                    left: ($(window).width() - $('.main').outerWidth()) / 2,
                    top: ($(window).height() - $('.main').outerHeight()) / 2
                });

            });
            $(window).resize();

        });
    </script>
    <meta name="GENERATOR" content="MSHTML 8.00.6001.19328">
</head>
<body id="exampleBody">
    <div id="login_center">
        <div id="login_area">
            <div id="login_box">
                <div id="login_form">
                    <form id="Form1" runat="server">
                    <div id="login_tip">
                        <span id="login_err" class="sty_txt2"></span>
                    </div>
                    <div>
                        用户名：<input type="text" name="userName" class="username" id="userName" />
                    </div>
                    <div>
                        密&nbsp;&nbsp;&nbsp;&nbsp;码：<input type="password" name="password" class="pwd"
                            id="password" />
                    </div>
                    <div>
                        验证码：<input type="text" name="verifyCode" class="username" id="verifyCode" />
                        <a href='#' title='看不清楚，换个图片' tabindex="5">
                            <img id="imgCheckCode" src="/VerifyImage.aspx" /></a>
                    </div>
                    <div id="btn_area">
                        <input type="submit" class="login_btn" id="login_sub" onclick="checkInfo()" value="登  录"  />
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $("#imgCheckCode").click(function () {
            $(this).attr("src", "/VerifyImage.aspx?" + new Date());
        });
        function checkInfo() {
            var username = $("#userName");
            var password = $("#password");
            var code = $("#verifyCode");

            if (username.val() == "") {
                alert("请输入用户名。");
                username.focus();
                return false;
            }
            if (password.val() == "") {
                alert("请输入密码。");
                password.focus();
                return false;
            }
            if (code.val() == "") {
                alert("请输入验证码。");
                code.focus();
                return false;
            }


        }</script>
</body>
</html>
