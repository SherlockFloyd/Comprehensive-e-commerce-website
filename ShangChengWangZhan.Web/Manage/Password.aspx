﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="Shopping.Web.Manage.Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="/base/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
</head>
<body style="height: 100%">
    <form id="form1" runat="server" class="form-panel">
    <div class="grid-panel">
        <div class="grid-header" style="mozuserselect: none; khtmluserselect: none" unselectable="on">
            <img src="/icons/table.gif" />&nbsp;修改密码</div>
        <div>
            <div class="grid-container grid-wrap header-noborder">
                <fieldset>
                    <table width="100%" id="otherInfo">
                        <colgroup>
                            <col width="20%" />
                            <col />
                        </colgroup>
                         <tr>
                            <td align="right">
                                旧密码：
                            </td>
                            <td>
                                <input type="password" id="Password1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                新密码：
                            </td>
                            <td>
                                <input type="password" id="Password2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                确认密码：
                            </td>
                            <td>
                                <input type="password" id="Password3" runat="server" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <table class="tb">
                    <tr>
                        <td align="center">
                            <asp:Button ID="subitBtn" runat="server" CssClass="btn2" Text="提交" OnClick="subitBtn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>


