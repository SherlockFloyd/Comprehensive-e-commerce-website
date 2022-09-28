<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryList.aspx.cs" Inherits="Shopping.Web.Member.DeliveryList" %>

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
                        <li class="active"><a href="javascript:;">收货地址</a></li>
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
                                <th>
                                    收货人
                                </th>
                                <th>
                                    收货地址
                                </th>
                                <th>
                                    联系电话
                                </th>
                                <th>
                                    操作
                                </th>
                            </tr>
                            <asp:Repeater ID="repeater" runat="server" OnItemCommand="repeater_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Address") %>
                                        </td>
                                        <td>
                                            <%# Eval("Tel") %>
                                        </td>
                                        <td align="center">
                                            <a href="DeliveryEdit.aspx?deliveryid=<%# Eval("DeliveryID")%>">编辑</a> |
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="设为默认" CommandArgument='<%# Eval("DeliveryID")%>'
                                                CommandName="setDefault"></asp:LinkButton>
                                            |
                                            <asp:LinkButton ID="txtDelButton" OnClientClick="return confirm('确认要删除吗?');" runat="server"
                                                Text="删除" CommandArgument='<%# Eval("DeliveryID")%>' CommandName="del"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="alt">
                                        <td>
                                            <%# Eval("Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Address") %>
                                        </td>
                                        <td>
                                            <%# Eval("Tel") %>
                                        </td>
                                        <td align="center">
                                            <a href="DeliveryEdit.aspx?deliveryid=<%# Eval("DeliveryID")%>">编辑</a> |
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="设为默认" CommandArgument='<%# Eval("DeliveryID")%>'
                                                CommandName="setDefault"></asp:LinkButton>
                                            |
                                            <asp:LinkButton ID="txtDelButton" OnClientClick="return confirm('确认要删除吗?');" runat="server"
                                                Text="删除" CommandArgument='<%# Eval("DeliveryID")%>' CommandName="del"></asp:LinkButton>
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
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
    </form>
</body>
</html>
