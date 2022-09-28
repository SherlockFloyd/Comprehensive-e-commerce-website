<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Shopping.Web.Member.Index1" %>

<%@ Register Src="/Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="/Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<%@ Register Src="Lefter.ascx" TagName="Lefter" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户中心</title>
    <link href="/CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/member.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/JS/base.js" type="text/javascript"></script>
</head>
<body>
    <form id="orderForm" runat="server">
    <!-- header start -->
    <Shopping:Header ID="Header1" runat="server" />
    <!-- header end -->
    <div class="body-skin w990">
        <ul class="navigation clearfix mb10">
        </ul>
        <div class="body-main clearfix">
            <Shopping:Lefter ID="Lefter1" runat="server" />
            <div class="main">
                <input type="hidden" name="action" id="action" value="" />
                <input type="hidden" name="orderId" id="orderId" value="0" />
                <div class="box user clearfix mb10">
                    <div class="avatar">
                        <div class="pic">
                            <img src="/images/UserGroup/VIP会员.png">
                        </div>
                    </div>
                    <div>
                        <p>
                            欢迎您！ <span class="name">
                                <%= userInfo.UserName %></span>
                        </p>
                        <p>
                            账户安全：<span class="box w100">上一次登陆时间：<%=userInfo.LastLoginTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                               
                                登录次数：<%= userInfo.LoginTimes%></span></p>
                        <table>
                            <tr>
                                <td>
                                    温馨提醒：
                                </td>
                                <td width="130">
                                    &middot;待处理订单(<a href="orderlist.aspx?action=operate">
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    </a>)
                                </td>
                                <td width="130">
                                    &middot;待评价商品(<a href="ratelist.aspx?rate=no">
                                        <asp:Literal ID="txtNeedRate" runat="server"></asp:Literal>
                                    </a>)
                                </td>
                                <td width="130">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    &middot;我的收藏(<a href="attentionlist.aspx">
                                        <asp:Literal ID="txtAttentionCount" runat="server"></asp:Literal>
                                    </a>)
                                </td>
                                <%--<td>
                                    &middot;咨询回复(<a href="ConsultList.aspx?isread=no"><asp:Literal ID="consultCount"
                                        runat="server"></asp:Literal></a>)
                                </td>
                                <td>
                                </td>--%>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="tabview clr">
                    <ul class="tab-nav clearfix">
                        <li class="active"><a href="javascript:;">成功订单</a></li>
                        <li><a href="javascript:;">等待评价</a></li>
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
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                            <asp:PlaceHolder ID="PlaceHolder1" Visible="false" runat="server">
                                <tr>
                                    <td colspan="5">
                                        没有订单信息!
                                    </td>
                                </tr>
                            </asp:PlaceHolder>
                        </table>
                    </div>
                    <div class="tab-content">
                        <table class="tb">
                            <colgroup>
                                <col width="50" />
                                <col />
                                <col width="50" />
                                <col width="50" />
                                <col width="50" />
                                <col width="80" />
                            </colgroup>
                            <tr>
                                <th class="first">
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
                                    合计
                                </th>
                                <th>
                                    操作
                                </th>
                            </tr>
                            <asp:Repeater ID="repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                <img width="50" height="50" src='<%# Eval("Photo") %>' /></a>
                                        </td>
                                        <td>
                                            <a href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                <%#Shopping.Common.Utils.CutString(Eval("Name").ToString(), 0, 10)%></a>
                                        </td>
                                        <td align="center">
                                            <%# Eval("Price") %>
                                        </td>
                                        <td align="center">
                                            <%# Eval("Quantity") %>
                                        </td>
                                        <td align="center">
                                            <%# Eval("TotalPrice") %>
                                        </td>
                                        <td class="rt">
                                            <%# Eval("IsGrade").ToString() == "1" ? "<a class=\"s1\"><span class=\"s2 w" + Eval("HtmlGrade") + "\"></span></a>" : "<a class=\"blue b-1\" href=\"PostRate.aspx?snapshotid=" + Eval("SnapshotID").ToString() + "\">评价</a>"%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="alt">
                                        <td>
                                            <a href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                <img width="50" height="50" src='<%# Eval("Photo") %>' /></a>
                                        </td>
                                        <td>
                                            <a href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                <%#Shopping.Common.Utils.CutString(Eval("Name").ToString(), 0, 10)%></a>
                                        </td>
                                        <td align="center">
                                            <%# Eval("Price") %>
                                        </td>
                                        <td align="center">
                                            <%# Eval("Quantity") %>
                                        </td>
                                        <td align="center">
                                            <%# Eval("TotalPrice") %>
                                        </td>
                                        <td class="rt">
                                            <%# Eval("IsGrade").ToString() == "1" ? "<a class=\"s1\"><span class=\"s2 w" + Eval("HtmlGrade") + "\"></span></a>" : "<a class=\"blue b-1\" href=\"PostRate.aspx?snapshotid=" + Eval("SnapshotID").ToString() + "\">评价</a>"%>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Shopping:Footer ID="Footer1" runat="server" />
    </form>
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
        $(function () {
            // $.tabs("tabview", "tt", "mouseover");
            makeTabs($(".tabview"), "mouseover");
        });
    </script>
</body>
</html>
