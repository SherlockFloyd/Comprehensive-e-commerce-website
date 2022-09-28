<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmOrder.aspx.cs" Inherits="Shopping.Web.ConfirmOrder" %>

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
            <div class="hd">
                <h3>
                    收货人信息<font class="red">  </font></h3>
            </div>
            <div class="bd">
                <table class="cart-table">
                    <colgroup>
                        <col width="10%" />
                        <col />
                    </colgroup>
                    <asp:Repeater ID="txtDeliveryList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input type="radio" <%# Eval("IsDefault").ToString()=="0"?"":"Checked=\"Checked\""  %>
                                        name="delivery" value='<%# Eval("DeliveryID")%>' id='delivery_<%# Eval("DeliveryID")%>' />
                                    收货人：<%# Eval("Name")%>&nbsp;&nbsp;收货地址：<%# Eval("Address")%>&nbsp;&nbsp;收货手机：<%# Eval("Tel")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td>
                            <input type="radio" name="delivery" id="delivery_0" value="0" runat="server" /><label
                                for="delivery_0">新的收货地址</label>&nbsp;&nbsp; 收货人：
                            <input type="text" class="text" runat="server" id="txtshippeople" /><font class="red">
                                 </font>收货地址：
                            <input type="text" class="text" runat="server" id="txtshipaddress" /><font class="red">
                                 </font>收货手机：
                            <input type="text" class="text" runat="server" id="txtshipmobile" /><font class="red">
                                 </font>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mod mb10">
            <div class="hd">
                <h3>
                    快递信息</h3>
            </div>
            <div class="bd">
                <input type="radio" checked="checked" id="radio1" /><label for="radio1">快递</label>
            </div>
        </div>
        <div class="mod mb10">
            <div class="hd">
                <h3>
                    购物清单</h3>
            </div>
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
                    <asp:Repeater ID="repeater" runat="server">
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
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div class="convert clearfix">
            <div class="convert-message clearfix">
                <table>
                    <colgroup>
                        <col width="20%" />
                        <col />
                    </colgroup>
                    <tr>
                        <td align="right">
                            订单留言：
                        </td>
                        <td>
                            <textarea id="comments" name="comments" runat="server"></textarea>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="convert-amount">
                <!--金额统计-->
                <table>
                    <tr>
                        <th>
                            商品总数：
                        </th>
                        <td class="total">
                            共<em id="totalAmount"><asp:Literal ID="txtQuantity" runat="server"></asp:Literal></em>
                            件商品
                        </td>
                    </tr>
                    <tr>
                        <th>
                            合计(含运费)：
                        </th>
                        <td class="pay">
                            <em>¥<asp:Literal ID="txtTotalPrice" runat="server"></asp:Literal></em> 元
                        </td>
                    </tr>
                    <tr>
                        <th>
                            优惠：
                        </th>
                        <td class="coupon-price">
                            <em id="couponSaving">¥<asp:Literal ID="Literal1" runat="server"></asp:Literal></em>
                            元
                        </td>
                    </tr>
                    <tr>
                        <th>
                            您需支付：
                        </th>
                        <td class="pay">
                            <em id="realpay">¥<asp:Literal ID="txtRealPay" runat="server"></asp:Literal></em>
                            元
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <a href="ShoppingCart.aspx">
                                <img src="icons/cart_edit.gif" />返回购物车</a>&nbsp;
                        </th>
                        <td class="pay">
                            <input type="button" value="提交订单" class="btn2" id="submitBtn" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <Shopping:Footer ID="Footer1" runat="server" />
    <script type="text/javascript">
        $("#allSortOuterbox").hide();
        $("#global_menu").addClass("tqyClass");
    </script>
    </form>
    <script type="text/javascript">
        $("#submitBtn").click(function () {
            var deliveryID = parseInt($("input[name=delivery]").val());
            if (deliveryID == 0) {
                var shippeople = $("#txtshippeople");
                var shipmobile = $("#txtshipaddress")
                var shipaddress = $("#txtshipmobile");

                if (shippeople.val() == "") {
                    alert("请输入收货人姓名!");
                    shippeople.focus();
                    return false;
                }
                if (shipmobile.val() == "") {
                    alert("请输入收货联系人的手机号码!");
                    shipmobile.focus();
                    return false;
                }
                if (shipaddress.val() == "") {
                    alert("请输入收货地址!");
                    shipaddress.focus();
                    return false;
                }
            }

            $("#form1").submit();
        });

//        $(function () {
//            $("#usePoint").on("blur", function (event) {
//                var userpoint = parseInt($(this).val());
//                var havePoint = parseInt($("#txthavePoint").val());

////                if (userpoint > havePoint) {
////                    alert("积分不足,最多只能是" + havePoint + "个积分!");
////                    $(this).val(havePoint);
////                }

////                userpoint = parseInt($(this).val());

////                var param = "action=checkuserpoint" + "&point=" + userpoint;
////                $.ajax({
////                    url: "ajax/Ajax_ConfirmOrder.aspx",
////                    data: param,
////                    dataType: "json",
////                    cache: false,
////                    async: false,
////                    ifModified: true,
//////                    success: function (msg) {
//////                        var retid = parseInt(msg[0].retid);
////////                        if (retid == -1) {
////////                            alert("积分不足!");
////////                            $("#usePoint").val("0");
////////                        }
//////                        $("#couponSaving").html(msg[0].save);
//////                        $("#realpay").html(msg[0].totalprice);

//////                    }
////                });
//            });


//        });
    </script>
</body>
</html>
