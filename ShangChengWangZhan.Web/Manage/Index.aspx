<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Shopping.Web.Manage.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理中心</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="/base/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
    <script src="/base/JS/manage.js" type="text/javascript"></script>
    <style type="text/css">
        body, html
        {
            height: 100%;
        }
        body
        {
            padding: 0px;
            margin: 0;
            overflow: hidden;
        }
        
        #pageloading
        {
            position: absolute;
            left: 0px;
            top: 0px;
            background: white url('loading.gif') no-repeat center;
            width: 100%;
            height: 100%;
            z-index: 99999;
        }
        /* 顶部 */
        .l-topmenu
        {
            margin: 0;
            padding: 0;
            height: 80px;
            line-height: 31px;
            background: url('lib/images/top.jpg') repeat-x bottom;
            position: relative;
            border-top: 1px solid #1D438B;
        }
        
        .top
        {
            margin: 0;
            padding: 0;
            height: 25px;
        }
    </style>
</head>
<body style="padding: 0px; background: #EAEEF5;">
    <form id="form1" runat="server">
    <div id="pageloading">
    </div>
    <div id="topmenu" class="l-topmenu">
        <div style="width: 100%; height: 85px; background: url(/base/images/header_bg.png) repeat-x;">
            <span style="font-size: 18px; line-height: 50px;">
                <img src="/base/images/logo2.png" style="width: 100%; height: 90px;" /></span>
        </div>
    </div>
    <div id="layout1" style="width: 99.2%; margin: 0 auto; margin-top: 12px;">
        <div position="top">
            <div id="toptoolbar" class="l-toolbar" style="width: 100%;">
                <ul>
                    <li><a href="/Index.aspx">退出系统</a> </li>
                    <li><a href="javascript:changepwd();">修改密码</a></li>
                    <li><a href="javascript:;" style="text-decoration: none;">欢迎您: "<%= adminInfo.AdminName %>"&nbsp;&nbsp;</a></li>
                </ul>
            </div>
        </div>
        <div class="top">
        </div>
        <div position="left" title="主要菜单" id="accordion1">
            <asp:Literal ID="menu" runat="server"></asp:Literal>
        </div>
        <div position="center" id="framecenter">
            <div tabid="home" title="我的主页">
                <iframe frameborder="0" name="home" src="InforCenter.aspx"></iframe>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        //载入事件
        $.fn.Onit();


//        function exit() {
//            if (confirm("确认要退出此系统吗?")) {
//                location = "Login.aspx";
//            }
//        }

        //修改密码
        function changepwd() {
            f_addTab('changepwd', '修改密码', 'Password.aspx');
        }
    </script>
</body>
</html>
