<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttentionList.aspx.cs"
    Inherits="Shopping.Web.Member.AttentionList" %>

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
                        <li class="active"><a href="javascript:;">我的关注</a></li>
                    </ul>
                    <div class="tab-content">
                        <table class="tb">
                            <colgroup>
                                <col />
                                <col />
                                <col />
                                <col width="150" />
                            </colgroup>
                            <tr>
                                <th class="first">
                                </th>
                                <th>
                                    名称
                                </th>
                                <th>
                                    关注时间
                                </th>
                                <th>
                                    操作
                                </th>
                            </tr>
                            <asp:Repeater ID="repeater" runat="server" OnItemCommand="repeater_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a target="_blank" href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("CommodityName") %>">
                                                <img src='<%# Eval("Photo") %>' width="50" height="50" /></a>
                                        </td>
                                        <td>
                                            <a target="_blank" href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("CommodityName") %>">
                                                <%# Eval("CommodityName") %></a>
                                        </td>
                                        <td>
                                            <%# Eval("CreateTime") %>
                                        </td>
                                        <td>
                                            <asp:LinkButton CssClass="b-1" ID="txtDelButton" OnClientClick="return confirm('确认要取消关注吗?');"
                                                runat="server" Text="取消关注" CommandArgument='<%# Eval("AttentionID")%>' CommandName="cancel"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="alt">
                                        <td>
                                            <a target="_blank" href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("CommodityName") %>">
                                                <img src='<%# Eval("Photo") %>' width="50" height="50" /></a>
                                        </td>
                                        <td>
                                            <a target="_blank" href="/Detail.aspx?commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("CommodityName") %>">
                                                <%# Eval("CommodityName") %></a>
                                        </td>
                                        <td>
                                            <%# Eval("CreateTime") %>
                                        </td>
                                        <td>
                                            <asp:LinkButton CssClass="b-1" ID="txtDelButton" OnClientClick="return confirm('确认要取消关注吗?');"
                                                runat="server" Text="取消关注" CommandArgument='<%# Eval("AttentionID")%>' CommandName="cancel"></asp:LinkButton>
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
        <script type="text/javascript">
            $("#allSortOuterbox").hide();
            $("#global_menu").addClass("tqyClass");
        </script>
    </form>
</body>
</html>
