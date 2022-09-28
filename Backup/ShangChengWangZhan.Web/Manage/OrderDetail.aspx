<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="Shopping.Web.Manage.OrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单详情</title>
    <link href="/base/Css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="/base/JS/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/base/JS/ligerui.min.js" type="text/javascript"></script>
    <script src="/base/JS/base.js" type="text/javascript"></script>
    <style type="text/css">
        .shoppingcartlist
        {
            border: 1px solid #AACCEF;
            border-bottom: none;
            marign-top: 10px;
        }
        .shoppingcartlist table
        {
            width: 100%;
            border-top: none;
        }
        .shoppingcartlist table th
        {
            background: #f4f4f4;
            height: 30px;
            line-height: 30px;
            font-weight: bold;
            text-align: left;
            padding: 0 10px;
            font-size: 12px;
            border-bottom: 1px solid #dedede;
        }
        .shoppingcartlist table th.first
        {
            border-left: 1px solid #dedede;
        }
        .shoppingcartlist table td
        {
            line-height: 20px;
            font-size: 12px;
            padding: 5px 0 5px 0;
            vertical-align: middle;
            border-bottom: 1px solid #AACCEF;
        }
        
        .base-info
        {
            border: 1px solid #AACCEF;
        }
        .base-info table
        {
            width: 100%;
        }
        .base-info table th
        {
            background: #f4f4f4;
            height: 30px;
            line-height: 30px;
            font-weight: bold;
            text-align: left;
            padding: 0 10px;
            font-size: 12px;
        }
        .base-info table td
        {
            line-height: 20px;
            font-size: 12px;
            padding: 5px 0 5px 0;
            vertical-align: middle;
        }
        .title
        {
            font-weight: bold;
            background: #E9F2Fb;
            height: 31px;
            border-bottom: 1px solid #AACCEF;
            padding-left: 5px;
        }
        .title h2
        {
            color: #2B64B8;
            font-size: 12px;
            font-weight: normal;
            background: url(/images/img05.gif) no-repeat 0 center;
            padding-left: 15px;
            line-height: 33px;
        }
        .btnDiv
        {
            border: 1px solid #AACCEF;
            line-height: 35px;
        }
        .btnDiv .content
        {
            padding: 10px;
        }
    </style>
</head>
<body style="height: 100%">
    <form id="form1" runat="server" class="form-panel">
    <div class="grid-panel">
        <div class="grid-header" style="mozuserselect: none; khtmluserselect: none" unselectable="on">
            <img src="/icons/table.gif" />&nbsp;订单详情</div>
        <div>
            <div class="grid-container grid-wrap header-noborder">
                <fieldset>
                    <div class="base-info">
                        <div class="title">
                            <h2>
                                订单信息</h2>
                        </div>
                        <table>
                            <colgroup>
                                <col width="20%" />
                                <col />
                            </colgroup>
                            <tr>
                                <td align="right">
                                    用户名：
                                </td>
                                <td>
                                    <asp:Literal ID="username" runat="server"></asp:Literal>
                                </td>
                            </tr>
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
                                    订单总价：
                                </td>
                                <td>
                                    <asp:Literal ID="orderprice" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    收货人姓名：
                                </td>
                                <td>
                                    <asp:Literal ID="shippeople" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    收货地址：
                                </td>
                                <td>
                                    <asp:Literal ID="shipaddress" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    联系电话：
                                </td>
                                <td>
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
                            <tr>
                                <td align="right">
                                    订单状态：
                                </td>
                                <td>
                                    <asp:Literal ID="orderstatus" runat="server"></asp:Literal>
                                    <asp:PlaceHolder ID="PlaceHolder2" Visible="false" runat="server">
                                        <asp:Button ID="subitBtn" runat="server" CssClass="b-1" Text="处理订单" OnClick="subitBtn_Click" />
                                    </asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div class="shoppingcartlist">
                        <div class="title">
                            <h2>
                                购物清单</h2>
                        </div>
                        <table>
                            <colgroup>
                                <col width="100" />
                                <col width="700" />
                                <col />
                                <col />
                                <col />
                            </colgroup>
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
                                    合计
                                </th>
                            </tr>
                            <asp:Repeater ID="repeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href="/Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                <img width="50" height="50" src='<%# Eval("Photo") %>' /></a>
                                        </td>
                                        <td>
                                            <a href="/Detail.aspx?Commodityid=<%# Eval("CommodityID") %>" title="<%# Eval("Name") %>">
                                                <%#Eval("Name") %></a>
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
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
