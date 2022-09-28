<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="Shopping.Web.Manage.AdminList" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理员信息</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
    <script src="/JS/layer.min.js" type="text/javascript"></script>
</head>
<body style="height: 100%">
    <form id="form1" runat="server" class="form-panel">
    <div class="grid-panel">
        <div class="grid-header" style="mozuserselect: none; khtmluserselect: none" unselectable="on">
            <img src="/icons/table.gif" />&nbsp;管理员信息</div>
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
                                            <asp:Button ID="search_btn" runat="server" Text="搜 索" CssClass="btn2" OnClick="search_btn_Click" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <Shopping:DataGrid ID="datagrid" runat="server" PageSize="50" OnItemDataBound="datagrid_OnItemDataBound"
                        OnItemCommand="datagrid_ItemCommand" OnPageIndexChanged="datagrid_PageIndexChanged">
                        <Columns>
                            <asp:TemplateColumn HeaderText="<input type='checkbox' id='selectall'/>">
                                <HeaderStyle Width="25" />
                                <ItemTemplate>
                                    <input type="checkbox" id="CateID" xz="xx" value='<%#Eval("AdminID") %>' />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="用户名" DataField="AdminName"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="上一次登录时间" DataField="LastLoginTIme"></asp:BoundColumn>
                            <%--<asp:BoundColumn HeaderText="最后一次登录IP" DataField="LastLoginIP"></asp:BoundColumn>--%>
                            <asp:BoundColumn HeaderText="添加时间" DataField="CreateTime"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="操作">
                                <HeaderStyle Width="50" />
                                <ItemTemplate>
                                   <%--
                                    <asp:ImageButton ID="ImageButton1" CssClass="cursor" CommandName="resetpwd" CommandArgument='<%# Eval("AdminID") %>'
                                        runat="server" title="初始化密码" OnClientClick="return confirm('确认要初始化密码吗?');" ImageUrl="/icons/refresh.gif" />
                                    |
                                    --%>

                                    <asp:ImageButton ID="del_btn" CssClass="cursor" CommandName="del" CommandArgument='<%# Eval("AdminID") %>'
                                        runat="server" title="删除" OnClientClick="return Seral.dell()" target="del" ImageUrl="/icons/delete.gif" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </Shopping:DataGrid>
                </fieldset>
            </div>
        </div>
        <input type="hidden" id="adminID" />
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            Seral.LocationHerf("AdminEdit.aspx?action=add", "add_btn");
        });

        $(".assignBtn").on('click', function (event) {

            var adminID = $(this).attr("adminid");

            event.preventDefault();

//            $.layer({
//                type: 2,
//                title: '分配权限',
//                iframe: { src: '/Manage/RBAC_Web/GroupAssign.aspx?id=' + adminID },
//                area: ['750px', '150px'],
//                offset: ['100px', '']
//            });
        });

    </script>
</body>
</html>
