<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CateEdit.aspx.cs" Inherits="Shopping.Web.Manage.CateEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加类别</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="/base/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
</head>
<body style="height: 100%">
    <form id="form1" runat="server" class="form-panel">
    <div class="grid-panel">
        <div class="grid-header" style="mozuserselect: none; khtmluserselect: none" unselectable="on">
            <img src="/icons/table.gif" />&nbsp;添加类别</div>
        <div>
            <div class="grid-container grid-wrap header-noborder">
                <fieldset>
                    <div id="add_cate">
                        <table class="edit-table">
                            <colgroup>
                                <col width="20%" />
                                <col width="250" />
                                <col />
                            </colgroup>
                           
                            <tr>
                                <td align="right">
                                    名称：
                                </td>
                                <td>
                                    <input type="text" name="txtName" id="txtName" runat="server" />
                                </td>
                                <td align="left">
                                    <font class="red">*名称不能为空</font>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="subitBtn" runat="server" OnClientClick="return checkInfo();" CssClass="btn2"
                                        Text="提交" OnClick="subitBtn_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <input type="hidden" runat="server" id="parentId" name="parentId" />
    </form>
    <script type="text/javascript">
        function checkInfo() {
            var name = $.trim($("#txtName").val());
            if (name == "") {
                alert("请输入类别名称!");
                $("#txtName").focus();
                return false;
            }
        }
    </script>
</body>
</html>
