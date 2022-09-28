<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CateList.aspx.cs" Inherits="Shopping.Web.Manage.CateList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>类别列表</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="/base/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
</head>
<body style="height: 100%">
    <form id="form1" runat="server" class="form-panel">
    <div class="grid-panel">
        <div class="grid-header" style="mozuserselect: none; khtmluserselect: none" unselectable="on">
            <img src="/icons/table.gif" />&nbsp;类别列表</div>
        <div>
            <div class="grid-container grid-wrap header-noborder">
                <fieldset>
                    <table class="tb">
                        <tr>
                            <td>
                                <input id="add_btn" class="btn2" type="button" value="添加" />
                            </td>
                            <td align="right">
                                <table>
                                    <tr>
                                        <td align="right">
                                            关键字搜索：
                                        </td>
                                        <td>
                                            <input type="text" id="txtKeyword" runat="server" class="text" />&nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="search_btn" runat="server" Text="搜 索" CssClass="btn2" OnClick="search_btn_Click"/>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <Shopping:DataGrid ID="datagrid" runat="server" PageSize="50" OnItemDataBound="datagrid_OnItemDataBound"
                    OnItemCommand="datagrid_ItemCommand" OnPageIndexChanged="datagrid_PageIndexChanged">
                    <Columns>
                        <asp:TemplateColumn HeaderText="<input type='checkbox' id='selectall'/>">
                            <HeaderStyle Width="25" />
                            <ItemTemplate>
                                <input type="checkbox" id="CateID" xz="xx" value='<%#Eval("CateID") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="类别名称" DataField="Name"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="添加时间" DataField="CreateTime" HeaderStyle-Width="120">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="操作">
                            <HeaderStyle Width="50" />
                            <ItemTemplate>
                           <a href="CateEdit.aspx?action=edit&id=<%# Eval("CateID") %>" title="编辑">
                                    <img src='/icons/page_white_edit.gif' /></a> | 
                                <asp:ImageButton ID="del_btn" CssClass="cursor" CommandName="del" CommandArgument='<%# Eval("CateID") %>'
                                    runat="server" title="删除" OnClientClick="return Seral.dell()" target="del" ImageUrl="/icons/delete.gif" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Shopping:DataGrid>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            Seral.LocationHerf("CateEdit.aspx?action=add", "add_btn");
        });
    </script>
</body>
</html>
