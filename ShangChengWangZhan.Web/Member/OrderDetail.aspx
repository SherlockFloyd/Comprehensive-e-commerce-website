<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="Shopping.Web.Member.OrderDetail" %>

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
    <style type="text/css">
        
    </style>
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
                <div class="tabview  tab-modify mb10">
                    <ul class="tab-nav clearfix">
                        <li class="active"><a href="javascript:;">订单详情</a></li>
                    </ul>
                    <div class="tab-content order clr">
                        <div class="b-title">
                            <h2>
                                订单基本信息</h2>
                        </div>
                        <table class="b">
                            <colgroup>
                                <col width="20%" />
                                <col />
                            </colgroup>
                            <tr>
                                <td align="right">
                                    订单号：
                                </td>
                                <td>
                                    <asp:Literal ID="orderno" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    订单状态：
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="orderstatus" runat="server"></asp:Literal>
                                            </td>
                                            <asp:PlaceHolder ID="btnPlaceHolder" Visible="false" runat="server">
                                                <td>
                                                    <asp:Button ID="subitBtn" runat="server" CssClass="b-1" Text="确认收货" OnClick="subitBtn_Click" />
                                                </td>
                                            </asp:PlaceHolder>
                                            <asp:PlaceHolder ID="PlaceHolder1" Visible="false" runat="server">
                                                <td>
                                                    <asp:Literal ID="payLink" runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    &nbsp;<asp:Button ID="cancelBtn" OnClientClick="return confirm('确认要取消订单吗?')" runat="server"
                                                        CssClass="b-2" Text="取消订单" OnClick="cancelBtn_Click" />
                                                </td>
                                            </asp:PlaceHolder>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div class="b-title">
                            <h2>
                                购物清单</h2>
                        </div>
                        <table class="tb">
                            <tr>
                                <th>
                                    图片
                                </th>
                                <th>
                                    名称
                                </th>
                                <th>
                                    价格
                                </th>
                                <th>
                                    数量
                                </th>
                                <th>
                                    小计
                                </th>
                                <th>
                                    评价
                                </th>
                            </tr>
                            <asp:Repeater ID="repeater" runat="server" OnItemDataBound="repeater_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href="/Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                <img width="50" height="50" src='<%# Eval("Photo") %>' /></a>
                                        </td>
                                        <td>
                                            <div style="width: 450px; height: 22px; overflow: hidden">
                                                
                                                    <%#Eval("Name") %></div>
                                        </td>
                                        <td>
                                            <%# Eval("Price") %>
                                        </td>
                                        <td>
                                            <%# Eval("Quantity") %>
                                        </td>
                                        <td>
                                            <%# Eval("TotalPrice") %>
                                        </td>
                                        <td>
                                            <asp:Literal ID="txtOrderStatusIntro" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="alt">
                                        <td>
                                            <a href="Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                <img width="50" height="50" src='<%# Eval("Photo") %>' /></a>
                                        </td>
                                        <td>
                                            <div style="width: 450px; height: 22px; overflow: hidden">
                                                <a href="/Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                    <%#Eval("Name") %></a></div>
                                        </td>
                                        <td>
                                            <%# Eval("Price") %>
                                        </td>
                                        <td>
                                            <%# Eval("Quantity") %>
                                        </td>
                                        <td>
                                            <%# Eval("TotalPrice") %>
                                        </td>
                                        <td>
                                            <asp:Literal ID="txtOrderStatusIntro" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div class="b-t clr">
                            <table>
                                <tr>
                                    <td class="usepoint">
                                        订单总价：<em><asp:Literal ID="txtTotalPrice" runat="server"></asp:Literal></em> 元
                                    </td>
                                </tr>
                                <%--<asp:PlaceHolder ID="PlaceHolder11" runat="server" Visible="false">
                                    <tr>
                                        <td class="usepoint">
                                            使用积分：<em><asp:Literal ID="userpoint" runat="server"></asp:Literal></em> 积分
                                        </td>
                                    </tr>
                                </asp:PlaceHolder>--%>
                                <%--<asp:PlaceHolder ID="PlaceHolder13" runat="server" Visible="false">
                                    <tr>
                                        <td class="usepoint">
                                            优惠券优惠金额：<em><asp:Literal ID="txtSaveByCouponPrice" runat="server"></asp:Literal></em>
                                            元
                                        </td>
                                    </tr>
                                </asp:PlaceHolder>--%>
                                <%--<asp:PlaceHolder ID="PlaceHolder12" runat="server" Visible="false">
                                    <tr>
                                        <td class="couponprice">
                                            优惠总计：<em>-<asp:Literal ID="couponprice" runat="server"></asp:Literal></em> 元
                                        </td>
                                    </tr>
                                </asp:PlaceHolder>--%>
                                <tr>
                                    <td class="tp">
                                        <asp:Literal ID="txtOrderIntro" runat="server"></asp:Literal>总价：<em><asp:Literal
                                            ID="orderprice" runat="server"></asp:Literal></em> 元
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="b-title">
                            <h2>
                                买家信息</h2>
                        </div>
                        <table class="b-s">
                            <colgroup>
                                <col width="20%" />
                                <col />
                            </colgroup>
                            <tr>
                                <td align="right">
                                    收货地址：
                                </td>
                                <td>
                                    <asp:Literal ID="shipaddress" runat="server"></asp:Literal>,
                                    <asp:Literal ID="shippeople" runat="server"></asp:Literal>,
                                    <asp:Literal ID="shipmobile" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    下单时间：
                                </td>
                                <td>
                                    <asp:Literal ID="ordertime" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                        <%--<div class="b-title" style="display: none">
                            <h2>
                                卖家信息</h2>
                        </div>--%>
                        <%--<table class="b-s" style="display: none">
                            <colgroup>
                                <col width="20%" />
                                <col />
                            </colgroup>
                            <tr>
                                <td align="right">
                                    卖家姓名：
                                </td>
                                <td>
                                    <asp:Literal ID="txtshopname" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    联系方式：
                                </td>
                                <td>
                                    <asp:Literal ID="txtcontact" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Shopping:Footer ID="Footer1" runat="server" />
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
    </form>
</body>
</html>
