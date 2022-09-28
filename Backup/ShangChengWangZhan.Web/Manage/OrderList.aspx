<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Shopping.Web.Manage.OrderList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单列表</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="/base/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
    <style type="text/css">
        
    </style>
</head>
<body style="height: 100%">
    <form id="form1" runat="server" class="form-panel">
    <div class="grid-panel">
        <div class="grid-header" style="mozuserselect: none; khtmluserselect: none" unselectable="on">
            <img src="/icons/table.gif" />&nbsp;订单列表</div>
        <div>
            <div class="grid-container grid-wrap header-noborder">
                <fieldset>
                    <table class="tb">
                        <tr>
                            <td>
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
                </fieldset>
                <Shopping:DataGrid ID="datagrid" runat="server" PageSize="50" OnItemDataBound="datagrid_OnItemDataBound"
                    OnItemCommand="datagrid_ItemCommand" OnPageIndexChanged="datagrid_PageIndexChanged">
                    <Columns>
                        <asp:TemplateColumn HeaderText="<input type='checkbox' id='selectall'/>">
                            <HeaderStyle Width="25" />
                            <ItemTemplate>
                                <input type="checkbox" id="OrderID" xz="xx" value='<%#Eval("OrderID") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="订单号" DataField="OrderNo"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="用户名" DataField="UserName"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="订单总价" DataField="TotalPrice"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="收货人" DataField="ShipPeopele"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="收货地址" DataField="ShipAddress"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="联系电话" DataField="ShipMobile"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="订单状态">
                            <HeaderStyle Width="100" />
                            <ItemTemplate>
                                <%# Eval("OrderStatusName")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="订单时间" DataField="OrderTime"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="操作">
                            <HeaderStyle Width="50" />
                            <ItemTemplate>
                                <a title="详情" href="OrderDetail.aspx?orderid=<%# Eval("OrderID") %>">
                                    <img src="/icons/brick.gif" /></a>
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
            Seral.LocationHerf("PressEdit.aspx?action=add", "add_btn");
        });
    </script>
</body>
</html>
