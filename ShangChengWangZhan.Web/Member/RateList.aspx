<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RateList.aspx.cs" Inherits="Shopping.Web.Member.RateList" %>

<%@ Register Src="/Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="/Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<%@ Register Src="Lefter.ascx" TagName="Lefter" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>评价</title>
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
                        <li class="active"><a href="javascript:;">已购商品</a></li>
                    </ul>
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
                            <asp:Repeater ID="repeater" runat="server">
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
    </form>
    <script type="text/javascript">
        function rateClick(snapshotid) {
            location = "rate.aspx?snapshotid=" + snapshotid;
        }
    </script>
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
</body>
</html>
