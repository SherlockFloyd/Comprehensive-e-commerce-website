<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommodityList.aspx.cs"
    Inherits="Shopping.Web.Manage.CommodityList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品列表</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="/base/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
</head>
<body style="height: 100%">
    <form id="form1" runat="server" class="form-panel">
    <div class="grid-panel">
        <div class="grid-header" style="mozuserselect: none; khtmluserselect: none" unselectable="on">
            <img src="/icons/table.gif" />&nbsp;商品列表</div>
        <div>
            <div class="grid-container grid-wrap header-noborder">
                <fieldset>
                    <table class="tb">
                        <tr>
                            <td>
                                <input id="add_btn" class="btn2" type="button" value="添加" />
                                &nbsp;<asp:Button ID="batchOnsaleBtn" runat="server" CssClass="btn2" Text="批量上架"
                                    OnClick="batchOnsaleBtn_Click" />&nbsp;<asp:Button ID="batchOffSaleBtn" runat="server"
                                        CssClass="btn2" Text="批量下架" OnClick="batchOffSaleBtn_Click" />
                            </td>
                            <td align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <select id="txtOnsale" name="txtOnsale" runat="server">
                                                <option value="0">全部</option>
                                                <option value="1">下架</option>
                                                <option value="2" selected="selected">上架</option>
                                            </select>
                                            关键字搜索：
                                            <input type="text" id="txtKeyword" runat="server" class="text" />&nbsp;
                                        </td>
                                        <td>
                                            <asp:Button OnClick="search_btn_Click" ID="search_btn" runat="server" Text="搜 索"
                                                CssClass="btn2" />
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
                                <input type="checkbox" name="CommodityIDs" xz="xx" value='<%#Eval("CommodityID") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="图片">
                            <HeaderStyle Width="60" />
                            <ItemTemplate>
                                <img src='<%# Eval("Photo")%>' height="50" width="50" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="名称">
                            <HeaderStyle Width="120" />
                            <ItemTemplate>
                                <a href="javascript:" title='<%# Eval("Name")%>'>
                                    <%# Shopping.Common.Utils.CutString(Eval("Name").ToString(),0,10)%></a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="编号" DataField="CommodityNo"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="市场价/售价">
                            <HeaderStyle Width="150" />
                            <ItemTemplate>
                                <%# Eval("MarketPrice")%>/<%# Eval("Price")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                        <asp:BoundColumn HeaderText="剩余库存" DataField="Stock"></asp:BoundColumn>


                        <asp:TemplateColumn HeaderText="上下架">
                            <HeaderStyle Width="50" />
                            <ItemTemplate>
                                <%# Eval("OnSale").ToString() == "2" ? "<font color=\"blue\">销售中</font>" : "<font color=\"red\">已下架</font>"%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="上架时间" DataField="OnSaleTime"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="添加时间" DataField="CreateTime" HeaderStyle-Width="120">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="操作">
                            <HeaderStyle Width="50" />
                            <ItemTemplate>
                                <a href="CommodityEdit.aspx?action=edit&id=<%# Eval("CommodityID") %>" title="编辑">
                                    <img src='/icons/page_white_edit.gif' /></a> |
                                <asp:ImageButton ID="del_btn" CssClass="cursor" CommandName="del" CommandArgument='<%# Eval("CommodityID") %>'
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
            Seral.LocationHerf("CommodityEdit.aspx?action=add", "add_btn");
        });
    </script>
</body>
</html>
