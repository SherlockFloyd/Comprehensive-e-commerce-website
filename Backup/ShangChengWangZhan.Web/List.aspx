<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Shopping.Web.List" %>


<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="Shopping" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="Shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>所有商品</title>
    <link href="CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="CSS/list.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <Shopping:Header ID="Header1" runat="server" />
    <div class="w990 mt10">
        <div class="filter clearfix">
            <table class="current">
                <asp:PlaceHolder ID="PlaceHolder1" Visible="false" runat="server">
                    <tr>
                        <td class="bg">
                            <div class="bt">
                                <h2>
                                    已选条件：</h2>
                            </div>
                        </td>
                        <td>
                            <ul class="clearfix red">
                                <asp:Literal ID="chooseCondition" runat="server"></asp:Literal>
                                <li>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></li>
                            </ul>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="PlaceHolder2" Visible="false" runat="server">
                    <tr>
                        <td class="bg">
                            <div class="bt">
                                <h2>
                                    按分类：</h2>
                            </div>
                        </td>
                        <td>
                            <ul class="clearfix">
                                <asp:Repeater ID="cateRepeater" runat="server" OnItemDataBound="cateRepeater_ItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                            <asp:Literal ID="txtCateLink" runat="server"></asp:Literal>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </td>
                    </tr>
                </asp:PlaceHolder>
            </table>
        </div> 
        <div class="w990  mt10 clr">
            <ul class="list-5">
                <asp:Repeater ID="repeater" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="pic">
                                <%#    Shopping.BLL.CommodityBLL.GetCommodityStatus((Shopping.Model.Commodity)Container.DataItem) %>
                                <a name="" title="<%# Eval("Name") %>" href="<%# Eval("DetailUrl") %>" target="_blank">
                                    <img width="140" height="140" src="<%# Eval("Photo") %>" /></a></div>
                            <div class="name">
                                <a  href="<%# Eval("DetailUrl") %>" title="<%# Eval("Name") %>" target="_blank">
                                    <%# Eval("Name")%></a>
                            </div>
                            <div class="market-price">
                                市场价：<del><%# Eval("MarketPrice") %></del></div>
                            <div class="price">
                                实惠价：<em>
                                    <%# Eval("Price") %>
                                </em>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="clearfix">
            <div class="pager-box">
                <div class="pager">
                    <Shopping:Pager ID="pager" runat="server" DisplayMode="num3" PageSize="18" />
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" runat="server" id="txtIsHot" />
    <input type="hidden" runat="server" id="txtIsNew" />
    <input type="hidden" runat="server" id="txtOrderBy" />
    <input type="hidden" runat="server" id="txtSoftType" />
    <Shopping:Footer ID="Footer1" runat="server" />
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
    </form>
</body>
</html>
