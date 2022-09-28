<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Shopping.Web.Member.OrderList" %>

<%@ Register Src="/Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="/Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<%@ Register Src="Lefter.ascx" TagName="Lefter" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员中心</title>
    <link href="/CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/member.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <Shopping:Header ID="Header1" runat="server" />
    <!-- header end -->
    <div class="body-skin w990">
        <ul class="navigation clearfix mb10">
        </ul>
        <div class="body-main clearfix">
            <Shopping:Lefter ID="Lefter1" runat="server" />
            <div class="main">
                <div class="tabview mb10">
                    <ul class="tab-nav clearfix">
                        <li class="active"><a href="javascript:;">我的订单</a></li>
                    </ul>
                    <div class="tab-content">
                        <table class="tb">
                            <colgroup>
                                <col width="120" />
                                <col />
                                <col width="80" />
                                <col width="120" />
                                <col width="110" />
                            </colgroup>
                            <tr>
                                <th class="first">
                                    订单号
                                </th>
                                <th>
                                    订单商品
                                </th>
                                <th>
                                    订单金额
                                </th>
                                <th>
                                    订单时间
                                </th>
                                <th>
                                    评价
                                </th>
                            </tr>
                            <asp:Repeater ID="repeater" runat="server" OnItemDataBound="repeater_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("OrderNo") %>
                                        </td>
                                        <td>
                                            <asp:Repeater ID="photoRepeater" runat="server">
                                                <ItemTemplate>
                                                    <a target="_blank" href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                        <img src='<%# Eval("Photo") %>' width="50" height="50" /></a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                        <td>
                                            <%# Eval("TotalPrice") %>
                                        </td>
                                        <td>
                                            <%# Eval("OrderTime") %>
                                        </td>
                                        <td>
                                            <a class="blue" href="OrderDetail.aspx?orderid=<%# Eval("OrderID") %>">订单详情</a><br />
                                            <%# Eval("OrderStatusName") %>
                                            <br />
                                            <asp:Literal ID="payLink" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="alt">
                                        <td>
                                            <%# Eval("OrderNo") %>
                                        </td>
                                        <td>
                                            <asp:Repeater ID="photoRepeater" runat="server">
                                                <ItemTemplate>
                                                    <a target="_blank" href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>"
                                                        title="<%# Eval("Name") %>">
                                                        <img src='<%# Eval("Photo") %>' width="50" height="50" /></a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                        <td>
                                            <%# Eval("TotalPrice") %>
                                        </td>
                                        <td>
                                            <%# Eval("OrderTime") %>
                                        </td>
                                        <td>
                                            <a class="blue" href="OrderDetail.aspx?orderid=<%# Eval("OrderID") %>">订单详情</a><br />
                                            <%# Eval("OrderStatusName") %>
                                            <br />
                                            <asp:Literal ID="payLink" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div class="pager-box">
                            <div class="pager">
                                <Shopping:Pager ID="pager" runat="server" PageSize="15" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
    </form>
</body>
</html>
