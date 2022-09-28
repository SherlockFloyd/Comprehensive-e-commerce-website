<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartEx.aspx.cs"
    Inherits="Shopping.Web.ShoppingCartEx" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>确认订单</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="CSS/shoppingcart.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990">
        <div class="flow clearfix">
            <div class="flow_steps">
                <ul>
                    <li class="done current_prev">1.我的购物车</li>
                    <li class="current">2.确认订单信息</li>
                    <li class="last">3.成功提交订单</li>
                </ul>
            </div>
        </div>
        <div class="mod mb10">
            <asp:Repeater ID="repeater" runat="server" OnItemDataBound="repeater_ItemDataBound">
                <ItemTemplate>
                    <div class="hd">
                        <h3>
                        <input type="radio" id="radio_<%# Eval("UserID") %>" name="shopid" value='<%# Eval("UserID") %>' />    订单<%= i++ %>卖家：<%# Eval("RealName") %></h3>
                    </div>
                    <asp:Repeater ID="repeater1" runat="server">
                        <HeaderTemplate>
                            <div class="bd">
                                <table class="cart-table">
                                    <colgroup>
                                        <col />
                                        <col />
                                        <col />
                                        <col />
                                        <col width="48" />
                                    </colgroup>
                                    <thead>
                                        <tr>
                                            <th class="td-1">
                                                图片
                                            </th>
                                            <th class="td-2">
                                                名称
                                            </th>
                                            <th class="td-5">
                                                价格
                                            </th>
                                            <th class="td-6">
                                                数量
                                            </th>
                                            <th class="td-7">
                                                合计
                                            </th>
                                        </tr>
                                    </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <a href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                        <img width="50" height="50" src='<%# Eval("Photo") %>' /></a>
                                </td>
                                <td>
                                    <a href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                        <%#Eval("Name")%></a>
                                </td>
                                <td id="price_<%# Eval("ShoppingCartID") %>">
                                    <%# Eval("Price") %>
                                </td>
                                <td>
                                    <%# Eval("Quantity") %>
                                </td>
                                <td>
                                    <%# Eval("TotalPrice") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                             </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </div>
          <div class="clearfix">
            <div class="tfoot ">
                <a href="ShoppingCart.aspx">
                    <img src="/icons/cart_edit.gif" />返回购物车"/icons/cart_edit.gif" />返回购物车</a>
                <asp:Button ID="subitBtn" CssClass="btn2" Text="立即结算" runat="server" OnClick="subitBtn_Click" />
            </div>
        </div>
    </div>
    <Shopping:Footer ID="Footer1" runat="server" />
    </form>
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
</body>
</html>
